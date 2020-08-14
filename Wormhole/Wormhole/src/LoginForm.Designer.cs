namespace Wormhole
{
    partial class frmLoginForm
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
            this.lblClose = new System.Windows.Forms.Label();
            this.plLogin = new System.Windows.Forms.Panel();
            this.lblSign = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.plSignup = new System.Windows.Forms.Panel();
            this.lblBack = new System.Windows.Forms.Label();
            this.lblRegister = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRetype = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtSchool = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.plAdmin = new System.Windows.Forms.Panel();
            this.lblSearchBox = new System.Windows.Forms.Label();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.lblImageOpen = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pbQuestion = new System.Windows.Forms.PictureBox();
            this.lblQuestionMode = new System.Windows.Forms.Label();
            this.txtQuestionMode = new System.Windows.Forms.TextBox();
            this.lblDifficulty = new System.Windows.Forms.Label();
            this.lblCorAns = new System.Windows.Forms.Label();
            this.txtCorAns = new System.Windows.Forms.TextBox();
            this.lvQuestionList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblAdminLogout = new System.Windows.Forms.Label();
            this.cbDifficulty = new System.Windows.Forms.ComboBox();
            this.plLogin.SuspendLayout();
            this.plSignup.SuspendLayout();
            this.plAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuestion)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.BackColor = System.Drawing.Color.Transparent;
            this.lblClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblClose.Location = new System.Drawing.Point(980, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(16, 16);
            this.lblClose.TabIndex = 0;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            // 
            // plLogin
            // 
            this.plLogin.BackColor = System.Drawing.Color.Black;
            this.plLogin.Controls.Add(this.lblSign);
            this.plLogin.Controls.Add(this.lblUsername);
            this.plLogin.Controls.Add(this.lblPassword);
            this.plLogin.Controls.Add(this.txtPassword);
            this.plLogin.Controls.Add(this.txtUsername);
            this.plLogin.Controls.Add(this.lblLogin);
            this.plLogin.Location = new System.Drawing.Point(0, 20);
            this.plLogin.Name = "plLogin";
            this.plLogin.Size = new System.Drawing.Size(1000, 530);
            this.plLogin.TabIndex = 1;
            // 
            // lblSign
            // 
            this.lblSign.AutoSize = true;
            this.lblSign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSign.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSign.Location = new System.Drawing.Point(364, 353);
            this.lblSign.Name = "lblSign";
            this.lblSign.Size = new System.Drawing.Size(294, 14);
            this.lblSign.TabIndex = 11;
            this.lblSign.Text = "Don\'t have an account yet?, Sign-in here!";
            this.lblSign.Click += new System.EventHandler(this.lblSign_Click);
            this.lblSign.MouseEnter += new System.EventHandler(this.lblSign_MouseEnter);
            this.lblSign.MouseLeave += new System.EventHandler(this.lblSign_MouseLeave);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(359, 129);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(77, 14);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "Username: ";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(359, 185);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(77, 14);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "Password: ";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Black;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.ForeColor = System.Drawing.Color.White;
            this.txtPassword.Location = new System.Drawing.Point(480, 184);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(178, 15);
            this.txtPassword.TabIndex = 9;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.Black;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.ForeColor = System.Drawing.Color.White;
            this.txtUsername.Location = new System.Drawing.Point(480, 129);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(178, 15);
            this.txtUsername.TabIndex = 7;
            // 
            // lblLogin
            // 
            this.lblLogin.Location = new System.Drawing.Point(0, 281);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(1000, 22);
            this.lblLogin.TabIndex = 12;
            this.lblLogin.Text = "Login                                                 ";
            this.lblLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLogin.Click += new System.EventHandler(this.lblLogin_Click);
            this.lblLogin.MouseEnter += new System.EventHandler(this.lblLogin_MouseEnter);
            this.lblLogin.MouseLeave += new System.EventHandler(this.lblLogin_MouseLeave);
            // 
            // lblHeader
            // 
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1000, 20);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "Login";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // plSignup
            // 
            this.plSignup.BackColor = System.Drawing.Color.Black;
            this.plSignup.Controls.Add(this.lblBack);
            this.plSignup.Controls.Add(this.lblRegister);
            this.plSignup.Controls.Add(this.label6);
            this.plSignup.Controls.Add(this.label7);
            this.plSignup.Controls.Add(this.txtRetype);
            this.plSignup.Controls.Add(this.txtPass);
            this.plSignup.Controls.Add(this.label4);
            this.plSignup.Controls.Add(this.label5);
            this.plSignup.Controls.Add(this.txtUser);
            this.plSignup.Controls.Add(this.txtSchool);
            this.plSignup.Controls.Add(this.label3);
            this.plSignup.Controls.Add(this.label2);
            this.plSignup.Controls.Add(this.txtLastName);
            this.plSignup.Controls.Add(this.txtFirstName);
            this.plSignup.Location = new System.Drawing.Point(0, 20);
            this.plSignup.Name = "plSignup";
            this.plSignup.Size = new System.Drawing.Size(1000, 530);
            this.plSignup.TabIndex = 13;
            // 
            // lblBack
            // 
            this.lblBack.Location = new System.Drawing.Point(0, 484);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(1000, 22);
            this.lblBack.TabIndex = 29;
            this.lblBack.Text = "Go Back     ";
            this.lblBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBack.Click += new System.EventHandler(this.lblBack_Click);
            this.lblBack.MouseEnter += new System.EventHandler(this.lblBack_MouseEnter);
            this.lblBack.MouseLeave += new System.EventHandler(this.lblBack_MouseLeave);
            // 
            // lblRegister
            // 
            this.lblRegister.Location = new System.Drawing.Point(0, 359);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(1000, 22);
            this.lblRegister.TabIndex = 28;
            this.lblRegister.Text = "Register!";
            this.lblRegister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRegister.Click += new System.EventHandler(this.lblRegister_Click);
            this.lblRegister.MouseEnter += new System.EventHandler(this.lblRegister_MouseEnter);
            this.lblRegister.MouseLeave += new System.EventHandler(this.lblRegister_MouseLeave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(336, 275);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 14);
            this.label6.TabIndex = 27;
            this.label6.Text = "Re-type Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(336, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 26;
            this.label7.Text = "Password:";
            // 
            // txtRetype
            // 
            this.txtRetype.BackColor = System.Drawing.Color.Black;
            this.txtRetype.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRetype.ForeColor = System.Drawing.Color.White;
            this.txtRetype.Location = new System.Drawing.Point(475, 275);
            this.txtRetype.Name = "txtRetype";
            this.txtRetype.PasswordChar = '•';
            this.txtRetype.Size = new System.Drawing.Size(198, 15);
            this.txtRetype.TabIndex = 25;
            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.Black;
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.ForeColor = System.Drawing.Color.White;
            this.txtPass.Location = new System.Drawing.Point(475, 243);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '•';
            this.txtPass.Size = new System.Drawing.Size(198, 15);
            this.txtPass.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 23;
            this.label4.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(336, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 22;
            this.label5.Text = "School Name:";
            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.Black;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUser.ForeColor = System.Drawing.Color.White;
            this.txtUser.Location = new System.Drawing.Point(475, 211);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(198, 15);
            this.txtUser.TabIndex = 21;
            // 
            // txtSchool
            // 
            this.txtSchool.BackColor = System.Drawing.Color.Black;
            this.txtSchool.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSchool.ForeColor = System.Drawing.Color.White;
            this.txtSchool.Location = new System.Drawing.Point(475, 179);
            this.txtSchool.Name = "txtSchool";
            this.txtSchool.Size = new System.Drawing.Size(198, 15);
            this.txtSchool.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 19;
            this.label3.Text = "Last Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "First Name:";
            // 
            // txtLastName
            // 
            this.txtLastName.BackColor = System.Drawing.Color.Black;
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastName.ForeColor = System.Drawing.Color.White;
            this.txtLastName.Location = new System.Drawing.Point(475, 147);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(198, 15);
            this.txtLastName.TabIndex = 17;
            // 
            // txtFirstName
            // 
            this.txtFirstName.BackColor = System.Drawing.Color.Black;
            this.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFirstName.ForeColor = System.Drawing.Color.White;
            this.txtFirstName.Location = new System.Drawing.Point(475, 115);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(198, 15);
            this.txtFirstName.TabIndex = 16;
            // 
            // plAdmin
            // 
            this.plAdmin.BackColor = System.Drawing.Color.Black;
            this.plAdmin.Controls.Add(this.lblSearchBox);
            this.plAdmin.Controls.Add(this.txtSearchBox);
            this.plAdmin.Controls.Add(this.lblImageOpen);
            this.plAdmin.Controls.Add(this.lblID);
            this.plAdmin.Controls.Add(this.btnCancel);
            this.plAdmin.Controls.Add(this.btnDelete);
            this.plAdmin.Controls.Add(this.btnEdit);
            this.plAdmin.Controls.Add(this.btnSave);
            this.plAdmin.Controls.Add(this.btnAdd);
            this.plAdmin.Controls.Add(this.pbQuestion);
            this.plAdmin.Controls.Add(this.lblQuestionMode);
            this.plAdmin.Controls.Add(this.txtQuestionMode);
            this.plAdmin.Controls.Add(this.lblDifficulty);
            this.plAdmin.Controls.Add(this.lblCorAns);
            this.plAdmin.Controls.Add(this.txtCorAns);
            this.plAdmin.Controls.Add(this.lvQuestionList);
            this.plAdmin.Controls.Add(this.lblAdminLogout);
            this.plAdmin.Controls.Add(this.cbDifficulty);
            this.plAdmin.Location = new System.Drawing.Point(0, 20);
            this.plAdmin.Name = "plAdmin";
            this.plAdmin.Size = new System.Drawing.Size(1000, 530);
            this.plAdmin.TabIndex = 14;
            // 
            // lblSearchBox
            // 
            this.lblSearchBox.AutoSize = true;
            this.lblSearchBox.Location = new System.Drawing.Point(433, 450);
            this.lblSearchBox.Name = "lblSearchBox";
            this.lblSearchBox.Size = new System.Drawing.Size(126, 14);
            this.lblSearchBox.TabIndex = 49;
            this.lblSearchBox.Text = "Search Question!:";
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.BackColor = System.Drawing.Color.Black;
            this.txtSearchBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearchBox.ForeColor = System.Drawing.Color.White;
            this.txtSearchBox.Location = new System.Drawing.Point(559, 450);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(170, 15);
            this.txtSearchBox.TabIndex = 48;
            this.txtSearchBox.TextChanged += new System.EventHandler(this.txtSearchBox_TextChanged);
            // 
            // lblImageOpen
            // 
            this.lblImageOpen.AutoSize = true;
            this.lblImageOpen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblImageOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblImageOpen.Enabled = false;
            this.lblImageOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblImageOpen.Location = new System.Drawing.Point(327, 147);
            this.lblImageOpen.Name = "lblImageOpen";
            this.lblImageOpen.Size = new System.Drawing.Size(93, 16);
            this.lblImageOpen.TabIndex = 47;
            this.lblImageOpen.Text = "Search Image";
            this.lblImageOpen.Click += new System.EventHandler(this.lblImageOpen_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(12, 154);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(35, 14);
            this.lblID.TabIndex = 46;
            this.lblID.Text = "ID: ";
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(331, 384);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(178, 423);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 44;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(178, 384);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 43;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(24, 423);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(24, 384);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 41;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pbQuestion
            // 
            this.pbQuestion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbQuestion.Location = new System.Drawing.Point(12, 171);
            this.pbQuestion.Name = "pbQuestion";
            this.pbQuestion.Size = new System.Drawing.Size(408, 196);
            this.pbQuestion.TabIndex = 40;
            this.pbQuestion.TabStop = false;
            // 
            // lblQuestionMode
            // 
            this.lblQuestionMode.AutoSize = true;
            this.lblQuestionMode.Location = new System.Drawing.Point(39, 115);
            this.lblQuestionMode.Name = "lblQuestionMode";
            this.lblQuestionMode.Size = new System.Drawing.Size(105, 14);
            this.lblQuestionMode.TabIndex = 39;
            this.lblQuestionMode.Text = "Question Mode:";
            // 
            // txtQuestionMode
            // 
            this.txtQuestionMode.BackColor = System.Drawing.Color.Black;
            this.txtQuestionMode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtQuestionMode.Enabled = false;
            this.txtQuestionMode.ForeColor = System.Drawing.Color.White;
            this.txtQuestionMode.Location = new System.Drawing.Point(178, 115);
            this.txtQuestionMode.Name = "txtQuestionMode";
            this.txtQuestionMode.Size = new System.Drawing.Size(198, 15);
            this.txtQuestionMode.TabIndex = 37;
            this.txtQuestionMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true;
            this.lblDifficulty.Location = new System.Drawing.Point(39, 74);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(84, 14);
            this.lblDifficulty.TabIndex = 36;
            this.lblDifficulty.Text = "Difficulty:";
            // 
            // lblCorAns
            // 
            this.lblCorAns.AutoSize = true;
            this.lblCorAns.Location = new System.Drawing.Point(39, 39);
            this.lblCorAns.Name = "lblCorAns";
            this.lblCorAns.Size = new System.Drawing.Size(112, 14);
            this.lblCorAns.TabIndex = 35;
            this.lblCorAns.Text = "Correct Answer:";
            // 
            // txtCorAns
            // 
            this.txtCorAns.BackColor = System.Drawing.Color.Black;
            this.txtCorAns.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorAns.Enabled = false;
            this.txtCorAns.ForeColor = System.Drawing.Color.White;
            this.txtCorAns.Location = new System.Drawing.Point(178, 39);
            this.txtCorAns.Name = "txtCorAns";
            this.txtCorAns.Size = new System.Drawing.Size(198, 15);
            this.txtCorAns.TabIndex = 33;
            this.txtCorAns.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lvQuestionList
            // 
            this.lvQuestionList.BackColor = System.Drawing.Color.Black;
            this.lvQuestionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvQuestionList.ForeColor = System.Drawing.Color.White;
            this.lvQuestionList.FullRowSelect = true;
            this.lvQuestionList.GridLines = true;
            this.lvQuestionList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvQuestionList.Location = new System.Drawing.Point(433, 28);
            this.lvQuestionList.MultiSelect = false;
            this.lvQuestionList.Name = "lvQuestionList";
            this.lvQuestionList.Size = new System.Drawing.Size(543, 409);
            this.lvQuestionList.TabIndex = 31;
            this.lvQuestionList.UseCompatibleStateImageBehavior = false;
            this.lvQuestionList.View = System.Windows.Forms.View.Details;
            this.lvQuestionList.SelectedIndexChanged += new System.EventHandler(this.lvQuestionList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "QuestionID";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "QuestionImage";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "CorrectAnswer";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Difficulty";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "QuestionMode";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 120;
            // 
            // lblAdminLogout
            // 
            this.lblAdminLogout.Location = new System.Drawing.Point(0, 476);
            this.lblAdminLogout.Name = "lblAdminLogout";
            this.lblAdminLogout.Size = new System.Drawing.Size(1000, 22);
            this.lblAdminLogout.TabIndex = 30;
            this.lblAdminLogout.Text = "Logout     ";
            this.lblAdminLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAdminLogout.Click += new System.EventHandler(this.lblAdminLogout_Click);
            this.lblAdminLogout.MouseEnter += new System.EventHandler(this.lblAdminLogout_MouseEnter);
            this.lblAdminLogout.MouseLeave += new System.EventHandler(this.lblAdminLogout_MouseLeave);
            // 
            // cbDifficulty
            // 
            this.cbDifficulty.BackColor = System.Drawing.Color.Black;
            this.cbDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDifficulty.Enabled = false;
            this.cbDifficulty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDifficulty.ForeColor = System.Drawing.Color.White;
            this.cbDifficulty.FormattingEnabled = true;
            this.cbDifficulty.Items.AddRange(new object[] {
            "----------",
            "Easy",
            "Normal",
            "Hard",
            "Insane"});
            this.cbDifficulty.Location = new System.Drawing.Point(178, 74);
            this.cbDifficulty.Name = "cbDifficulty";
            this.cbDifficulty.Size = new System.Drawing.Size(198, 22);
            this.cbDifficulty.TabIndex = 35;
            // 
            // frmLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.plAdmin);
            this.Controls.Add(this.plSignup);
            this.Controls.Add(this.plLogin);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmLoginForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmLoginForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLoginForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmLoginForm_KeyUp);
            this.plLogin.ResumeLayout(false);
            this.plLogin.PerformLayout();
            this.plSignup.ResumeLayout(false);
            this.plSignup.PerformLayout();
            this.plAdmin.ResumeLayout(false);
            this.plAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuestion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Panel plLogin;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblSign;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Panel plSignup;
        private System.Windows.Forms.Label lblRegister;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRetype;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtSchool;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblBack;
        private System.Windows.Forms.Panel plAdmin;
        private System.Windows.Forms.Label lblAdminLogout;
        private System.Windows.Forms.ListView lvQuestionList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lblQuestionMode;
        private System.Windows.Forms.TextBox txtQuestionMode;
        private System.Windows.Forms.Label lblDifficulty;
        private System.Windows.Forms.Label lblCorAns;
        private System.Windows.Forms.TextBox txtCorAns;
        private System.Windows.Forms.PictureBox pbQuestion;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblImageOpen;
        private System.Windows.Forms.ComboBox cbDifficulty;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.Label lblSearchBox;
    }
}

