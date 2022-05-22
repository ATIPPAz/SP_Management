namespace SP_Management.Pages.HumanResourcePage
{
    partial class DialogUser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.BackBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.cbPrefix = new System.Windows.Forms.ComboBox();
            this.DateHired = new System.Windows.Forms.DateTimePicker();
            this.BirthDate = new System.Windows.Forms.DateTimePicker();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.cbPosition = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(130, 190);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(6);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(147, 33);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "UserName";
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(289, 254);
            this.txtLName.Margin = new System.Windows.Forms.Padding(6);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(193, 33);
            this.txtLName.TabIndex = 0;
            this.txtLName.Text = "LastName";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(20, 190);
            this.txtID.Margin = new System.Windows.Forms.Padding(6);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(98, 33);
            this.txtID.TabIndex = 0;
            this.txtID.Text = "ID";
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(130, 254);
            this.txtFName.Margin = new System.Windows.Forms.Padding(6);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(147, 33);
            this.txtFName.TabIndex = 0;
            this.txtFName.Text = "FirstName";
            this.txtFName.Enter += new System.EventHandler(this.txtFName_Enter);
            this.txtFName.Leave += new System.EventHandler(this.txtFName_Leave);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(130, 321);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(6);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(278, 33);
            this.txtEmail.TabIndex = 0;
            this.txtEmail.Text = "Email";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(20, 387);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(6);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(172, 33);
            this.txtPhone.TabIndex = 0;
            this.txtPhone.Text = "TelPhone";
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(432, 11);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(6);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(52, 44);
            this.BackBtn.TabIndex = 1;
            this.BackBtn.Text = "X";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(346, 737);
            this.SaveBtn.Margin = new System.Windows.Forms.Padding(6);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(138, 44);
            this.SaveBtn.TabIndex = 1;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Nirmala UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 88);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(191, 47);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "UserDetail";
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(20, 534);
            this.txtSalary.Margin = new System.Windows.Forms.Padding(6);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(156, 33);
            this.txtSalary.TabIndex = 0;
            this.txtSalary.Text = "Salary";
            // 
            // cbGender
            // 
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "ชาย",
            "หญิง"});
            this.cbGender.Location = new System.Drawing.Point(20, 321);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(98, 33);
            this.cbGender.TabIndex = 3;
            // 
            // cbPrefix
            // 
            this.cbPrefix.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrefix.FormattingEnabled = true;
            this.cbPrefix.Items.AddRange(new object[] {
            "นาย",
            "นางสาว",
            "นาง"});
            this.cbPrefix.Location = new System.Drawing.Point(20, 254);
            this.cbPrefix.Name = "cbPrefix";
            this.cbPrefix.Size = new System.Drawing.Size(98, 33);
            this.cbPrefix.TabIndex = 3;
            this.cbPrefix.Enter += new System.EventHandler(this.cbPrefix_Enter);
            // 
            // DateHired
            // 
            this.DateHired.Location = new System.Drawing.Point(335, 531);
            this.DateHired.Name = "DateHired";
            this.DateHired.Size = new System.Drawing.Size(147, 33);
            this.DateHired.TabIndex = 4;
            // 
            // BirthDate
            // 
            this.BirthDate.Location = new System.Drawing.Point(335, 387);
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.Size = new System.Drawing.Size(147, 33);
            this.BirthDate.TabIndex = 4;
            // 
            // cbDepartment
            // 
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(20, 456);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(156, 33);
            this.cbDepartment.TabIndex = 5;
            // 
            // cbPosition
            // 
            this.cbPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPosition.FormattingEnabled = true;
            this.cbPosition.Location = new System.Drawing.Point(198, 456);
            this.cbPosition.Name = "cbPosition";
            this.cbPosition.Size = new System.Drawing.Size(156, 33);
            this.cbPosition.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "BirthDate :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 534);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "HireDate :";
            // 
            // DialogUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPosition);
            this.Controls.Add(this.cbDepartment);
            this.Controls.Add(this.BirthDate);
            this.Controls.Add(this.DateHired);
            this.Controls.Add(this.cbPrefix);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.txtSalary);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtUsername);
            this.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DialogUser";
            this.Size = new System.Drawing.Size(496, 796);
            this.Load += new System.EventHandler(this.DialogUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.ComboBox cbPrefix;
        private System.Windows.Forms.DateTimePicker DateHired;
        private System.Windows.Forms.DateTimePicker BirthDate;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.ComboBox cbPosition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
