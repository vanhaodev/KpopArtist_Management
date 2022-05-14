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
    public partial class Intermediary_Image : Form
    {
        bool isCreateNewRow;

        public Intermediary_Image()
        {
            InitializeComponent();
            LoadDesign();
        }

        private void Intermediary_Image_Load(object sender, EventArgs e)
        {
            dataGridView_DatabaseImage.Columns.Add("ImageID", "ImageID");
            dataGridView_DatabaseImage.Columns.Add("ImageURL", "ImageURL");
            dataGridView_DatabaseImage.Columns.Add("Description", "Description");

            dataGridView_TargetImage.Columns.Add("ImageID", "ImageID");
            dataGridView_TargetImage.Columns.Add("ImageURL", "ImageURL");
            dataGridView_TargetImage.Columns.Add("Description", "Description");

            loadGridView();
        }

        void loadGridView()
        {
            var databaseImage = DatabaseManager.ShowData(DatabaseTable.Image, "*");
            for (int i = 0; i < databaseImage.Rows.Count; i++)
            {
                dataGridView_DatabaseImage.Rows.Add(databaseImage.Rows[i][0], databaseImage.Rows[i][1], databaseImage.Rows[i][2]);
            }
            if (QueryData.Instance.Artist.ArtistID > 0)
            {
                var targetImage = DatabaseManager.ShowDataStoredProcedure("Artist_GetImage", QueryData.Instance.Artist.ArtistID.ToString());
                for (int i = 0; i < targetImage.Rows.Count; i++)
                {
                    dataGridView_TargetImage.Rows.Add(targetImage.Rows[i][0], targetImage.Rows[i][1], targetImage.Rows[i][2]);
                }                  

                //set delete  
                for(int i = 0; i < QueryData.Instance.Artist.ArtistImage_Delete.Count; i++)
                {
                    for (int j = dataGridView_TargetImage.Rows.Count - 1; j >= 0; j--)
                    {
                        if (QueryData.Instance.Artist.ArtistImage_Delete[i].ImageID == (int)dataGridView_TargetImage.Rows[j].Cells[0].Value)
                        {
                            dataGridView_TargetImage.Rows.RemoveAt(j);
                        }
                    }    
                }    
            }
            else if (QueryData.Instance.Group.GroupID > 0)
            {
                var targetImage = DatabaseManager.ShowDataStoredProcedure("Group_GetImage", QueryData.Instance.Group.GroupID.ToString());
                for (int i = 0; i < targetImage.Rows.Count; i++)
                {
                    dataGridView_TargetImage.Rows.Add(targetImage.Rows[i][0], targetImage.Rows[i][1], targetImage.Rows[i][2]);
                }
            }

            if(QueryData.Instance.Group.GroupID == 0) //group id là 0 thì gọi artist data
            {
                for (int i = 0; i < QueryData.Instance.Artist.ArtistImage_Add.Count; i++)
                {
                    dataGridView_TargetImage.Rows.Add(QueryData.Instance.Artist.ArtistImage_Add[i].ImageID, QueryData.Instance.Artist.ArtistImage_Add[i].ImageURL, QueryData.Instance.Artist.ArtistImage_Add[i].Description);
                }
            }
            else if (QueryData.Instance.Group.GroupID == 0) //arttis id là 0 thì gọi group data
            {
                
            }
            cbxSearchDatabaseImageType.SelectedIndex = 1;

        }

        private void btnCheckImage_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox_Image.Load(tx_ImageURL.Text);
            }
            catch
            {
                MessageBox.Show("Ảnh không hợp lệ!");
            }
        }

        private void dataGridView_DatabaseImage_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_DatabaseImage.SelectedRows.Count < 1 || dataGridView_DatabaseImage.SelectedRows.Count > 1) return;
            try
            {
                pictureBox_DatabaseImage.LoadAsync(dataGridView_DatabaseImage.SelectedRows[0].Cells[1].Value.ToString());
            }
            catch
            {
                MessageBox.Show("Ảnh không hợp lệ!");
            }
        }

        private void dataGridView_TargetImage_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_TargetImage.SelectedRows.Count < 1 || dataGridView_TargetImage.SelectedRows.Count > 1) return;
            tx_ImageURL.Text = dataGridView_TargetImage.SelectedRows[0].Cells[1].Value.ToString();
            txImageDescription.Text = dataGridView_TargetImage.SelectedRows[0].Cells[2].Value.ToString();
            try
            {
                pictureBox_Image.LoadAsync(dataGridView_TargetImage.SelectedRows[0].Cells[1].Value.ToString());
            }
            catch
            {
                pictureBox_Image = null;
            }
            isCreateNewRow = false;
            btnApplyAdd.Enabled = false;
            btnApplyDelete.Enabled = true;
            btnApplyEdit.Enabled = true;
        }       
        void ClearDataFiled()
        {
            pictureBox_Image.Image = null;
            tx_ImageURL.Text = string.Empty;
            txImageDescription.Text = string.Empty;
        }
        private void btnNewRow_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Khi tạo mới sẽ xóa hết dữ liệu đang nhập trong form!", "Tạo mới", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            ClearDataFiled();
            dataGridView_TargetImage.ClearSelection();
            isCreateNewRow = true;
            btnApplyAdd.Enabled = true;
            btnApplyDelete.Enabled = false;
            btnApplyEdit.Enabled = false;
        }
        private void btnApplyAdd_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox_Image.Load(tx_ImageURL.Text);
            }
            catch
            {
                MessageBox.Show("Ảnh không hợp lệ!");
                return;
            }

            ModelImage modelImage = new ModelImage();
            modelImage.ImageID = 0;
            modelImage.ImageURL = tx_ImageURL.Text;
            modelImage.Description = txImageDescription.Text;
            
            for(int i = 0; i < dataGridView_TargetImage.Rows.Count; i++)
            {
                if(dataGridView_TargetImage.Rows[i].Cells[1].Value.ToString() == modelImage.ImageURL)
                {
                    MessageBox.Show("Đã tồn tại url tương tự!");
                    return;
                }    
            }

            QueryData.Instance.Artist.ArtistImage_Add.Add(modelImage);

            bool artistImageIsContains = false;
            for (int i = 0; i < frmApp.artistImage.Count; i++)
            {
                if (frmApp.artistImage[i] == modelImage.ImageURL)
                {
                    artistImageIsContains = true;
                }
            }
            if (!artistImageIsContains)
            {
                frmApp.artistImage.Add(modelImage.ImageURL);
            }
            dataGridView_TargetImage.Rows.Add(0, tx_ImageURL.Text, txImageDescription.Text);
        }

        private void btnApplyEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView_TargetImage.SelectedRows.Count < 1 || dataGridView_TargetImage.SelectedRows.Count > 1)
            {
                MessageBox.Show("Chọn 1 hàng để sửa!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn sửa?", "Sửa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

          
            if (QueryData.Instance.Artist.ArtistID == 0 && QueryData.Instance.Group.GroupID == 0)
            {               
                for(int i = 0; i < QueryData.Instance.Artist.ArtistImage_Add.Count; i++)
                {
                    if(QueryData.Instance.Artist.ArtistImage_Add[i].ImageURL == dataGridView_TargetImage.SelectedRows[0].Cells[1].Value.ToString())
                    {
                        QueryData.Instance.Artist.ArtistImage_Add[i].ImageURL = tx_ImageURL.Text;
                        QueryData.Instance.Artist.ArtistImage_Add[i].Description = txImageDescription.Text;
                        break;
                    }    
                }    
            }    
            else if(QueryData.Instance.Artist.ArtistID > 0)
            {
                bool isContains = false;
                for (int i = 0; i < QueryData.Instance.Artist.ArtistImage_Update.Count; i++)
                {
                    if (QueryData.Instance.Artist.ArtistImage_Update[i].ImageID == (int)dataGridView_TargetImage.SelectedRows[0].Cells[0].Value)
                    {
                        QueryData.Instance.Artist.ArtistImage_Update[i].ImageURL = tx_ImageURL.Text;
                        QueryData.Instance.Artist.ArtistImage_Update[i].Description = txImageDescription.Text;
                        isContains = true;
                        break;
                    }
                }
                if(!isContains)
                {
                    ModelImage modelImage = new ModelImage();
                    modelImage.ImageID = (int)dataGridView_TargetImage.SelectedRows[0].Cells[1].Value;
                    modelImage.ImageURL = tx_ImageURL.Text;
                    modelImage.Description = txImageDescription.Text;
                    QueryData.Instance.Artist.ArtistImage_Update.Add(modelImage);
                }    
            }   
            else if(QueryData.Instance.Group.GroupID > 0)
            {

            }
            dataGridView_TargetImage.SelectedRows[0].Cells[1].Value = tx_ImageURL.Text;
            dataGridView_TargetImage.SelectedRows[0].Cells[2].Value = txImageDescription.Text;
        }

        private void btnApplyDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView_TargetImage.SelectedRows.Count < 1 || dataGridView_TargetImage.SelectedRows.Count > 1)
            {
                MessageBox.Show("Chọn 1 hàng để xóa!");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn xóa?", "Xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            string selectedUrl = dataGridView_TargetImage.SelectedRows[0].Cells[1].Value.ToString();
            if (QueryData.Instance.Artist.ArtistID == 0 && QueryData.Instance.Group.GroupID == 0)
            {
                //do nothing    
            }    
            else if (QueryData.Instance.Artist.ArtistID > 0)
            {
                ModelImage modelImage = new ModelImage();
                modelImage.ImageID = (int)dataGridView_TargetImage.SelectedRows[0].Cells[0].Value;
                modelImage.ImageURL = dataGridView_TargetImage.SelectedRows[0].Cells[1].Value.ToString();
                modelImage.Description = dataGridView_TargetImage.SelectedRows[0].Cells[2].Value.ToString();

                if (QueryData.Instance.Artist.ArtistImage_Add.Count < 1)
                {
                    MessageBox.Show($"QueryData.Instance.Artist.ArtistImage_Add.Count {QueryData.Instance.Artist.ArtistImage_Add.Count}");
                    QueryData.Instance.Artist.ArtistImage_Delete.Add(modelImage);
                }
                for (int i = 0; i < QueryData.Instance.Artist.ArtistImage_Add.Count; i++)
                {
                    if (QueryData.Instance.Artist.ArtistImage_Add[i].ImageURL == modelImage.ImageURL)
                    {
                        QueryData.Instance.Artist.ArtistImage_Add.RemoveAt(i);                            
                    }
                    else
                    {
                        bool isContains = false;
                        for (int j = 0; j < QueryData.Instance.Artist.ArtistImage_Delete.Count; j++)
                        {
                            if (QueryData.Instance.Artist.ArtistImage_Delete[j].ImageURL == modelImage.ImageURL)
                            {
                                isContains = true;
                            }
                        }

                        if (!isContains)
                        {
                            QueryData.Instance.Artist.ArtistImage_Delete.Add(modelImage);
                        }
                    }
                }

            }
            else if (QueryData.Instance.Group.GroupID > 0)
            {

            }
            if(QueryData.Instance.Group.GroupID == 0)
            {
                
            }   
            if(QueryData.Instance.Artist.ArtistID == 0)
            {
                //set delete  
                for (int i = 0; i < QueryData.Instance.Artist.ArtistImage_Add.Count; i++)
                {
                    if (QueryData.Instance.Artist.ArtistImage_Add[i].ImageURL == dataGridView_TargetImage.SelectedRows[0].Cells[1].Value.ToString())
                    {
                        QueryData.Instance.Artist.ArtistImage_Add.RemoveAt(i);
                    }
                }   
            }

            for (int i = frmApp.artistImage.Count - 1; i >= 0; i--)
            {
                if (frmApp.artistImage[i] == selectedUrl)
                {
                    frmApp.artistImage.RemoveAt(i);
                }
            }
            dataGridView_TargetImage.Rows.RemoveAt(dataGridView_TargetImage.SelectedRows[0].Index);
        }

        private void btnAddImageFromDbToArtist_Click(object sender, EventArgs e)
        {
            if (dataGridView_DatabaseImage.SelectedRows.Count < 1 || dataGridView_DatabaseImage.SelectedRows.Count > 1)
            {
                MessageBox.Show("Chọn 1 hàng bên database để chuyển sang!");
                return;
            }
            bool isContains = false;
            for(int i = 0; i < dataGridView_TargetImage.Rows.Count; i++)
            {
                if((int)dataGridView_TargetImage.Rows[i].Cells[0].Value == (int)dataGridView_DatabaseImage.SelectedRows[0].Cells[0].Value)
                {                   
                    isContains = true;
                }                    
            }    
            for(int i = 0; i < QueryData.Instance.Artist.ArtistImage_Add.Count; i++)
            {
                if(QueryData.Instance.Artist.ArtistImage_Add[i].ImageID == (int)dataGridView_DatabaseImage.SelectedRows[0].Cells[0].Value)
                {
                    isContains = true;
                }    
            }  
            
            if(!isContains)
            {
                ModelImage modelImage = new ModelImage();
                modelImage.ImageID = (int)dataGridView_DatabaseImage.SelectedRows[0].Cells[0].Value;
                modelImage.ImageURL = dataGridView_DatabaseImage.SelectedRows[0].Cells[1].Value.ToString();
                modelImage.Description = dataGridView_DatabaseImage.SelectedRows[0].Cells[2].Value.ToString();
                QueryData.Instance.Artist.ArtistImage_Add.Add(modelImage);
                dataGridView_TargetImage.Rows.Add(dataGridView_DatabaseImage.SelectedRows[0].Cells[0].Value, dataGridView_DatabaseImage.SelectedRows[0].Cells[1].Value, dataGridView_DatabaseImage.SelectedRows[0].Cells[2].Value);

                bool artistImageIsContains = false;
                for (int i = 0; i < frmApp.artistImage.Count; i++)
                {
                    if (frmApp.artistImage[i] == modelImage.ImageURL)
                    {
                        artistImageIsContains = true;
                    }
                }
                if (!artistImageIsContains)
                {
                    frmApp.artistImage.Add(modelImage.ImageURL);
                }
                for(int i = 0; i < QueryData.Instance.Artist.ArtistImage_Delete.Count; i++)
                {
                    if(QueryData.Instance.Artist.ArtistImage_Delete[i].ImageURL == modelImage.ImageURL)
                    {
                        QueryData.Instance.Artist.ArtistImage_Delete.RemoveAt(i);
                    }
                }
            }   
            else
            {
                MessageBox.Show("Đã tồn tại dữ liệu tương tự!");
            }
            //MessageBox.Show($"QueryData.Instance.Artist.ArtistImage_Add.Count {QueryData.Instance.Artist.ArtistImage_Add.Count}");
        }

        void LoadDesign()
        {
            this.Icon = ImageFile.SetWindowIcon("AMlogo.ico");
            switch(frmApp.currentTable)
            {
                case DatabaseTable.Artist:
                    this.Text = "Nghệ sĩ (Ảnh)";
                    break;
                case DatabaseTable.Group:
                    this.Text = "Nhóm (Ảnh)";
                    break;
                case DatabaseTable.Song:
                    this.Text = "Bài hát (Ảnh)";
                    break;
                case DatabaseTable.Album:
                    this.Text = "Album (Ảnh)";
                    break;
                case DatabaseTable.Label:
                    this.Text = "Công ty (Ảnh)";
                    break;
            }
            btnApplyAdd.Enabled = true;
            btnApplyDelete.Enabled = false;
            btnApplyEdit.Enabled = false;

            btnSearchDatabaseImage.Image = (Image)(new Bitmap(ImageFile.SetIconFromFolder("search.png"), new Size(32, 32)));
            btnSearchDatabaseImage.ImageAlign = ContentAlignment.MiddleLeft;
            //Target image
            DatagridViewStyle.DarkStyle(dataGridView_TargetImage);
            DatagridViewStyle.MinimumWidth(dataGridView_TargetImage, 100);

            //database
            DatagridViewStyle.DarkStyle(dataGridView_DatabaseImage);
            DatagridViewStyle.MinimumWidth(dataGridView_DatabaseImage, 100);

            pictureBox_Image.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_DatabaseImage.SizeMode = PictureBoxSizeMode.Zoom;
            groupBox1.Paint += PaintBorderlessGroupBox;
            groupBox2.Paint += PaintBorderlessGroupBox;
            groupBox3.Paint += PaintBorderlessGroupBox;
            groupBox4.Paint += PaintBorderlessGroupBox;
            groupBox5.Paint += PaintBorderlessGroupBox;
            groupBox6.Paint += PaintBorderlessGroupBox;
            
        }
        void PaintBorderlessGroupBox(object sender, PaintEventArgs e)
        {
            GroupBoxStyle.PaintBorderlessGroupBox(sender, e, this);
        }

        private void btnSearchDatabaseImage_Click(object sender, EventArgs e)
        {
            if (txValueSearchDatabaseImage.Text.Length < 1 || cbxSearchDatabaseImageType.SelectedIndex == 0)
            {
                return;
            }
            DataTable database = null;
            switch (cbxSearchDatabaseImageType.SelectedIndex)
            {
                case 1:
                    if (Regex.IsMatch(txValueSearchDatabaseImage.Text, @"^\d$")) //Regex only số
                    {
                        database = DatabaseManager.ShowDataQuery($"SELECT * FROM [Image] WHERE ImageID = {txValueSearchDatabaseImage.Text}");
                    }
                    else
                    {
                        MessageBox.Show("ID chỉ tồn tại số nguyên!");
                        return;
                    }

                    break;
                case 2:
                    database = DatabaseManager.ShowDataQuery($"SELECT * FROM [Image] WHERE Description LIKE '%{txValueSearchDatabaseImage.Text}%'");
                    break;
            }
            ResultSearch(database);
        }

        private void cbxSearchDatabaseImageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSearchDatabaseImageType.SelectedIndex == 0)
            {
                ResultSearch(DatabaseManager.ShowDataQuery("SELECT * FROM [Image]"));
            }
        }
        void ResultSearch(DataTable database)
        {
            if (database != null)
            {
                dataGridView_DatabaseImage.Rows.Clear();
                for (int i = 0; i < database.Rows.Count; i++)
                {
                    dataGridView_DatabaseImage.Rows.Add(
                        database.Rows[i][0],
                        database.Rows[i][1],
                        database.Rows[i][2]);
                }
            }
        }
    }
}
