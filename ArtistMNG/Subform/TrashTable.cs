using ArtistMNG.Module;
using ArtistMNG.Module.SQL;
using ArtistMNG.Module.SQL.CUD;
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
    public partial class TrashTable : Form
    {
        public TrashTable()
        {
            InitializeComponent();
        }

        private void TrashTable_Load(object sender, EventArgs e)
        {
            //Album
            DatagridViewStyle.DarkStyle(dataGridViewData);
            LoadData();
        }
        void LoadData()
        {
            dataGridViewData.DataSource = DatabaseManager.ShowDataQuery("Artist_Trash");
        }

        private void btnApplyRestore_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn khôi phục?", "Khôi phục", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            for (int i = 0; i < dataGridViewData.SelectedRows.Count; i++)
            {
                if (!DatabaseManager.QueryNonReturn($"UPDATE [Artist] SET IsActivate = 1 WHERE ArtistID = {(int)dataGridViewData.SelectedRows[i].Cells[0].Value}"))
                {
                    MessageBox.Show($"Có lỗi tại id {(int)dataGridViewData.SelectedRows[i].Cells[0].Value}");
                    LoadData();
                    return;
                }
            }
            LoadData();
        }

        private void btnApplyRestoreAll_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn khôi phục?", "Khôi phục tất cả", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            for (int i = 0; i < dataGridViewData.Rows.Count; i++)
            {
                if (!DatabaseManager.QueryNonReturn($"UPDATE [Artist] SET IsActivate = 1 WHERE ArtistID = {(int)dataGridViewData.Rows[i].Cells[0].Value}"))
                {
                    MessageBox.Show($"Có lỗi tại id {(int)dataGridViewData.Rows[i].Cells[0].Value}");
                    LoadData();
                    return;
                }
            }
            LoadData();
        }

        private void btnApplyDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            for (int i = 0; i < dataGridViewData.SelectedRows.Count; i++)
            {
                QueryData.Instance.Artist.ArtistID = (int)dataGridViewData.SelectedRows[i].Cells[0].Value;
                if(!ArtistCUD.Delete(DatabaseExecuteState.Delete))
                {
                    MessageBox.Show($"Có lỗi tại id {QueryData.Instance.Artist.ArtistID}");
                    LoadData();
                    return;
                }    
            }
            LoadData();
        }

        private void btnApplyDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xóa hết?", "Xóa tất cả", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            for (int i = 0; i < dataGridViewData.Rows.Count; i++)
            {
                QueryData.Instance.Artist.ArtistID = (int)dataGridViewData.Rows[i].Cells[0].Value;
                if (!ArtistCUD.Delete(DatabaseExecuteState.Delete))
                {
                    MessageBox.Show($"Có lỗi tại id {QueryData.Instance.Artist.ArtistID}");
                    LoadData();
                    return;
                }
            }
            LoadData();
        }
    }
}
