using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessMatrix
{
    public partial class DateForm : Form
    {
        private string path, securityPath;
        private bool w, admin, secure;
        private FolderSecurity folderSecurity;


        public DateForm(string path, bool w, bool admin, string securityPath)
        {
            InitializeComponent();
            this.path = path.Replace(@"\", @"\\");
            this.w = w;
            this.admin = admin;
            w = admin = false;
            secure = true;
            this.securityPath = securityPath;
            folderSecurity = new FolderSecurity();
        }

        private void SecurityUp()
        {
            try
            {
                if (!secure)
                {
                    folderSecurity.RecursiveSecurityUp(securityPath);
                    secure = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Увы, но мы имем проблемы с доступом к D:\\Matrix.");
                Application.Exit();
            }
        }

        private void SecurityDown()
        {
            if (secure)
            {
                folderSecurity.RecursiveSecurityDown(securityPath);
                secure = false;
            }
        }

        private bool IsDisAllowFile()
        {
            SecurityDown();

            StreamReader SRD = new StreamReader("D:\\Matrix\\matrix.db", Encoding.GetEncoding(1251));
            string Array = SRD.ReadToEnd();
            SRD.Close();

            SecurityUp();

            string[] lines = System.Text.RegularExpressions.Regex.Split(Array, "\n");

            for (int i = 0; i < lines.Length - 1; i++)
            {
                if (lines[i].Contains("user:system|"))
                {
                    string value = Regex.Match(lines[i], path + @"(<\w*?>)").Value;
                    value = Regex.Match(value, @"(<\w*?>)").Value;

                    if (value.Equals("<>"))
                    {
                        return true;
                    }

                    return false;
                }
            }
            return false;
        }
        
        private void DateForm_Load(object sender, EventArgs e)
        {
            SecurityDown();

            maskedTextBox.Text = File.GetCreationTimeUtc(path).ToShortDateString();

            FileAttributes fileAttributes = File.GetAttributes(path);
            if ((fileAttributes & FileAttributes.System) == FileAttributes.System)
                systemCheckBox.Checked = true;

            if (IsDisAllowFile())
                disallowСheckBox.Checked = true;

            SecurityUp();

            if (!w)
                maskedTextBox.Enabled = false;

            if (!admin)
            {
                disallowСheckBox.Enabled = false;
                systemCheckBox.Enabled = false;
            }
        }

        private void maskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                DateTime time;

                SecurityDown();

                if (!DateTime.TryParse((sender as MaskedTextBox).Text, out time))
                {
                    MessageBox.Show("Введите корректный формат времени.");

                    maskedTextBox.Text = File.GetCreationTimeUtc(path).ToShortDateString();

                    SecurityUp();
                    return;
                }

                try
                {
                    File.SetCreationTimeUtc(path, DateTime.ParseExact(maskedTextBox.Text, "dd.M.yyyy", null));
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Введенное вами время не поддерживается в системе.");
                    maskedTextBox.Text = File.GetCreationTimeUtc(path).ToShortDateString();
                }
                finally
                {
                    SecurityUp();
                }

            }
        }

        private void WhenFormIsClosing()
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
            ifrm.Activate();
        }

        private void DateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            WhenFormIsClosing();
        }

        private void disallowСheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (disallowСheckBox.Checked)
                setAtributesForAFile("");
            else
                setAtributesForAFile("rw");
        }

        private void setAtributesForAFile(string atributes)
        {
            SecurityDown();

            StreamReader SRD = new StreamReader("D:\\Matrix\\matrix.db", Encoding.GetEncoding(1251));
            string Array = SRD.ReadToEnd();
            SRD.Close();

            string[] lines = System.Text.RegularExpressions.Regex.Split(Array, "\n");
            StreamWriter SWP = new StreamWriter("D:\\Matrix\\matrix.db", false, Encoding.GetEncoding(1251));

            for (int i = 0; i < lines.Length-1; i++)
            {
                if (lines[i].Contains("user:system|"))
                {
                    string value = Regex.Match(lines[i], path + @"(<\w*?>)").Value;
                    path = path.Replace(@"\\", @"\");
                    lines[i] = lines[i].Replace(value, String.Format("{0}<{1}>", path, atributes));
                    path = path.Replace(@"\", @"\\");
                }
                SWP.Write(lines[i]+"\n");
            }
            SWP.Close();

            SecurityUp();
        }

        private void systemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SecurityDown();

            FileAttributes fileAttributes = File.GetAttributes(path);

            if (systemCheckBox.Checked)
                    File.SetAttributes(path, fileAttributes | FileAttributes.System);
            else
                File.SetAttributes(path, fileAttributes & ~FileAttributes.System);

            SecurityUp();
        }
    }
}
