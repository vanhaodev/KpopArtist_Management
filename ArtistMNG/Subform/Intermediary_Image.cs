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
    public partial class Intermediary_Image : Form
    {
        int artistID, groupID;
        bool isCreateNewRow;

        public Intermediary_Image(int artistID, int groupID)
        {
            InitializeComponent();
            this.artistID = artistID;
            this.groupID = groupID;
            MessageBox.Show($"Artist: {artistID}\nGroup: {groupID}");
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
            if (artistID > 0)
            {
                var targetImage = DatabaseManager.ShowDataStoredProcedure("Artist_GetImage", artistID.ToString());
                for (int i = 0; i < targetImage.Rows.Count; i++)
                {
                    dataGridView_TargetImage.Rows.Add(targetImage.Rows[i][0], targetImage.Rows[i][1], targetImage.Rows[i][2]);
                }                  

                //set delete  
                for(int i = 0; i < ModelArtist.Instance.ArtistImage_Delete.Count; i++)
                {
                    for (int j = dataGridView_TargetImage.Rows.Count - 1; j >= 0; j--)
                    {
                        if (ModelArtist.Instance.ArtistImage_Delete[i].ImageID == (int)dataGridView_TargetImage.Rows[j].Cells[0].Value)
                        {
                            dataGridView_TargetImage.Rows.RemoveAt(j);
                        }
                    }    
                }    
            }
            else if (groupID > 0)
            {
                var targetImage = DatabaseManager.ShowDataStoredProcedure("Group_GetImage", groupID.ToString());
                for (int i = 0; i < targetImage.Rows.Count; i++)
                {
                    dataGridView_TargetImage.Rows.Add(targetImage.Rows[i][0], targetImage.Rows[i][1], targetImage.Rows[i][2]);
                }
            }

            if(groupID == 0) //group id là 0 thì gọi artist data
            {
                for (int i = 0; i < ModelArtist.Instance.ArtistImage_Add.Count; i++)
                {
                    dataGridView_TargetImage.Rows.Add(ModelArtist.Instance.ArtistImage_Add[i].ImageID, ModelArtist.Instance.ArtistImage_Add[i].ImageURL, ModelArtist.Instance.ArtistImage_Add[i].Description);
                }
            }
            else if (artistID == 0) //arttis id là 0 thì gọi group data
            {
                
            }


        }

        private void btnCheckImage_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox_Image.LoadAsync(tx_ImageURL.Text);
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
            ModelArtist.Instance.ArtistImage_Add.Add(modelImage);
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

          
            if (artistID == 0 && groupID == 0)
            {               
                for(int i = 0; i < ModelArtist.Instance.ArtistImage_Add.Count; i++)
                {
                    if(ModelArtist.Instance.ArtistImage_Add[i].ImageURL == dataGridView_TargetImage.SelectedRows[0].Cells[1].Value.ToString())
                    {
                        ModelArtist.Instance.ArtistImage_Add[i].ImageURL = tx_ImageURL.Text;
                        ModelArtist.Instance.ArtistImage_Add[i].Description = txImageDescription.Text;
                        break;
                    }    
                }    
            }    
            else if(artistID > 0)
            {
                bool isContains = false;
                for (int i = 0; i < ModelArtist.Instance.ArtistImage_Update.Count; i++)
                {
                    if (ModelArtist.Instance.ArtistImage_Update[i].ImageID == (int)dataGridView_TargetImage.SelectedRows[0].Cells[0].Value)
                    {
                        ModelArtist.Instance.ArtistImage_Update[i].ImageURL = tx_ImageURL.Text;
                        ModelArtist.Instance.ArtistImage_Update[i].Description = txImageDescription.Text;
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
                    ModelArtist.Instance.ArtistImage_Update.Add(modelImage);
                }    
            }   
            else if(groupID > 0)
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
            if (artistID == 0 && groupID == 0)
            {
                //do nothing    
            }    
            else if (artistID > 0)
            {
                ModelImage modelImage = new ModelImage();
                modelImage.ImageID = (int)dataGridView_TargetImage.SelectedRows[0].Cells[0].Value;
                modelImage.ImageURL = dataGridView_TargetImage.SelectedRows[0].Cells[1].Value.ToString();
                modelImage.Description = dataGridView_TargetImage.SelectedRows[0].Cells[2].Value.ToString();

                if (ModelArtist.Instance.ArtistImage_Add.Count < 1)
                {
                    MessageBox.Show($"ModelArtist.Instance.ArtistImage_Add.Count {ModelArtist.Instance.ArtistImage_Add.Count}");
                    ModelArtist.Instance.ArtistImage_Delete.Add(modelImage);
                }
                for (int i = 0; i < ModelArtist.Instance.ArtistImage_Add.Count; i++)
                {
                    if (ModelArtist.Instance.ArtistImage_Add[i].ImageURL == modelImage.ImageURL)
                    {
                        ModelArtist.Instance.ArtistImage_Add.RemoveAt(i);                            
                    }
                    else
                    {
                        bool isContains = false;
                        for (int j = 0; j < ModelArtist.Instance.ArtistImage_Delete.Count; j++)
                        {
                            if (ModelArtist.Instance.ArtistImage_Delete[j].ImageURL == modelImage.ImageURL)
                            {
                                isContains = true;
                            }
                        }

                        if (!isContains)
                        {
                            ModelArtist.Instance.ArtistImage_Delete.Add(modelImage);
                        }
                    }
                }

            }
            else if (groupID > 0)
            {

            }
            if(groupID == 0)
            {
                
            }   
            if(artistID == 0)
            {
                //set delete  
                for (int i = 0; i < ModelArtist.Instance.ArtistImage_Add.Count; i++)
                {
                    if (ModelArtist.Instance.ArtistImage_Add[i].ImageURL == dataGridView_TargetImage.SelectedRows[0].Cells[1].Value.ToString())
                    {
                        ModelArtist.Instance.ArtistImage_Add.RemoveAt(i);
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
            for(int j = 0; j < ModelArtist.Instance.ArtistImage_Add.Count; j++)
            {
                if(ModelArtist.Instance.ArtistImage_Add[0].ImageID == (int)dataGridView_DatabaseImage.SelectedRows[0].Cells[0].Value)
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
                ModelArtist.Instance.ArtistImage_Add.Add(modelImage);
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
            }   
            else
            {
                MessageBox.Show("Đã tồn tại dữ liệu tương tự!");
            }
            MessageBox.Show($"ModelArtist.Instance.ArtistImage_Add.Count {ModelArtist.Instance.ArtistImage_Add.Count}");
        }

        void LoadDesign()
        {
            btnApplyAdd.Enabled = true;
            btnApplyDelete.Enabled = false;
            btnApplyEdit.Enabled = false;

            //Target image
            DatagridViewStyle.DarkStyle(dataGridView_TargetImage);
            DatagridViewStyle.MinimumWidth(dataGridView_TargetImage, 100);

            //database
            DatagridViewStyle.DarkStyle(dataGridView_DatabaseImage);
            DatagridViewStyle.MinimumWidth(dataGridView_DatabaseImage, 100);

            pictureBox_Image.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_DatabaseImage.SizeMode = PictureBoxSizeMode.Zoom;
            
        }

    }
}
