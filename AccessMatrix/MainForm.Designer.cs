namespace AccessMatrix
{
    partial class FormAccessMatrix
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxDirectoryPath = new System.Windows.Forms.TextBox();
            this.listViewFileManager = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(515, 12);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 1;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(142, 12);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Вход";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.AccessibleName = "";
            this.textBoxLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLogin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxLogin.Location = new System.Drawing.Point(12, 12);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(124, 22);
            this.textBoxLogin.TabIndex = 3;
            this.textBoxLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLogin_KeyPress);
            // 
            // textBoxDirectoryPath
            // 
            this.textBoxDirectoryPath.Enabled = false;
            this.textBoxDirectoryPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDirectoryPath.Location = new System.Drawing.Point(223, 12);
            this.textBoxDirectoryPath.Name = "textBoxDirectoryPath";
            this.textBoxDirectoryPath.ReadOnly = true;
            this.textBoxDirectoryPath.Size = new System.Drawing.Size(286, 22);
            this.textBoxDirectoryPath.TabIndex = 4;
            this.textBoxDirectoryPath.Text = "D:\\Matrix";
            // 
            // listViewFileManager
            // 
            this.listViewFileManager.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.listViewFileManager.HideSelection = false;
            this.listViewFileManager.Location = new System.Drawing.Point(12, 40);
            this.listViewFileManager.Name = "listViewFileManager";
            this.listViewFileManager.Size = new System.Drawing.Size(578, 247);
            this.listViewFileManager.TabIndex = 5;
            this.listViewFileManager.UseCompatibleStateImageBehavior = false;
            this.listViewFileManager.SelectedIndexChanged += new System.EventHandler(this.listViewFileManager_SelectedIndexChanged);
            // 
            // FormAccessMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(602, 299);
            this.Controls.Add(this.listViewFileManager);
            this.Controls.Add(this.textBoxDirectoryPath);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.buttonBack);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormAccessMatrix";
            this.ShowIcon = false;
            this.Text = "AccessMatrix";
            //this.Activated += new System.EventHandler(this.FormAccessMatrix_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAccessMatrix_FormClosed);
            this.Load += new System.EventHandler(this.FormAccessMatrix_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxDirectoryPath;
        private System.Windows.Forms.ListView listViewFileManager;
    }
}

