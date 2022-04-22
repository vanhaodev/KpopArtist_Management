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
    public partial class Intermediary_Fandom : Form
    {
        int artistID, groupID;
        public Intermediary_Fandom(int artistID, int groupID)
        {
            InitializeComponent();
            this.artistID = artistID;
            this.groupID = groupID;
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
            
            
            if (artistID > 0)
            {              
                if(ModelArtist.Instance.Fandom.FandomID != 0)
                {
                    targetFandom = DatabaseManager.ShowDataQuery($"SELECT * FROM [Fandom] WHERE FandomID = {ModelArtist.Instance.Fandom.FandomID}");
                }    
                else
                {
                    targetFandom = DatabaseManager.ShowDataQuery(
                    $"SELECT _Fandom.* FROM [Fandom] _Fandom " +
                    $"LEFT JOIN [Artist] _Artist ON _Artist.FandomID = _Fandom.FandomID " +
                    $"WHERE _Artist.ArtistID = {artistID}"
                    );
                }    

            }
            else if (groupID > 0)
            {
                targetFandom = DatabaseManager.ShowDataStoredProcedure("Group_GetFandom", groupID.ToString());               
            }
            else if(artistID == 0 && groupID == 0)
            {
                if (ModelArtist.Instance.Fandom != null && ModelArtist.Instance.Fandom.FandomID != 0)
                {
                    targetFandom = DatabaseManager.ShowDataQuery($"SELECT * FROM [Fandom] WHERE FandomID = {ModelArtist.Instance.Fandom.FandomID}");
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
                ModelArtist.Instance.Fandom.FandomID = (int)targetFandom.Rows[0][0];
                ModelArtist.Instance.Fandom.FandomName = targetFandom.Rows[0][1].ToString();
                ModelArtist.Instance.Fandom.Description = targetFandom.Rows[0][2].ToString();
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

            ModelArtist.Instance.Fandom.FandomID = (int)dataGridView_DatabaseFandom.SelectedRows[0].Cells[0].Value;
            ModelArtist.Instance.Fandom.FandomName = dataGridView_DatabaseFandom.SelectedRows[0].Cells[1].Value.ToString();
            ModelArtist.Instance.Fandom.Description = dataGridView_DatabaseFandom.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btnClearFandom_Click(object sender, EventArgs e)
        {
            label_selectedFandomInfor.Text = "Không có fandom";
            ModelArtist.Instance.Fandom = new ModelFandom();
        }

        void LoadDesign()
        {
            //database
            DatagridViewStyle.DarkStyle(dataGridView_DatabaseFandom);
            DatagridViewStyle.MinimumWidth(dataGridView_DatabaseFandom, 100);
        }

    }
}
