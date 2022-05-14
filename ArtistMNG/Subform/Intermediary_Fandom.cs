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
    public partial class Intermediary_Fandom : Form
    {
        public Intermediary_Fandom()
        {
            InitializeComponent();
            LoadDesign();
        }

        private void Intermediary_Fandom_Load(object sender, EventArgs e)
        {

            dataGridView_DatabaseFandom.Columns.Add("FandomID", "FandomID");
            dataGridView_DatabaseFandom.Columns.Add("Name", "Name");
            dataGridView_DatabaseFandom.Columns.Add("Description", "Description");

            DataTable databaseFandom = DatabaseManager.ShowData(DatabaseTable.Fandom, "*");
            for (int i = 0; i < databaseFandom.Rows.Count; i++)
            {
                dataGridView_DatabaseFandom.Rows.Add(databaseFandom.Rows[i][0], databaseFandom.Rows[i][1], databaseFandom.Rows[i][2]);
            }

            loadGridView();
        }
        void loadGridView()
        {
            DataTable targetFandom = new DataTable();
            //QueryData.Instance.Artist

            if (frmApp.currentTable == DatabaseTable.Artist)
            {
                targetFandom = DatabaseManager.ShowDataQuery($"SELECT * FROM [Fandom] WHERE FandomID = {QueryData.Instance.Artist.Fandom.FandomID}");

            }
            else if (frmApp.currentTable == DatabaseTable.Group)
            {
                targetFandom = DatabaseManager.ShowDataQuery($"SELECT * FROM [Fandom] WHERE FandomID = {QueryData.Instance.Group.Fandom.FandomID}");
            }
   

            
            if(targetFandom.Rows.Count > 1 || targetFandom.Rows.Count == 0)
            {
                label_selectedFandomInfor.Text = "Không có fandom";
            }    
            else
            {
                label_selectedFandomInfor.Text =
                    $"ID: {targetFandom.Rows[0][0]}\n" +
                    $"Tên: {targetFandom.Rows[0][1]}\n\n" +
                    $"Mô tả: {targetFandom.Rows[0][2]}";
                
                //Dành cho Artist
                if (frmApp.currentTable == DatabaseTable.Artist)
                {
                    QueryData.Instance.Artist.Fandom.FandomID = (int)targetFandom.Rows[0][0];
                    QueryData.Instance.Artist.Fandom.FandomName = targetFandom.Rows[0][1].ToString();
                    QueryData.Instance.Artist.Fandom.Description = targetFandom.Rows[0][2].ToString();
                }
                //Dành cho Group
                else if (frmApp.currentTable == DatabaseTable.Group)
                {
                    QueryData.Instance.Group.Fandom.FandomID = (int)targetFandom.Rows[0][0];
                    QueryData.Instance.Group.Fandom.FandomName = targetFandom.Rows[0][1].ToString();
                    QueryData.Instance.Group.Fandom.Description = targetFandom.Rows[0][2].ToString();
                }
            }

            cbxSearchDatabaseFandomType.SelectedIndex = 1;
        }

        private void btnAddFandomFromDbToArtist_Click(object sender, EventArgs e)
        {
            if (dataGridView_DatabaseFandom.SelectedRows.Count < 1 || dataGridView_DatabaseFandom.SelectedRows.Count > 1)
            {
                MessageBox.Show("Chọn 1 hàng bên database để chuyển sang!");
                return;
            }

            label_selectedFandomInfor.Text =
                    $"ID: {dataGridView_DatabaseFandom.SelectedRows[0].Cells[0].Value}\n" +
                    $"Tên: {dataGridView_DatabaseFandom.SelectedRows[0].Cells[1].Value}\n\n" +
                    $"Mô tả: {dataGridView_DatabaseFandom.SelectedRows[0].Cells[2].Value}";

            //Dành cho Artist
            if(frmApp.currentTable == DatabaseTable.Artist)
            {
                QueryData.Instance.Artist.Fandom.FandomID = (int)dataGridView_DatabaseFandom.SelectedRows[0].Cells[0].Value;
                QueryData.Instance.Artist.Fandom.FandomName = dataGridView_DatabaseFandom.SelectedRows[0].Cells[1].Value.ToString();
                QueryData.Instance.Artist.Fandom.Description = dataGridView_DatabaseFandom.SelectedRows[0].Cells[2].Value.ToString();
            }    
            //Dành cho Group
            else if(frmApp.currentTable == DatabaseTable.Group)
            {
                QueryData.Instance.Group.Fandom.FandomID = (int)dataGridView_DatabaseFandom.SelectedRows[0].Cells[0].Value;
                QueryData.Instance.Group.Fandom.FandomName = dataGridView_DatabaseFandom.SelectedRows[0].Cells[1].Value.ToString();
                QueryData.Instance.Group.Fandom.Description = dataGridView_DatabaseFandom.SelectedRows[0].Cells[2].Value.ToString();
            }
        }

        private void btnClearFandom_Click(object sender, EventArgs e)
        {
            label_selectedFandomInfor.Text = "Không có fandom";         
            //Dành cho Artist
            if (frmApp.currentTable == DatabaseTable.Artist)
            {
                QueryData.Instance.Artist.Fandom = new ModelFandom();
            }
            //Dành cho Group
            else if (frmApp.currentTable == DatabaseTable.Group)
            {
                QueryData.Instance.Group.Fandom = new ModelFandom();
            }    
        }

        void LoadDesign()
        {
            this.Icon = ImageFile.SetWindowIcon("AMlogo.ico");
            switch(frmApp.currentTable)
            {
                case DatabaseTable.Artist:
                    this.Text = "Nghệ sĩ (Fandom)";
                    break;
                case DatabaseTable.Group:
                    this.Text = "Nhóm (Fandom)";
                    break;
            }
            btnSearchDatabaseFandom.Image = (Image)(new Bitmap(ImageFile.SetIconFromFolder("search.png"), new Size(32, 32)));
            btnSearchDatabaseFandom.ImageAlign = ContentAlignment.MiddleLeft;
            //database
            DatagridViewStyle.DarkStyle(dataGridView_DatabaseFandom);
            DatagridViewStyle.MinimumWidth(dataGridView_DatabaseFandom, 100);

            //Label set size
            label_selectedFandomInfor.MaximumSize = new Size(groupBox_CurrentFandomInfor.Width - (groupBox_CurrentFandomInfor.Width * 10 / 100), 0);
            label_selectedFandomInfor.AutoSize = true;
            groupBox2.Paint += PaintBorderlessGroupBox;
            groupBox6.Paint += PaintBorderlessGroupBox;
            groupBox_CurrentFandomInfor.Paint += PaintBorderlessGroupBox;

        }
        void PaintBorderlessGroupBox(object sender, PaintEventArgs e)
        {
            GroupBoxStyle.PaintBorderlessGroupBox(sender, e, this);
        }

        private void btnSearchDatabaseFandom_Click(object sender, EventArgs e)
        {
            if (txValueSearchDatabaseFandom.Text.Length < 1 || cbxSearchDatabaseFandomType.SelectedIndex == 0)
            {
                return;
            }
            if (txValueSearchDatabaseFandom.Text.Contains("'"))
            {
                MessageBox.Show("Giá trị tìm kiếm không hợp lệ!");
                return;
            }
            DataTable database = null;
            switch (cbxSearchDatabaseFandomType.SelectedIndex)
            {
                case 1:
                    if (Regex.IsMatch(txValueSearchDatabaseFandom.Text, @"^\d$")) //Regex only số
                    {
                        database = DatabaseManager.ShowDataQuery($"SELECT * FROM [Fandom] WHERE FandomID = {txValueSearchDatabaseFandom.Text}");
                    }
                    else
                    {
                        MessageBox.Show("ID chỉ tồn tại số nguyên!");
                        return;
                    }

                    break;
                case 2:
                    database = DatabaseManager.ShowDataQuery($"SELECT * FROM [Fandom] WHERE Name LIKE '%{txValueSearchDatabaseFandom.Text}%'");
                    break;
                case 3:
                    database = DatabaseManager.ShowDataQuery($"SELECT * FROM [Fandom] WHERE Description LIKE '%{txValueSearchDatabaseFandom.Text}%'");
                    break;
            }
            ResultSearch(database);


        }

        private void cbxSearchDatabaseFandomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxSearchDatabaseFandomType.SelectedIndex == 0)
            {
                ResultSearch(DatabaseManager.ShowDataQuery("SELECT * FROM [Fandom]"));
            }    
        }
        void ResultSearch(DataTable database)
        {
            if (database != null)
            {
                dataGridView_DatabaseFandom.Rows.Clear();
                for (int i = 0; i < database.Rows.Count; i++)
                {
                    dataGridView_DatabaseFandom.Rows.Add(
                        database.Rows[i][0],
                        database.Rows[i][1],
                        database.Rows[i][2]);
                }
            }
        }
    }
}
