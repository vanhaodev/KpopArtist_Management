using ArtistMNG.Module;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtistMNG.Subform
{
    public partial class Intermediary_Song : Form
    {

        public Intermediary_Song()
        {
            InitializeComponent();
            LoadDesign();
        }
        void LoadDesign()
        {
            this.Icon = ImageFile.SetWindowIcon("AMlogo.ico");
            switch (frmApp.currentTable)
            {
                case DatabaseTable.Artist:
                    this.Text = "Nghệ sĩ (Bài hát)";
                    break;
                case DatabaseTable.Group:
                    this.Text = "Nhóm (Bài hát)";
                    break;
            }
            //btnApplyAdd.Enabled = true;
            //btnApplyDelete.Enabled = false;
            //btnApplyEdit.Enabled = false;

            //Target image
            DatagridViewStyle.DarkStyle(dataGridView_TargetSong);
            DatagridViewStyle.MinimumWidth(dataGridView_TargetSong, 100);

            //database
            DatagridViewStyle.DarkStyle(dataGridView_DatabaseSong);
            DatagridViewStyle.MinimumWidth(dataGridView_DatabaseSong, 100);

            panel_Description.AutoScroll = true;
            //Label
            label_Information.MaximumSize = new Size(panel_Description.Width - (panel_Description.Width * 5 / 100), 0);
            label_Information.AutoSize = true;


            groupBox2.Paint += PaintBorderlessGroupBox;
            groupBox3.Paint += PaintBorderlessGroupBox;
            groupBox6.Paint += PaintBorderlessGroupBox;

            
        }
        void PaintBorderlessGroupBox(object sender, PaintEventArgs e)
        {
            GroupBoxStyle.PaintBorderlessGroupBox(sender, e, this);
        }
        private void Intermediary_Group_Load(object sender, EventArgs e)
        {
            dataGridView_TargetSong.Columns.Add("SongID", "ID");
            dataGridView_TargetSong.Columns.Add("Name", "Tên");
            dataGridView_TargetSong.Columns.Add("ReleaseDay", "Phát hành");
            dataGridView_TargetSong.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView_TargetSong.Columns.Add("Genre", "Thể loại");
            dataGridView_TargetSong.Columns.Add("Producer", "Producer");
            dataGridView_TargetSong.Columns.Add("Description", "Mô tả");

            dataGridView_DatabaseSong.Columns.Add("SongID", "ID");
            dataGridView_DatabaseSong.Columns.Add("Name", "Tên");
            dataGridView_DatabaseSong.Columns.Add("ReleaseDay", "Phát hành");
            dataGridView_DatabaseSong.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView_DatabaseSong.Columns.Add("Genre", "Thể loại");
            dataGridView_DatabaseSong.Columns.Add("Producer", "Producer");
            dataGridView_DatabaseSong.Columns.Add("Description", "Mô tả");


            loadGridView();
        }
        void loadGridView()
        {
            var databaseImage = DatabaseManager.ShowData(DatabaseTable.Song, "*");
            for (int i = 0; i < databaseImage.Rows.Count; i++)
            {
                dataGridView_DatabaseSong.Rows.Add(
                    databaseImage.Rows[i][0],
                    databaseImage.Rows[i][1], 
                    databaseImage.Rows[i][2], 
                    databaseImage.Rows[i][3], 
                    databaseImage.Rows[i][4], 
                    databaseImage.Rows[i][5]);
            }
            if (frmApp.currentTable == DatabaseTable.Artist)
            {
                var targetGroup = DatabaseManager.ShowDataStoredProcedure("Artist_GetSong", QueryData.Instance.Artist.ArtistID.ToString());
                
                for (int i = 0; i < targetGroup.Rows.Count; i++)
                {
                    if(targetGroup.Rows[0].Field<int>(0) != 0)
                    {
                        dataGridView_TargetSong.Rows.Add(
                            targetGroup.Rows[i][0], 
                            targetGroup.Rows[i][1], 
                            targetGroup.Rows[i][2], 
                            targetGroup.Rows[i][3], 
                            targetGroup.Rows[i][4], 
                            targetGroup.Rows[i][5]);
                    }    
                }

                //set delete  
                for (int i = 0; i < QueryData.Instance.Artist.ArtistSong_Delete.Count; i++)
                {
                    for (int j = dataGridView_TargetSong.Rows.Count - 1; j >= 0; j--)
                    {
                        if (QueryData.Instance.Artist.ArtistSong_Delete[i].SongID == (int)dataGridView_TargetSong.Rows[j].Cells[0].Value)
                        {
                            dataGridView_TargetSong.Rows.RemoveAt(j);
                        }
                    }
                }
                for (int i = 0; i < QueryData.Instance.Artist.ArtistSong_Add.Count; i++)
                {
                    dataGridView_TargetSong.Rows.Add(
                        QueryData.Instance.Artist.ArtistSong_Add[i].SongID,
                        QueryData.Instance.Artist.ArtistSong_Add[i].SongName,
                        QueryData.Instance.Artist.ArtistSong_Add[i].ReleaseDay,
                        QueryData.Instance.Artist.ArtistSong_Add[i].Genre,
                        QueryData.Instance.Artist.ArtistSong_Add[i].Producer,
                        QueryData.Instance.Artist.ArtistSong_Add[i].Description);
                }
            }
            else if (frmApp.currentTable == DatabaseTable.Group)
            {
                var targetGroup = DatabaseManager.ShowDataStoredProcedure("Group_GetSong", QueryData.Instance.Group.GroupID.ToString());
                for (int i = 0; i < targetGroup.Rows.Count; i++)
                {
                    if (targetGroup.Rows[0].Field<int>(0) != 0)
                    {
                        dataGridView_TargetSong.Rows.Add(
                            targetGroup.Rows[i][0],
                            targetGroup.Rows[i][1],
                            targetGroup.Rows[i][2],
                            targetGroup.Rows[i][3],
                            targetGroup.Rows[i][4],
                            targetGroup.Rows[i][5]);
                    }
                }

                //set delete  
                for (int i = 0; i < QueryData.Instance.Group.GroupSong_Delete.Count; i++)
                {
                    for (int j = dataGridView_TargetSong.Rows.Count - 1; j >= 0; j--)
                    {
                        if (QueryData.Instance.Group.GroupSong_Delete[i].SongID == (int)dataGridView_TargetSong.Rows[j].Cells[0].Value)
                        {
                            dataGridView_TargetSong.Rows.RemoveAt(j);
                        }
                    }
                }
                for (int i = 0; i < QueryData.Instance.Group.GroupSong_Add.Count; i++)
                {
                    dataGridView_TargetSong.Rows.Add(
                        QueryData.Instance.Group.GroupSong_Add[i].SongID,
                        QueryData.Instance.Group.GroupSong_Add[i].SongName,
                        QueryData.Instance.Group.GroupSong_Add[i].ReleaseDay,
                        QueryData.Instance.Group.GroupSong_Add[i].Genre,
                        QueryData.Instance.Group.GroupSong_Add[i].Producer,
                        QueryData.Instance.Group.GroupSong_Add[i].Description);
                }
            }
            else if (frmApp.currentTable == DatabaseTable.Album)
            {
                var targetGroup = DatabaseManager.ShowDataStoredProcedure("Album_GetSong", QueryData.Instance.Album.AlbumID.ToString());
                for (int i = 0; i < targetGroup.Rows.Count; i++)
                {
                    if (targetGroup.Rows[0].Field<int>(0) != 0)
                    {
                        dataGridView_TargetSong.Rows.Add(
                            targetGroup.Rows[i][0],
                            targetGroup.Rows[i][1],
                            targetGroup.Rows[i][2],
                            targetGroup.Rows[i][3],
                            targetGroup.Rows[i][4],
                            targetGroup.Rows[i][5]);
                    }
                }

                //set delete  
                for (int i = 0; i < QueryData.Instance.Album.AlbumSong_Delete.Count; i++)
                {
                    for (int j = dataGridView_TargetSong.Rows.Count - 1; j >= 0; j--)
                    {
                        if (QueryData.Instance.Album.AlbumSong_Delete[i].SongID == (int)dataGridView_TargetSong.Rows[j].Cells[0].Value)
                        {
                            dataGridView_TargetSong.Rows.RemoveAt(j);
                        }
                    }
                }
                for (int i = 0; i < QueryData.Instance.Album.AlbumSong_Add.Count; i++)
                {
                    dataGridView_TargetSong.Rows.Add(
                        QueryData.Instance.Album.AlbumSong_Add[i].SongID,
                        QueryData.Instance.Album.AlbumSong_Add[i].SongName,
                        QueryData.Instance.Album.AlbumSong_Add[i].ReleaseDay,
                        QueryData.Instance.Album.AlbumSong_Add[i].Genre,
                        QueryData.Instance.Album.AlbumSong_Add[i].Producer,
                        QueryData.Instance.Album.AlbumSong_Add[i].Description);
                }
            }


            cbxSearchDatabaseSongType.SelectedIndex = 0;
        }

        private void btnAddGroupFromDbToArtist_Click(object sender, EventArgs e)
        {
            if (dataGridView_DatabaseSong.SelectedRows.Count < 1 || dataGridView_DatabaseSong.SelectedRows.Count > 1)
            {
                MessageBox.Show("Chọn 1 hàng bên database để chuyển sang!");
                return;
            }
            bool isContains = false;
            for (int i = 0; i < dataGridView_TargetSong.Rows.Count; i++)
            {
                if ((int)dataGridView_TargetSong.Rows[i].Cells[0].Value == (int)dataGridView_DatabaseSong.SelectedRows[0].Cells[0].Value)
                {
                    isContains = true;
                }
            }
            if(frmApp.currentTable == DatabaseTable.Artist)
            {
                for (int i = 0; i < QueryData.Instance.Artist.ArtistSong_Add.Count; i++)
                {
                    if (QueryData.Instance.Artist.ArtistSong_Add[i].SongID == (int)dataGridView_DatabaseSong.SelectedRows[0].Cells[0].Value)
                    {
                        isContains = true;
                    }
                }

                if (!isContains)
                {
                    ModelSong modelSong = new ModelSong();
                    modelSong.SongID = (int)dataGridView_DatabaseSong.SelectedRows[0].Cells[0].Value;
                    modelSong.SongName = dataGridView_DatabaseSong.SelectedRows[0].Cells[1].Value.ToString();
                    modelSong.ReleaseDay = (DateTime)dataGridView_DatabaseSong.SelectedRows[0].Cells[2].Value;
                    modelSong.Genre = dataGridView_DatabaseSong.SelectedRows[0].Cells[3].Value.ToString();
                    modelSong.Producer = dataGridView_DatabaseSong.SelectedRows[0].Cells[4].Value.ToString();
                    modelSong.Description = dataGridView_DatabaseSong.SelectedRows[0].Cells[5].Value.ToString();

                    if (QueryData.Instance.Artist.ArtistSong_Delete.Count == 0)
                    {
                        QueryData.Instance.Artist.ArtistSong_Add.Add(modelSong);
                    }
                    for (int i = 0; i < QueryData.Instance.Artist.ArtistSong_Delete.Count; i++)
                    {
                        if (QueryData.Instance.Artist.ArtistSong_Delete[i].SongID == modelSong.SongID)
                        {
                            QueryData.Instance.Artist.ArtistSong_Delete.RemoveAt(i);
                        }
                        else
                        {
                            QueryData.Instance.Artist.ArtistSong_Add.Add(modelSong);
                        }
                    }

                    dataGridView_TargetSong.Rows.Add(
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[0].Value,
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[1].Value,
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[2].Value,
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[3].Value,
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[4].Value,
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[5].Value
                        );

                }
                else
                {
                    MessageBox.Show("Đã tồn tại dữ liệu tương tự!");
                }
            }   
            else if(frmApp.currentTable == DatabaseTable.Group)
            {
                for (int i = 0; i < QueryData.Instance.Group.GroupSong_Add.Count; i++)
                {
                    if (QueryData.Instance.Group.GroupSong_Add[i].SongID == (int)dataGridView_DatabaseSong.SelectedRows[0].Cells[0].Value)
                    {
                        isContains = true;
                    }
                }

                if (!isContains)
                {
                    ModelSong modelSong = new ModelSong();
                    modelSong.SongID = (int)dataGridView_DatabaseSong.SelectedRows[0].Cells[0].Value;
                    modelSong.SongName = dataGridView_DatabaseSong.SelectedRows[0].Cells[1].Value.ToString();
                    modelSong.ReleaseDay = (DateTime)dataGridView_DatabaseSong.SelectedRows[0].Cells[2].Value;
                    modelSong.Genre = dataGridView_DatabaseSong.SelectedRows[0].Cells[3].Value.ToString();
                    modelSong.Producer = dataGridView_DatabaseSong.SelectedRows[0].Cells[4].Value.ToString();
                    modelSong.Description = dataGridView_DatabaseSong.SelectedRows[0].Cells[5].Value.ToString();

                    if (QueryData.Instance.Group.GroupSong_Delete.Count == 0)
                    {
                        QueryData.Instance.Group.GroupSong_Add.Add(modelSong);
                    }
                    for (int i = 0; i < QueryData.Instance.Group.GroupSong_Delete.Count; i++)
                    {
                        if (QueryData.Instance.Group.GroupSong_Delete[i].SongID == modelSong.SongID)
                        {
                            QueryData.Instance.Group.GroupSong_Delete.RemoveAt(i);
                        }
                        else
                        {
                            QueryData.Instance.Group.GroupSong_Add.Add(modelSong);
                        }
                    }

                    dataGridView_TargetSong.Rows.Add(
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[0].Value,
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[1].Value,
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[2].Value,
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[3].Value,
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[4].Value,
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[5].Value
                        );

                }
                else
                {
                    MessageBox.Show("Đã tồn tại dữ liệu tương tự!");
                }
            }
            else if (frmApp.currentTable == DatabaseTable.Album)
            {
                for (int i = 0; i < QueryData.Instance.Album.AlbumSong_Add.Count; i++)
                {
                    if (QueryData.Instance.Album.AlbumSong_Add[i].SongID == (int)dataGridView_DatabaseSong.SelectedRows[0].Cells[0].Value)
                    {
                        isContains = true;
                    }
                }

                if (!isContains)
                {
                    ModelSong modelSong = new ModelSong();
                    modelSong.SongID = (int)dataGridView_DatabaseSong.SelectedRows[0].Cells[0].Value;
                    modelSong.SongName = dataGridView_DatabaseSong.SelectedRows[0].Cells[1].Value.ToString();
                    modelSong.ReleaseDay = (DateTime)dataGridView_DatabaseSong.SelectedRows[0].Cells[2].Value;
                    modelSong.Genre = dataGridView_DatabaseSong.SelectedRows[0].Cells[3].Value.ToString();
                    modelSong.Producer = dataGridView_DatabaseSong.SelectedRows[0].Cells[4].Value.ToString();
                    modelSong.Description = dataGridView_DatabaseSong.SelectedRows[0].Cells[5].Value.ToString();

                    if (QueryData.Instance.Album.AlbumSong_Delete.Count == 0)
                    {
                        QueryData.Instance.Album.AlbumSong_Add.Add(modelSong);
                    }
                    for (int i = 0; i < QueryData.Instance.Album.AlbumSong_Delete.Count; i++)
                    {
                        if (QueryData.Instance.Album.AlbumSong_Delete[i].SongID == modelSong.SongID)
                        {
                            QueryData.Instance.Album.AlbumSong_Delete.RemoveAt(i);
                        }
                        else
                        {
                            QueryData.Instance.Album.AlbumSong_Add.Add(modelSong);
                        }
                    }

                    dataGridView_TargetSong.Rows.Add(
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[0].Value,
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[1].Value,
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[2].Value,
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[3].Value,
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[4].Value,
                        dataGridView_DatabaseSong.SelectedRows[0].Cells[5].Value
                        );

                }
                else
                {
                    MessageBox.Show("Đã tồn tại dữ liệu tương tự!");
                }
            }
        }

        private void btnApplyDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView_TargetSong.SelectedRows.Count < 1 || dataGridView_TargetSong.SelectedRows.Count > 1)
            {
                MessageBox.Show("Chọn 1 hàng để xóa! ");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn xóa?", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            if(frmApp.currentTable == DatabaseTable.Artist)
            {
                if (QueryData.Instance.Artist.ArtistID > 0)
                {
                    ModelSong modelSong = new ModelSong();
                    modelSong.SongID = (int)dataGridView_TargetSong.SelectedRows[0].Cells[0].Value;
                    modelSong.SongName = dataGridView_TargetSong.SelectedRows[0].Cells[1].Value.ToString();
                    modelSong.ReleaseDay = (DateTime)dataGridView_TargetSong.SelectedRows[0].Cells[2].Value;
                    modelSong.Genre = dataGridView_TargetSong.SelectedRows[0].Cells[3].Value.ToString();
                    modelSong.Producer = dataGridView_TargetSong.SelectedRows[0].Cells[4].Value.ToString();
                    modelSong.Description = dataGridView_TargetSong.SelectedRows[0].Cells[5].Value.ToString();

                    if (QueryData.Instance.Artist.ArtistSong_Add.Count < 1)
                    {
                        QueryData.Instance.Artist.ArtistSong_Delete.Add(modelSong);
                    }
                    for (int i = 0; i < QueryData.Instance.Artist.ArtistSong_Add.Count; i++)
                    {
                        if (QueryData.Instance.Artist.ArtistSong_Add[i].SongID == modelSong.SongID)
                        {
                            QueryData.Instance.Artist.ArtistSong_Add.RemoveAt(i);
                        }
                        else
                        {
                            bool isContains = false;
                            for (int j = 0; j < QueryData.Instance.Artist.ArtistSong_Delete.Count; j++)
                            {
                                if (QueryData.Instance.Artist.ArtistSong_Delete[j].SongID == modelSong.SongID)
                                {
                                    isContains = true;
                                }
                            }

                            if (!isContains)
                            {
                                QueryData.Instance.Artist.ArtistSong_Delete.Add(modelSong);
                            }
                        }
                    }

                }

                if (QueryData.Instance.Artist.ArtistID == 0)
                {
                    //set delete  
                    for (int i = 0; i < QueryData.Instance.Artist.ArtistSong_Add.Count; i++)
                    {
                        if (QueryData.Instance.Artist.ArtistSong_Add[i].SongID == (int)dataGridView_TargetSong.SelectedRows[0].Cells[0].Value)
                        {
                            QueryData.Instance.Artist.ArtistSong_Add.RemoveAt(i);
                        }
                    }
                }            
            }
            else if (frmApp.currentTable == DatabaseTable.Group)
            {
                if (QueryData.Instance.Group.GroupID > 0)
                {
                    ModelSong modelSong = new ModelSong();
                    modelSong.SongID = (int)dataGridView_TargetSong.SelectedRows[0].Cells[0].Value;
                    modelSong.SongName = dataGridView_TargetSong.SelectedRows[0].Cells[1].Value.ToString();
                    modelSong.ReleaseDay = (DateTime)dataGridView_TargetSong.SelectedRows[0].Cells[2].Value;
                    modelSong.Genre = dataGridView_TargetSong.SelectedRows[0].Cells[3].Value.ToString();
                    modelSong.Producer = dataGridView_TargetSong.SelectedRows[0].Cells[4].Value.ToString();
                    modelSong.Description = dataGridView_TargetSong.SelectedRows[0].Cells[5].Value.ToString();

                    if (QueryData.Instance.Group.GroupSong_Add.Count < 1)
                    {
                        QueryData.Instance.Group.GroupSong_Delete.Add(modelSong);
                    }
                    for (int i = 0; i < QueryData.Instance.Group.GroupSong_Add.Count; i++)
                    {
                        if (QueryData.Instance.Group.GroupSong_Add[i].SongID == modelSong.SongID)
                        {
                            QueryData.Instance.Group.GroupSong_Add.RemoveAt(i);
                        }
                        else
                        {
                            bool isContains = false;
                            for (int j = 0; j < QueryData.Instance.Group.GroupSong_Delete.Count; j++)
                            {
                                if (QueryData.Instance.Group.GroupSong_Delete[j].SongID == modelSong.SongID)
                                {
                                    isContains = true;
                                }
                            }

                            if (!isContains)
                            {
                                QueryData.Instance.Group.GroupSong_Delete.Add(modelSong);
                            }
                        }
                    }

                }

                if (QueryData.Instance.Group.GroupID == 0)
                {
                    //set delete  
                    for (int i = 0; i < QueryData.Instance.Group.GroupSong_Add.Count; i++)
                    {
                        if (QueryData.Instance.Group.GroupSong_Add[i].SongID == (int)dataGridView_TargetSong.SelectedRows[0].Cells[0].Value)
                        {
                            QueryData.Instance.Group.GroupSong_Add.RemoveAt(i);
                        }
                    }
                }
            }
            else if (frmApp.currentTable == DatabaseTable.Album)
            {
                if (QueryData.Instance.Album.AlbumID > 0)
                {
                    ModelSong modelSong = new ModelSong();
                    modelSong.SongID = (int)dataGridView_TargetSong.SelectedRows[0].Cells[0].Value;
                    modelSong.SongName = dataGridView_TargetSong.SelectedRows[0].Cells[1].Value.ToString();
                    modelSong.ReleaseDay = (DateTime)dataGridView_TargetSong.SelectedRows[0].Cells[2].Value;
                    modelSong.Genre = dataGridView_TargetSong.SelectedRows[0].Cells[3].Value.ToString();
                    modelSong.Producer = dataGridView_TargetSong.SelectedRows[0].Cells[4].Value.ToString();
                    modelSong.Description = dataGridView_TargetSong.SelectedRows[0].Cells[5].Value.ToString();

                    if (QueryData.Instance.Album.AlbumSong_Add.Count < 1)
                    {
                        QueryData.Instance.Album.AlbumSong_Delete.Add(modelSong);
                    }
                    for (int i = 0; i < QueryData.Instance.Album.AlbumSong_Add.Count; i++)
                    {
                        if (QueryData.Instance.Album.AlbumSong_Add[i].SongID == modelSong.SongID)
                        {
                            QueryData.Instance.Album.AlbumSong_Add.RemoveAt(i);
                        }
                        else
                        {
                            bool isContains = false;
                            for (int j = 0; j < QueryData.Instance.Album.AlbumSong_Delete.Count; j++)
                            {
                                if (QueryData.Instance.Album.AlbumSong_Delete[j].SongID == modelSong.SongID)
                                {
                                    isContains = true;
                                }
                            }

                            if (!isContains)
                            {
                                QueryData.Instance.Album.AlbumSong_Delete.Add(modelSong);
                            }
                        }
                    }

                }

                if (QueryData.Instance.Album.AlbumID == 0)
                {
                    //set delete  
                    for (int i = 0; i < QueryData.Instance.Album.AlbumSong_Add.Count; i++)
                    {
                        if (QueryData.Instance.Album.AlbumSong_Add[i].SongID == (int)dataGridView_TargetSong.SelectedRows[0].Cells[0].Value)
                        {
                            QueryData.Instance.Album.AlbumSong_Add.RemoveAt(i);
                        }
                    }
                }
            }
            dataGridView_TargetSong.Rows.RemoveAt(dataGridView_TargetSong.SelectedRows[0].Index);
        }

        private void btnSearchDatabaseSong_Click(object sender, EventArgs e)
        {
            if (txValueSearchDatabaseSong.Text.Length < 1 || cbxSearchDatabaseSongType.SelectedIndex == 0)
            {
                return;
            }
            DataTable database = null;
            switch (cbxSearchDatabaseSongType.SelectedIndex)
            {
                case 1:
                    if (Regex.IsMatch(txValueSearchDatabaseSong.Text, @"^\d$")) //Regex only số
                    {
                        database = DatabaseManager.ShowDataQuery($"SELECT * FROM [Song] WHERE SongID = {txValueSearchDatabaseSong.Text}");
                    }
                    else
                    {
                        MessageBox.Show("ID chỉ tồn tại số nguyên!");
                        return;
                    }

                    break;
                case 2:
                    database = DatabaseManager.ShowDataQuery($"SELECT * FROM [Song] WHERE Name LIKE '%{txValueSearchDatabaseSong.Text}%'");
                    break;
                case 3:
                    database = DatabaseManager.ShowDataQuery($"SELECT * FROM [Song] WHERE Producer LIKE '%{txValueSearchDatabaseSong.Text}%'");
                    break;
            }
            ResultSearch(database);


        }

        private void cbxSearchDatabaseSongType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSearchDatabaseSongType.SelectedIndex == 0)
            {
                ResultSearch(DatabaseManager.ShowDataQuery("SELECT * FROM [Song]"));
            }
        }
        void ResultSearch(DataTable database)
        {
            if (database != null)
            {
                dataGridView_DatabaseSong.Rows.Clear();
                for (int i = 0; i < database.Rows.Count; i++)
                {
                    dataGridView_DatabaseSong.Rows.Add(
                        database.Rows[i][0],
                        database.Rows[i][1],
                        database.Rows[i][2],
                        database.Rows[i][3],
                        database.Rows[i][4],
                        database.Rows[i][5]);
                }
            }
        }
        private void dataGridView_DatabaseSong_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridView_DatabaseSong.SelectedRows.Count == 0)
            {
                return;
            }
            label_Information.Text = $"ID: {dataGridView_DatabaseSong.SelectedRows[0].Cells[0].Value}\n" +
                $"Tên: {dataGridView_DatabaseSong.SelectedRows[0].Cells[1].Value}\n" +
                $"Phát hành: {TimerType.VietnamTimeType((DateTime)dataGridView_DatabaseSong.SelectedRows[0].Cells[2].Value)}\n"+
                $"Thể loại: {dataGridView_DatabaseSong.SelectedRows[0].Cells[3].Value}\n"+
                $"Producer: {dataGridView_DatabaseSong.SelectedRows[0].Cells[4].Value}\n"+
                $"{dataGridView_DatabaseSong.SelectedRows[0].Cells[5].Value}\n";
        }

        private void dataGridView_TargetSong_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_TargetSong.SelectedRows.Count == 0)
            {
                return;
            }
            label_Information.Text = $"ID: {dataGridView_TargetSong.SelectedRows[0].Cells[0].Value}\n" +
                $"Tên: {dataGridView_TargetSong.SelectedRows[0].Cells[1].Value}\n" +
                $"Phát hành: {TimerType.VietnamTimeType((DateTime)dataGridView_TargetSong.SelectedRows[0].Cells[2].Value)}\n" +
                $"Thể loại: {dataGridView_TargetSong.SelectedRows[0].Cells[3].Value}\n" +
                $"Producer: {dataGridView_TargetSong.SelectedRows[0].Cells[4].Value}\n" +
                $"{dataGridView_TargetSong.SelectedRows[0].Cells[5].Value}\n";
        }

        
    }
}
