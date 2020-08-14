namespace Wormhole.src
{
    partial class frmMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.pbBackGround = new System.Windows.Forms.PictureBox();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();
            this.lblStartGame = new System.Windows.Forms.Label();
            this.lblScores = new System.Windows.Forms.Label();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.lblOption = new System.Windows.Forms.Label();
            this.lblAbout = new System.Windows.Forms.Label();
            this.lblUserHeader = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblBack = new System.Windows.Forms.Label();
            this.lblSignout = new System.Windows.Forms.Label();
            this.lblQuickDemo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGround)).BeginInit();
            this.SuspendLayout();
            // 
            // pbBackGround
            // 
            this.pbBackGround.BackColor = System.Drawing.Color.Transparent;
            this.pbBackGround.Location = new System.Drawing.Point(0, 0);
            this.pbBackGround.Name = "pbBackGround";
            this.pbBackGround.Size = new System.Drawing.Size(1300, 700);
            this.pbBackGround.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBackGround.TabIndex = 1;
            this.pbBackGround.TabStop = false;
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblClose.Location = new System.Drawing.Point(1275, 0);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(16, 17);
            this.lblClose.TabIndex = 2;
            this.lblClose.Text = "X";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseEnter += new System.EventHandler(this.lblClose_MouseEnter);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMin.Location = new System.Drawing.Point(1253, 0);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(16, 17);
            this.lblMin.TabIndex = 3;
            this.lblMin.Text = "-";
            this.lblMin.Click += new System.EventHandler(this.lblMin_Click);
            this.lblMin.MouseEnter += new System.EventHandler(this.lblMin_MouseEnter);
            this.lblMin.MouseLeave += new System.EventHandler(this.lblMin_MouseLeave);
            // 
            // lblStartGame
            // 
            this.lblStartGame.BackColor = System.Drawing.Color.Transparent;
            this.lblStartGame.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartGame.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.lblStartGame.Location = new System.Drawing.Point(0, 430);
            this.lblStartGame.Name = "lblStartGame";
            this.lblStartGame.Size = new System.Drawing.Size(1300, 30);
            this.lblStartGame.TabIndex = 4;
            this.lblStartGame.Text = "Login       ";
            this.lblStartGame.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStartGame.Click += new System.EventHandler(this.lblStartGame_Click);
            this.lblStartGame.MouseEnter += new System.EventHandler(this.lblStartGame_MouseEnter);
            this.lblStartGame.MouseLeave += new System.EventHandler(this.lblStartGame_MouseLeave);
            // 
            // lblScores
            // 
            this.lblScores.BackColor = System.Drawing.Color.Transparent;
            this.lblScores.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScores.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.lblScores.Location = new System.Drawing.Point(0, 480);
            this.lblScores.Name = "lblScores";
            this.lblScores.Size = new System.Drawing.Size(1300, 30);
            this.lblScores.TabIndex = 5;
            this.lblScores.Text = "Ranking Board       ";
            this.lblScores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblScores.Click += new System.EventHandler(this.lblScores_Click);
            this.lblScores.MouseEnter += new System.EventHandler(this.lblScores_MouseEnter);
            this.lblScores.MouseLeave += new System.EventHandler(this.lblScores_MouseLeave);
            // 
            // lblInstruction
            // 
            this.lblInstruction.BackColor = System.Drawing.Color.Transparent;
            this.lblInstruction.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruction.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.lblInstruction.Location = new System.Drawing.Point(0, 530);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(1300, 30);
            this.lblInstruction.TabIndex = 6;
            this.lblInstruction.Text = "Instruction       ";
            this.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblInstruction.Click += new System.EventHandler(this.lblInstruction_Click);
            this.lblInstruction.MouseEnter += new System.EventHandler(this.lblInstruction_MouseEnter);
            this.lblInstruction.MouseLeave += new System.EventHandler(this.lblInstruction_MouseLeave);
            // 
            // lblOption
            // 
            this.lblOption.BackColor = System.Drawing.Color.Transparent;
            this.lblOption.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOption.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.lblOption.Location = new System.Drawing.Point(0, 580);
            this.lblOption.Name = "lblOption";
            this.lblOption.Size = new System.Drawing.Size(1300, 30);
            this.lblOption.TabIndex = 7;
            this.lblOption.Text = "Option       ";
            this.lblOption.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblOption.Click += new System.EventHandler(this.lblOption_Click);
            this.lblOption.MouseEnter += new System.EventHandler(this.lblOption_MouseEnter);
            this.lblOption.MouseLeave += new System.EventHandler(this.lblOption_MouseLeave);
            // 
            // lblAbout
            // 
            this.lblAbout.BackColor = System.Drawing.Color.Transparent;
            this.lblAbout.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbout.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.lblAbout.Location = new System.Drawing.Point(0, 630);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(1300, 30);
            this.lblAbout.TabIndex = 8;
            this.lblAbout.Text = "About       ";
            this.lblAbout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblAbout.Click += new System.EventHandler(this.lblAbout_Click);
            this.lblAbout.MouseEnter += new System.EventHandler(this.lblAbout_MouseEnter);
            this.lblAbout.MouseLeave += new System.EventHandler(this.lblAbout_MouseLeave);
            // 
            // lblUserHeader
            // 
            this.lblUserHeader.AutoSize = true;
            this.lblUserHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblUserHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUserHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUserHeader.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserHeader.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.lblUserHeader.Location = new System.Drawing.Point(13, 13);
            this.lblUserHeader.Name = "lblUserHeader";
            this.lblUserHeader.Size = new System.Drawing.Size(137, 21);
            this.lblUserHeader.TabIndex = 9;
            this.lblUserHeader.Text = "Current User: ";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Consolas", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.lblTitle.Location = new System.Drawing.Point(0, 170);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1300, 44);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "HyperSpace WormHole";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBack
            // 
            this.lblBack.BackColor = System.Drawing.Color.Transparent;
            this.lblBack.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBack.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.lblBack.Location = new System.Drawing.Point(0, 610);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(1300, 30);
            this.lblBack.TabIndex = 11;
            this.lblBack.Text = "Back       ";
            this.lblBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBack.Click += new System.EventHandler(this.lblBack_Click);
            this.lblBack.MouseEnter += new System.EventHandler(this.lblBack_MouseEnter);
            this.lblBack.MouseLeave += new System.EventHandler(this.lblBack_MouseLeave);
            // 
            // lblSignout
            // 
            this.lblSignout.BackColor = System.Drawing.Color.Transparent;
            this.lblSignout.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSignout.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.lblSignout.Location = new System.Drawing.Point(0, 350);
            this.lblSignout.Name = "lblSignout";
            this.lblSignout.Size = new System.Drawing.Size(1300, 30);
            this.lblSignout.TabIndex = 12;
            this.lblSignout.Text = "Logout       ";
            this.lblSignout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSignout.Click += new System.EventHandler(this.lblSignout_Click);
            this.lblSignout.MouseEnter += new System.EventHandler(this.lblSignout_MouseEnter);
            this.lblSignout.MouseLeave += new System.EventHandler(this.lblSignout_MouseLeave);
            // 
            // lblQuickDemo
            // 
            this.lblQuickDemo.BackColor = System.Drawing.Color.Transparent;
            this.lblQuickDemo.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuickDemo.ForeColor = System.Drawing.Color.PaleGoldenrod;
            this.lblQuickDemo.Location = new System.Drawing.Point(0, 380);
            this.lblQuickDemo.Name = "lblQuickDemo";
            this.lblQuickDemo.Size = new System.Drawing.Size(1300, 30);
            this.lblQuickDemo.TabIndex = 13;
            this.lblQuickDemo.Text = "Quick Tutorial       ";
            this.lblQuickDemo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblQuickDemo.Click += new System.EventHandler(this.lblQuickDemo_Click);
            this.lblQuickDemo.MouseEnter += new System.EventHandler(this.lblQuickDemo_MouseEnter);
            this.lblQuickDemo.MouseLeave += new System.EventHandler(this.lblQuickDemo_MouseLeave);
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1300, 700);
            this.Controls.Add(this.lblQuickDemo);
            this.Controls.Add(this.lblSignout);
            this.Controls.Add(this.lblBack);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblUserHeader);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.lblOption);
            this.Controls.Add(this.lblInstruction);
            this.Controls.Add(this.lblScores);
            this.Controls.Add(this.lblStartGame);
            this.Controls.Add(this.lblMin);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.pbBackGround);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainForm_FormClosing);
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMainForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pbBackGround)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbBackGround;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblStartGame;
        private System.Windows.Forms.Label lblScores;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.Label lblOption;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.Label lblUserHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBack;
        private System.Windows.Forms.Label lblSignout;
        private System.Windows.Forms.Label lblQuickDemo;
    }
}