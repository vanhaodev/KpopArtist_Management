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
    public partial class Intermediary_Group : Form
    {

        public Intermediary_Group()
        {
            InitializeComponent();
            LoadDesign();
        }
        void LoadDesign()
        {
            this.Icon = ImageFile.SetWindowIcon("AMlogo.ico");
            this.Text = "Nghệ sĩ (Nhóm)";    
            //btnApplyAdd.Enabled = true;
            //btnApplyDelete.Enabled = false;
            //btnApplyEdit.Enabled = false;

            //Target image
            DatagridViewStyle.DarkStyle(dataGridView_TargetGroup);
            DatagridViewStyle.MinimumWidth(dataGridView_TargetGroup, 100);

            //database
            DatagridViewStyle.DarkStyle(dataGridView_DatabaseGroup);
            DatagridViewStyle.MinimumWidth(dataGridView_DatabaseGroup, 100);

            pictureBox_GroupImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_GroupImage.SizeMode = PictureBoxSizeMode.Zoom;
            groupBox2.Paint += PaintBorderlessGroupBox;
            groupBox3.Paint += PaintBorderlessGroupBox;
            groupBox6.Paint += PaintBorderlessGroupBox;

            //Label
            label_Information.MaximumSize = new Size(panel_Description.Width - (panel_Description.Width * 5 / 100), 0);
            label_Information.AutoSize = true;
            panel_Description.AutoScroll = true;

        }
        void PaintBorderlessGroupBox(object sender, PaintEventArgs e)
        {
            GroupBoxStyle.PaintBorderlessGroupBox(sender, e, this);
        }

        private void Intermediary_Group_Load(object sender, EventArgs e)
        {
            dataGridView_TargetGroup.Columns.Add("GroupID", "GroupID");
            dataGridView_TargetGroup.Columns.Add("Name", "Name");
            dataGridView_TargetGroup.Columns.Add("DebutDay", "DebutDay");
            dataGridView_TargetGroup.Columns.Add("FandomID", "FandomID");
            dataGridView_TargetGroup.Columns.Add("Description", "Description");

            dataGridView_DatabaseGroup.Columns.Add("GroupID", "GroupID");
            dataGridView_DatabaseGroup.Columns.Add("Name", "Name");
            dataGridView_DatabaseGroup.Columns.Add("DebutDay", "DebutDay");
            dataGridView_DatabaseGroup.Columns.Add("FandomID", "FandomID");
            dataGridView_DatabaseGroup.Columns.Add("Description", "Description");

            loadGridView();
        }
        void loadGridView()
        {
            var databaseImage = DatabaseManager.ShowData(DatabaseTable.Group, "*");
            for (int i = 0; i < databaseImage.Rows.Count; i++)
            {
                dataGridView_DatabaseGroup.Rows.Add(databaseImage.Rows[i][0], databaseImage.Rows[i][1], databaseImage.Rows[i][2], databaseImage.Rows[i][3], databaseImage.Rows[i][4]);
            }
            if (QueryData.Instance.Artist.ArtistID > 0)
            {
                var targetGroup = DatabaseManager.ShowDataStoredProcedure("Artist_GetGroup", QueryData.Instance.Artist.ArtistID.ToString());
                for (int i = 0; i < targetGroup.Rows.Count; i++)
                {
                    if(targetGroup.Rows[0].Field<int>(0) != 0)
                    {
                        dataGridView_TargetGroup.Rows.Add(targetGroup.Rows[i][0], targetGroup.Rows[i][1], targetGroup.Rows[i][2], targetGroup.Rows[i][3], targetGroup.Rows[i][4]);
                    }    
                }

                //set delete  
                for (int i = 0; i < QueryData.Instance.Artist.ArtistGroup_Delete.Count; i++)
                {
                    for (int j = dataGridView_TargetGroup.Rows.Count - 1; j >= 0; j--)
                    {
                        if (QueryData.Instance.Artist.ArtistGroup_Delete[i].GroupID == (int)dataGridView_TargetGroup.Rows[j].Cells[0].Value)
                        {
                            dataGridView_TargetGroup.Rows.RemoveAt(j);
                        }
                    }
                }
            }
            for (int i = 0; i < QueryData.Instance.Artist.ArtistGroup_Add.Count; i++)
            {
                dataGridView_TargetGroup.Rows.Add(
                    QueryData.Instance.Artist.ArtistGroup_Add[i].GroupID, 
                    QueryData.Instance.Artist.ArtistGroup_Add[i].GroupName, 
                    QueryData.Instance.Artist.ArtistGroup_Add[i].DebutDay,
                    QueryData.Instance.Artist.ArtistGroup_Add[i].Fandom.FandomID,
                    QueryData.Instance.Artist.ArtistGroup_Add[i].Description);
            }

            if (QueryData.Instance.Artist.ArtistID == 0) //arttis id là 0 thì gọi group data
            {

            }

            cbxSearchDatabaseGroupType.SelectedIndex = 1;

        }

        private void btnAddGroupFromDbToArtist_Click(object sender, EventArgs e)
        {
            if (dataGridView_DatabaseGroup.SelectedRows.Count < 1 || dataGridView_DatabaseGroup.SelectedRows.Count > 1)
            {
                MessageBox.Show("Chọn 1 hàng bên database để chuyển sang!");
                return;
            }
            bool isContains = false;
            for (int i = 0; i < dataGridView_TargetGroup.Rows.Count; i++)
            {
                if ((int)dataGridView_TargetGroup.Rows[i].Cells[0].Value == (int)dataGridView_DatabaseGroup.SelectedRows[0].Cells[0].Value)
                {
                    isContains = true;
                }
            }
            for (int i = 0; i < QueryData.Instance.Artist.ArtistGroup_Add.Count; i++)
            {
                if (QueryData.Instance.Artist.ArtistGroup_Add[i].GroupID == (int)dataGridView_DatabaseGroup.SelectedRows[0].Cells[0].Value)
                {
                    isContains = true;
                }
            }
            
            if (!isContains)
            {
                ModelGroup modelGroup = new ModelGroup();
                modelGroup.GroupID = (int)dataGridView_DatabaseGroup.SelectedRows[0].Cells[0].Value;
                modelGroup.GroupName = dataGridView_DatabaseGroup.SelectedRows[0].Cells[1].Value.ToString();
                modelGroup.DebutDay = (DateTime)dataGridView_DatabaseGroup.SelectedRows[0].Cells[2].Value;
                modelGroup.Fandom.FandomID = (int)dataGridView_DatabaseGroup.SelectedRows[0].Cells[3].Value;
                modelGroup.Description = dataGridView_DatabaseGroup.SelectedRows[0].Cells[4].Value.ToString();

                if(QueryData.Instance.Artist.ArtistGroup_Delete.Count == 0)
                {
                    QueryData.Instance.Artist.ArtistGroup_Add.Add(modelGroup);
                }    
                for (int i = 0; i < QueryData.Instance.Artist.ArtistGroup_Delete.Count; i++)
                {
                    if (QueryData.Instance.Artist.ArtistGroup_Delete[i].GroupID == (int)dataGridView_DatabaseGroup.SelectedRows[0].Cells[0].Value)
                    {
                        QueryData.Instance.Artist.ArtistGroup_Delete.RemoveAt(i);

                    }
                    else
                    {
                        QueryData.Instance.Artist.ArtistGroup_Add.Add(modelGroup);
                        MessageBox.Show(modelGroup.GroupName);
                    }    
                }
                
                dataGridView_TargetGroup.Rows.Add(
                    dataGridView_DatabaseGroup.SelectedRows[0].Cells[0].Value, 
                    dataGridView_DatabaseGroup.SelectedRows[0].Cells[1].Value, 
                    dataGridView_DatabaseGroup.SelectedRows[0].Cells[2].Value, 
                    dataGridView_DatabaseGroup.SelectedRows[0].Cells[3].Value, 
                    dataGridView_DatabaseGroup.SelectedRows[0].Cells[4].Value
                    );
                
            }
            else
            {
                MessageBox.Show("Đã tồn tại dữ liệu tương tự!");
            }
        }

        private void btnApplyDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView_TargetGroup.SelectedRows.Count < 1 || dataGridView_TargetGroup.SelectedRows.Count > 1)
            {
                MessageBox.Show("Chọn 1 hàng để xóa!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn xóa?", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            string selectedUrl = dataGridView_TargetGroup.SelectedRows[0].Cells[1].Value.ToString();
            if (QueryData.Instance.Artist.ArtistID == 0)
            {
                //do nothing    
            }
            else if (QueryData.Instance.Artist.ArtistID > 0)
            {
                ModelGroup modelGroup = new ModelGroup();
                modelGroup.GroupID = (int)dataGridView_TargetGroup.SelectedRows[0].Cells[0].Value;
                modelGroup.GroupName = dataGridView_TargetGroup.SelectedRows[0].Cells[1].Value.ToString();
                modelGroup.DebutDay = (DateTime)dataGridView_TargetGroup.SelectedRows[0].Cells[2].Value;
                modelGroup.Fandom.FandomID = (int)dataGridView_TargetGroup.SelectedRows[0].Cells[3].Value;
                modelGroup.Description = dataGridView_TargetGroup.SelectedRows[0].Cells[4].Value.ToString();

                if (QueryData.Instance.Artist.ArtistGroup_Add.Count < 1)
                {
                    QueryData.Instance.Artist.ArtistGroup_Delete.Add(modelGroup);
                }
                for (int i = 0; i < QueryData.Instance.Artist.ArtistGroup_Add.Count; i++)
                {
                    if (QueryData.Instance.Artist.ArtistGroup_Add[i].GroupID == modelGroup.GroupID)
                    {
                        QueryData.Instance.Artist.ArtistGroup_Add.RemoveAt(i);
                    }
                    else
                    {
                        bool isContains = false;
                        for (int j = 0; j < QueryData.Instance.Artist.ArtistGroup_Delete.Count; j++)
                        {
                            if (QueryData.Instance.Artist.ArtistGroup_Delete[j].GroupID == modelGroup.GroupID)
                            {
                                isContains = true;
                            }
                        }

                        if (!isContains)
                        {
                            QueryData.Instance.Artist.ArtistGroup_Delete.Add(modelGroup);
                        }
                    }
                }

            }
            
            if (QueryData.Instance.Artist.ArtistID == 0)
            {
                //set delete  
                for (int i = 0; i < QueryData.Instance.Artist.ArtistGroup_Add.Count; i++)
                {
                    if (QueryData.Instance.Artist.ArtistGroup_Add[i].GroupID == (int)dataGridView_TargetGroup.SelectedRows[0].Cells[0].Value)
                    {
                        QueryData.Instance.Artist.ArtistGroup_Add.RemoveAt(i);
                    }
                }
            }
         
            dataGridView_TargetGroup.Rows.RemoveAt(dataGridView_TargetGroup.SelectedRows[0].Index);
        }

        private void btnSearchDatabaseGroup_Click(object sender, EventArgs e)
        {
            if (txValueSearchDatabaseGroup.Text.Length < 1 || cbxSearchDatabaseGroupType.SelectedIndex == 0)
            {
                return;
            }
            DataTable database = null;
            switch (cbxSearchDatabaseGroupType.SelectedIndex)
            {
                case 1:
                    if (Regex.IsMatch(txValueSearchDatabaseGroup.Text, @"^\d$")) //Regex only số
                    {
                        database = DatabaseManager.ShowDataQuery($"SELECT * FROM [Group] WHERE GroupID = {txValueSearchDatabaseGroup.Text}");
                    }
                    else
                    {
                        MessageBox.Show("ID chỉ tồn tại số nguyên!");
                        return;
                    }

                    break;
                case 2:
                    database = DatabaseManager.ShowDataQuery($"SELECT * FROM [Group] WHERE Name LIKE '%{txValueSearchDatabaseGroup.Text}%'");
                    break;
                case 3:
                    database = DatabaseManager.ShowDataQuery($"SELECT * FROM [Group] WHERE Description LIKE '%{txValueSearchDatabaseGroup.Text}%'");
                    break;
            }
            ResultSearch(database);
        }

        private void cbxSearchDatabaseGroupType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSearchDatabaseGroupType.SelectedIndex == 0)
            {
                ResultSearch(DatabaseManager.ShowDataQuery("SELECT * FROM [Group]"));
            }
        }
        void ResultSearch(DataTable database)
        {
            if (database != null)
            {
                dataGridView_DatabaseGroup.Rows.Clear();
                for (int i = 0; i < database.Rows.Count; i++)
                {
                    dataGridView_DatabaseGroup.Rows.Add(
                        database.Rows[i][0],
                        database.Rows[i][1],
                        database.Rows[i][2],
                        database.Rows[i][3],
                        database.Rows[i][4]);
                }
            }
        }

        private void dataGridView_DatabaseGroup_SelectionChanged(object sender, EventArgs e)
        {
            /*
             * modelGroup.GroupID = (int)dataGridView_TargetGroup.SelectedRows[0].Cells[0].Value;
                modelGroup.GroupName = dataGridView_TargetGroup.SelectedRows[0].Cells[1].Value.ToString();
                modelGroup.DebutDay = (DateTime)dataGridView_TargetGroup.SelectedRows[0].Cells[2].Value;
                modelGroup.Fandom.FandomID = (int)dataGridView_TargetGroup.SelectedRows[0].Cells[3].Value;
                modelGroup.Description = dataGridView_TargetGroup.SelectedRows[0].Cells[4].Value.ToString();*/
            if (dataGridView_DatabaseGroup.SelectedRows.Count == 0)
            {
                return;
            }
            label_Information.Text = $"ID: {dataGridView_DatabaseGroup.SelectedRows[0].Cells[0].Value}\n" +
                $"Tên: {dataGridView_DatabaseGroup.SelectedRows[0].Cells[1].Value}\n" +
                $"Ra mắt: {TimerType.VietnamTimeType((DateTime)dataGridView_DatabaseGroup.SelectedRows[0].Cells[2].Value)}\n" +
                $"Fandom: {(dataGridView_DatabaseGroup.SelectedRows[0].Cells[3].Value.ToString() != "0" ? DatabaseManager.ShowDataQuery($"SELECT Name FROM [Fandom] WHERE FandomID = {dataGridView_DatabaseGroup.SelectedRows[0].Cells[3].Value}").Rows[0].Field<string>(0) : "Không có")} (ID: {dataGridView_DatabaseGroup.SelectedRows[0].Cells[3].Value})\n" +
                $"{dataGridView_DatabaseGroup.SelectedRows[0].Cells[4].Value}";
                
        }

        private void dataGridView_TargetGroup_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_TargetGroup.SelectedRows.Count == 0)
            {
                return;
            }

            label_Information.Text = $"ID: {dataGridView_TargetGroup.SelectedRows[0].Cells[0].Value}\n" +
                $"Tên: {dataGridView_TargetGroup.SelectedRows[0].Cells[1].Value}\n" +
                $"Ra mắt: {TimerType.VietnamTimeType((DateTime)dataGridView_TargetGroup.SelectedRows[0].Cells[2].Value)}\n" +
                $"Fandom: {(dataGridView_TargetGroup.SelectedRows[0].Cells[3].Value.ToString() != "0" ? DatabaseManager.ShowDataQuery($"SELECT Name FROM [Fandom] WHERE FandomID = {dataGridView_TargetGroup.SelectedRows[0].Cells[3].Value}").Rows[0].Field<string>(0) : "Không có")} (ID: {dataGridView_TargetGroup.SelectedRows[0].Cells[3].Value})\n" +
                $"{dataGridView_TargetGroup.SelectedRows[0].Cells[4].Value}";
        }
    }
}
