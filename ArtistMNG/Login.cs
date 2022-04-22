using ArtistMNG.Module;
using ArtistMNG.Module.ImageFile;
using ArtistMNG.Module.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ArtistMNG
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            SetUpLoginAndRegisterForm();
            this.ActiveControl = panel_Login;

            pictureBox_randomWallpaper.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_LoadingGIF.Image = ImageFile.SetIconFromFolder("ajax_loadding.gif");
            pictureBox_LoadingGIF.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_TitleIcon.BackgroundImage = ImageFile.SetIconFromFolder("user.png");
            btnExit.BackgroundImage = ImageFile.SetIconFromFolder("close-window.png");
            FormLoad.isLoaded = true;
            
        }

        void SetUpLoginAndRegisterForm()
        {
            if (LoadLogin() == 2)
            {
                LoginInputChangeStyle();
                btnShowAndHidePWD.Enabled = true;
                btnShowAndHidePWD.BackColor = Color.FromArgb(255, 69, 69, 77);

            }
            else if (LoadLogin() == 1)
            {
                txInput_Pwd.Text = "Mật khẩu...";
                txInput_Pwd.ForeColor = Color.FromArgb(173, 173, 173);

                btnShowAndHidePWD.Enabled = false;
                btnShowAndHidePWD.BackColor = Color.FromArgb(50, 69, 69, 77);
            }
            else if (LoadLogin() == 0)
            {
                txInput_User.Text = "Tên tài khoản...";
                txInput_User.ForeColor = Color.FromArgb(173, 173, 173);
                txInput_Pwd.Text = "Mật khẩu...";
                txInput_Pwd.ForeColor = Color.FromArgb(173, 173, 173);
                btnShowAndHidePWD.Enabled = false;
                btnShowAndHidePWD.BackColor = Color.FromArgb(50, 69, 69, 77);
            }
            txInput_User.GotFocus += PlaceholderRemoveText;
            txInput_User.LostFocus += PlaceholderAddText;
            txInput_Pwd.GotFocus += PlaceholderRemoveText;
            txInput_Pwd.LostFocus += PlaceholderAddText;            

            btnShowAndHidePWD.BackgroundImage = ImageFile.SetIconFromFolder("password_eye_show.png");           
        }
        public void PlaceholderRemoveText(object sender, EventArgs e)
        {
            if (txInput_User.Text == "Tên tài khoản..." && (sender as TextBox).Name == txInput_User.Name)
            {
                txInput_User.Text = "";
                txInput_User.ForeColor = Color.FromArgb(0, 0, 0);
            }
            if (txInput_Pwd.Text == "Mật khẩu..." && (sender as TextBox).Name == txInput_Pwd.Name)
            {
                txInput_Pwd.Text = "";
                txInput_Pwd.ForeColor = Color.FromArgb(0, 0, 0);
            }    
        }

        public void PlaceholderAddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txInput_User.Text) && (sender as TextBox).Name == txInput_User.Name)
            {
                txInput_User.Text = "Tên tài khoản...";
                txInput_User.ForeColor = Color.FromArgb(173, 173, 173);               
            }    
            if (string.IsNullOrWhiteSpace(txInput_Pwd.Text) && (sender as TextBox).Name == txInput_Pwd.Name)
            {
                txInput_Pwd.Text = "Mật khẩu...";
                txInput_Pwd.ForeColor = Color.FromArgb(173, 173, 173);
            }    
                
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnShowAndHidePWD_Click(object sender, EventArgs e)
        {
            if(showPWD)
            {
                showPWD = false;
            }    
            else
            {
                showPWD = true;
            }    
            btnShowAndHidePWD.BackgroundImage = showPWD ? ImageFile.SetIconFromFolder("password_eye_hide.png") : ImageFile.SetIconFromFolder("password_eye_show.png");
            if (txInput_Pwd.Text == "Mật khẩu..." || txInput_Pwd.Text.Length < 1)
            {
                return;
            }    
            else
            {               
                txInput_Pwd.PasswordChar = txInput_Pwd.PasswordChar == '*' ? '\0' : '*';

            }            
        }

        bool showPWD = false;
        private void txInput_Pwd_TextChanged(object sender, EventArgs e)
        {
            LoginInputChangeStyle();
        }
        void LoginInputChangeStyle()
        {
            if (txInput_Pwd.Text != "Mật khẩu..." && txInput_Pwd.Text.Length > 0)
            {
                btnShowAndHidePWD.Enabled = true;
                btnShowAndHidePWD.BackColor = Color.FromArgb(255, 69, 69, 77);
            }
            else if (txInput_Pwd.Text == "Mật khẩu..." || txInput_Pwd.Text.Length < 1)
            {
                btnShowAndHidePWD.Enabled = false;
                btnShowAndHidePWD.BackColor = Color.FromArgb(50, 69, 69, 77);
            }

            if (!showPWD && txInput_Pwd.Text != "Mật khẩu...")
            {
                txInput_Pwd.PasswordChar = '*';
            }
            else
            {
                txInput_Pwd.PasswordChar = '\0';
            }
        }

        int poster_Index = 1;
        private void timer_PictureBox_Tick(object sender, EventArgs e)
        {
            switch(poster_Index)
            {
                case 1:
                    pictureBox_randomWallpaper.Image = ImageFile.SetImageFromFolder("itzy.jpg");
                    poster_Index++;
                    break;
                case 2:
                    pictureBox_randomWallpaper.Image = ImageFile.SetImageFromFolder("Nmixx.jpg");
                    poster_Index++;
                    break;
                case 3:
                    pictureBox_randomWallpaper.Image = ImageFile.SetImageFromFolder("exo.jpg");
                    poster_Index++;
                    break;
                case 4:
                    pictureBox_randomWallpaper.Image = ImageFile.SetImageFromFolder("blackpink.jpg");
                    poster_Index++;
                    break;
                case 5:
                    pictureBox_randomWallpaper.Image = ImageFile.SetImageFromFolder("straykids.png");
                    poster_Index = 1;
                    break;
            }    
        }       

        static System.Windows.Forms.Timer loadingTime = new System.Windows.Forms.Timer();

        #region Mở form chính
        string userName, fullName;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txInput_User.Text.Length < 1 || txInput_Pwd.Text.Length < 1 
                || txInput_User.Text == "Tên tài khoản..." || txInput_Pwd.Text == "Mật khẩu...")
            {                                
                MessageBox.Show("Thông tin đăng nhập không được để trống!", "Lỗi");
                return;
            }
            var user = UserManager.Login(txInput_User.Text.ToLower(), txInput_Pwd.Text.ToLower());
            if (user.Item1 == false)
            {
                MessageBox.Show("Thông tin đăng nhập không đúng hoặc lỗi cái khác!", "Lỗi");
                return;
            }
            userName = user.Item2;
            fullName = user.Item3;
            panel_Loading.Visible = true;
            panel_Login.Visible = false;
            FormLoad.isLoaded = false;
            loadingTime.Tick += new EventHandler(OpenForm);

            loadingTime.Interval = 1;
            loadingTime.Start();
            
        }
        bool AccountIsCorrect()
        {
            /*
            try
            {
                if (Database.AccountValidate(userName, password) == true)
                {
                    return true;
                }

                MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng!");
                return false;
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra!");
                return false;
            }
            */
            return false;
        }
        void OpenForm(object sender, EventArgs e)
        {
            frmApp app = new frmApp(userName, fullName);
            app.Closed += (s, args) => this.Close();

            app.Show();
            //return;
            while (FormLoad.isLoaded)
            {
                this.Hide();
                loadingTime.Stop();

                break;
            }
        }
        #endregion

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        void SaveLogin()
        {
            string userName = txInput_User.Text.ToLower();
            string password = txInput_Pwd.Text.ToLower();
            if (checkBox_RememberPWD.Checked == true)
            {
                SaveManager.SaveLoginAccount(userName, password, true);
            }   
            else
            {
                SaveManager.SaveLoginAccount(userName, password, false);
            }    
        }
        byte LoadLogin()
        {
            var loadAccount = SaveManager.LoadLoginAccount();
            txInput_User.Text = loadAccount.Item1;
            txInput_Pwd.Text = loadAccount.Item2;
            checkBox_RememberPWD.Checked = loadAccount.Item2.Length > 0 ? true : false;

            if(loadAccount.Item1.Length > 0 && loadAccount.Item2.Length > 0)
            {
                return 2;
            }
            else if (loadAccount.Item1.Length > 0)
            {
                return 1;
            }
            return 0;
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveLogin();
        }
    }
}
