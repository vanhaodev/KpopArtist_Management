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
            if (ModelArtist.Instance.ArtistID > 0)
            {
                var targetGroup = DatabaseManager.ShowDataStoredProcedure("Artist_GetSong", ModelArtist.Instance.ArtistID.ToString());
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
                for (int i = 0; i < ModelArtist.Instance.ArtistSong_Delete.Count; i++)
                {
                    for (int j = dataGridView_TargetSong.Rows.Count - 1; j >= 0; j--)
                    {
                        if (ModelArtist.Instance.ArtistGroup_Delete[i].GroupID == (int)dataGridView_TargetSong.Rows[j].Cells[0].Value)
                        {
                            dataGridView_TargetSong.Rows.RemoveAt(j);
                        }
                    }
                }
            }
            for (int i = 0; i < ModelArtist.Instance.ArtistGroup_Add.Count; i++)
            {
                dataGridView_TargetSong.Rows.Add(
                    ModelArtist.Instance.ArtistGroup_Add[i].GroupID, 
                    ModelArtist.Instance.ArtistGroup_Add[i].GroupName, 
                    ModelArtist.Instance.ArtistGroup_Add[i].DebutDay,
                    ModelArtist.Instance.ArtistGroup_Add[i].FandomID,
                    ModelArtist.Instance.ArtistGroup_Add[i].Description);
            }

            if (ModelArtist.Instance.ArtistID == 0) //arttis id là 0 thì gọi group data
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
            for (int j = 0; j < ModelArtist.Instance.ArtistGroup_Add.Count; j++)
            {
                if (ModelArtist.Instance.ArtistGroup_Add[0].GroupID == (int)dataGridView_DatabaseSong.SelectedRows[0].Cells[0].Value)
                {
                    isContains = true;
                }
            }

            if (!isContains)
            {
                ModelGroup modelGroup = new ModelGroup();
                modelGroup.GroupID = (int)dataGridView_DatabaseSong.SelectedRows[0].Cells[0].Value;
                modelGroup.GroupName = dataGridView_DatabaseSong.SelectedRows[0].Cells[1].Value.ToString();
                modelGroup.DebutDay = (DateTime)dataGridView_DatabaseSong.SelectedRows[0].Cells[2].Value;
                modelGroup.FandomID = (int)dataGridView_DatabaseSong.SelectedRows[0].Cells[3].Value;
                modelGroup.Description = dataGridView_DatabaseSong.SelectedRows[0].Cells[4].Value.ToString();

                ModelArtist.Instance.ArtistGroup_Add.Add(modelGroup);
                dataGridView_TargetSong.Rows.Add(
                    dataGridView_DatabaseSong.SelectedRows[0].Cells[0].Value, 
                    dataGridView_DatabaseSong.SelectedRows[0].Cells[1].Value, 
                    dataGridView_DatabaseSong.SelectedRows[0].Cells[2].Value, 
                    dataGridView_DatabaseSong.SelectedRows[0].Cells[3].Value, 
                    dataGridView_DatabaseSong.SelectedRows[0].Cells[4].Value
                    );
                for (int i = 0; i < ModelArtist.Instance.ArtistGroup_Delete.Count; i++)
                {
                    if (ModelArtist.Instance.ArtistGroup_Delete[i].GroupID == modelGroup.GroupID)
                    {
                        ModelArtist.Instance.ArtistGroup_Delete.RemoveAt(i);
                    }
                }
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
                MessageBox.Show("Chọn 1 hàng để xóa!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn xóa?", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            string selectedUrl = dataGridView_TargetSong.SelectedRows[0].Cells[1].Value.ToString();
            if (ModelArtist.Instance.ArtistID == 0)
            {
                //do nothing    
            }
            else if (ModelArtist.Instance.ArtistID > 0)
            {
                ModelGroup modelGroup = new ModelGroup();
                modelGroup.GroupID = (int)dataGridView_TargetSong.SelectedRows[0].Cells[0].Value;
                modelGroup.GroupName = dataGridView_TargetSong.SelectedRows[0].Cells[1].Value.ToString();
                modelGroup.DebutDay = (DateTime)dataGridView_TargetSong.SelectedRows[0].Cells[2].Value;
                modelGroup.FandomID = (int)dataGridView_TargetSong.SelectedRows[0].Cells[3].Value;
                modelGroup.Description = dataGridView_TargetSong.SelectedRows[0].Cells[4].Value.ToString();

                if (ModelArtist.Instance.ArtistGroup_Add.Count < 1)
                {
                    //MessageBox.Show($"ModelArtist.Instance.ArtistImage_Add.Count {ModelArtist.Instance.ArtistImage_Add.Count}");
                    ModelArtist.Instance.ArtistGroup_Delete.Add(modelGroup);
                }
                for (int i = 0; i < ModelArtist.Instance.ArtistGroup_Add.Count; i++)
                {
                    if (ModelArtist.Instance.ArtistGroup_Add[i].GroupID == modelGroup.GroupID)
                    {
                        ModelArtist.Instance.ArtistGroup_Add.RemoveAt(i);
                    }
                    else
                    {
                        bool isContains = false;
                        for (int j = 0; j < ModelArtist.Instance.ArtistGroup_Delete.Count; j++)
                        {
                            if (ModelArtist.Instance.ArtistGroup_Delete[j].GroupID == modelGroup.GroupID)
                            {
                                isContains = true;
                            }
                        }

                        if (!isContains)
                        {
                            ModelArtist.Instance.ArtistGroup_Delete.Add(modelGroup);
                        }
                    }
                }

            }
            
            if (ModelArtist.Instance.ArtistID == 0)
            {
                //set delete  
                for (int i = 0; i < ModelArtist.Instance.ArtistGroup_Add.Count; i++)
                {
                    if (ModelArtist.Instance.ArtistGroup_Add[i].GroupID == (int)dataGridView_TargetSong.SelectedRows[0].Cells[0].Value)
                    {
                        ModelArtist.Instance.ArtistGroup_Add.RemoveAt(i);
                    }
                }
            }
         
            dataGridView_TargetSong.Rows.RemoveAt(dataGridView_TargetSong.SelectedRows[0].Index);
        }
    }
}
