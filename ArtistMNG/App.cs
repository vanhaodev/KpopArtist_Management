/*
#################################################################
#                             _`				#
#                          _ooOoo_				#
#                         o8888888o				#
#                         88" . "88				#
#                         (| -_- |)				#
#                         O\  =  /O				#
#                      ____/`---'\____				#
#                    .'  \\|     |//  `.			#
#                   /  \\|||  :  |||//  \			#
#                  /  _||||| -:- |||||_  \			#
#                  |   | \\\  -  /'| |   |			#
#                  | \_|  `\`---'//  |_/ |			#
#                  \  .-\__ `-. -'__/-.  /			#
#                ___`. .'  /--.--\  `. .'___			#
#             ."" '<  `.___\_<|>_/___.' _> \"".			#
#            | | :  `- \`. ;`. _/; .'/ /  .' ; |		#
#            \  \ `-.   \_\_`. _.'_/_/  -' _.' /		#
#=============`-.`___`-.__\ \___  /__.-'_.'_.-'=================#
                           `= --= -'    
                          A DI ĐÀ PHẬT
*/
using ArtistMNG.Module;
using ArtistMNG.Module.ControlStyle;
using ArtistMNG.Module.ImageFile;
using ArtistMNG.Module.SQL;
using ArtistMNG.Module.SQL.CUD;
using ArtistMNG.Subform;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ArtistMNG
{
    public partial class frmApp : Form
    {
        #region DESIGN
        ///DESIGN
        ///
        //Cho phép kéo vị trí form ở How to move a Windows Form when its FormBorderStyle is none       
        #region Kéo thả, resize form
        /*
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            //e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }

            //Onchanged Windowstate
            //if (m.Msg == 0x0112) // WM_SYSCOMMAND
            //{
            //    // Check your window state here
            //    if (m.WParam == new IntPtr(0xF030)) // Maximize event - SC_MAXIMIZE from Winuser.h
            //    {
            //        OnWindowStateChanged();
            //    }
            //    else
            //    {
            //        OnWindowStateChanged();
            //    }
            //}
            base.WndProc(ref m);  
        }
        */
        #endregion
        private void userInfor_MouseHover(object sender, EventArgs e)
        {
            panel_UserInfor.BackColor = Color.FromArgb(81, 84, 89);
        }

        private void userInfor_MouseLeave(object sender, EventArgs e)
        {
            panel_UserInfor.BackColor = Color.FromArgb(53, 55, 59);
        }

        void LoadDesign()
        {
            this.Icon = ImageFile.SetWindowIcon("AMlogo.ico");
            string versionName = "1.0";
            this.Text = $"Artist Managenment {versionName}";

            btnApplyAdd.Enabled = true;
            btnApplyDelete.Enabled = false;
            btnApplyEdit.Enabled = false;

            pictureBox_LoadingGIF.Image = ImageFile.SetIconFromFolder("ajax_loadding.gif");
            pictureBox_LoadingGIF.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_LoadingGIF.BackColor = Color.Transparent;

            //pictureBox_ArtistImageLoadingGIF.Image = ImageFile.SetIconFromFolder("ajax_loadding.gif");
            pictureBox_ArtistImage.Controls.Add(pictureBox_ArtistImageLoadingGIF);
            pictureBox_ArtistImage.Image = ImageFile.SetIconFromFolder("unknow_ArtistImage.png");

            //int pdx = pictureBox_ArtistImageLoadingGIF.Location.x - pictureBox_ArtistImage.Width / 2;
            //int pdy = pictureBox_ArtistImageLoadingGIF.Location.y - pictureBox_ArtistImage.Height / 2;
            pictureBox_ArtistImageLoadingGIF.Location = new Point((pictureBox_ArtistImage.Width - pictureBox_ArtistImageLoadingGIF.Width) / 2, (pictureBox_ArtistImage.Height - pictureBox_ArtistImageLoadingGIF.Height) / 2);

            pictureBox_ArtistImageLoadingGIF.BackColor = Color.Transparent;
            pictureBox_ArtistImageLoadingGIF.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox_ArtistImageLoadingGIF.BackColor = Color.Transparent;

            //mấy cái load đồ
            AppStatus(false);

            //btnWindowMinMax.BackgroundImage = ImageFile.SetIconFromFolder("normal-button.png");
            //btnWindowHide.BackgroundImage = ImageFile.SetIconFromFolder("minimize-button.png");
            //btnExit.BackgroundImage = ImageFile.SetIconFromFolder("close-window.png");
            //pictureBox_Icon.BackgroundImage = ImageFile.SetIconFromFolder("itzy_icon.jpg");
            menuStrip_Main.Renderer = new ToolStripProfessionalRenderer(new ColorTable());
            pictureBo_userAvatarMin.BackgroundImage = ImageFile.SetIconFromFolder("user.png");
            pictureBox_ArtistImage.SizeMode = PictureBoxSizeMode.Zoom;

            //TOOLTIP
            toolTip1.BackColor = Color.FromArgb(151, 152, 153);

            #region Datagridview Main
            //DATAGRIDVIEW
            DatagridViewStyle.DarkStyle(dataGridView_Data);

            #endregion
            //2 cái panel chính
            panel_DataContent.MinimumSize = new Size(200, 200);
            //panel_DataContent.MaximumSize = new Size(this.Width - 150, panel_DataContent.Height);

            #region Artist and Group Manage
            panel_ArtistManager.MinimumSize = new Size(200, 200);
            //panel_ArtistManager.MaximumSize = new Size(this.Width - 150, panel_ArtistManager.Height);
            panel_GroupManager.MinimumSize = new Size(200, 200);
            //panel_GroupManager.MaximumSize = new Size(this.Width - 150, panel_GroupManager.Height);
            //=======================ARTIST======================
            //group
            DatagridViewStyle.DarkStyle(dataGridViewArtist_Group);

            ////Song       
            DatagridViewStyle.DarkStyle(dataGridViewArtist_Song);

            //Album
            DatagridViewStyle.DarkStyle(dataGridViewArtist_Album);
            //-----------------------------------------------------
            //=======================GROUP======================
            ////Song       
            DatagridViewStyle.DarkStyle(dataGridViewGroup_Song);

            //groupAlbum
            DatagridViewStyle.DarkStyle(dataGridViewGroup_Album);

            //=========================ALBUM====================
            //albumsong
            DatagridViewStyle.DarkStyle(dataGridViewAlbum_AlbumSong);
            //-----------------------------------------------------
            //Timepicker
            dateTimePickerArtist_Birthday.CustomFormat = "dd-MM-yyyy";
            dateTimePickerArtist_Debutday.CustomFormat = "dd-MM-yyyy";
            dateTimePickerGroup_Debutday.CustomFormat = "dd-MM-yyyy";
            dateTimePicker_LabelFounded.CustomFormat = "dd-MM-yyyy";
            dateTimePickerAlbum_AlbumReleaseDay.CustomFormat = "dd-MM-yyyy";
            #endregion


            //ArtistGroup datagrid
            dataGridViewArtist_Group.Columns.Add("GroupID", "ID");
            dataGridViewArtist_Group.Columns.Add("Name", "Tên");
            dataGridViewArtist_Group.Columns.Add("DebutDay", "Ngày debut");
            dataGridViewArtist_Group.Columns.Add("FandomID", "Fandom");
            dataGridViewArtist_Group.Columns.Add("Description", "Mô tả");
            //ArtistSong datagrid
            dataGridViewArtist_Song.Columns.Add("SongID", "ID");
            dataGridViewArtist_Song.Columns.Add("Name", "Tên");
            dataGridViewArtist_Song.Columns.Add("ReleaseDay", "Phát hành");
            dataGridViewArtist_Song.Columns.Add("Genre", "Thể loại");
            dataGridViewArtist_Song.Columns.Add("Producer", "Producer");
            dataGridViewArtist_Song.Columns.Add("Description", "Mô tả");
            //ArtistAlbum datagrid
            dataGridViewArtist_Album.Columns.Add("AlbumID", "ID");
            dataGridViewArtist_Album.Columns.Add("Name", "Tên");
            dataGridViewArtist_Album.Columns.Add("Release", "Phát hành");
            dataGridViewArtist_Album.Columns.Add("Description", "Mô tả");
            //GroupSong datagrid
            dataGridViewGroup_Song.Columns.Add("SongID", "ID");
            dataGridViewGroup_Song.Columns.Add("Name", "Tên");
            dataGridViewGroup_Song.Columns.Add("ReleaseDay", "Phát hành");
            dataGridViewGroup_Song.Columns.Add("Genre", "Thể loại");
            dataGridViewGroup_Song.Columns.Add("Producer", "Producer");
            dataGridViewGroup_Song.Columns.Add("Description", "Mô tả");
            //GroupAlbum datagrid
            dataGridViewGroup_Album.Columns.Add("AlbumID", "ID");
            dataGridViewGroup_Album.Columns.Add("Name", "Tên");
            dataGridViewGroup_Album.Columns.Add("Release", "Phát hành");
            dataGridViewGroup_Album.Columns.Add("Description", "Mô tả");
            //AlbumSong datagrid
            dataGridViewAlbum_AlbumSong.Columns.Add("SongID", "ID");
            dataGridViewAlbum_AlbumSong.Columns.Add("Name", "Tên");
            dataGridViewAlbum_AlbumSong.Columns.Add("ReleaseDay", "Phát hành");
            dataGridViewAlbum_AlbumSong.Columns.Add("Genre", "Thể loại");
            dataGridViewAlbum_AlbumSong.Columns.Add("Producer", "Producer");
            dataGridViewAlbum_AlbumSong.Columns.Add("Description", "Mô tả");

            //label in artist 
            labelArtist_Fandom.MaximumSize = new Size(panel_ArtistInforFandom.Width - (panel_ArtistInforFandom.Width*10/100), 0);
            labelArtist_Fandom.AutoSize = true;
            labelArtist_Label.MaximumSize = new Size(panel_ArtistInforLabel.Width - (panel_ArtistInforLabel.Width * 10 / 100), 0);
            labelArtist_Label.AutoSize = true;
            //label in group
            labelGroup_Fandom.MaximumSize = new Size(panel_GroupInforFandom.Width - (panel_GroupInforFandom.Width * 10 / 100), 0);
            labelGroup_Fandom.AutoSize = true;
            labelGroup_Label.MaximumSize = new Size(panel_GroupInforLabel.Width - (panel_GroupInforLabel.Width * 10 / 100), 0);
            labelGroup_Label.AutoSize = true;

            groupBox1.Paint += PaintBorderlessGroupBox;
            groupBox2.Paint += PaintBorderlessGroupBox;
            groupBox_ArtistGender.Paint += PaintBorderlessGroupBox;
            groupBox3.Paint += PaintBorderlessGroupBox;
            groupBox_ArtistDescription.Paint += PaintBorderlessGroupBox;
            groupBox5.Paint += PaintBorderlessGroupBox;
            groupBox6.Paint += PaintBorderlessGroupBox;
            groupBox7.Paint += PaintBorderlessGroupBox;
            groupBox_Artist_SNS.Paint += PaintBorderlessGroupBox;
            groupBox_ArtistID.Paint += PaintBorderlessGroupBox;
            //groupBox_ArtistID.Visible = false;

            groupBox10.Paint += PaintBorderlessGroupBox;
            groupBox11.Paint += PaintBorderlessGroupBox;
            groupBox12.Paint += PaintBorderlessGroupBox;
            groupBox13.Paint += PaintBorderlessGroupBox;
            groupBox14.Paint += PaintBorderlessGroupBox;

            //groupbox in Group
            groupBox_GroupID.Paint += PaintBorderlessGroupBox;
            groupBox_GroupName.Paint += PaintBorderlessGroupBox;
            groupBox_GroupDebutday.Paint += PaintBorderlessGroupBox;
            groupBox_GroupDescription.Paint += PaintBorderlessGroupBox;
            groupBox_GroupFandom.Paint += PaintBorderlessGroupBox;
            groupBox_GroupSong.Paint += PaintBorderlessGroupBox;
            groupBox_GroupAlbum.Paint += PaintBorderlessGroupBox;
            groupBox_GroupLabel.Paint += PaintBorderlessGroupBox;
            groupBox_GroupSNS.Paint += PaintBorderlessGroupBox;
            //groupBox_GroupID.Visible = false;
            //dataGridView_Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //dataGridViewArtist_Album.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            txArtist_ID.Enabled = false;
            //groupbox in Label
            groupBoxLabel_LabelID.Paint += PaintBorderlessGroupBox;
            groupBoxLabel_Name.Paint += PaintBorderlessGroupBox;
            groupBoxLabel_Founder.Paint += PaintBorderlessGroupBox;
            groupBoxLabel_Founded.Paint += PaintBorderlessGroupBox;
            groupBoxLabel_Location.Paint += PaintBorderlessGroupBox;
            groupBoxLabel_Description.Paint += PaintBorderlessGroupBox;

            //groupbox in song
            groupBoxSong_ID.Paint += PaintBorderlessGroupBox;
            groupBoxSong_Name.Paint += PaintBorderlessGroupBox;
            groupBoxSong_Genre.Paint += PaintBorderlessGroupBox;
            groupBoxSong_ReleaseDay.Paint += PaintBorderlessGroupBox;
            groupBox_ArtistGender.Paint += PaintBorderlessGroupBox;
            groupBoxSong_Producer.Paint += PaintBorderlessGroupBox;
            groupBoxSong_Description.Paint += PaintBorderlessGroupBox;

            //groupbox album
            groupBoxAlbum_AlbumID.Paint += PaintBorderlessGroupBox;
            groupBoxAlbum_AlbumName.Paint += PaintBorderlessGroupBox;
            groupBoxAlbum_AlbumReleaseDay.Paint += PaintBorderlessGroupBox;
            groupBoxAlbum_AlbumSong.Paint += PaintBorderlessGroupBox;
            groupBoxAlbum_AlbumDescription.Paint += PaintBorderlessGroupBox;

            //group box in fandom
            groupBoxFandom_FandomID.Paint += PaintBorderlessGroupBox;
            groupBoxFandom_FandomName.Paint += PaintBorderlessGroupBox;
            groupBoxFandom_FandomDescription.Paint += PaintBorderlessGroupBox;

            //artist SNS
            pictureBox_Artist_Youtube.Image = ImageFile.SetIconFromFolder("youtube.png");
            pictureBox_Artist_Youtube.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Artist_Instagram.Image = ImageFile.SetIconFromFolder("instagram.png");
            pictureBox_Artist_Instagram.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Artist_Facebook.Image = ImageFile.SetIconFromFolder("facebook.png");
            pictureBox_Artist_Facebook.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Artist_Twitter.Image = ImageFile.SetIconFromFolder("twitter.png");
            pictureBox_Artist_Twitter.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Artist_Tiktok.Image = ImageFile.SetIconFromFolder("tiktok.png");
            pictureBox_Artist_Tiktok.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Artist_Vlive.Image = ImageFile.SetIconFromFolder("vlive.png");
            pictureBox_Artist_Vlive.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Artist_AppleMusic.Image = ImageFile.SetIconFromFolder("applemusic.png");
            pictureBox_Artist_AppleMusic.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Artist_Spotify.Image = ImageFile.SetIconFromFolder("spotify.png");
            pictureBox_Artist_Spotify.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Artist_Website.Image = ImageFile.SetIconFromFolder("website.png");
            pictureBox_Artist_Website.SizeMode = PictureBoxSizeMode.Zoom;
            //Group SNS
            pictureBox_Group_Youtube.Image = ImageFile.SetIconFromFolder("youtube.png");
            pictureBox_Group_Youtube.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Group_Instagram.Image = ImageFile.SetIconFromFolder("instagram.png");
            pictureBox_Group_Instagram.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Group_Facebook.Image = ImageFile.SetIconFromFolder("facebook.png");
            pictureBox_Group_Facebook.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Group_Twitter.Image = ImageFile.SetIconFromFolder("twitter.png");
            pictureBox_Group_Twitter.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Group_Tiktok.Image = ImageFile.SetIconFromFolder("tiktok.png");
            pictureBox_Group_Tiktok.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Group_Vlive.Image = ImageFile.SetIconFromFolder("vlive.png");
            pictureBox_Group_Vlive.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Group_AppleMusic.Image = ImageFile.SetIconFromFolder("applemusic.png");
            pictureBox_Group_AppleMusic.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Group_Spotify.Image = ImageFile.SetIconFromFolder("spotify.png");
            pictureBox_Group_Spotify.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_Group_Website.Image = ImageFile.SetIconFromFolder("website.png");
            pictureBox_Group_Website.SizeMode = PictureBoxSizeMode.Zoom;

            WorkSpaceSetGrid(24);
        }

        void PaintBorderlessGroupBox(object sender, PaintEventArgs e)
        {
            GroupBoxStyle.PaintBorderlessGroupBox(sender, e, this);
        }
        
        //bool isResizeMode = false;
        void panel_Datagrid_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    isResizeMode = true;
            //}
        }
        private void panel_Datagrid_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    isResizeMode = false;
            //}
        }
        private void panel_Datagrid_MouseMove(object sender, MouseEventArgs e)
        {
            //if (isResizeMode)
            //{
            //    this.Size = new Size(e.X, e.Y);
            //}
        }
        /// <summary>
        /// Khi event Resize kích hoạt sẽ kiểm tra xem window đang ở chế độ full màn (max) hay bình thường (normal)
        /// Để tránh việc lặp lại hàm liên tục thì có isMaximized để kiểm tra form đã được set chưa để tránh phải set lại.
        /// </summary>
        bool isMaximized = false;
        private void frmApp_Resize(object sender, EventArgs e)
        {
            if (!isMaximized && this.WindowState == FormWindowState.Maximized)
            {
                WorkSpaceSetGrid(tableSizeAuto);
                Console.WriteLine("chỉnh cho max");
                isMaximized = true;
            }
            if (isMaximized && this.WindowState == FormWindowState.Normal)
            {
                WorkSpaceSetGrid(tableSizeAuto);
                Console.WriteLine("chỉnh cho normal");
                isMaximized = false;
            }
        }
        private void menuStrip_TableSizeAuto1p4_Click(object sender, EventArgs e)
        {
            WorkSpaceSetGrid(14);
        }

        private void menuStrip_TableSizeAuto2p4_Click(object sender, EventArgs e)
        {
            WorkSpaceSetGrid(24);
        }

        private void menuStrip_TableSizeAuto3p4_Click(object sender, EventArgs e)
        {
            WorkSpaceSetGrid(34);
        }


        byte tableSizeAuto = 0;
        void WorkSpaceSetGrid(byte ratio)
        {
            switch (ratio)
            {
                case 14:
                    panel_DataContent.Size = new Size(panel_MainWorkSpace.Width * 25 / 100, panel_DataContent.Height);
                    break;
                case 24:
                    panel_DataContent.Size = new Size(panel_MainWorkSpace.Width * 50 / 100, panel_DataContent.Height);
                    break;
                case 34:
                    panel_DataContent.Size = new Size(panel_MainWorkSpace.Width * 75 / 100, panel_DataContent.Height);
                    break;
            }

            for (int i = 0; i < tableManagePanel.Length; i++)
            {
                switch (ratio)
                {
                    case 14:
                        tableManagePanel[i].Size = new Size(panel_MainWorkSpace.Width * 75 / 100, tableManagePanel[i].Height);
                        tableManagePanel[i].Location = new Point((panel_MainWorkSpace.Width * 75 / 100) / 3, tableManagePanel[i].Location.Y);
                        break;
                    case 24:
                        tableManagePanel[i].Size = new Size(panel_MainWorkSpace.Width * 50 / 100, tableManagePanel[i].Height);
                        tableManagePanel[i].Location = new Point((panel_MainWorkSpace.Width * 50 / 100), tableManagePanel[i].Location.Y);
                        break;
                    case 34:
                        tableManagePanel[i].Size = new Size(panel_MainWorkSpace.Width * 25 / 100, tableManagePanel[i].Height);
                        tableManagePanel[i].Location = new Point((panel_MainWorkSpace.Width * 25 / 100) * 3, tableManagePanel[i].Location.Y);
                        break;
                }
            }
            //textlabel in artist
            labelArtist_Fandom.MaximumSize = new Size(panel_ArtistInforFandom.Width - (panel_ArtistInforFandom.Width * 10 / 100), 0);
            labelArtist_Fandom.AutoSize = true;
            labelArtist_Label.MaximumSize = new Size(panel_ArtistInforLabel.Width - (panel_ArtistInforLabel.Width * 10 / 100), 0);
            labelArtist_Label.AutoSize = true;
            //textlabel in group
            labelGroup_Fandom.MaximumSize = new Size(panel_GroupInforFandom.Width - (panel_GroupInforFandom.Width * 10 / 100), 0);
            labelGroup_Fandom.AutoSize = true;
            labelGroup_Label.MaximumSize = new Size(panel_GroupInforLabel.Width - (panel_GroupInforLabel.Width * 10 / 100), 0);
            labelGroup_Label.AutoSize = true;
            tableSizeAuto = ratio;
        }

        private void btnRatio1p4_Click(object sender, EventArgs e)
        {
            WorkSpaceSetGrid(14);
        }

        private void pictureBox_ArtistImage_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            pictureBox_ArtistImageLoadingGIF.Image = null;
        }
   
        private void dataGridView_Data_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_Data.SelectedRows.Count < 1 || dataGridView_Data.SelectedRows == null)
            {
                //MessageBox.Show("Hãy chọn một hàng để sửa.");
                return;
            }
            else if (dataGridView_Data.SelectedRows.Count > 1)
            {
                //MessageBox.Show("Chỉ được chọn một hàng.");
                return;
            }
            if(showChooseRowToEdit_Warning)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có đang nhập liệu dở dang không? việc này sẽ khiến dữ liệu đang nhập bị reset! \nBạn thật sự muốn nhập lại?", "Cảnh báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }    
            
            selectedRowFirstIndex = dataGridView_Data.SelectedRows[0].Index;
            

            QueryData.Instance.Clear();
            switch (currentTable)
            {
                case DatabaseTable.Artist:
                    artistID = (int)dataGridView_Data.SelectedRows[0].Cells[0].Value;
                    Artist_ChooseRowToEdit();
                    break;
                case DatabaseTable.Group:
                    groupID = (int)dataGridView_Data.SelectedRows[0].Cells[0].Value;
                    Group_ChooseRowToEdit();
                    break;
                case DatabaseTable.Song:
                    songID = (int)dataGridView_Data.SelectedRows[0].Cells[0].Value;
                    Song_ChooseRowToEdit();
                    break;
                case DatabaseTable.Album:
                   albumID = (int)dataGridView_Data.SelectedRows[0].Cells[0].Value;
                    Album_ChooseRowToEdit();
                    break;
                case DatabaseTable.Fandom:
                    fandomID = (int)dataGridView_Data.SelectedRows[0].Cells[0].Value;
                    Fandom_ChooseRowToEdit();
                    break;
                case DatabaseTable.Label:
                    labelID = (int)dataGridView_Data.SelectedRows[0].Cells[0].Value;
                    Label_ChooseRowToEdit();
                    break;
            }
            isCreateNewRow = false;
            btnApplyAdd.Enabled = false;
            btnApplyDelete.Enabled = true;
            btnApplyEdit.Enabled = true;
            //ShowSelectedRow(dataGridView_Data.SelectedRows[0].Index);
        }
        private void btnRatio2p4_Click(object sender, EventArgs e)
        {
            WorkSpaceSetGrid(24);
        }
        private void btnRatio3p4_Click(object sender, EventArgs e)
        {
            WorkSpaceSetGrid(34);
        }  
    #endregion
    //private static frmApp instance;
    //public static frmApp Instance
    //{
    //    get
    //    {
    //        if (instance == null || instance.IsDisposed)
    //        {
    //            instance = new frmApp("", "");
    //        }
    //        return instance;
    //    }
    //}
    //public List<ModelImage> modelImageList = new List<ModelImage>();
    string userName, fullName;
        /// <summary>
        /// Bảng hiện tại đang tương tác.
        /// </summary>
        public static DatabaseTable currentTable;
        /// <summary>
        /// Nếu đây là insert mới thì khi mở các bảng trung gian như Image sẽ không gửi ArtistID hoặc GroupID. (Tạo mới nên không thể biết ID).
        /// </summary>
        bool isCreateNewRow;
        /// <summary>
        /// Chọn bảng cần Refresh
        /// </summary>
        DatabaseTable tableWantToRefresh;
        /// <summary>
        /// Lưu trữ 5 panel ở phần manger như panel_ArtistManager....
        /// </summary>
        Panel[] tableManagePanel = new Panel[6];
        ///<summary>
        ///True sẽ không hiện cảnh báo ở phần select row ở dataGridView_Data
        ///</summary>
        bool showChooseRowToEdit_Warning = true;
        ///<summary>
        ///Index của dòng đầu tiên trong dataGridView_Data
        ///</summary>
        int selectedRowFirstIndex = 0;
        ///<summary>
        ///ID hiện tại của Nghệ sĩ đang tương tác
        ///</summary>
        int artistID = 0;
        ///<summary>
        ///ID hiện tại của nhóm đang tương tác
        ///</summary>
        int groupID = 0;
        int songID = 0, albumID = 0, fandomID = 0, labelID = 0;
        public frmApp(string userName, string fullName)
        {
            InitializeComponent();
            this.fullName = fullName;
            this.userName = userName;
            
        }

        private async void frmApp_Load(object sender, EventArgs e)
        {
            FormLoad.isLoaded = true;
            currentTable = DatabaseTable.Artist;
            ShowData(DatabaseTable.Artist);
            lbl_UserFullName.Text = fullName;

            tableManagePanel[0] = panel_ArtistManager;
            tableManagePanel[1] = panel_GroupManager;
            tableManagePanel[2] = panel_SongManager;
            tableManagePanel[3] = panel_AlbumManager;
            tableManagePanel[4] = panel_LabelManager;
            tableManagePanel[5] = panel_FandomManager;
            isCreateNewRow = true;
            LoadDesign();


        }

        //Nút thoát - phóng to thu nhỏ (đã bỏ)
        //private void btnExit_Click(object sender, EventArgs e)
        //{
        //    Application.Exit();
        //}

        //private void btnWindowMinMax_Click(object sender, EventArgs e)
        //{
        //    if (WindowState == FormWindowState.Normal)
        //    {
        //        WindowState = FormWindowState.Maximized;
        //        //btnWindowMinMax.BackgroundImage = ImageFile.SetIconFromFolder("normal-button.png");
        //    }
        //    else
        //    {
        //        WindowState = FormWindowState.Normal;
        //        //btnWindowMinMax.BackgroundImage = ImageFile.SetIconFromFolder("maximize-button.png");
        //    }
        //    WorkSpaceSetGrid(tableSizeAuto);
        //}

        //private void btnWindowHide_Click(object sender, EventArgs e)
        //{
        //    if (WindowState == FormWindowState.Minimized)
        //    {
        //        WindowState = FormWindowState.Maximized;                
        //    }
        //    else
        //    {
        //        WindowState = FormWindowState.Minimized;                
        //    }
        //}

       
        private void userInfor_Click(object sender, EventArgs e)
        {
            MessageBox.Show(fullName);
        }

        void SetTooltip()
        {
            //Tab user
            toolTip1.SetToolTip(panel_UserInfor, $"Xin chào {fullName}, \nclick để xem chi tiết tài khoản.");
            toolTip1.SetToolTip(lbl_UserFullName, $"Xin chào {fullName}, \nclick để xem chi tiết tài khoản.");
            toolTip1.SetToolTip(pictureBo_userAvatarMin, $"Xin chào {fullName}, \nclick để xem chi tiết tài khoản.");

            string tableName = "??";
            switch (currentTable)
            {
                case DatabaseTable.Artist:
                    tableName = "nghệ sĩ";
                    break;
                case DatabaseTable.Group:
                    tableName = "nhóm";
                    break;
                case DatabaseTable.Song:
                    tableName = "bài hát";
                    break;
                case DatabaseTable.Album:
                    tableName = "album";
                    break;
                case DatabaseTable.Label:
                    tableName = "công ty";
                    break;
            }

            toolTip1.SetToolTip(btnNewRow, $"Tạo {tableName} mới");
            toolTip1.SetToolTip(btnApplyAdd, $"Thêm {tableName} này vào cơ sở dữ liệu");
            toolTip1.SetToolTip(btnApplyEdit, $"Cập nhật {tableName} này");
            toolTip1.SetToolTip(btnApplyDelete, $"Xóa {tableName} này");
        }

        private void MenuStrip_ShowArtistTable_Click(object sender, EventArgs e)
        {
            ClearDataFiled();
            ShowData(DatabaseTable.Artist);
        }

        private void MenuStrip_ShowGroupTable_Click(object sender, EventArgs e)
        {
            ClearDataFiled();
            ShowData(DatabaseTable.Group);
        }

        private void MenuStrip_ShowSongTable_Click(object sender, EventArgs e)
        {
            ClearDataFiled();
            ShowData(DatabaseTable.Song);
        }

        private void MenuStrip_ShowAlbumTable_Click(object sender, EventArgs e)
        {
            ClearDataFiled();
            ShowData(DatabaseTable.Album);
        }

        private void MenuStrip_ShowLabelTable_Click(object sender, EventArgs e)
        {
            ClearDataFiled();
            ShowData(DatabaseTable.Label);
        }
        private void MenuStrip_ShowFandomTable_Click(object sender, EventArgs e)
        {
            ClearDataFiled();
            ShowData(DatabaseTable.Fandom);
        }
        void ShowData(DatabaseTable databaseTable)
        {
            ClearDataFiled();
            panel_ArtistManager.Visible = false;
            panel_GroupManager.Visible = false;
            panel_SongManager.Visible = false;
            panel_AlbumManager.Visible = false;
            panel_LabelManager.Visible = false;
            panel_FandomManager.Visible = false;

            switch (databaseTable)
            {

                case DatabaseTable.Artist:
                    dataGridView_Data.DataSource = DatabaseManager.ShowDataStoredProcedure("Artist_Basic_Infor");
                    //dataGridView_Data.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                    //dataGridView_Data.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
                    currentTable = DatabaseTable.Artist;
                    panel_ArtistManager.Visible = true;
                    break;
                case DatabaseTable.Group:
                    dataGridView_Data.DataSource = DatabaseManager.ShowDataStoredProcedure("Group_Basic_Infor");
                    currentTable = DatabaseTable.Group;
                    panel_GroupManager.Visible = true;
                    break;
                case DatabaseTable.Song:
                    dataGridView_Data.DataSource = DatabaseManager.ShowDataStoredProcedure("Song_Basic_Infor");
                    currentTable = DatabaseTable.Song;
                    panel_SongManager.Visible = true;
                    break;
                case DatabaseTable.Album:
                    dataGridView_Data.DataSource = DatabaseManager.ShowDataStoredProcedure("Album_Basic_Infor");
                    currentTable = DatabaseTable.Album;
                    panel_AlbumManager.Visible = true;
                    break;
                case DatabaseTable.Label:
                    dataGridView_Data.DataSource = DatabaseManager.ShowDataStoredProcedure("Label_Basic_Infor");
                    currentTable = DatabaseTable.Label;
                    panel_LabelManager.Visible = true;
                    break;
                case DatabaseTable.Fandom:
                    dataGridView_Data.DataSource = DatabaseManager.ShowDataStoredProcedure("Fandom_Basic_Infor");
                    currentTable = DatabaseTable.Fandom;
                    panel_FandomManager.Visible = true;
                    break;
            }
            dataGridView_Data.AllowUserToAddRows = false;
            DatagridViewStyle.MinimumWidth(dataGridView_Data, 100);
            SetTooltip();
        }

        /// <summary>
        /// BUTTON NÀY HIỆN KHÔNG DÙNG NỮA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditRow_Click(object sender, EventArgs e)
        {
            if (dataGridView_Data.SelectedRows.Count < 1 || dataGridView_Data.SelectedRows == null)
            {
                MessageBox.Show("Hãy chọn một hàng để sửa.");
                return;
            }
            else if (dataGridView_Data.SelectedRows.Count > 1)
            {
                MessageBox.Show("Chỉ được chọn một hàng.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn có đang nhập liệu dở dang không? việc này sẽ khiến dữ liệu đang nhập bị reset! \nBạn thật sự muốn nhập lại?", "Cảnh báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            QueryData.Instance.Clear();
            switch (currentTable)
            {
                case DatabaseTable.Artist:
                    Artist_ChooseRowToEdit();
                    break;
                case DatabaseTable.Group:
                    Group_ChooseRowToEdit();
                    break;
                case DatabaseTable.Song:
                    Song_ChooseRowToEdit();
                    break;
                case DatabaseTable.Album:
                    Album_ChooseRowToEdit();
                    break;
                case DatabaseTable.Label:
                    Label_ChooseRowToEdit();
                    break;
                case DatabaseTable.Fandom:
                    Fandom_ChooseRowToEdit();
                    break;
            }
            isCreateNewRow = false;
            btnApplyAdd.Enabled = false;
            btnApplyDelete.Enabled = true;
            btnApplyEdit.Enabled = true;
        }

        private void btnNewRow_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Khi tạo mới sẽ xóa hết dữ liệu đang nhập trong form!", "Tạo mới", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            ClearDataFiled();
            
        }
        private void btnApplyAdd_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn thêm?", "Thêm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            switch (currentTable)
            {
                case DatabaseTable.Artist:
                    if(!SetQueryData_Artist())
                    {
                        return;
                    }
                    var insertDetail = ArtistCUD.Insert();
                    if (insertDetail.Item1)
                    {
                        MessageBox.Show($"Thêm {QueryData.Instance.Artist.StageName} thành công");              
                    }  
                    else
                    {
                        MessageBox.Show($"Thêm thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }

                    ShowData(DatabaseTable.Artist);
                    for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
                    {
                        if ((int)dataGridView_Data.Rows[i].Cells[0].Value == insertDetail.Item2)
                        {                        
                            showChooseRowToEdit_Warning = false;
                            dataGridView_Data.ClearSelection();
                            dataGridView_Data.Rows[i].Selected = true;
                            break;
                        }
                    }
                    showChooseRowToEdit_Warning = true;
                    break;
                case DatabaseTable.Group:
                    if (!SetQueryData_Group())
                    {
                        return;
                    }
                    var gInsertDetail = GroupCUD.Insert();
                    if (gInsertDetail.Item1)
                    {
                        MessageBox.Show($"Thêm {QueryData.Instance.Group.GroupName} thành công");
                    }
                    else
                    {
                        MessageBox.Show($"Thêm thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }

                    ShowData(DatabaseTable.Group);
                    for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
                    {
                        if ((int)dataGridView_Data.Rows[i].Cells[0].Value == gInsertDetail.Item2)
                        {
                            showChooseRowToEdit_Warning = false;
                            dataGridView_Data.ClearSelection();
                            dataGridView_Data.Rows[i].Selected = true;
                            break;
                        }
                    }
                    showChooseRowToEdit_Warning = true;
                    break;
                case DatabaseTable.Song:
                    if (!SetQueryData_Song())
                    {
                        return;
                    }
                    var songInsertDetail = SongCUD.Insert();
                    if (songInsertDetail.Item1)
                    {
                        MessageBox.Show($"Thêm {QueryData.Instance.Song.SongName} thành công");
                    }
                    else
                    {
                        MessageBox.Show($"Thêm thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }

                    ShowData(DatabaseTable.Song);
                    for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
                    {
                        if ((int)dataGridView_Data.Rows[i].Cells[0].Value == songInsertDetail.Item2)
                        {
                            showChooseRowToEdit_Warning = false;
                            dataGridView_Data.ClearSelection();
                            dataGridView_Data.Rows[i].Selected = true;
                            break;
                        }
                    }
                    showChooseRowToEdit_Warning = true;
                    break;
                case DatabaseTable.Album:
                    if (!SetQueryData_Album())
                    {
                        return;
                    }
                    var albumInsertDetail = AlbumCUD.Insert();
                    if (albumInsertDetail.Item1)
                    {
                        MessageBox.Show($"Thêm {QueryData.Instance.Album.AlbumName} thành công");
                    }
                    else
                    {
                        MessageBox.Show($"Thêm thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }

                    ShowData(DatabaseTable.Album);
                    for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
                    {
                        if ((int)dataGridView_Data.Rows[i].Cells[0].Value == albumInsertDetail.Item2)
                        {
                            showChooseRowToEdit_Warning = false;
                            dataGridView_Data.ClearSelection();
                            dataGridView_Data.Rows[i].Selected = true;
                            break;
                        }
                    }
                    showChooseRowToEdit_Warning = true;
                    break;
                case DatabaseTable.Fandom:
                    if (!SetQueryData_Fandom())
                    {
                        return;
                    }
                    var fandomInsertDetail = FandomCUD.Insert();
                    if (fandomInsertDetail.Item1)
                    {
                        MessageBox.Show($"Thêm {QueryData.Instance.Fandom.FandomName} thành công");
                    }
                    else
                    {
                        MessageBox.Show($"Thêm thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }

                    ShowData(DatabaseTable.Fandom);
                    for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
                    {
                        if ((int)dataGridView_Data.Rows[i].Cells[0].Value == fandomInsertDetail.Item2)
                        {
                            showChooseRowToEdit_Warning = false;
                            dataGridView_Data.ClearSelection();
                            dataGridView_Data.Rows[i].Selected = true;
                            break;
                        }
                    }
                    showChooseRowToEdit_Warning = true;
                    break;
                case DatabaseTable.Label:
                    if (!SetQueryData_Label())
                    {
                        return;
                    }
                    var labelInsertDetail = LabelCUD.Insert();
                    if (labelInsertDetail.Item1)
                    {
                        MessageBox.Show($"Thêm {QueryData.Instance.Label.LabelName} thành công");
                    }
                    else
                    {
                        MessageBox.Show($"Thêm thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }

                    ShowData(DatabaseTable.Label);
                    for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
                    {
                        if ((int)dataGridView_Data.Rows[i].Cells[0].Value == labelInsertDetail.Item2)
                        {
                            showChooseRowToEdit_Warning = false;
                            dataGridView_Data.ClearSelection();
                            dataGridView_Data.Rows[i].Selected = true;
                            break;
                        }
                    }
                    showChooseRowToEdit_Warning = true;
                    break;
            }
        }

        private void btnApplyUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn cập nhật?", "Cập nhật", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            switch (currentTable)
            {
                case DatabaseTable.Artist:
                    if (!SetQueryData_Artist())
                    {
                        return;
                    }

                    if (ArtistCUD.Update())
                    {
                        MessageBox.Show($"Cập nhật {QueryData.Instance.Artist.StageName} thành công");

                    }
                    else
                    {
                        MessageBox.Show($"Cập nhật thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }
                    ShowData(DatabaseTable.Artist);
                    for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
                    {
                        if ((int)dataGridView_Data.Rows[i].Cells[0].Value == artistID)
                        {
                            showChooseRowToEdit_Warning = false;
                            dataGridView_Data.ClearSelection();
                            dataGridView_Data.Rows[i].Selected = true;
                            break;
                        }
                    }
                    showChooseRowToEdit_Warning = true;
                    break;
                case DatabaseTable.Group:
                    if (!SetQueryData_Group())
                    {
                        return;
                    }

                    if (GroupCUD.Update())
                    {
                        MessageBox.Show($"Cập nhật {QueryData.Instance.Group.GroupName} thành công");

                    }
                    else
                    {
                        MessageBox.Show($"Cập nhật thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }
                    ShowData(DatabaseTable.Group);
                    for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
                    {
                        if ((int)dataGridView_Data.Rows[i].Cells[0].Value == groupID)
                        {
                            showChooseRowToEdit_Warning = false;
                            dataGridView_Data.ClearSelection();
                            dataGridView_Data.Rows[i].Selected = true;
                            break;
                        }
                    }
                    showChooseRowToEdit_Warning = true;
                    break;
                case DatabaseTable.Song:
                    if (!SetQueryData_Song())
                    {
                        return;
                    }

                    if (SongCUD.Update())
                    {
                        MessageBox.Show($"Cập nhật {QueryData.Instance.Song.SongName} thành công");

                    }
                    else
                    {
                        MessageBox.Show($"Cập nhật thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }
                    ShowData(DatabaseTable.Song);
                    for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
                    {
                        if ((int)dataGridView_Data.Rows[i].Cells[0].Value == songID)
                        {
                            showChooseRowToEdit_Warning = false;
                            dataGridView_Data.ClearSelection();
                            dataGridView_Data.Rows[i].Selected = true;
                            break;
                        }
                    }
                    showChooseRowToEdit_Warning = true;
                    break;
                case DatabaseTable.Album:
                    if (!SetQueryData_Album())
                    {
                        return;
                    }

                    if (AlbumCUD.Update())
                    {
                        MessageBox.Show($"Cập nhật {QueryData.Instance.Album.AlbumID} thành công");

                    }
                    else
                    {
                        MessageBox.Show($"Cập nhật thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }
                    ShowData(DatabaseTable.Album);
                    for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
                    {
                        if ((int)dataGridView_Data.Rows[i].Cells[0].Value == albumID)
                        {
                            showChooseRowToEdit_Warning = false;
                            dataGridView_Data.ClearSelection();
                            dataGridView_Data.Rows[i].Selected = true;
                            break;
                        }
                    }
                    showChooseRowToEdit_Warning = true;
                    break;
                case DatabaseTable.Fandom:
                    if (!SetQueryData_Fandom())
                    {
                        return;
                    }

                    if (FandomCUD.Update())
                    {
                        MessageBox.Show($"Cập nhật {QueryData.Instance.Fandom.FandomID} thành công");

                    }
                    else
                    {
                        MessageBox.Show($"Cập nhật thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }
                    ShowData(DatabaseTable.Fandom);
                    for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
                    {
                        if ((int)dataGridView_Data.Rows[i].Cells[0].Value == fandomID)
                        {
                            showChooseRowToEdit_Warning = false;
                            dataGridView_Data.ClearSelection();
                            dataGridView_Data.Rows[i].Selected = true;
                            break;
                        }
                    }
                    showChooseRowToEdit_Warning = true;
                    break;
                case DatabaseTable.Label:
                    if (!SetQueryData_Label())
                    {
                        return;
                    }

                    if (LabelCUD.Update())
                    {
                        MessageBox.Show($"Cập nhật {QueryData.Instance.Label.LabelName} thành công");

                    }
                    else
                    {
                        MessageBox.Show($"Cập nhật thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }
                    ShowData(DatabaseTable.Label);
                    for (int i = 0; i < dataGridView_Data.Rows.Count; i++)
                    {
                        if ((int)dataGridView_Data.Rows[i].Cells[0].Value == labelID)
                        {
                            showChooseRowToEdit_Warning = false;
                            dataGridView_Data.ClearSelection();
                            dataGridView_Data.Rows[i].Selected = true;
                            break;
                        }
                    }
                    showChooseRowToEdit_Warning = true;
                    break;
            }
        }
        private void btnApplyDelete_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xóa?\nChỉ bảng 'Nghệ Sĩ' mới có thể khôi phục trong Bảng/Thùng rác.", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            switch (currentTable)
            {

                case DatabaseTable.Artist:
                    try
                    {
                        QueryData.Instance.Artist.ArtistID = Convert.ToInt32(txArtist_ID.Text);
                    }
                    catch
                    {
                        MessageBox.Show($"Lỗi ID! giá trị: {txArtist_ID.Text}");
                        return;
                    }

                    if (ArtistCUD.Delete(DatabaseExecuteState.Hide))
                    {
                        MessageBox.Show($"Xóa {QueryData.Instance.Artist.StageName} thành công");

                    }
                    else
                    {
                        MessageBox.Show($"Xóa thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }
                    ClearDataFiled();
                    ShowData(DatabaseTable.Artist);
                    break;
                case DatabaseTable.Group:
                    try
                    {
                        QueryData.Instance.Group.GroupID = Convert.ToInt32(txGroup_ID.Text);
                    }
                    catch
                    {
                        MessageBox.Show($"Lỗi ID! giá trị: {txGroup_ID.Text}");
                        return;
                    }

                    if (GroupCUD.Delete(DatabaseExecuteState.Delete))
                    {
                        MessageBox.Show($"Xóa {QueryData.Instance.Group.GroupName} thành công");

                    }
                    else
                    {
                        MessageBox.Show($"Xóa thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }
                    ClearDataFiled();
                    ShowData(DatabaseTable.Group);
                    break;
                case DatabaseTable.Song:
                    try
                    {
                        QueryData.Instance.Song.SongID = Convert.ToInt32(txSong_SongID.Text); ;
                    }
                    catch
                    {
                        MessageBox.Show($"Lỗi ID! giá trị: {txSong_SongName.Text}");
                        return;
                    }

                    if (SongCUD.Delete())
                    {
                        MessageBox.Show($"Xóa {QueryData.Instance.Song.SongName} thành công");

                    }
                    else
                    {
                        MessageBox.Show($"Xóa thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }
                    ClearDataFiled();
                    ShowData(DatabaseTable.Song);
                    break;
                case DatabaseTable.Album:
                    try
                    {
                        QueryData.Instance.Album.AlbumID = Convert.ToInt32(txAlbum_AlbumID.Text); ;
                    }
                    catch
                    {
                        MessageBox.Show($"Lỗi ID! giá trị: {txAlbum_AlbumID.Text}");
                        return;
                    }

                    if (AlbumCUD.Delete())
                    {
                        MessageBox.Show($"Xóa {QueryData.Instance.Album.AlbumID} thành công");

                    }
                    else
                    {
                        MessageBox.Show($"Xóa thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }
                    ClearDataFiled();
                    ShowData(DatabaseTable.Album);
                    break;
                case DatabaseTable.Fandom:
                    try
                    {
                        QueryData.Instance.Fandom.FandomID = Convert.ToInt32(txFandom_FandomID.Text); ;
                    }
                    catch
                    {
                        MessageBox.Show($"Lỗi ID! giá trị: {txFandom_FandomID.Text}");
                        return;
                    }

                    if (FandomCUD.Delete())
                    {
                        MessageBox.Show($"Xóa {QueryData.Instance.Fandom.FandomName} thành công");

                    }
                    else
                    {
                        MessageBox.Show($"Xóa thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }
                    ClearDataFiled();
                    ShowData(DatabaseTable.Fandom);
                    break;
                case DatabaseTable.Label:
                    try
                    {
                        QueryData.Instance.Label.LabelID = Convert.ToInt32(txLabel_LabelID.Text); ;
                    }
                    catch
                    {
                        MessageBox.Show($"Lỗi ID! giá trị: {txLabel_LabelID.Text}");
                        return;
                    }

                    if (LabelCUD.Delete())
                    {
                        MessageBox.Show($"Xóa {QueryData.Instance.Label.LabelName} thành công");

                    }
                    else
                    {
                        MessageBox.Show($"Xóa thất bại!\nlỗi đến từ việc giao tiếp với database");
                        return;
                    }
                    ClearDataFiled();
                    ShowData(DatabaseTable.Label);
                    break;
            }                 
        }
        bool SetQueryData_Artist()
        {
            if (txArtist_StageName.Text.Length < 1
                        || txArtist_RealName.Text.Length < 1)
            {
                MessageBox.Show("Phải điền đầy đủ nghệ danh và tên thật!");
                return false;
            }
            if (!Regex.IsMatch(txArtist_Height.Text, @"^[0-9]*(?:\,[0-9]*)?$")
                || !Regex.IsMatch(txArtist_Weight.Text, @"^[0-9]*(?:\,[0-9]*)?$"))
            {
                MessageBox.Show("Chiều cao và cân nặng phải là số nguyên hoặc số thực!\nĐối với chiều cao là mét (vd: '1,77') và cân nặng là kg (vd: '49')");
                return false;
            }
            //index 1 là nữ | index 0 là nam, nếu khác thì lỗi
            if(comboBox_ArtistGender.SelectedIndex == -1)
            {
                MessageBox.Show("Phải chọn giới tính!");
                return false;
            }    

            QueryData.Instance.Artist.ArtistID = Convert.ToInt32(txArtist_ID.Text);
            QueryData.Instance.Artist.StageName = txArtist_StageName.Text;
            QueryData.Instance.Artist.RealName = txArtist_RealName.Text;
            QueryData.Instance.Artist.Gender = comboBox_ArtistGender.SelectedIndex == 0 ? 1 : 0;
            QueryData.Instance.Artist.BirthDay = dateTimePickerArtist_Birthday.Value;
            QueryData.Instance.Artist.BirthPlace = txArtist_BirthPlace.Text;
            QueryData.Instance.Artist.DebutDay = dateTimePickerArtist_Debutday.Value;
            QueryData.Instance.Artist.Description = txArtist_Description.Text;
            QueryData.Instance.Artist.Height = txArtist_Height.Text.Length > 0 ? (float)Convert.ToDouble(txArtist_Height.Text) : 0;
            QueryData.Instance.Artist.Weight = txArtist_Weight.Text.Length > 0 ? (float)Convert.ToDouble(txArtist_Weight.Text) : 0;

            QueryData.Instance.Artist.Sns.Youtube = tx_Artist_YoutubeURL.Text;
            QueryData.Instance.Artist.Sns.Instagram = tx_Artist_InstagramURL.Text;
            QueryData.Instance.Artist.Sns.Facebook = tx_Artist_FacebookURL.Text;
            QueryData.Instance.Artist.Sns.Twitter = tx_Artist_TwitterURL.Text;
            QueryData.Instance.Artist.Sns.Tiktok = tx_Artist_TiktokURL.Text;
            QueryData.Instance.Artist.Sns.Vlive = tx_Artist_VliveURL.Text;
            QueryData.Instance.Artist.Sns.AppleMusic = tx_Artist_AppleMusicURL.Text;
            QueryData.Instance.Artist.Sns.Spotify = tx_Artist_SpotifyURL.Text;
            QueryData.Instance.Artist.Sns.Website = tx_Artist_WebsiteURL.Text;

            //Đã update FandomID - LabelID (trong lúc thêm trong form thì đã tự chỉnh sửa QueryData.Instance rồi
            return true;
        }
        bool SetQueryData_Group()
        {
            if (txGroup_Name.Text.Length < 1)
            {
                MessageBox.Show("Phải điền tên nhóm!");
                return false;
            }
            QueryData.Instance.Group.GroupID = Convert.ToInt32(txGroup_ID.Text);
            QueryData.Instance.Group.GroupName = txGroup_Name.Text;
            QueryData.Instance.Group.DebutDay = dateTimePickerGroup_Debutday.Value;
            QueryData.Instance.Group.Description = txGroup_Description.Text;


            QueryData.Instance.Group.Sns.Youtube = tx_Group_YoutubeURL.Text;
            QueryData.Instance.Group.Sns.Instagram = tx_Group_InstagramURL.Text;
            QueryData.Instance.Group.Sns.Facebook = tx_Group_FacebookURL.Text;
            QueryData.Instance.Group.Sns.Twitter = tx_Group_TwitterURL.Text;
            QueryData.Instance.Group.Sns.Tiktok = tx_Group_TiktokURL.Text;
            QueryData.Instance.Group.Sns.Vlive = tx_Group_VliveURL.Text;
            QueryData.Instance.Group.Sns.AppleMusic = tx_Group_AppleMusicURL.Text;
            QueryData.Instance.Group.Sns.Spotify = tx_Group_SpotifyURL.Text;
            QueryData.Instance.Group.Sns.Website = tx_Group_WebsiteURL.Text;

            //Đã update FandomID - LabelID (trong lúc thêm trong form thì đã tự chỉnh sửa QueryData.Instance rồi
            return true;
        }
        bool SetQueryData_Song()
        {
            if (txSong_SongName.Text.Length < 1)
            {
                MessageBox.Show("Phải điền tên bài hát!");
                return false;
            }

            QueryData.Instance.Song.SongID = Convert.ToInt32(txSong_SongID.Text);
            QueryData.Instance.Song.SongName = txSong_SongName.Text;
            QueryData.Instance.Song.ReleaseDay = dateTimePickerSong_SongReleaseDay.Value;
            QueryData.Instance.Song.Genre = txSong_SongGenre.Text;
            QueryData.Instance.Song.Producer = txSong_SongProducer.Text;
            QueryData.Instance.Song.Description = txSong_SongDescription.Text;
            return true;
        }
        bool SetQueryData_Album()
        {
            if (txAlbum_AlbumName.Text.Length < 1)
            {
                MessageBox.Show("Phải điền tên album!");
                return false;
            }

            QueryData.Instance.Album.AlbumID = Convert.ToInt32(txAlbum_AlbumID.Text);
            QueryData.Instance.Album.AlbumName = txAlbum_AlbumName.Text;
            QueryData.Instance.Album.ReleaseDay = dateTimePickerAlbum_AlbumReleaseDay.Value;
            QueryData.Instance.Album.Description = txAlbum_AlbumDescription.Text;
            return true;
        }
        bool SetQueryData_Label()
        {
            if (txLabel_LabelName.Text.Length < 1)
            {
                MessageBox.Show("Phải điền tên công ty!");
                return false;
            }
            if (txLabel_Founder.Text.Length < 1)
            {
                MessageBox.Show("Phải điền tên người thành lập!");
                return false;
            }
            QueryData.Instance.Label.LabelID = Convert.ToInt32(txLabel_LabelID.Text);
            QueryData.Instance.Label.LabelName = txLabel_LabelName.Text;
            QueryData.Instance.Label.Founder = txLabel_Founder.Text;
            QueryData.Instance.Label.Founded = dateTimePicker_LabelFounded.Value;
            QueryData.Instance.Label.Location = txLabel_Location.Text;
            QueryData.Instance.Label.Description = txLabel_Description.Text;
            return true;
        }
        bool SetQueryData_Fandom()
        {
            if (txFandom_FandomName.Text.Length < 1)
            {
                MessageBox.Show("Phải điền tên fandom!");
                return false;
            }
            QueryData.Instance.Fandom.FandomID = Convert.ToInt32(txFandom_FandomID.Text);
            QueryData.Instance.Fandom.FandomName = txFandom_FandomName.Text;
            QueryData.Instance.Fandom.Description = txFandom_FandomDescription.Text;

            return true;
        }
        void ClearDataFiled()
        {
            dataGridView_Data.ClearSelection();
      
            QueryData.Instance.Clear();
            isCreateNewRow = true;
            btnApplyAdd.Enabled = true;
            btnApplyDelete.Enabled = false;
            btnApplyEdit.Enabled = false;
            //================CLEAR ARTIST==========
            txArtist_ID.Enabled = false;
            txArtist_ID.Text = "0";
            txArtist_StageName.Text = string.Empty;
            txArtist_RealName.Text = string.Empty;
            comboBox_ArtistGender.SelectedIndex = -1;
            txArtist_BirthPlace.Text = string.Empty;
            txArtist_Description.Text = string.Empty;
            txArtist_Height.Text = string.Empty;
            txArtist_Weight.Text = string.Empty;

            labelArtist_Fandom.Text = string.Empty;

            labelArtist_Label.Text = string.Empty;

            artistImage.Clear();
            pictureBox_ArtistImage.Image = null;
            btnArtist_NextImage.Text = "Ảnh 0/0";
            pictureBox_ArtistImage.Image = ImageFile.SetIconFromFolder("unknow_ArtistImage.png");

            dataGridViewArtist_Group.Rows.Clear();
            dataGridViewArtist_Song.Rows.Clear();
            dataGridViewArtist_Album.Rows.Clear();

            dateTimePickerArtist_Birthday.Value = DateTime.Now;
            dateTimePickerArtist_Debutday.Value = DateTime.Now;

            foreach (Control c in groupBox_Artist_SNS.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
            }
            //================CLEAR GROUP===================
            txGroup_ID.Enabled = false;
            txGroup_ID.Text = "0";
            txGroup_Name.Text = string.Empty;
            txGroup_Description.Text = string.Empty;

            //clear debutday
            dateTimePickerGroup_Debutday.Value = DateTime.Now;

            //Clear label & fandom
            labelGroup_Fandom.Text = string.Empty;
            labelGroup_Label.Text = string.Empty;

            //clear song & album
            dataGridViewGroup_Song.Rows.Clear();
            dataGridViewGroup_Album.Rows.Clear();
            foreach (Control c in groupBox_GroupSNS.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }
            }
            //================CLEAR SONG===================
            txSong_SongID.Enabled = false;
            txSong_SongID.Text = "0";
            txSong_SongName.Text = string.Empty;
            txSong_SongGenre.Text = string.Empty;
            dateTimePickerSong_SongReleaseDay.Value = DateTime.Now;
            txSong_SongProducer.Text = string.Empty;
            txSong_SongDescription.Text = string.Empty;
            //================CLEAR ALBUM===================
            txAlbum_AlbumID.Enabled = false;
            txAlbum_AlbumID.Text = "0";
            txAlbum_AlbumName.Text = string.Empty;
            dateTimePickerAlbum_AlbumReleaseDay.Value = DateTime.Now;
            txAlbum_AlbumDescription.Text = string.Empty;
            dataGridViewAlbum_AlbumSong.Rows.Clear();
            //================CLEAR FANDOM===================
            txFandom_FandomID.Enabled = false;
            txFandom_FandomID.Text = "0";
            txFandom_FandomName.Text = string.Empty;
            txFandom_FandomDescription.Text = string.Empty;
            //================CLEAR LABEL===================
            txLabel_LabelID.Enabled = false;
            txLabel_LabelID.Text = "0";
            txLabel_LabelName.Text = string.Empty;
            txLabel_Founder.Text = string.Empty;
            dateTimePicker_LabelFounded.Value = DateTime.Now;
            txLabel_Location.Text = string.Empty;
            txLabel_Description.Text = string.Empty;
        }
        /// Cách get value trong DataTable
        /// https://stackoverflow.com/questions/13816490/get-cell-value-from-a-datatable-in-c-sharp
        /// <summary>   
        /// (0)Artist - (1)Group - (2)Song - (3)Album - (4)Label - (5)Fandom
        /// </summary>
        List<DataTable> datas = new List<DataTable>()
        {
            DatabaseManager.ShowData(DatabaseTable.Artist, "*"),
            DatabaseManager.ShowData(DatabaseTable.Group, "*"),
            DatabaseManager.ShowData(DatabaseTable.Song, "*"),
            DatabaseManager.ShowData(DatabaseTable.Album, "*"),
            DatabaseManager.ShowData(DatabaseTable.Label, "*"),
            DatabaseManager.ShowData(DatabaseTable.Fandom, "*")
        };
        //==========================================================================================
        //                                    FORM ARTIS                                                      
        //                                                                                          
        //==========================================================================================

        void RefreshData(object sender, FormClosedEventArgs e)
        {
            RefreshDatagridAndInput();
        }
        void RefreshDatagridAndInput()
        {
            switch (tableWantToRefresh)
            {
                case DatabaseTable.Artist:
                    
                    Artist_ChooseRowToEdit();
                    break;
                case DatabaseTable.Group:
                    datas[1] = DatabaseManager.ShowData(DatabaseTable.Group, "*");
                    Group_ChooseRowToEdit();
                    break;
                case DatabaseTable.Song:
                    datas[2] = DatabaseManager.ShowData(DatabaseTable.Song, "*");
                    Song_ChooseRowToEdit();
                    break;
                case DatabaseTable.Album:
                    datas[3] = DatabaseManager.ShowData(DatabaseTable.Album, "*");
                    Album_ChooseRowToEdit();
                    break;
                case DatabaseTable.Label:
                    datas[4] = DatabaseManager.ShowData(DatabaseTable.Label, "*");
                    Label_ChooseRowToEdit();
                    break;
                case DatabaseTable.Fandom:
                    datas[5] = DatabaseManager.ShowData(DatabaseTable.Fandom, "*");
                    Fandom_ChooseRowToEdit();
                    break;
            }
        }
        void Artist_ChooseRowToEdit()
        {
            //txArtist_ID.Enabled = true;
            datas[0] = DatabaseManager.ShowDataQuery("SELECT * FROM [Artist] WHERE IsActivate = 1");
            artistImage.Clear();

            nextImageIndex = 0;
            //AppStatus(true, "đang tải dữ liệu nghệ sĩ...");
            //MessageBox.Show(dataGridView_Data.SelectedRows[0].Index.ToString());
            txArtist_ID.Text = datas[0].Rows[selectedRowFirstIndex].Field<int>("ArtistID").ToString();

            txArtist_StageName.Text = datas[0].Rows[selectedRowFirstIndex].Field<string>("StageName").ToString();
            txArtist_RealName.Text = datas[0].Rows[selectedRowFirstIndex].Field<string>("RealName").ToString();

            int gender;
            if(datas[0].Rows[selectedRowFirstIndex].Field<bool>("Gender"))
            {
                //NAM
                comboBox_ArtistGender.SelectedIndex = 0;
                gender = 1;
            }   
            else
            {
                //NỮ
                comboBox_ArtistGender.SelectedIndex = 1;
                gender = 0;
            }   
            
            // dateTimePicker_Idol_Birthday.Value = (DateTime)dataGridView_DatabaseShow.SelectedRows[0].Cells[8].Value;
            dateTimePickerArtist_Birthday.Value = datas[0].Rows[selectedRowFirstIndex].Field<DateTime>("BirthDay");
            dateTimePickerArtist_Debutday.Value = datas[0].Rows[selectedRowFirstIndex].Field<DateTime>("DebutDay");
           
            txArtist_BirthPlace.Text = datas[0].Rows[selectedRowFirstIndex].Field<string>("BirthPlace");
            txArtist_Description.Text = datas[0].Rows[selectedRowFirstIndex].Field<string>("Description");

            try
            {
                txArtist_Height.Text = Convert.ToDecimal(datas[0].Rows[selectedRowFirstIndex].Field<double>("Height")).ToString("0.00");
            }
            catch
            {
                txArtist_Height.Text = "1,70";
            }
            try
            {
                txArtist_Weight.Text = Convert.ToDecimal(datas[0].Rows[selectedRowFirstIndex].Field<double>("Weight")).ToString("0.00");
            }
            catch
            {
                txArtist_Weight.Text = "50";
            }


            int fandomID = DatabaseManager.ShowDataQuery($"SELECT * FROM [Artist] WHERE ArtistID = {dataGridView_Data.Rows[selectedRowFirstIndex].Cells[0].Value.ToString()}").Rows[0].Field<int>("FandomID");

            DataTable fandom = DatabaseManager.ShowDataQuery($"SELECT * FROM [Fandom] WHERE FandomID = {fandomID.ToString()}");
            if (fandom.Rows.Count > 0)
            {
                labelArtist_Fandom.Text = $"ID: {fandom.Rows[0].Field<int>(0)}\n" +
                $"Tên: {fandom.Rows[0].Field<string>(1)}\n\n" +
                $"{fandom.Rows[0].Field<string>(2)}";
            }
            else
            {
                labelArtist_Fandom.Text = "Không có";
            }
            


            //LABEL
            DataTable label = null;
            try
            {
                label = DatabaseManager.ShowDataQuery($"SELECT * FROM [Label] WHERE LabelID = " +
                $"{DatabaseManager.ShowDataQuery($"SELECT LabelID FROM [Artist] WHERE ArtistID = {datas[0].Rows[selectedRowFirstIndex].Field<int>("ArtistID")}").Rows[0].Field<int>(0)}");

                if(label.Rows[0].Field<int>(0) != 0)
                {
                    labelArtist_Label.Text = $"ID: {label.Rows[0].Field<int>("LabelID")}\nTên: {label.Rows[0].Field<string>("Name")}\n" +
                        $"Thành lập bởi: {label.Rows[0].Field<string>("Founder")}\n" +
                        $"Ngày thành lập: {TimerType.VietnamTimeType((DateTime)label.Rows[0].Field<DateTime>("Founded"))}\n" +
                        $"Địa điểm: {label.Rows[0].Field<string>("Location")}\n\n" +
                        $"{label.Rows[0].Field<string>("Description")}";

                    QueryData.Instance.Artist.Label.LabelID = label.Rows[0].Field<int>("LabelID");
                    QueryData.Instance.Artist.Label.LabelName = label.Rows[0].Field<string>("Name");
                    QueryData.Instance.Artist.Label.Founder = label.Rows[0].Field<string>("Founder");
                    QueryData.Instance.Artist.Label.Founded = (DateTime)label.Rows[0].Field<DateTime>("Founded");
                    QueryData.Instance.Artist.Label.Location = label.Rows[0].Field<string>("Location");
                    QueryData.Instance.Artist.Label.Description = label.Rows[0].Field<string>("Description");
                }    
                else
                {
                    labelArtist_Label.Text = "Không có";
                    QueryData.Instance.Artist.Label.LabelID = 0;
                    QueryData.Instance.Artist.Label.LabelName = string.Empty;
                    QueryData.Instance.Artist.Label.Founder = string.Empty;
                    QueryData.Instance.Artist.Label.Founded = DateTime.Now;
                    QueryData.Instance.Artist.Label.Location = string.Empty;
                    QueryData.Instance.Artist.Label.Description = string.Empty;
                }    
            }
            catch
            {
                labelArtist_Label.Text = "Không có";
                QueryData.Instance.Artist.Label.LabelID = 0;
                QueryData.Instance.Artist.Label.LabelName = string.Empty;
                QueryData.Instance.Artist.Label.Founder = string.Empty;
                QueryData.Instance.Artist.Label.Founded = DateTime.Now;
                QueryData.Instance.Artist.Label.Location = string.Empty;
                QueryData.Instance.Artist.Label.Description = string.Empty;
            }



            //IMAGE
            DataTable image = null;
            try
            {
                image = DatabaseManager.ShowDataStoredProcedure("Artist_GetImage", datas[0].Rows[selectedRowFirstIndex].Field<int>("ArtistID").ToString());
                for (int i = 0; i < image.Rows.Count; i++)
                {
                    //image.Rows[i].Field<Image>("ImageURL")
                    artistImage.Add(image.Rows[i].Field<string>("ImageURL"));
                }

                if (image.Rows.Count > 0)
                {
                    pictureBox_ArtistImageLoadingGIF.Image = ImageFile.SetIconFromFolder("ajax_loadding.gif");
                    pictureBox_ArtistImage.LoadAsync(artistImage[0]);
                    nextImageIndex = 0;
                    btnArtist_NextImage.Font = new Font("Roboto", 10, FontStyle.Bold);
                    btnArtist_NextImage.Text = $"Ảnh {nextImageIndex + 1}/{artistImage.Count}";
                }
                else
                {
                    //pictureBox_ArtistImageLoadingGIF.Image = ImageFile.SetIconFromFolder("ajax_loadding.gif");
                    pictureBox_ArtistImage.Image = ImageFile.SetIconFromFolder("unknow_ArtistImage.png");
                    btnArtist_NextImage.Font = new Font("Roboto", 10, FontStyle.Bold);
                    btnArtist_NextImage.Text = "Ảnh 0/0";
                }
            }
            catch
            {

            }

            //SNS
            DataTable sns = null;
            try
            {
                
                sns = DatabaseManager.ShowDataQuery($"SELECT * FROM [SNS] WHERE SnsID = " +
                 $"{DatabaseManager.ShowDataQuery($"SELECT SnsID FROM [Artist] WHERE ArtistID = {datas[0].Rows[selectedRowFirstIndex].Field<int>("ArtistID")}").Rows[0].Field<int>(0)}");

                tx_Artist_YoutubeURL.Text = sns.Rows[0].Field<string>("youtube");
                tx_Artist_InstagramURL.Text = sns.Rows[0].Field<string>("instagram");
                tx_Artist_FacebookURL.Text = sns.Rows[0].Field<string>("facebook");
                tx_Artist_TwitterURL.Text = sns.Rows[0].Field<string>("twitter");
                tx_Artist_TiktokURL.Text = sns.Rows[0].Field<string>("tiktok");
                tx_Artist_VliveURL.Text = sns.Rows[0].Field<string>("vlive");
                tx_Artist_AppleMusicURL.Text = sns.Rows[0].Field<string>("applemusic");
                tx_Artist_SpotifyURL.Text = sns.Rows[0].Field<string>("spotify");
                tx_Artist_WebsiteURL.Text = sns.Rows[0].Field<string>("website");
            }
            catch
            {
                tx_Artist_YoutubeURL.Text = string.Empty;
                tx_Artist_InstagramURL.Text = string.Empty;
                tx_Artist_FacebookURL.Text = string.Empty;
                tx_Artist_TwitterURL.Text = string.Empty;
                tx_Artist_TiktokURL.Text = string.Empty;
                tx_Artist_VliveURL.Text = string.Empty;
                tx_Artist_AppleMusicURL.Text = string.Empty;
                tx_Artist_SpotifyURL.Text = string.Empty;
                tx_Artist_WebsiteURL.Text = string.Empty;
            }

            //ADD to list
            QueryData.Instance.Artist.ArtistID = Convert.ToInt32(txArtist_ID.Text);
            QueryData.Instance.Artist.StageName = txArtist_StageName.Text;
            QueryData.Instance.Artist.StageName = txArtist_RealName.Text;
            QueryData.Instance.Artist.Gender = gender;
            QueryData.Instance.Artist.BirthDay = dateTimePickerArtist_Birthday.Value;
            QueryData.Instance.Artist.BirthPlace = txArtist_BirthPlace.Text;
            QueryData.Instance.Artist.DebutDay = dateTimePickerArtist_Debutday.Value;
            QueryData.Instance.Artist.Description = txArtist_Description.Text;
            QueryData.Instance.Artist.Fandom.FandomID = fandom.Rows[0].Field<int>(0);

            QueryData.Instance.Artist.Sns.Youtube = tx_Artist_YoutubeURL.Text;
            QueryData.Instance.Artist.Sns.Instagram = tx_Artist_InstagramURL.Text;
            QueryData.Instance.Artist.Sns.Facebook = tx_Artist_FacebookURL.Text;
            QueryData.Instance.Artist.Sns.Twitter = tx_Artist_TwitterURL.Text;
            QueryData.Instance.Artist.Sns.Tiktok = tx_Artist_TiktokURL.Text;
            QueryData.Instance.Artist.Sns.Vlive = tx_Artist_VliveURL.Text;
            QueryData.Instance.Artist.Sns.AppleMusic = tx_Artist_AppleMusicURL.Text;
            QueryData.Instance.Artist.Sns.Spotify = tx_Artist_SpotifyURL.Text;
            QueryData.Instance.Artist.Sns.Website = tx_Artist_WebsiteURL.Text;

            GetArtistGroup();  
            GetArtistSong();
            GetArtistAlbum();
        }
        void GetArtistGroup()
        {
            var group = DatabaseManager.ShowDataStoredProcedure("Artist_GetGroup", QueryData.Instance.Artist.ArtistID.ToString());
            dataGridViewArtist_Group.Rows.Clear();
            for (int i = 0; i < group.Rows.Count; i++)
            {
                bool isContains = false;
                for (int j = 0; j < dataGridViewArtist_Group.Rows.Count; j++)
                {
                    
                    if (group.Rows[i].Field<int>(0) == (int)dataGridViewArtist_Group.Rows[j].Cells[0].Value)
                    {
                        isContains = true;
                    }
                    
                }
                if (!isContains && group.Rows[i].Field<int>(0) != 0)
                {
                    dataGridViewArtist_Group.Rows.Add(
                        group.Rows[i].Field<int>(0),
                        group.Rows[i].Field<string>(1),
                        group.Rows[i].Field<DateTime>(2),
                        group.Rows[i].Field<int>(3),
                        group.Rows[i].Field<string>(4)
                    );
                }
            }
        }
        void GetArtistSong()
        {
            var song = DatabaseManager.ShowDataStoredProcedure("Artist_GetSong", QueryData.Instance.Artist.ArtistID.ToString());
            dataGridViewArtist_Song.Rows.Clear();
            for (int i = 0; i < song.Rows.Count; i++)
            {
                bool isContains = false;
                for (int j = 0; j < dataGridViewArtist_Song.Rows.Count; j++)
                {
                    
                    if (song.Rows[i].Field<int>(0) == (int)dataGridViewArtist_Song.Rows[j].Cells[0].Value)
                    {
                        isContains = true;
                    }
                    
                }
                if (!isContains && song.Rows[i].Field<int>(0) != 0)
                {
                    dataGridViewArtist_Song.Rows.Add(
                        song.Rows[i].Field<int>(0),
                        song.Rows[i].Field<string>(1),
                        song.Rows[i].Field<DateTime>(2),
                        song.Rows[i].Field<string>(3),
                        song.Rows[i].Field<string>(4),
                        song.Rows[i].Field<string>(5)
                    );
                }
            }
        }
        void GetArtistAlbum()
        {
            var album = DatabaseManager.ShowDataStoredProcedure("Artist_GetAlbum", QueryData.Instance.Artist.ArtistID.ToString());
            dataGridViewArtist_Album.Rows.Clear();
            for (int i = 0; i < album.Rows.Count; i++)
            {
                bool isContains = false;
                for (int j = 0; j < dataGridViewArtist_Album.Rows.Count; j++)
                {

                    if (album.Rows[i].Field<int>(0) == (int)dataGridViewArtist_Album.Rows[j].Cells[0].Value)
                    {
                        isContains = true;
                    }

                }
                if (!isContains && album.Rows[i].Field<int>(0) != 0)
                {
                    dataGridViewArtist_Album.Rows.Add(
                        album.Rows[i].Field<int>(0),
                        album.Rows[i].Field<string>(1),
                        album.Rows[i].Field<DateTime>(2),
                        album.Rows[i].Field<string>(3)
                    );
                }
            }
        }
        //====================================================
        void Group_ChooseRowToEdit()
        {
            //txGroup_ID.Enabled = true;
            datas[1] = DatabaseManager.ShowDataQuery("SELECT * FROM [Group] WHERE IsActivate = 1");

            txGroup_ID.Text = datas[1].Rows[selectedRowFirstIndex].Field<int>("GroupID").ToString();
            txGroup_Name.Text = datas[1].Rows[selectedRowFirstIndex].Field<string>("Name").ToString();
            dateTimePickerGroup_Debutday.Value = datas[1].Rows[selectedRowFirstIndex].Field<DateTime>("DebutDay");
            txGroup_Description.Text = datas[1].Rows[selectedRowFirstIndex].Field<string>("Description").ToString();

            //Fandom
            int fandomID = DatabaseManager.ShowDataQuery($"SELECT * FROM [Group] WHERE GroupID = {dataGridView_Data.Rows[selectedRowFirstIndex].Cells[0].Value.ToString()}").Rows[0].Field<int>("FandomID");

            DataTable fandom = DatabaseManager.ShowDataQuery($"SELECT * FROM [Fandom] WHERE FandomID = {fandomID.ToString()}");
            if (fandom.Rows.Count > 0)
            {
                labelGroup_Fandom.Text = $"ID: {fandom.Rows[0].Field<int>(0)}\n" +
                $"Tên: {fandom.Rows[0].Field<string>(1)}\n\n" +
                $"{fandom.Rows[0].Field<string>(2)}";
            }
            else
            {
                labelGroup_Fandom.Text = "Không có";
            }

            //LABEL
            DataTable label = null;
            try
            {
                int labelID = DatabaseManager.ShowDataQuery($"SELECT LabelID FROM [Group] WHERE GroupID = {datas[1].Rows[selectedRowFirstIndex].Field<int>("GroupID")}").Rows[0].Field<int>(0);

                label = DatabaseManager.ShowDataQuery($"SELECT * FROM [Label] WHERE LabelID = {labelID}");

                if (label.Rows[0].Field<int>(0) != 0)
                {
                    labelGroup_Label.Text = $"ID: {label.Rows[0].Field<int>("LabelID")}\nTên: {label.Rows[0].Field<string>("Name")}\n" +
                        $"Thành lập bởi: {label.Rows[0].Field<string>("Founder")}\n" +
                        $"Ngày thành lập: {TimerType.VietnamTimeType((DateTime)label.Rows[0].Field<DateTime>("Founded"))}\n" +
                        $"Địa điểm: {label.Rows[0].Field<string>("Location")}\n\n" +
                        $"{label.Rows[0].Field<string>("Description")}";

                    QueryData.Instance.Group.Label.LabelID = label.Rows[0].Field<int>("LabelID");
                    QueryData.Instance.Group.Label.LabelName = label.Rows[0].Field<string>("Name");
                    QueryData.Instance.Group.Label.Founder = label.Rows[0].Field<string>("Founder");
                    QueryData.Instance.Group.Label.Founded = (DateTime)label.Rows[0].Field<DateTime>("Founded");
                    QueryData.Instance.Group.Label.Location = label.Rows[0].Field<string>("Location");
                    QueryData.Instance.Group.Label.Description = label.Rows[0].Field<string>("Description");
                }
                else
                {
                    labelGroup_Label.Text = "Không có";
                    QueryData.Instance.Group.Label.LabelID = 0;
                    QueryData.Instance.Group.Label.LabelName = string.Empty;
                    QueryData.Instance.Group.Label.Founder = string.Empty;
                    QueryData.Instance.Group.Label.Founded = DateTime.Now;
                    QueryData.Instance.Group.Label.Location = string.Empty;
                    QueryData.Instance.Group.Label.Description = string.Empty;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                labelGroup_Label.Text = "Không có";
                QueryData.Instance.Group.Label.LabelID = 0;
                QueryData.Instance.Group.Label.LabelName = string.Empty;
                QueryData.Instance.Group.Label.Founder = string.Empty;
                QueryData.Instance.Group.Label.Founded = DateTime.Now;
                QueryData.Instance.Group.Label.Location = string.Empty;
                QueryData.Instance.Group.Label.Description = string.Empty;
            }

            //SNS
            DataTable sns = null;
            try
            {
                int snsID = DatabaseManager.ShowDataQuery($"SELECT SnsID FROM [Group] WHERE GroupID = {datas[1].Rows[selectedRowFirstIndex].Field<int>("GroupID")}").Rows[0].Field<int>(0);
                sns = DatabaseManager.ShowDataQuery($"SELECT * FROM [SNS] WHERE SnsID = {snsID}");

                tx_Group_YoutubeURL.Text = sns.Rows[0].Field<string>("youtube");
                tx_Group_InstagramURL.Text = sns.Rows[0].Field<string>("instagram");
                tx_Group_FacebookURL.Text = sns.Rows[0].Field<string>("facebook");
                tx_Group_TwitterURL.Text = sns.Rows[0].Field<string>("twitter");
                tx_Group_TiktokURL.Text = sns.Rows[0].Field<string>("tiktok");
                tx_Group_VliveURL.Text = sns.Rows[0].Field<string>("vlive");
                tx_Group_AppleMusicURL.Text = sns.Rows[0].Field<string>("applemusic");
                tx_Group_SpotifyURL.Text = sns.Rows[0].Field<string>("spotify");
                tx_Group_WebsiteURL.Text = sns.Rows[0].Field<string>("website");
            }
            catch
            {
                tx_Group_YoutubeURL.Text = string.Empty;
                tx_Group_InstagramURL.Text = string.Empty;
                tx_Group_FacebookURL.Text = string.Empty;
                tx_Group_TwitterURL.Text = string.Empty;
                tx_Group_TiktokURL.Text = string.Empty;
                tx_Group_VliveURL.Text = string.Empty;
                tx_Group_AppleMusicURL.Text = string.Empty;
                tx_Group_SpotifyURL.Text = string.Empty;
                tx_Group_WebsiteURL.Text = string.Empty;
            }

            //ADD to list
            QueryData.Instance.Group.GroupID = Convert.ToInt32(txGroup_ID.Text);
            QueryData.Instance.Group.GroupName = txGroup_Name.Text;
            QueryData.Instance.Group.DebutDay = dateTimePickerGroup_Debutday.Value;
            QueryData.Instance.Group.Description = txGroup_Description.Text;
            QueryData.Instance.Group.Fandom.FandomID = fandom.Rows[0].Field<int>(0);

            QueryData.Instance.Group.Sns.Youtube = tx_Group_YoutubeURL.Text;
            QueryData.Instance.Group.Sns.Instagram = tx_Group_InstagramURL.Text;
            QueryData.Instance.Group.Sns.Facebook = tx_Group_FacebookURL.Text;
            QueryData.Instance.Group.Sns.Twitter = tx_Group_TwitterURL.Text;
            QueryData.Instance.Group.Sns.Tiktok = tx_Group_TiktokURL.Text;
            QueryData.Instance.Group.Sns.Vlive = tx_Group_VliveURL.Text;
            QueryData.Instance.Group.Sns.AppleMusic = tx_Group_AppleMusicURL.Text;
            QueryData.Instance.Group.Sns.Spotify = tx_Group_SpotifyURL.Text;
            QueryData.Instance.Group.Sns.Website = tx_Group_WebsiteURL.Text;

            GetGroupSong();
            GetGroupAlbum();
        }
        void GetGroupSong()
        {
            var song = DatabaseManager.ShowDataStoredProcedure("Group_GetSong", QueryData.Instance.Group.GroupID.ToString());
            dataGridViewGroup_Song.Rows.Clear();
            for (int i = 0; i < song.Rows.Count; i++)
            {
                bool isContains = false;
                for (int j = 0; j < dataGridViewGroup_Song.Rows.Count; j++)
                {

                    if (song.Rows[i].Field<int>(0) == (int)dataGridViewGroup_Song.Rows[j].Cells[0].Value)
                    {
                        isContains = true;
                    }

                }
                if (!isContains && song.Rows[i].Field<int>(0) != 0)
                {
                    dataGridViewGroup_Song.Rows.Add(
                        song.Rows[i].Field<int>(0),
                        song.Rows[i].Field<string>(1),
                        song.Rows[i].Field<DateTime>(2),
                        song.Rows[i].Field<string>(3),
                        song.Rows[i].Field<string>(4),
                        song.Rows[i].Field<string>(5)
                    );
                }
            }
        }
        void GetGroupAlbum()
        {
            var album = DatabaseManager.ShowDataStoredProcedure("Group_GetAlbum", QueryData.Instance.Group.GroupID.ToString());
            dataGridViewGroup_Album.Rows.Clear();
            for (int i = 0; i < album.Rows.Count; i++)
            {
                bool isContains = false;
                for (int j = 0; j < dataGridViewGroup_Album.Rows.Count; j++)
                {

                    if (album.Rows[i].Field<int>(0) == (int)dataGridViewGroup_Album.Rows[j].Cells[0].Value)
                    {
                        isContains = true;
                    }

                }
                if (!isContains && album.Rows[i].Field<int>(0) != 0)
                {
                    dataGridViewGroup_Album.Rows.Add(
                        album.Rows[i].Field<int>(0),
                        album.Rows[i].Field<string>(1),
                        album.Rows[i].Field<DateTime>(2),
                        album.Rows[i].Field<string>(3)
                    );
                }
            }
        }
        int nextImageIndex = 1;
        public static List<string> artistImage = new List<string>();
        private void btnArtist_NextImage_Click(object sender, EventArgs e)
        {
            if (artistImage.Count < 1) return;

            nextImageIndex++;
            if (nextImageIndex >= artistImage.Count) nextImageIndex = 0;

            if (artistImage.Count > 0)
            {
                btnArtist_NextImage.Text = $"Ảnh {nextImageIndex + 1}/{artistImage.Count}";
                pictureBox_ArtistImageLoadingGIF.Image = ImageFile.SetIconFromFolder("ajax_loadding.gif");
                pictureBox_ArtistImage.LoadAsync(artistImage[nextImageIndex]);
            }
            else
            {
                btnArtist_NextImage.Text = $"Ảnh 0/0";
            }

        }
        //=====================ARTIST BTN===============================
        private void btnArtist_EditImage_Click(object sender, EventArgs e)
        {
            Intermediary_Image intermediary_Image = new Intermediary_Image();
            intermediary_Image.Closed += (s, args) => ReloadArtistImage();
            intermediary_Image.ShowDialog();
        }
        private void buttonArtist_EditGroup_Click(object sender, EventArgs e)
        {
            Intermediary_Group intermediary_Group = new Intermediary_Group();
            intermediary_Group.Closed += (s, args) => RealoadArtistGroup();
            intermediary_Group.ShowDialog();
        }

        private void buttonArtist_EditFandom_Click(object sender, EventArgs e)
        {
            Intermediary_Fandom intermediary_Fandom = new Intermediary_Fandom();
            intermediary_Fandom.Closed += (s, args) => RealoadArtistFandom();
            intermediary_Fandom.ShowDialog();
        }

        private void buttonArtist_EditSong_Click(object sender, EventArgs e)
        {
            Intermediary_Song intermediary_Song = new Intermediary_Song();
            intermediary_Song.Closed += (s, args) => RealoadArtistSong();
            intermediary_Song.ShowDialog();
        }

        private void buttonArtist_EditAlbum_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Album sẽ tự được thêm vào hoặc xóa đi theo ràng buộc của bài hát thuộc album.");
        }

        private void buttonArtist_EditLabel_Click(object sender, EventArgs e)
        {
            Intermediary_Label intermediary_Label = new Intermediary_Label();
            intermediary_Label.Closed += (s, args) => RealoadArtistLabel();
            
            intermediary_Label.ShowDialog();
        }
        private void MenuStrip_ShowArtistTableTrash_Click(object sender, EventArgs e)
        {
            TrashTable trashTable = new TrashTable();
            trashTable.Closed += (s, args) => ReloadArtistData();
            trashTable.ShowDialog();
        }
        void ReloadArtistData()
        {
            ClearDataFiled();
            ShowData(DatabaseTable.Artist);
        }
        void ReloadArtistImage()
        {
            nextImageIndex = 0;
            if (QueryData.Instance.Artist.ArtistImage_Add.Count < 1)
            {
                if (QueryData.Instance.Artist.ArtistID == 0)
                {
                    artistImage.Clear();
                }
                //if (groupID == 0)
                //{

                //}
            }
            if (artistImage.Count > 0)
            {
                btnArtist_NextImage.Text = $"Ảnh {nextImageIndex + 1}/{artistImage.Count}";
                pictureBox_ArtistImageLoadingGIF.Image = ImageFile.SetIconFromFolder("ajax_loadding.gif");
                pictureBox_ArtistImage.LoadAsync(artistImage[nextImageIndex]);
            }
            else
            {
                btnArtist_NextImage.Text = $"Ảnh 0/0";
                pictureBox_ArtistImage.Image = ImageFile.SetIconFromFolder("unknow_ArtistImage.png");
            }
        }
        void RealoadArtistGroup()
        {
            dataGridViewArtist_Group.Rows.Clear();
            GetArtistGroup();
            for (int i = 0; i < QueryData.Instance.Artist.ArtistGroup_Add.Count; i++)
            {                  
                if(dataGridViewArtist_Group.Rows.Count < 1)
                {
                    dataGridViewArtist_Group.Rows.Add(
                            QueryData.Instance.Artist.ArtistGroup_Add[i].GroupID,
                            QueryData.Instance.Artist.ArtistGroup_Add[i].GroupName,
                            QueryData.Instance.Artist.ArtistGroup_Add[i].DebutDay,
                            QueryData.Instance.Artist.ArtistGroup_Add[i].Fandom.FandomID,
                            QueryData.Instance.Artist.ArtistGroup_Add[i].Description
                        );
                }  
                else
                {
                    bool isContains = false;
                    for (int j = 0; j < dataGridViewArtist_Group.Rows.Count; j++)
                    {
                        
                        if (QueryData.Instance.Artist.ArtistGroup_Add[i].GroupID == (int)dataGridViewArtist_Group.Rows[j].Cells[0].Value)
                        {
                            isContains = true;
                        }
                          
                    }
                    if (!isContains)
                    {
                        dataGridViewArtist_Group.Rows.Add(
                            QueryData.Instance.Artist.ArtistGroup_Add[i].GroupID,
                            QueryData.Instance.Artist.ArtistGroup_Add[i].GroupName,
                            QueryData.Instance.Artist.ArtistGroup_Add[i].DebutDay,
                            QueryData.Instance.Artist.ArtistGroup_Add[i].Fandom.FandomID,
                            QueryData.Instance.Artist.ArtistGroup_Add[i].Description
                        );
                    }
                }    
            }
            for (int i = 0; i < QueryData.Instance.Artist.ArtistGroup_Delete.Count; i++)
            {
                for (int j = 0; j < dataGridViewArtist_Group.Rows.Count; j++)
                {
                    if (QueryData.Instance.Artist.ArtistGroup_Delete[i].GroupID == (int)dataGridViewArtist_Group.Rows[j].Cells[0].Value)
                    {
                        dataGridViewArtist_Group.Rows.RemoveAt(j);
                    }
                }

            }        
        }
        void RealoadArtistFandom()
        {
            if(QueryData.Instance.Artist.Fandom.FandomID != 0)
            {
                labelArtist_Fandom.Text =
                $"ID: {QueryData.Instance.Artist.Fandom.FandomID}\n" +
                    $"Tên: {QueryData.Instance.Artist.Fandom.FandomName}\n\n" +
                    $"{QueryData.Instance.Artist.Fandom.Description}";
            }    
            else
            {
                labelArtist_Fandom.Text = "Không có fandom";
            }    
        }
        void RealoadArtistSong()
        {
            dataGridViewArtist_Song.Rows.Clear();
            GetArtistSong();
            for (int i = 0; i < QueryData.Instance.Artist.ArtistSong_Add.Count; i++)
            {
                bool isContains = false;
                for (int j = 0; j < dataGridViewArtist_Song.Rows.Count; j++)
                {

                    if (QueryData.Instance.Artist.ArtistSong_Add[i].SongID == (int)dataGridViewArtist_Song.Rows[j].Cells[0].Value)
                    {
                        isContains = true;
                    }

                }
                if (!isContains)
                {
                    dataGridViewArtist_Song.Rows.Add(
                        QueryData.Instance.Artist.ArtistSong_Add[i].SongID,
                        QueryData.Instance.Artist.ArtistSong_Add[i].SongName,
                        QueryData.Instance.Artist.ArtistSong_Add[i].ReleaseDay,
                        QueryData.Instance.Artist.ArtistSong_Add[i].Genre,
                        QueryData.Instance.Artist.ArtistSong_Add[i].Producer,
                        QueryData.Instance.Artist.ArtistSong_Add[i].Description
                    );
                }
            }
            //MessageBox.Show(QueryData.Instance.Artist.ArtistSong_Delete.Count.ToString());
            for (int i = 0; i < QueryData.Instance.Artist.ArtistSong_Delete.Count; i++)
            {
                for (int j = 0; j < dataGridViewArtist_Song.Rows.Count; j++)
                {
                    if (QueryData.Instance.Artist.ArtistSong_Delete[i].SongID == (int)dataGridViewArtist_Song.Rows[j].Cells[0].Value)
                    {
                        dataGridViewArtist_Song.Rows.RemoveAt(j);
                    }
                } 
            }
        }
        void RealoadArtistLabel()
        {
            if (QueryData.Instance.Artist.Label.LabelID != 0)
            {
                labelArtist_Label.Text =
                $"ID: {QueryData.Instance.Artist.Label.LabelID}\n" +
                    $"Tên: {QueryData.Instance.Artist.Label.LabelName}\n" +
                    $"Người t.lập: {QueryData.Instance.Artist.Label.Founder}\n" +
                    $"Ngày lập: {TimerType.VietnamTimeType((DateTime)QueryData.Instance.Artist.Label.Founded)}\n" +
                    $"Địa điểm: {QueryData.Instance.Artist.Label.Location}\n\n" +
                    $"{QueryData.Instance.Artist.Label.Description}";
            }
            else
            {
                labelArtist_Label.Text = "Không có công ty";
            }
        }
        //=========================GROUP==========================\\
        //=========================GROUP BTN==========================
        private void btnGroup_EditFandom_Click(object sender, EventArgs e)
        {
            Intermediary_Fandom intermediary_Fandom = new Intermediary_Fandom();
            intermediary_Fandom.Closed += (s, args) => RealoadGroupFandom();
            intermediary_Fandom.Show();
        }

        private void btnGroup_EditSong_Click(object sender, EventArgs e)
        {
            Intermediary_Song intermediary_Song = new Intermediary_Song();
            intermediary_Song.Closed += (s, args) => RealoadGroupSong();
            intermediary_Song.Show();
        }

        private void btnGroup_EditAlbum_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Album sẽ tự được thêm vào hoặc xóa đi theo ràng buộc của bài hát thuộc album.");
        }

        private void btnGroup_EditLabel_Click(object sender, EventArgs e)
        {
            Intermediary_Label intermediary_Label = new Intermediary_Label();
            intermediary_Label.Closed += (s, args) => RealoadGroupLabel();
            intermediary_Label.Show();
        }
        void RealoadGroupFandom()
        {
            if (QueryData.Instance.Group.Fandom.FandomID != 0)
            {
                labelGroup_Fandom.Text =
                $"ID: {QueryData.Instance.Group.Fandom.FandomID}\n" +
                    $"Tên: {QueryData.Instance.Group.Fandom.FandomName}\n\n" +
                    $"{QueryData.Instance.Group.Fandom.Description}";
            }
            else
            {
                labelGroup_Fandom.Text = "Không có fandom";
            }
        }
        void RealoadGroupSong()
        {
            dataGridViewGroup_Song.Rows.Clear();
            GetGroupSong();
            for (int i = 0; i < QueryData.Instance.Group.GroupSong_Add.Count; i++)
            {
                bool isContains = false;
                for (int j = 0; j < dataGridViewGroup_Song.Rows.Count; j++)
                {

                    if (QueryData.Instance.Group.GroupSong_Add[i].SongID == (int)dataGridViewGroup_Song.Rows[j].Cells[0].Value)
                    {
                        isContains = true;
                    }

                }
                if (!isContains)
                {
                    dataGridViewGroup_Song.Rows.Add(
                        QueryData.Instance.Group.GroupSong_Add[i].SongID,
                        QueryData.Instance.Group.GroupSong_Add[i].SongName,
                        QueryData.Instance.Group.GroupSong_Add[i].ReleaseDay,
                        QueryData.Instance.Group.GroupSong_Add[i].Genre,
                        QueryData.Instance.Group.GroupSong_Add[i].Producer,
                        QueryData.Instance.Group.GroupSong_Add[i].Description
                    );
                }
            }
            MessageBox.Show(QueryData.Instance.Group.GroupSong_Delete.Count.ToString());
            for (int i = 0; i < QueryData.Instance.Group.GroupSong_Delete.Count; i++)
            {
                for (int j = 0; j < dataGridViewGroup_Song.Rows.Count; j++)
                {
                    if (QueryData.Instance.Group.GroupSong_Delete[i].SongID == (int)dataGridViewGroup_Song.Rows[j].Cells[0].Value)
                    {
                        dataGridViewGroup_Song.Rows.RemoveAt(j);
                    }
                }
            }
        }
        void RealoadGroupLabel()
        {
            if (QueryData.Instance.Group.Label.LabelID != 0)
            {
                labelGroup_Label.Text =
                $"ID: {QueryData.Instance.Group.Label.LabelID}\n" +
                    $"Tên: {QueryData.Instance.Group.Label.LabelName}\n" +
                    $"Người t.lập: {QueryData.Instance.Group.Label.Founder}\n" +
                    $"Ngày lập: {TimerType.VietnamTimeType((DateTime)QueryData.Instance.Group.Label.Founded)}\n" +
                    $"Địa điểm: {QueryData.Instance.Group.Label.Location}\n\n" +
                    $"{QueryData.Instance.Group.Label.Description}";
            }
            else
            {
                labelGroup_Label.Text = "Không có công ty";
            }
        }
        //=====================================ALBUM===================================

        private void btnAlbum_EditSong_Click(object sender, EventArgs e)
        {
            Intermediary_Song intermediary_Song = new Intermediary_Song();
            intermediary_Song.Closed += (s, args) => RealoadAlbumSong();
            intermediary_Song.Show();
        }
        void RealoadAlbumSong()
        {
            dataGridViewAlbum_AlbumSong.Rows.Clear();
            GetAlbumSong();
            for (int i = 0; i < QueryData.Instance.Album.AlbumSong_Add.Count; i++)
            {
                bool isContains = false;
                for (int j = 0; j < dataGridViewAlbum_AlbumSong.Rows.Count; j++)
                {

                    if (QueryData.Instance.Album.AlbumSong_Add[i].SongID == (int)dataGridViewAlbum_AlbumSong.Rows[j].Cells[0].Value)
                    {
                        isContains = true;
                    }

                }
                if (!isContains)
                {
                    dataGridViewAlbum_AlbumSong.Rows.Add(
                        QueryData.Instance.Album.AlbumSong_Add[i].SongID,
                        QueryData.Instance.Album.AlbumSong_Add[i].SongName,
                        QueryData.Instance.Album.AlbumSong_Add[i].ReleaseDay,
                        QueryData.Instance.Album.AlbumSong_Add[i].Genre,
                        QueryData.Instance.Album.AlbumSong_Add[i].Producer,
                        QueryData.Instance.Album.AlbumSong_Add[i].Description
                    );
                }
            }
            MessageBox.Show(QueryData.Instance.Album.AlbumSong_Delete.Count.ToString());
            for (int i = 0; i < QueryData.Instance.Album.AlbumSong_Delete.Count; i++)
            {
                for (int j = 0; j < dataGridViewAlbum_AlbumSong.Rows.Count; j++)
                {
                    if (QueryData.Instance.Album.AlbumSong_Delete[i].SongID == (int)dataGridViewAlbum_AlbumSong.Rows[j].Cells[0].Value)
                    {
                        dataGridViewAlbum_AlbumSong.Rows.RemoveAt(j);
                    }
                }
            }
        }
        void Song_ChooseRowToEdit()
        {
            //txSong_SongID.Enabled = true;
            datas[2] = DatabaseManager.ShowDataQuery("SELECT * FROM [Song] WHERE SongID <> 0");

            txSong_SongID.Text = datas[2].Rows[selectedRowFirstIndex].Field<int>("SongID").ToString();
            txSong_SongName.Text = datas[2].Rows[selectedRowFirstIndex].Field<string>("Name");
            dateTimePickerSong_SongReleaseDay.Value = datas[2].Rows[selectedRowFirstIndex].Field<DateTime>("ReleaseDay");

            if(datas[2].Rows[selectedRowFirstIndex].Field<string>("Genre") != null)
            {
                txSong_SongGenre.Text = datas[2].Rows[selectedRowFirstIndex].Field<string>("Genre");
            }    
            else
            {
                txSong_SongGenre.Text = string.Empty;
            }

            if (datas[2].Rows[selectedRowFirstIndex].Field<string>("Producer") != null)
            {
                txSong_SongProducer.Text = datas[2].Rows[selectedRowFirstIndex].Field<string>("Producer");
            }
            else
            {
                txSong_SongProducer.Text = string.Empty;
            }

            if (datas[2].Rows[selectedRowFirstIndex].Field<string>("Description") != null)
            {
                txSong_SongDescription.Text = datas[2].Rows[selectedRowFirstIndex].Field<string>("Description");
            }
            else
            {
                txSong_SongDescription.Text = string.Empty;
            }
        }
        void Album_ChooseRowToEdit()
        {
            datas[3] = DatabaseManager.ShowDataQuery("SELECT * FROM [Album] WHERE AlbumID <> 0");
            txAlbum_AlbumID.Text = datas[3].Rows[selectedRowFirstIndex].Field<int>("AlbumID").ToString();
            txAlbum_AlbumName.Text = datas[3].Rows[selectedRowFirstIndex].Field<string>("Name");
            dateTimePickerAlbum_AlbumReleaseDay.Value = datas[3].Rows[selectedRowFirstIndex].Field<DateTime>("ReleaseDay");
            if (datas[3].Rows[selectedRowFirstIndex].Field<string>("Description") != null)
            {
                txAlbum_AlbumDescription.Text = datas[3].Rows[selectedRowFirstIndex].Field<string>("Description");
            }
            else
            {
                txAlbum_AlbumDescription.Text = string.Empty;
            }
            QueryData.Instance.Album.AlbumID = Convert.ToInt32(txAlbum_AlbumID.Text);
            QueryData.Instance.Album.AlbumName = txAlbum_AlbumName.Text;
            QueryData.Instance.Album.ReleaseDay = dateTimePickerAlbum_AlbumReleaseDay.Value;
            QueryData.Instance.Album.Description = txAlbum_AlbumDescription.Text;

            GetAlbumSong();
        }
        void GetAlbumSong()
        {
            var song = DatabaseManager.ShowDataStoredProcedure("Album_GetSong", QueryData.Instance.Album.AlbumID.ToString());
            dataGridViewAlbum_AlbumSong.Rows.Clear();
            for (int i = 0; i < song.Rows.Count; i++)
            {
                bool isContains = false;
                for (int j = 0; j < dataGridViewAlbum_AlbumSong.Rows.Count; j++)
                {

                    if (song.Rows[i].Field<int>(0) == (int)dataGridViewAlbum_AlbumSong.Rows[j].Cells[0].Value)
                    {
                        isContains = true;
                    }

                }
                if (!isContains && song.Rows[i].Field<int>(0) != 0)
                {
                    dataGridViewAlbum_AlbumSong.Rows.Add(
                        song.Rows[i].Field<int>(0),
                        song.Rows[i].Field<string>(1),
                        song.Rows[i].Field<DateTime>(2),
                        song.Rows[i].Field<string>(3),
                        song.Rows[i].Field<string>(4),
                        song.Rows[i].Field<string>(5)
                    );
                }
            }
        }
        void Label_ChooseRowToEdit()
        {
            //txLabel_LabelID.Enabled = true;
            datas[4] = DatabaseManager.ShowDataQuery("SELECT * FROM [Label] WHERE LabelID <> 0");

            txLabel_LabelID.Text = datas[4].Rows[selectedRowFirstIndex].Field<int>("LabelID").ToString();
            txLabel_LabelName.Text = datas[4].Rows[selectedRowFirstIndex].Field<string>("Name");
            txLabel_Founder.Text = datas[4].Rows[selectedRowFirstIndex].Field<string>("Founder");
            dateTimePicker_LabelFounded.Value = datas[4].Rows[selectedRowFirstIndex].Field<DateTime>("Founded");
            
            if(datas[4].Rows[selectedRowFirstIndex].Field<string>("Location") != null)
            {
                txLabel_Location.Text = datas[4].Rows[selectedRowFirstIndex].Field<string>("Location");
            }    
            else
            {
                txLabel_Location.Text = string.Empty;
            }
            if (datas[4].Rows[selectedRowFirstIndex].Field<string>("Description") != null)
            {
                txLabel_Description.Text = datas[4].Rows[selectedRowFirstIndex].Field<string>("Description");
            }
            else
            {
                txLabel_Description.Text = string.Empty;
            }

            //ADD to list
            QueryData.Instance.Label.LabelID = Convert.ToInt32(txLabel_LabelID.Text);
            QueryData.Instance.Label.LabelName = txLabel_LabelName.Text;
            QueryData.Instance.Label.Founder = txLabel_Founder.Text;
            QueryData.Instance.Label.Founded = dateTimePicker_LabelFounded.Value;
            QueryData.Instance.Label.Location = txLabel_Location.Text;
            QueryData.Instance.Label.Description = txLabel_Description.Text;
        }
        void Fandom_ChooseRowToEdit()
        {
            txFandom_FandomID.Enabled = true;
            datas[5] = DatabaseManager.ShowDataQuery("SELECT * FROM [Fandom] WHERE FandomID <> 0");

            txFandom_FandomID.Text = datas[5].Rows[selectedRowFirstIndex].Field<int>("FandomID").ToString();
            txFandom_FandomName.Text = datas[5].Rows[selectedRowFirstIndex].Field<string>("Name");
            if (datas[5].Rows[selectedRowFirstIndex].Field<string>("Description") != null)
            {
                txFandom_FandomDescription.Text = datas[5].Rows[selectedRowFirstIndex].Field<string>("Description");
            }    
            else
            {
                txFandom_FandomDescription.Text = string.Empty;
            }

            //ADD to list
            QueryData.Instance.Fandom.FandomID = Convert.ToInt32(txFandom_FandomID.Text);
            QueryData.Instance.Fandom.FandomName = txFandom_FandomName.Text;
            QueryData.Instance.Fandom.Description = txFandom_FandomDescription.Text;
        }
        void AppStatus(bool open, string message = "")
        {
            if (open)
            {
                label_AppStatus.Visible = true;
                label_AppStatus.Text = message;

                pictureBox_LoadingGIF.Visible = true;

            }
            else
            {
                label_AppStatus.Visible = false;

                pictureBox_LoadingGIF.Visible = false;
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
/*_.-/`)
         // / / )
      .=// / / / )
     //`/ / / / /
     // /     ` /
   ||         /
    \\       /
     ))    .'
         //    /
         /
         */