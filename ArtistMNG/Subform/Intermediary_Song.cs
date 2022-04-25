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
            this.Text = "Nghệ sĩ (Bài hát)";    
            //btnApplyAdd.Enabled = true;
            //btnApplyDelete.Enabled = false;
            //btnApplyEdit.Enabled = false;

            //Target image
            DatagridViewStyle.DarkStyle(dataGridView_TargetSong);
            DatagridViewStyle.MinimumWidth(dataGridView_TargetSong, 100);

            //database
            DatagridViewStyle.DarkStyle(dataGridView_DatabaseSong);
            DatagridViewStyle.MinimumWidth(dataGridView_DatabaseSong, 100);

            pictureBox_GroupImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_GroupImage.SizeMode = PictureBoxSizeMode.Zoom;

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
            dataGridView_TargetSong.Columns.Add("Genre", "Thể loại");
            dataGridView_TargetSong.Columns.Add("Producer", "Producer");
            dataGridView_TargetSong.Columns.Add("Description", "Mô tả");

            dataGridView_DatabaseSong.Columns.Add("SongID", "ID");
            dataGridView_DatabaseSong.Columns.Add("Name", "Tên");
            dataGridView_DatabaseSong.Columns.Add("ReleaseDay", "Phát hành");
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
            if (QueryData.Instance.Artist.ArtistID > 0)
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

            if (QueryData.Instance.Artist.ArtistID == 0) //arttis id là 0 thì gọi group data
            {

            }


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

                if(QueryData.Instance.Artist.ArtistSong_Delete.Count == 0)
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

        private void btnApplyDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView_TargetSong.SelectedRows.Count < 1 || dataGridView_TargetSong.SelectedRows.Count > 1)
            {
                MessageBox.Show("Chọn 1 hàng để xóa! " + QueryData.Instance.Artist.ArtistID);
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn xóa?", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            if (QueryData.Instance.Artist.ArtistID == 0)
            {
                //do nothing    
            }
            else if (QueryData.Instance.Artist.ArtistID > 0)
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
                        for (int j = 0; j < QueryData.Instance.Artist.ArtistGroup_Delete.Count; j++)
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
         
            dataGridView_TargetSong.Rows.RemoveAt(dataGridView_TargetSong.SelectedRows[0].Index);
        }
    }
}
