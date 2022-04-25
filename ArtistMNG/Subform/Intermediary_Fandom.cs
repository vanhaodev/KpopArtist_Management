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

            if (QueryData.Instance.Artist.ArtistID > 0)
            {              
                if(QueryData.Instance.Artist.Fandom.FandomID != 0)
                {
                    targetFandom = DatabaseManager.ShowDataQuery($"SELECT * FROM [Fandom] WHERE FandomID = {QueryData.Instance.Artist.Fandom.FandomID}");
                }    
                else
                {
                    targetFandom = DatabaseManager.ShowDataQuery(
                    $"SELECT _Fandom.* FROM [Fandom] _Fandom " +
                    $"LEFT JOIN [Artist] _Artist ON _Artist.FandomID = _Fandom.FandomID " +
                    $"WHERE _Artist.ArtistID = {QueryData.Instance.Artist.ArtistID}"
                    );
                }    

            }
            else if (QueryData.Instance.Group.GroupID > 0)
            {
                targetFandom = DatabaseManager.ShowDataStoredProcedure("Group_GetFandom", QueryData.Instance.Group.GroupID.ToString());               
            }
            else if(QueryData.Instance.Artist.ArtistID == 0 && QueryData.Instance.Group.GroupID == 0)
            {
                if (QueryData.Instance.Artist.Fandom != null && QueryData.Instance.Artist.Fandom.FandomID != 0)
                {
                    targetFandom = DatabaseManager.ShowDataQuery($"SELECT * FROM [Fandom] WHERE FandomID = {QueryData.Instance.Artist.Fandom.FandomID}");
                }
            }    

            
            if(targetFandom.Rows.Count > 1 || targetFandom.Rows.Count == 0)
            {
                label_selectedFandomInfor.Text = "Không có fandom";
            }    
            else
            {
                label_selectedFandomInfor.Text =
                    $"ID: {targetFandom.Rows[0][0]}\n" +
                    $"Tên: {targetFandom.Rows[0][1]}\n" +
                    $"Mô tả: {targetFandom.Rows[0][2]}";
                QueryData.Instance.Artist.Fandom.FandomID = (int)targetFandom.Rows[0][0];
                QueryData.Instance.Artist.Fandom.FandomName = targetFandom.Rows[0][1].ToString();
                QueryData.Instance.Artist.Fandom.Description = targetFandom.Rows[0][2].ToString();
            }

            
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
                    $"Tên: {dataGridView_DatabaseFandom.SelectedRows[0].Cells[1].Value}\n" +
                    $"Mô tả: {dataGridView_DatabaseFandom.SelectedRows[0].Cells[2].Value}";

            QueryData.Instance.Artist.Fandom.FandomID = (int)dataGridView_DatabaseFandom.SelectedRows[0].Cells[0].Value;
            QueryData.Instance.Artist.Fandom.FandomName = dataGridView_DatabaseFandom.SelectedRows[0].Cells[1].Value.ToString();
            QueryData.Instance.Artist.Fandom.Description = dataGridView_DatabaseFandom.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btnClearFandom_Click(object sender, EventArgs e)
        {
            label_selectedFandomInfor.Text = "Không có fandom";
            QueryData.Instance.Artist.Fandom = new ModelFandom();
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
            
            //database
            DatagridViewStyle.DarkStyle(dataGridView_DatabaseFandom);
            DatagridViewStyle.MinimumWidth(dataGridView_DatabaseFandom, 100);

            //Label set size
            label_selectedFandomInfor.MaximumSize = new Size(groupBox_CurrentFandomInfor.Width - (groupBox_CurrentFandomInfor.Width * 10 / 100), 0);
            label_selectedFandomInfor.AutoSize = true;
            groupBox2.Paint += PaintBorderlessGroupBox;
            groupBox6.Paint += PaintBorderlessGroupBox;

        }
        void PaintBorderlessGroupBox(object sender, PaintEventArgs e)
        {
            GroupBoxStyle.PaintBorderlessGroupBox(sender, e, this);
        }

    }
}
