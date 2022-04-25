﻿/*
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
            base.WndProc(ref m);
        }
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
            panel_DataContent.MaximumSize = new Size(this.Width - 150, panel_DataContent.Height);

            #region Artist Manage
            panel_ArtistManager.MinimumSize = new Size(200, 200);
            panel_ArtistManager.MaximumSize = new Size(this.Width - 150, panel_ArtistManager.Height);

            //group
            DatagridViewStyle.DarkStyle(dataGridViewArtist_Group);

            ////Song       
            DatagridViewStyle.DarkStyle(dataGridViewArtist_Song);

            //Album
            DatagridViewStyle.DarkStyle(dataGridViewArtist_Album);

            //Sns
            DatagridViewStyle.DarkStyle(dataGridViewArtist_SNS);

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

            //label in artist
            labelArtist_Fandom.MaximumSize = new Size(panel_ArtistInforFandom.Width - (panel_ArtistInforFandom.Width*10/100), 0);
            labelArtist_Fandom.AutoSize = true;
            labelArtist_Label.MaximumSize = new Size(panel_ArtistInforLabel.Width - (panel_ArtistInforLabel.Width * 10 / 100), 0);
            labelArtist_Label.AutoSize = true;

            groupBox1.Paint += PaintBorderlessGroupBox;
            groupBox2.Paint += PaintBorderlessGroupBox;
            groupBox3.Paint += PaintBorderlessGroupBox;
            groupBox4.Paint += PaintBorderlessGroupBox;
            groupBox5.Paint += PaintBorderlessGroupBox;
            groupBox6.Paint += PaintBorderlessGroupBox;
            groupBox7.Paint += PaintBorderlessGroupBox;
            groupBox8.Paint += PaintBorderlessGroupBox;
            groupBox9.Paint += PaintBorderlessGroupBox;
            groupBox10.Paint += PaintBorderlessGroupBox;
            groupBox11.Paint += PaintBorderlessGroupBox;
            groupBox12.Paint += PaintBorderlessGroupBox;
            groupBox13.Paint += PaintBorderlessGroupBox;
            groupBox14.Paint += PaintBorderlessGroupBox;
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
            //label in artist
            labelArtist_Fandom.MaximumSize = new Size(panel_ArtistInforFandom.Width - (panel_ArtistInforFandom.Width * 10 / 100), 0);
            labelArtist_Fandom.AutoSize = true;
            labelArtist_Label.MaximumSize = new Size(panel_ArtistInforLabel.Width - (panel_ArtistInforLabel.Width * 10 / 100), 0);
            labelArtist_Label.AutoSize = true;
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
            }
            isCreateNewRow = false;
            btnApplyAdd.Enabled = false;
            btnApplyDelete.Enabled = true;
            btnApplyEdit.Enabled = true;
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
        DatabaseTable tableWantToRefresh;
        /// <summary>
        /// Lưu trữ 5 panel ở phần manger như panel_ArtistManager....
        /// </summary>
        Panel[] tableManagePanel = new Panel[5];
        public frmApp(string userName, string fullName)
        {
            InitializeComponent();
            this.fullName = fullName;
            this.userName = userName;
        }

        private void frmApp_Load(object sender, EventArgs e)
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
            ShowData(DatabaseTable.Artist);
        }

        private void MenuStrip_ShowGroupTable_Click(object sender, EventArgs e)
        {
            ShowData(DatabaseTable.Group);
        }

        private void MenuStrip_ShowSongTable_Click(object sender, EventArgs e)
        {
            ShowData(DatabaseTable.Song);
        }

        private void MenuStrip_ShowAlbumTable_Click(object sender, EventArgs e)
        {
            ShowData(DatabaseTable.Album);
        }

        private void MenuStrip_ShowLabelTable_Click(object sender, EventArgs e)
        {
            ShowData(DatabaseTable.Label);
        }

        void ShowData(DatabaseTable databaseTable)
        {
            QueryData.Instance.Clear();
            panel_ArtistManager.Visible = false;
            panel_GroupManager.Visible = false;
            panel_SongManager.Visible = false;
            panel_AlbumManager.Visible = false;
            panel_LabelManager.Visible = false;

            switch (databaseTable)
            {
                case DatabaseTable.Artist:
                    dataGridView_Data.DataSource = DatabaseManager.ShowDataStoredProcedure("Artist_Basic_Infor");
                    currentTable = DatabaseTable.Artist;
                    panel_ArtistManager.Visible = true;
                    break;
                case DatabaseTable.Group:
                    dataGridView_Data.DataSource = DatabaseManager.ShowDataStoredProcedure("Group_Basic_Infor");
                    currentTable = DatabaseTable.Group;
                    panel_GroupManager.Visible = true;
                    break;
                case DatabaseTable.Song:
                    dataGridView_Data.DataSource = DatabaseManager.ShowData(DatabaseTable.Song, "*");
                    currentTable = DatabaseTable.Song;
                    panel_SongManager.Visible = true;
                    break;
                case DatabaseTable.Album:
                    dataGridView_Data.DataSource = DatabaseManager.ShowData(DatabaseTable.Album, "*");
                    currentTable = DatabaseTable.Album;
                    panel_AlbumManager.Visible = true;
                    break;
                case DatabaseTable.Label:
                    dataGridView_Data.DataSource = DatabaseManager.ShowData(DatabaseTable.Label, "*");
                    currentTable = DatabaseTable.Label;
                    panel_LabelManager.Visible = true;
                    break;
            }
            dataGridView_Data.AllowUserToAddRows = false;
            DatagridViewStyle.MinimumWidth(dataGridView_Data, 100);
            SetTooltip();
        }
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
            }
            isCreateNewRow = false;
            btnApplyAdd.Enabled = false;
            btnApplyDelete.Enabled = true;
            btnApplyEdit.Enabled = true;
        }

        private void btnNewRow_Click(object sender, EventArgs e)
        {
            dataGridView_Data.ClearSelection();
            DialogResult dialogResult = MessageBox.Show("Khi tạo mới sẽ xóa hết dữ liệu đang nhập trong form!", "Tạo mới", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            QueryData.Instance.Clear();
            ClearDataFiled();
            isCreateNewRow = true;
            btnApplyAdd.Enabled = true;
            btnApplyDelete.Enabled = false;
            btnApplyEdit.Enabled = false;
        }
        private void btnApplyAdd_Click(object sender, EventArgs e)
        {
            switch (currentTable)
            {
                case DatabaseTable.Artist:
                    QueryData.Instance.Artist.ArtistID = 0;
                    QueryData.Instance.Artist.StageName = txArtist_StageName.Text;
                    QueryData.Instance.Artist.StageName = txArtist_RealName.Text;
                    QueryData.Instance.Artist.BirthDay = dateTimePickerArtist_Birthday.Value;
                    QueryData.Instance.Artist.BirthPlace = txArtist_BirthPlace.Text;
                    QueryData.Instance.Artist.DebutDay = dateTimePickerArtist_Debutday.Value;
                    QueryData.Instance.Artist.Description = txArtist_Description.Text;
                    break;
            }
        }

        private void btnApplyUpdate_Click(object sender, EventArgs e)
        {
            switch (currentTable)
            {
                case DatabaseTable.Artist:
                     QueryData.Instance.Artist.ArtistID = Convert.ToInt32(txArtist_ID.Text);
                     QueryData.Instance.Artist.StageName = txArtist_StageName.Text;
                     QueryData.Instance.Artist.StageName = txArtist_RealName.Text;
                     QueryData.Instance.Artist.BirthDay = dateTimePickerArtist_Birthday.Value;
                     QueryData.Instance.Artist.BirthPlace = txArtist_BirthPlace.Text;
                     QueryData.Instance.Artist.DebutDay = dateTimePickerArtist_Debutday.Value;
                     QueryData.Instance.Artist.Description = txArtist_Description.Text;
                    break;
            }
        }

        private void btnApplyDelete_Click(object sender, EventArgs e)
        {
            switch (currentTable)
            {
                case DatabaseTable.Artist:
                    QueryData.Instance.Artist.ArtistID = Convert.ToInt32(txArtist_ID.Text);
                    QueryData.Instance.Artist.StageName = txArtist_StageName.Text;
                    QueryData.Instance.Artist.StageName = txArtist_RealName.Text;
                    QueryData.Instance.Artist.BirthDay = dateTimePickerArtist_Birthday.Value;
                    QueryData.Instance.Artist.BirthPlace = txArtist_BirthPlace.Text;
                    QueryData.Instance.Artist.DebutDay = dateTimePickerArtist_Debutday.Value;
                    QueryData.Instance.Artist.Description = txArtist_Description.Text;
                    break;
            }
        }
        /*
        ID
        Nghệ danh
        Tên thật
        Ngày sinh
        Nơi sinh
        Ngày ra mắt
        Mô tả
        Tên fandom
        Chiều cao
        Cân nặng
        Nhóm
        Công ty
        Sns
        Song
        Album
        */
        void ClearDataFiled()
        {
            switch (currentTable)
            {
                case DatabaseTable.Artist:
                    txArtist_ID.Text = "0";
                    txArtist_StageName.Text = string.Empty;
                    txArtist_RealName.Text = string.Empty;
                    txArtist_BirthPlace.Text = string.Empty;
                    txArtist_Description.Text = string.Empty;
                    txArtist_Height.Text = string.Empty;
                    txArtist_Weight.Text = string.Empty;

                    labelArtist_Fandom.Text = string.Empty;
                    
                    labelArtist_Label.Text = string.Empty;

                    artistImage.Clear();
                    pictureBox_ArtistImage.Image = null;
                    btnArtist_NextImage.Text = "Không có ảnh";
                    dataGridViewArtist_Group.Rows.Clear();
                    dataGridViewArtist_Song.Rows.Clear();
                    dataGridViewArtist_Album.Rows.Clear();
                    dataGridViewArtist_SNS.Rows.Clear();

                    dateTimePickerArtist_Birthday.Value = DateTime.Now;
                    dateTimePickerArtist_Debutday.Value = DateTime.Now;
                    break;
                case DatabaseTable.Group:

                    break;
                case DatabaseTable.Song:

                    break;
                case DatabaseTable.Album:

                    break;
                case DatabaseTable.Label:

                    break;
            }
        }
        /// <summary>
        /// Cách get value trong DataTable
        /// https://stackoverflow.com/questions/13816490/get-cell-value-from-a-datatable-in-c-sharp
        /// </summary>
        List<DataTable> datas = new List<DataTable>()
        {
            DatabaseManager.ShowData(DatabaseTable.Artist, "*"),
            DatabaseManager.ShowData(DatabaseTable.Group, "*"),
            DatabaseManager.ShowData(DatabaseTable.Song, "*"),
            DatabaseManager.ShowData(DatabaseTable.Album, "*"),
            DatabaseManager.ShowData(DatabaseTable.Label, "*")
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
                    datas[0] = DatabaseManager.ShowData(DatabaseTable.Artist, "*");
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
            }
        }
        void Artist_ChooseRowToEdit()
        {
            artistImage.Clear();

            nextImageIndex = 0;
            //AppStatus(true, "đang tải dữ liệu nghệ sĩ...");
            //MessageBox.Show(dataGridView_Data.SelectedRows[0].Index.ToString());
            txArtist_ID.Text = datas[0].Rows[dataGridView_Data.SelectedRows[0].Index].Field<int>("ArtistID").ToString();

            txArtist_StageName.Text = datas[0].Rows[dataGridView_Data.SelectedRows[0].Index].Field<string>("StageName").ToString();
            txArtist_RealName.Text = datas[0].Rows[dataGridView_Data.SelectedRows[0].Index].Field<string>("RealName").ToString();

            // dateTimePicker_Idol_Birthday.Value = (DateTime)dataGridView_DatabaseShow.SelectedRows[0].Cells[8].Value;
            dateTimePickerArtist_Birthday.Value = datas[0].Rows[dataGridView_Data.SelectedRows[0].Index].Field<DateTime>("BirthDay");
            dateTimePickerArtist_Birthday.CustomFormat = "dd-MM-yyyy";
            dateTimePickerArtist_Debutday.Value = datas[0].Rows[dataGridView_Data.SelectedRows[0].Index].Field<DateTime>("DebutDay");
            dateTimePickerArtist_Debutday.CustomFormat = "dd-MM-yyyy";
            txArtist_BirthPlace.Text = datas[0].Rows[dataGridView_Data.SelectedRows[0].Index].Field<string>("BirthPlace");
            txArtist_Description.Text = datas[0].Rows[dataGridView_Data.SelectedRows[0].Index].Field<string>("Description");

            try
            {
                txArtist_Height.Text = Convert.ToDecimal(datas[0].Rows[dataGridView_Data.SelectedRows[0].Index].Field<double>("Height")).ToString();
            }
            catch
            {
                txArtist_Height.Text = "1,70";
            }
            try
            {
                txArtist_Weight.Text = Convert.ToDecimal(datas[0].Rows[dataGridView_Data.SelectedRows[0].Index].Field<double>("Weight")).ToString();
            }
            catch
            {
                txArtist_Weight.Text = "50";
            }


            var fandom = DatabaseManager.ShowDataStoredProcedure("Artist_GetFandom", dataGridView_Data.SelectedRows[0].Cells[0].Value.ToString());
            labelArtist_Fandom.Text = $"ID: {fandom.Rows[0].Field<int>(0)}\n" +
                $"Tên: {fandom.Rows[0].Field<string>(1)}\n" +
                $"Mô tả: {fandom.Rows[0].Field<string>(2)}";


            dataGridViewArtist_Album.DataSource = DatabaseManager.ShowDataStoredProcedure("Artist_GetAlbum", datas[0].Rows[dataGridView_Data.SelectedRows[0].Index].Field<int>("ArtistID").ToString());

            DataTable label = DatabaseManager.ShowDataStoredProcedure("Artist_GetLabel", datas[0].Rows[dataGridView_Data.SelectedRows[0].Index].Field<int>("ArtistID").ToString());

            labelArtist_Label.Text = string.Empty;
            for (int i = 0; i < label.Rows.Count; i++)
            {
                labelArtist_Label.Text += label.Rows[i].Field<string>("Name");
                if (i > 0)
                    labelArtist_Label.Text += "\n";
            }

            dataGridViewArtist_SNS.DataSource = DatabaseManager.ShowDataStoredProcedure("Artist_GetSNS", datas[0].Rows[dataGridView_Data.SelectedRows[0].Index].Field<int>("ArtistID").ToString());

            DataTable image = DatabaseManager.ShowDataStoredProcedure("Artist_GetImage", datas[0].Rows[dataGridView_Data.SelectedRows[0].Index].Field<int>("ArtistID").ToString());
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
                pictureBox_ArtistImageLoadingGIF.Image = ImageFile.SetIconFromFolder("ajax_loadding.gif");
                pictureBox_ArtistImage.Image = ImageFile.SetIconFromFolder("unknow_ArtistImage.png");
                btnArtist_NextImage.Font = new Font("Roboto", 6, FontStyle.Bold);
                btnArtist_NextImage.Text = "Không có ảnh";
            }

            //ADD to list
            QueryData.Instance.Artist.ArtistID = Convert.ToInt32(txArtist_ID.Text);
            QueryData.Instance.Artist.StageName = txArtist_StageName.Text;
            QueryData.Instance.Artist.StageName = txArtist_RealName.Text;
            QueryData.Instance.Artist.BirthDay = dateTimePickerArtist_Birthday.Value;
            QueryData.Instance.Artist.BirthPlace = txArtist_BirthPlace.Text;
            QueryData.Instance.Artist.DebutDay = dateTimePickerArtist_Debutday.Value;
            QueryData.Instance.Artist.Description = txArtist_Description.Text;
            GetArtistGroup();  
            GetArtistSong();
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
                btnArtist_NextImage.Text = $"Không có ảnh";
            }

        }
        private void btnArtist_EditImage_Click(object sender, EventArgs e)
        {
            Intermediary_Image intermediary_Image = new Intermediary_Image();
            intermediary_Image.Closed += (s, args) => ReloadArtistImage();
            intermediary_Image.Show();
        }
        private void buttonArtist_EditGroup_Click(object sender, EventArgs e)
        {
            Intermediary_Group intermediary_Group = new Intermediary_Group();
            intermediary_Group.Closed += (s, args) => RealoadArtistGroup();
            intermediary_Group.Show();
        }

        private void buttonArtist_EditFandom_Click(object sender, EventArgs e)
        {
            Intermediary_Fandom intermediary_Fandom = new Intermediary_Fandom();
            intermediary_Fandom.Closed += (s, args) => RealoadArtistFandom();
            intermediary_Fandom.Show();
        }

        private void buttonArtist_EditSong_Click(object sender, EventArgs e)
        {
            Intermediary_Song intermediary_Song = new Intermediary_Song();
            intermediary_Song.Closed += (s, args) => RealoadArtistSong();
            intermediary_Song.Show();
        }

        private void buttonArtist_EditAlbum_Click(object sender, EventArgs e)
        {

        }

        private void buttonArtist_EditLabel_Click(object sender, EventArgs e)
        {

        }

        private void buttonArtist_EditSNS_Click(object sender, EventArgs e)
        {

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
                btnArtist_NextImage.Text = $"Ảnh";
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
                    $"Tên: {QueryData.Instance.Artist.Fandom.FandomName}\n" +
                    $"Mô tả: {QueryData.Instance.Artist.Fandom.Description}";
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
            MessageBox.Show(QueryData.Instance.Artist.ArtistSong_Delete.Count.ToString());
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
        //=========================GROUP==========================\\
        void Group_ChooseRowToEdit()
        {

        }
        void Song_ChooseRowToEdit()
        {

        }
        void Album_ChooseRowToEdit()
        {

        }
        void Label_ChooseRowToEdit()
        {

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