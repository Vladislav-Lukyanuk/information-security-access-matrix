namespace AccessMatrix
{
    partial class DateForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.systemCheckBox = new System.Windows.Forms.CheckBox();
            this.disallowСheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // maskedTextBox
            // 
            this.maskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox.Location = new System.Drawing.Point(157, 12);
            this.maskedTextBox.Mask = "00/00/0000";
            this.maskedTextBox.Name = "maskedTextBox";
            this.maskedTextBox.Size = new System.Drawing.Size(127, 35);
            this.maskedTextBox.TabIndex = 0;
            this.maskedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.maskedTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Create date :";
            // 
            // systemCheckBox
            // 
            this.systemCheckBox.AutoSize = true;
            this.systemCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.systemCheckBox.Location = new System.Drawing.Point(135, 53);
            this.systemCheckBox.Name = "systemCheckBox";
            this.systemCheckBox.Size = new System.Drawing.Size(149, 22);
            this.systemCheckBox.TabIndex = 2;
            this.systemCheckBox.Text = "Системный файл";
            this.systemCheckBox.UseVisualStyleBackColor = true;
            this.systemCheckBox.CheckedChanged += new System.EventHandler(this.systemCheckBox_CheckedChanged);
            // 
            // disallowСheckBox
            // 
            this.disallowСheckBox.AutoSize = true;
            this.disallowСheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.disallowСheckBox.Location = new System.Drawing.Point(6, 53);
            this.disallowСheckBox.Name = "disallowСheckBox";
            this.disallowСheckBox.Size = new System.Drawing.Size(123, 22);
            this.disallowСheckBox.TabIndex = 3;
            this.disallowСheckBox.Text = "Запрещенный";
            this.disallowСheckBox.UseVisualStyleBackColor = true;
            this.disallowСheckBox.CheckedChanged += new System.EventHandler(this.disallowСheckBox_CheckedChanged);
            // 
            // DateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 80);
            this.Controls.Add(this.disallowСheckBox);
            this.Controls.Add(this.systemCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DateForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DateForm_FormClosed);
            this.Load += new System.EventHandler(this.DateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox maskedTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox systemCheckBox;
        private System.Windows.Forms.CheckBox disallowСheckBox;
    }
}