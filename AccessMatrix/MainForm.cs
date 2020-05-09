using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessMatrix
{
    public partial class FormAccessMatrix : Form
    {
        private bool logined, secure;
        private string[] dataBase;
        private bool s,r,w;
        private string securityPath;
        private FolderSecurity folderSecurity;

        public FormAccessMatrix()
        {
            InitializeComponent();
            logined = secure = false;
            dataBase = new string[]
            {
            "admin",
            "user",
            "system"
            };
            s = r = w = false;
            securityPath = "D:\\Matrix";
            folderSecurity = new FolderSecurity();
        }

        private void FormAccessMatrix_Load(object sender, EventArgs e)
        {
            //предотвращает при некорректном завершении работы восстановить доступ к файлам
            secure = true;
            SecurityDown();
            if (File.Exists("D:\\Matrix\\matrix.db"))
                File.Delete("D:\\Matrix\\matrix.db");
            //

            LoadFiles();
            CreateAccessMatrix();
            SecurityUp();
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

        private void WriteToMatrix(string path, char[] access)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            FileInfo[] files = directoryInfo.GetFiles();

            foreach (FileInfo file in files)
            {
                File.AppendAllText("D:\\Matrix\\matrix.db",
                    String.Format("{0}<{1}>;",
                    file.FullName, new string(access)));

            }

            DirectoryInfo[] directories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo directory in directories)
                WriteToMatrix(directory.FullName, access);
        }

        private void CreateUserAccess(string user, char[] access)
        {
            SecurityDown();

            File.AppendAllText("D:\\Matrix\\matrix.db", String.Format("user:{0}|", user));
            WriteToMatrix("D:\\Matrix", access);
            File.AppendAllText("D:\\Matrix\\matrix.db", "\n");

            SecurityUp();
        }

        private void CreateAccessMatrix()
        {
            CreateUserAccess("admin", new char[] { 's', 'r', 'w' });
            CreateUserAccess("user", new char[] { 's', 'r' });
            CreateUserAccess("system", new char[] { 'r', 'w' });
        }

        private void Login()
        {
            textBoxLogin.Text = textBoxLogin.Text.ToLower();

            if (!logined & (logined = loginUser()))
            {
                LoadFiles();
                textBoxLogin.Enabled = false;
                buttonLogin.Text = "Выход";
                return;
            }

            logined = logOutUser();
            SetListView();
            textBoxLogin.Enabled = true;
            textBoxDirectoryPath.Text = "D:\\Matrix";
            buttonLogin.Text = "Вход";
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private bool logOutUser()
        {
            return false;
        }

        private bool loginUser()
        {
            if (dataBase.Contains(textBoxLogin.Text))
            {
                return true;
            }
            return false;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (!logined)
                return;

            string path = textBoxDirectoryPath.Text;
            if (path.Contains("D:\\Matrix") & !path.Equals("D:\\Matrix"))
            {
                path = path.Substring(0, path.LastIndexOf("\\"));
                textBoxDirectoryPath.Text = path;
                LoadFiles();
            }
        }

        private void WriteFileToListView(DirectoryInfo di)
        {
            ListViewItem listViewItem = new ListViewItem(di.Name);
            listViewFileManager.Items.Add(listViewItem);
        }

        private void WriteFileToListView(FileInfo fi)
        {
            ListViewItem listViewItem = new ListViewItem(fi.Name);
            listViewFileManager.Items.Add(listViewItem);
        }

        private void SetListView()
        {
            listViewFileManager.Clear();
            listViewFileManager.View = View.Details;
            listViewFileManager.Columns.Add("File", 400, HorizontalAlignment.Left);
        }

        private void LoadFiles()
        {
            SetListView();

            if (!logined)
                return;

            SecurityDown();

            DirectoryInfo directoryInfo = new DirectoryInfo(textBoxDirectoryPath.Text);

            DirectoryInfo[] folders = directoryInfo.GetDirectories();
            foreach (DirectoryInfo di in folders)
                WriteFileToListView(di);

            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo fi in files)
                WriteFileToListView(fi);

            SecurityUp();
        }

        private bool CheckOpenSecondForm()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "DateForm")
                    return true;
            }
            return false;
        }

        private void OpenFile(string path)
        {
            if (!CheckOpenSecondForm())
            {
                SecurityDown();
                Access(path);

                FileAttributes fileAttributes = File.GetAttributes(path);
                if (((fileAttributes & FileAttributes.System) == FileAttributes.System & !s) || !r)
                {
                    SecurityUp();
                    return;
                }

                SecurityUp();

                DateForm newForm = new DateForm(path, w, textBoxLogin.Text.Equals("admin"), securityPath);
                this.Hide();
                newForm.Show();
            }
        }

        private void Access(string path)
        {
            s = r = w = false;

            SecurityDown();

            StreamReader SRD = new StreamReader("D:\\Matrix\\matrix.db", Encoding.GetEncoding(1251));
            while (!SRD.EndOfStream)
            {
                string line = SRD.ReadLine();
                if (Regex.Match(line, String.Format(@"user:{0}", textBoxLogin.Text)).Value != "")
                {
                    string regex = String.Format("({0})[^;]*", path);
                    regex = regex.Replace("\\", "\\\\");
                    line = Regex.Match(line, regex).Value;
                    line = Regex.Match(line, @"<\w*?>").Value;
                    if (line.Contains("s"))
                        s = true;
                    if (line.Contains("r"))
                        r = true;
                    if (line.Contains("w"))
                        w = true;
                    SRD.Close();
                    return;
                }
            }
            SRD.Close();

            SecurityUp();
        }

        private void listViewFileManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewFileManager.SelectedItems.Count == 1)
            {
                SecurityDown();

                string path = listViewFileManager.SelectedItems[0].Text;           
                path = String.Format("{0}\\{1}", textBoxDirectoryPath.Text, path);
                DirectoryInfo directoryInfo = new DirectoryInfo(path);
                if (directoryInfo.Exists)
                {
                    textBoxDirectoryPath.Text = path;
                    LoadFiles();
                    return;
                }
                listViewFileManager.SelectedItems[0].Selected = false;

                SecurityUp();

                OpenFile(path);
            }
        }

        private void textBoxLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Login();
            }
        }

        private void FormAccessMatrix_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (secure)
            {
                SecurityDown();
                File.Delete("D:\\Matrix\\matrix.db");
            }
        }
    }
}
