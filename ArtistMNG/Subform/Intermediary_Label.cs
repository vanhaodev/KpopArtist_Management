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
    public partial class Intermediary_Label : Form
    {
        public Intermediary_Label()
        {
            InitializeComponent();
            LoadDesign();
        }

        private void Intermediary_Fandom_Load(object sender, EventArgs e)
        {

            dataGridView_DatabaseLabel.Columns.Add("LabelID", "ID");
            dataGridView_DatabaseLabel.Columns.Add("Name", "Tên");
            dataGridView_DatabaseLabel.Columns.Add("Founder", "Người t.lập");
            dataGridView_DatabaseLabel.Columns.Add("Founded", "Ngày lập");
            dataGridView_DatabaseLabel.Columns.Add("Location", "Địa điểm");
            dataGridView_DatabaseLabel.Columns.Add("Description", "Mô tả");

            DataTable database = DatabaseManager.ShowData(DatabaseTable.Label, "*");
            for (int i = 0; i < database.Rows.Count; i++)
            {
                dataGridView_DatabaseLabel.Rows.Add(
                    database.Rows[i][0], 
                    database.Rows[i][1], 
                    database.Rows[i][2],
                    database.Rows[i][3],
                    database.Rows[i][4],
                    database.Rows[i][5]);
            }

            loadGridView();
        }
        void loadGridView()
        {
            DataTable target = new DataTable();
            //QueryData.Instance.Artist

            if (frmApp.currentTable == DatabaseTable.Artist)
            {
                target = DatabaseManager.ShowDataQuery($"SELECT * FROM [Label] WHERE LabelID = {QueryData.Instance.Artist.Label.LabelID}");

            }
            else if (frmApp.currentTable == DatabaseTable.Group)
            {
                target = DatabaseManager.ShowDataQuery($"SELECT * FROM [Label] WHERE LabelID = {QueryData.Instance.Group.Label.LabelID}");
            }



            if (target.Rows.Count > 1 || target.Rows.Count == 0)
            {
                label_selectedLabelInfor.Text = "Không có công ty";
            }
            else
            {
                label_selectedLabelInfor.Text =
                    $"ID: {target.Rows[0][0]}\n" +
                    $"Tên: {target.Rows[0][1]}\n" +
                    $"Người thành lập: {target.Rows[0][2]}\n" +
                    $"Ngày thành lập: {TimerType.VietnamTimeType((DateTime)target.Rows[0][3])}\n" +
                    $"Địa điểm: {target.Rows[0][4]}\n\n" +
                    $"{target.Rows[0][5]}";

                if(frmApp.currentTable == DatabaseTable.Artist)
                {
                    QueryData.Instance.Artist.Label.LabelID = (int)target.Rows[0][0];
                    QueryData.Instance.Artist.Label.LabelName = target.Rows[0][1].ToString();
                    QueryData.Instance.Artist.Label.Founder = target.Rows[0][2].ToString();
                    QueryData.Instance.Artist.Label.Founded = (DateTime)target.Rows[0][3];
                    QueryData.Instance.Artist.Label.Location = target.Rows[0][4].ToString();
                    QueryData.Instance.Artist.Label.Description = target.Rows[0][5].ToString();
                }    
                else if(frmApp.currentTable == DatabaseTable.Group)
                {
                    QueryData.Instance.Group.Label.LabelID = (int)target.Rows[0][0];
                    QueryData.Instance.Group.Label.LabelName = target.Rows[0][1].ToString();
                    QueryData.Instance.Group.Label.Founder = target.Rows[0][2].ToString();
                    QueryData.Instance.Group.Label.Founded = (DateTime)target.Rows[0][3];
                    QueryData.Instance.Group.Label.Location = target.Rows[0][4].ToString();
                    QueryData.Instance.Group.Label.Description = target.Rows[0][5].ToString();
                }    
            }

            cbxSearchDatabaseLabelType.SelectedIndex = 1;
        }
        private void btnAddLabelFromDbToArtist_Click(object sender, EventArgs e)
        {
            if (dataGridView_DatabaseLabel.SelectedRows.Count < 1 || dataGridView_DatabaseLabel.SelectedRows.Count > 1)
            {
                MessageBox.Show("Chọn 1 hàng bên database để chuyển sang!");
                return;
            }

            label_selectedLabelInfor.Text =
                    $"ID: {dataGridView_DatabaseLabel.SelectedRows[0].Cells[0].Value}\n" +
                    $"Tên: {dataGridView_DatabaseLabel.SelectedRows[0].Cells[1].Value}\n" +
                    $"Người t.lập: {dataGridView_DatabaseLabel.SelectedRows[0].Cells[2].Value}\n"+
                    $"Ngày lập: {TimerType.VietnamTimeType((DateTime)dataGridView_DatabaseLabel.SelectedRows[0].Cells[3].Value)}\n"+
                    $"Địa điểm: {dataGridView_DatabaseLabel.SelectedRows[0].Cells[4].Value}\n\n" +
                    $"{dataGridView_DatabaseLabel.SelectedRows[0].Cells[5].Value}";

            if(frmApp.currentTable == DatabaseTable.Artist)
            {
                QueryData.Instance.Artist.Label.LabelID = (int)dataGridView_DatabaseLabel.SelectedRows[0].Cells[0].Value;
                QueryData.Instance.Artist.Label.LabelName = dataGridView_DatabaseLabel.SelectedRows[0].Cells[1].Value.ToString();
                QueryData.Instance.Artist.Label.Founder = dataGridView_DatabaseLabel.SelectedRows[0].Cells[2].Value.ToString();
                QueryData.Instance.Artist.Label.Founded = (DateTime)dataGridView_DatabaseLabel.SelectedRows[0].Cells[3].Value;
                QueryData.Instance.Artist.Label.Location = dataGridView_DatabaseLabel.SelectedRows[0].Cells[4].Value.ToString();
                QueryData.Instance.Artist.Label.Description = dataGridView_DatabaseLabel.SelectedRows[0].Cells[5].Value.ToString();
            }    
            else if(frmApp.currentTable == DatabaseTable.Group)
            {
                QueryData.Instance.Group.Label.LabelID = (int)dataGridView_DatabaseLabel.SelectedRows[0].Cells[0].Value;
                QueryData.Instance.Group.Label.LabelName = dataGridView_DatabaseLabel.SelectedRows[0].Cells[1].Value.ToString();
                QueryData.Instance.Group.Label.Founder = dataGridView_DatabaseLabel.SelectedRows[0].Cells[2].Value.ToString();
                QueryData.Instance.Group.Label.Founded = (DateTime)dataGridView_DatabaseLabel.SelectedRows[0].Cells[3].Value;
                QueryData.Instance.Group.Label.Location = dataGridView_DatabaseLabel.SelectedRows[0].Cells[4].Value.ToString();
                QueryData.Instance.Group.Label.Description = dataGridView_DatabaseLabel.SelectedRows[0].Cells[5].Value.ToString();
            }    
        }

        private void btnClearFandom_Click(object sender, EventArgs e)
        {
            label_selectedLabelInfor.Text = "Không có công ty";
            if(frmApp.currentTable == DatabaseTable.Artist)
            {
                QueryData.Instance.Artist.Label = new ModelLabel();
            }    
            else if (frmApp.currentTable == DatabaseTable.Group)
            {
                QueryData.Instance.Group.Label = new ModelLabel();
            }    
        }

        void LoadDesign()
        {
            this.Icon = ImageFile.SetWindowIcon("AMlogo.ico");
            switch(frmApp.currentTable)
            {
                case DatabaseTable.Artist:
                    this.Text = "Nghệ sĩ (Công ty)";
                    break;
                case DatabaseTable.Group:
                    this.Text = "Nhóm (Công ty)";
                    break;
            }
            
            //database
            DatagridViewStyle.DarkStyle(dataGridView_DatabaseLabel);
            DatagridViewStyle.MinimumWidth(dataGridView_DatabaseLabel, 100);

            btnSearchDatabaseLabel.Image = (Image)(new Bitmap(ImageFile.SetIconFromFolder("search.png"), new Size(32, 32)));
            btnSearchDatabaseLabel.ImageAlign = ContentAlignment.MiddleLeft;
            //Label set size
            label_selectedLabelInfor.MaximumSize = new Size(groupBox_CurrentLabelInfor.Width - (groupBox_CurrentLabelInfor.Width * 10 / 100), 0);
            label_selectedLabelInfor.AutoSize = true;
            groupBox2.Paint += PaintBorderlessGroupBox;
            groupBox6.Paint += PaintBorderlessGroupBox;
            groupBox_CurrentLabelInfor.Paint += PaintBorderlessGroupBox;

        }
        void PaintBorderlessGroupBox(object sender, PaintEventArgs e)
        {
            GroupBoxStyle.PaintBorderlessGroupBox(sender, e, this);
        }

        private void btnSearchDatabaseFandom_Click(object sender, EventArgs e)
        {
            if (txValueSearchDatabaseLabel.Text.Length < 1 || cbxSearchDatabaseLabelType.SelectedIndex == 0)
            {
                return;
            }
            if (txValueSearchDatabaseLabel.Text.Contains("'"))
            {
                MessageBox.Show("Giá trị tìm kiếm không hợp lệ!");
                return;
            }
            DataTable database = null;
            switch (cbxSearchDatabaseLabelType.SelectedIndex)
            {
                case 1:
                    if (Regex.IsMatch(txValueSearchDatabaseLabel.Text, @"^\d$")) //Regex only số
                    {
                        database = DatabaseManager.ShowDataQuery($"SELECT * FROM [Label] WHERE LabelID = {txValueSearchDatabaseLabel.Text}");
                    }
                    else
                    {
                        MessageBox.Show("ID chỉ tồn tại số nguyên!");
                        return;
                    }

                    break;
                case 2:
                    database = DatabaseManager.ShowDataQuery($"SELECT * FROM [Label] WHERE Name LIKE '%{txValueSearchDatabaseLabel.Text}%'");
                    break;
                case 3:
                    database = DatabaseManager.ShowDataQuery($"SELECT * FROM [Label] WHERE Founder LIKE '%{txValueSearchDatabaseLabel.Text}%'");
                    break;
                case 4:
                    database = DatabaseManager.ShowDataQuery($"SELECT * FROM [Label] WHERE Description LIKE '%{txValueSearchDatabaseLabel.Text}%'");
                    break;
            }
            ResultSearch(database);


        }

        private void cbxSearchDatabaseFandomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxSearchDatabaseLabelType.SelectedIndex == 0)
            {
                ResultSearch(DatabaseManager.ShowDataQuery("SELECT * FROM [Label]"));
            }    
        }
        void ResultSearch(DataTable database)
        {
            if (database != null)
            {
                dataGridView_DatabaseLabel.Rows.Clear();
                for (int i = 0; i < database.Rows.Count; i++)
                {
                    dataGridView_DatabaseLabel.Rows.Add(
                        database.Rows[i][0],
                        database.Rows[i][1],
                        database.Rows[i][2],
                        database.Rows[i][3],
                        database.Rows[i][4],
                        database.Rows[i][5]);
                }
            }
        }

        
    }
}
