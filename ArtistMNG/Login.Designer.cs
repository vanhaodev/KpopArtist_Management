
namespace ArtistMNG
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            this.panel_Login = new System.Windows.Forms.Panel();
            this.checkBox_RememberPWD = new System.Windows.Forms.CheckBox();
            this.pictureBox_randomWallpaper = new System.Windows.Forms.PictureBox();
            this.btnShowAndHidePWD = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txInput_Pwd = new System.Windows.Forms.TextBox();
            this.txInput_User = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.timer_PictureBox = new System.Windows.Forms.Timer(this.components);
            this.panel_Loading = new System.Windows.Forms.Panel();
            this.pictureBox_LoadingGIF = new System.Windows.Forms.PictureBox();
            this.pictureBox_TitleIcon = new System.Windows.Forms.PictureBox();
            this.panel_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_randomWallpaper)).BeginInit();
            this.panel_Loading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_LoadingGIF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TitleIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Login
            // 
            this.panel_Login.Controls.Add(this.checkBox_RememberPWD);
            this.panel_Login.Controls.Add(this.pictureBox_randomWallpaper);
            this.panel_Login.Controls.Add(this.btnShowAndHidePWD);
            this.panel_Login.Controls.Add(this.btnLogin);
            this.panel_Login.Controls.Add(this.txInput_Pwd);
            this.panel_Login.Controls.Add(this.txInput_User);
            this.panel_Login.Location = new System.Drawing.Point(12, 74);
            this.panel_Login.Name = "panel_Login";
            this.panel_Login.Size = new System.Drawing.Size(595, 245);
            this.panel_Login.TabIndex = 0;
            // 
            // checkBox_RememberPWD
            // 
            this.checkBox_RememberPWD.AutoSize = true;
            this.checkBox_RememberPWD.Font = new System.Drawing.Font("Roboto Condensed", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_RememberPWD.ForeColor = System.Drawing.Color.White;
            this.checkBox_RememberPWD.Location = new System.Drawing.Point(39, 134);
            this.checkBox_RememberPWD.Name = "checkBox_RememberPWD";
            this.checkBox_RememberPWD.Size = new System.Drawing.Size(124, 27);
            this.checkBox_RememberPWD.TabIndex = 5;
            this.checkBox_RememberPWD.Text = "Nhớ mật khẩu";
            this.checkBox_RememberPWD.UseVisualStyleBackColor = true;
            // 
            // pictureBox_randomWallpaper
            // 
            this.pictureBox_randomWallpaper.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox_randomWallpaper.Location = new System.Drawing.Point(406, 17);
            this.pictureBox_randomWallpaper.Name = "pictureBox_randomWallpaper";
            this.pictureBox_randomWallpaper.Size = new System.Drawing.Size(169, 206);
            this.pictureBox_randomWallpaper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_randomWallpaper.TabIndex = 4;
            this.pictureBox_randomWallpaper.TabStop = false;
            // 
            // btnShowAndHidePWD
            // 
            this.btnShowAndHidePWD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(69)))), ((int)(((byte)(77)))));
            this.btnShowAndHidePWD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowAndHidePWD.FlatAppearance.BorderSize = 0;
            this.btnShowAndHidePWD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowAndHidePWD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAndHidePWD.ForeColor = System.Drawing.Color.White;
            this.btnShowAndHidePWD.Location = new System.Drawing.Point(338, 89);
            this.btnShowAndHidePWD.Name = "btnShowAndHidePWD";
            this.btnShowAndHidePWD.Size = new System.Drawing.Size(41, 32);
            this.btnShowAndHidePWD.TabIndex = 3;
            this.btnShowAndHidePWD.TabStop = false;
            this.btnShowAndHidePWD.UseVisualStyleBackColor = false;
            this.btnShowAndHidePWD.Click += new System.EventHandler(this.btnShowAndHidePWD_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(226, 150);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(153, 40);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.TabStop = false;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txInput_Pwd
            // 
            this.txInput_Pwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txInput_Pwd.Location = new System.Drawing.Point(39, 89);
            this.txInput_Pwd.MaxLength = 30;
            this.txInput_Pwd.Name = "txInput_Pwd";
            this.txInput_Pwd.Size = new System.Drawing.Size(299, 30);
            this.txInput_Pwd.TabIndex = 1;
            this.txInput_Pwd.TextChanged += new System.EventHandler(this.txInput_Pwd_TextChanged);
            // 
            // txInput_User
            // 
            this.txInput_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txInput_User.Location = new System.Drawing.Point(39, 30);
            this.txInput_User.MaxLength = 30;
            this.txInput_User.Name = "txInput_User";
            this.txInput_User.Size = new System.Drawing.Size(340, 30);
            this.txInput_User.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(572, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(35, 35);
            this.btnExit.TabIndex = 0;
            this.btnExit.TabStop = false;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTitle.Location = new System.Drawing.Point(68, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(153, 37);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Đăng nhập";
            // 
            // timer_PictureBox
            // 
            this.timer_PictureBox.Enabled = true;
            this.timer_PictureBox.Interval = 1000;
            this.timer_PictureBox.Tick += new System.EventHandler(this.timer_PictureBox_Tick);
            // 
            // panel_Loading
            // 
            this.panel_Loading.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.panel_Loading.Controls.Add(this.pictureBox_LoadingGIF);
            this.panel_Loading.Location = new System.Drawing.Point(12, 12);
            this.panel_Loading.Name = "panel_Loading";
            this.panel_Loading.Size = new System.Drawing.Size(595, 307);
            this.panel_Loading.TabIndex = 2;
            this.panel_Loading.Visible = false;
            // 
            // pictureBox_LoadingGIF
            // 
            this.pictureBox_LoadingGIF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_LoadingGIF.Location = new System.Drawing.Point(226, 79);
            this.pictureBox_LoadingGIF.Name = "pictureBox_LoadingGIF";
            this.pictureBox_LoadingGIF.Size = new System.Drawing.Size(150, 137);
            this.pictureBox_LoadingGIF.TabIndex = 0;
            this.pictureBox_LoadingGIF.TabStop = false;
            // 
            // pictureBox_TitleIcon
            // 
            this.pictureBox_TitleIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_TitleIcon.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_TitleIcon.Name = "pictureBox_TitleIcon";
            this.pictureBox_TitleIcon.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_TitleIcon.TabIndex = 1;
            this.pictureBox_TitleIcon.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(619, 331);
            this.Controls.Add(this.panel_Loading);
            this.Controls.Add(this.pictureBox_TitleIcon);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogin_FormClosed);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.panel_Login.ResumeLayout(false);
            this.panel_Login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_randomWallpaper)).EndInit();
            this.panel_Loading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_LoadingGIF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_TitleIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Login;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txInput_User;
        private System.Windows.Forms.TextBox txInput_Pwd;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnShowAndHidePWD;
        private System.Windows.Forms.PictureBox pictureBox_randomWallpaper;
        private System.Windows.Forms.Timer timer_PictureBox;
        private System.Windows.Forms.Panel panel_Loading;
        private System.Windows.Forms.PictureBox pictureBox_LoadingGIF;
        private System.Windows.Forms.CheckBox checkBox_RememberPWD;
        private System.Windows.Forms.PictureBox pictureBox_TitleIcon;
    }
}

