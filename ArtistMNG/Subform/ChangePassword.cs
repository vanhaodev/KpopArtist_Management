using ArtistMNG.Module.ControlStyle;
using ArtistMNG.Module.ImageFile;
using ArtistMNG.Module.SQL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtistMNG.Subform
{
    public partial class ChangePassword : Form
    {
        int artistID, groupID;
        public ChangePassword()
        {
            InitializeComponent();
            LoadDesign();
        }
        void LoadDesign()
        {
            this.Icon = ImageFile.SetWindowIcon("AMlogo.ico");
            groupBox1.Paint += PaintBorderlessGroupBox;
            groupBox11.Paint += PaintBorderlessGroupBox;
            groupBox2.Paint += PaintBorderlessGroupBox;
        }

        private void btnApplyChangePass_Click(object sender, EventArgs e)
        {
            if(txNewPass.Text != txNewRePass.Text)
            {
                MessageBox.Show("Mật khẩu mới 1 và 2 phải giống nhau!");
                return;
            }    
            if(txNewPass.Text.Length < 1 || txOldPass.Text.Length < 1)
            {
                MessageBox.Show("Mật khẩu không được để trống");
                return;
            }    
            if(UserManager.ChangePassword(User.userName, txOldPass.Text, txNewPass.Text))
            {
                MessageBox.Show($"Mật khẩu đã được đổi thành {txNewPass.Text}");
                txNewPass.Text = string.Empty;
                txNewRePass.Text = string.Empty;
                txOldPass.Text = string.Empty;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!");
            }
        }

        void PaintBorderlessGroupBox(object sender, PaintEventArgs e)
        {
            GroupBoxStyle.PaintBorderlessGroupBox(sender, e, this);
        }


    }
}
