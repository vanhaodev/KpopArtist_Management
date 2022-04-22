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
    public partial class Intermediary_Group : Form
    {
        int artistID;
        public Intermediary_Group(int artistID)
        {
            InitializeComponent();
            this.artistID = artistID;
            LoadDesign();
        }
        void LoadDesign()
        {
            btnApplyAdd.Enabled = true;
            btnApplyDelete.Enabled = false;
            btnApplyEdit.Enabled = false;

            //Target image
            DatagridViewStyle.DarkStyle(dataGridView_TargetGroup);
            DatagridViewStyle.MinimumWidth(dataGridView_TargetGroup, 100);

            //database
            DatagridViewStyle.DarkStyle(dataGridView_DatabaseGroup);
            DatagridViewStyle.MinimumWidth(dataGridView_DatabaseGroup, 100);

            pictureBox_GroupImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_GroupImage.SizeMode = PictureBoxSizeMode.Zoom;
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
            if (artistID > 0)
            {
                var targetImage = DatabaseManager.ShowDataStoredProcedure("Artist_GetGroup", artistID.ToString());
                for (int i = 0; i < targetImage.Rows.Count; i++)
                {
                    dataGridView_TargetGroup.Rows.Add(targetImage.Rows[i][0], targetImage.Rows[i][1], targetImage.Rows[i][2], targetImage.Rows[i][3], targetImage.Rows[i][4]);
                }

                //set delete  
                for (int i = 0; i < ModelArtist.Instance.ArtistGroup_Delete.Count; i++)
                {
                    for (int j = dataGridView_TargetGroup.Rows.Count - 1; j >= 0; j--)
                    {
                        if (ModelArtist.Instance.ArtistGroup_Delete[i].GroupID == (int)dataGridView_TargetGroup.Rows[j].Cells[0].Value)
                        {
                            dataGridView_TargetGroup.Rows.RemoveAt(j);
                        }
                    }
                }
            }

            if (artistID == 0) //arttis id là 0 thì gọi group data
            {

            }


        }
    }
}
