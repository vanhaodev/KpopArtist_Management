
namespace ArtistMNG.Subform
{
    partial class Intermediary_Image
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_Workspace = new System.Windows.Forms.Panel();
            this.pictureBox_DatabaseImage = new System.Windows.Forms.PictureBox();
            this.btnAddImageFromDbToArtist = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchDatabaseImage = new System.Windows.Forms.Button();
            this.txValueSearchDatabaseImage = new System.Windows.Forms.TextBox();
            this.cbxSearchDatabaseImageType = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txImageDescription = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tx_ImageURL = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_TargetImage = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_DatabaseImage = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox_Image = new System.Windows.Forms.PictureBox();
            this.btnCheckImage = new System.Windows.Forms.Button();
            this.btnNewRow = new System.Windows.Forms.Button();
            this.btnApplyDelete = new System.Windows.Forms.Button();
            this.btnApplyEdit = new System.Windows.Forms.Button();
            this.btnApplyAdd = new System.Windows.Forms.Button();
            this.panel_Workspace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DatabaseImage)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TargetImage)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DatabaseImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Workspace
            // 
            this.panel_Workspace.Controls.Add(this.pictureBox_DatabaseImage);
            this.panel_Workspace.Controls.Add(this.btnAddImageFromDbToArtist);
            this.panel_Workspace.Controls.Add(this.groupBox6);
            this.panel_Workspace.Controls.Add(this.groupBox5);
            this.panel_Workspace.Controls.Add(this.groupBox4);
            this.panel_Workspace.Controls.Add(this.groupBox3);
            this.panel_Workspace.Controls.Add(this.groupBox2);
            this.panel_Workspace.Controls.Add(this.groupBox1);
            this.panel_Workspace.Location = new System.Drawing.Point(12, 12);
            this.panel_Workspace.Name = "panel_Workspace";
            this.panel_Workspace.Size = new System.Drawing.Size(857, 595);
            this.panel_Workspace.TabIndex = 0;
            // 
            // pictureBox_DatabaseImage
            // 
            this.pictureBox_DatabaseImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_DatabaseImage.Location = new System.Drawing.Point(452, 343);
            this.pictureBox_DatabaseImage.Name = "pictureBox_DatabaseImage";
            this.pictureBox_DatabaseImage.Size = new System.Drawing.Size(113, 112);
            this.pictureBox_DatabaseImage.TabIndex = 1;
            this.pictureBox_DatabaseImage.TabStop = false;
            // 
            // btnAddImageFromDbToArtist
            // 
            this.btnAddImageFromDbToArtist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnAddImageFromDbToArtist.FlatAppearance.BorderSize = 0;
            this.btnAddImageFromDbToArtist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddImageFromDbToArtist.Font = new System.Drawing.Font("Roboto", 8F, System.Drawing.FontStyle.Bold);
            this.btnAddImageFromDbToArtist.ForeColor = System.Drawing.Color.White;
            this.btnAddImageFromDbToArtist.Location = new System.Drawing.Point(407, 24);
            this.btnAddImageFromDbToArtist.Name = "btnAddImageFromDbToArtist";
            this.btnAddImageFromDbToArtist.Size = new System.Drawing.Size(39, 39);
            this.btnAddImageFromDbToArtist.TabIndex = 8;
            this.btnAddImageFromDbToArtist.Text = "<<";
            this.btnAddImageFromDbToArtist.UseVisualStyleBackColor = false;
            this.btnAddImageFromDbToArtist.Click += new System.EventHandler(this.btnAddImageFromDbToArtist_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.btnSearchDatabaseImage);
            this.groupBox6.Controls.Add(this.txValueSearchDatabaseImage);
            this.groupBox6.Controls.Add(this.cbxSearchDatabaseImageType);
            this.groupBox6.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(452, 461);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(402, 131);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tìm kiếm trong database";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tìm theo:";
            // 
            // btnSearchDatabaseImage
            // 
            this.btnSearchDatabaseImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchDatabaseImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnSearchDatabaseImage.FlatAppearance.BorderSize = 0;
            this.btnSearchDatabaseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchDatabaseImage.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchDatabaseImage.ForeColor = System.Drawing.Color.White;
            this.btnSearchDatabaseImage.Location = new System.Drawing.Point(273, 82);
            this.btnSearchDatabaseImage.Name = "btnSearchDatabaseImage";
            this.btnSearchDatabaseImage.Size = new System.Drawing.Size(123, 40);
            this.btnSearchDatabaseImage.TabIndex = 23;
            this.btnSearchDatabaseImage.TabStop = false;
            this.btnSearchDatabaseImage.Text = "Tìm";
            this.btnSearchDatabaseImage.UseVisualStyleBackColor = false;
            // 
            // txValueSearchDatabaseImage
            // 
            this.txValueSearchDatabaseImage.Location = new System.Drawing.Point(6, 86);
            this.txValueSearchDatabaseImage.Name = "txValueSearchDatabaseImage";
            this.txValueSearchDatabaseImage.Size = new System.Drawing.Size(261, 27);
            this.txValueSearchDatabaseImage.TabIndex = 1;
            // 
            // cbxSearchDatabaseImageType
            // 
            this.cbxSearchDatabaseImageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSearchDatabaseImageType.FormattingEnabled = true;
            this.cbxSearchDatabaseImageType.Items.AddRange(new object[] {
            "Tất cả",
            "Id ảnh",
            "Mô tả ảnh",
            "Id nghệ sĩ (ảnh theo nghệ sĩ)",
            "Tên nghệ sĩ (ảnh theo nghệ sĩ)",
            "Id nhóm (ảnh theo nhóm)",
            "Tên nhóm ảnh theo nhóm)",
            "Id bài hát (ảnh theo bài hát)",
            "Tên bài hát (ảnh theo bài hát)",
            "Id album (ảnh theo album)",
            "Tên album (ảnh theo album)",
            "Id công ty (ảnh theo công ty)",
            "Tên công ty (ảnh theo công ty)"});
            this.cbxSearchDatabaseImageType.Location = new System.Drawing.Point(6, 48);
            this.cbxSearchDatabaseImageType.Name = "cbxSearchDatabaseImageType";
            this.cbxSearchDatabaseImageType.Size = new System.Drawing.Size(390, 28);
            this.cbxSearchDatabaseImageType.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txImageDescription);
            this.groupBox5.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(166, 509);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(236, 83);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Mô tả";
            // 
            // txImageDescription
            // 
            this.txImageDescription.Location = new System.Drawing.Point(7, 26);
            this.txImageDescription.Multiline = true;
            this.txImageDescription.Name = "txImageDescription";
            this.txImageDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txImageDescription.Size = new System.Drawing.Size(223, 50);
            this.txImageDescription.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tx_ImageURL);
            this.groupBox4.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(166, 421);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(236, 83);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "URL ảnh";
            // 
            // tx_ImageURL
            // 
            this.tx_ImageURL.Location = new System.Drawing.Point(7, 27);
            this.tx_ImageURL.Multiline = true;
            this.tx_ImageURL.Name = "tx_ImageURL";
            this.tx_ImageURL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tx_ImageURL.Size = new System.Drawing.Size(223, 50);
            this.tx_ImageURL.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView_TargetImage);
            this.groupBox3.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(397, 412);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ảnh của nghệ sĩ";
            // 
            // dataGridView_TargetImage
            // 
            this.dataGridView_TargetImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_TargetImage.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(55)))), ((int)(((byte)(59)))));
            this.dataGridView_TargetImage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_TargetImage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TargetImage.Location = new System.Drawing.Point(6, 21);
            this.dataGridView_TargetImage.Name = "dataGridView_TargetImage";
            this.dataGridView_TargetImage.RowHeadersWidth = 51;
            this.dataGridView_TargetImage.RowTemplate.Height = 24;
            this.dataGridView_TargetImage.Size = new System.Drawing.Size(385, 385);
            this.dataGridView_TargetImage.TabIndex = 0;
            this.dataGridView_TargetImage.SelectionChanged += new System.EventHandler(this.dataGridView_TargetImage_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_DatabaseImage);
            this.groupBox2.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(452, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 334);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ảnh trong database";
            // 
            // dataGridView_DatabaseImage
            // 
            this.dataGridView_DatabaseImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_DatabaseImage.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(55)))), ((int)(((byte)(59)))));
            this.dataGridView_DatabaseImage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_DatabaseImage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DatabaseImage.Location = new System.Drawing.Point(6, 21);
            this.dataGridView_DatabaseImage.Name = "dataGridView_DatabaseImage";
            this.dataGridView_DatabaseImage.RowHeadersWidth = 51;
            this.dataGridView_DatabaseImage.RowTemplate.Height = 24;
            this.dataGridView_DatabaseImage.Size = new System.Drawing.Size(390, 307);
            this.dataGridView_DatabaseImage.TabIndex = 1;
            this.dataGridView_DatabaseImage.SelectionChanged += new System.EventHandler(this.dataGridView_DatabaseImage_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox_Image);
            this.groupBox1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(4, 421);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 171);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ảnh";
            // 
            // pictureBox_Image
            // 
            this.pictureBox_Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_Image.Location = new System.Drawing.Point(6, 21);
            this.pictureBox_Image.Name = "pictureBox_Image";
            this.pictureBox_Image.Size = new System.Drawing.Size(143, 143);
            this.pictureBox_Image.TabIndex = 1;
            this.pictureBox_Image.TabStop = false;
            // 
            // btnCheckImage
            // 
            this.btnCheckImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheckImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnCheckImage.FlatAppearance.BorderSize = 0;
            this.btnCheckImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckImage.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckImage.ForeColor = System.Drawing.Color.White;
            this.btnCheckImage.Location = new System.Drawing.Point(12, 613);
            this.btnCheckImage.Name = "btnCheckImage";
            this.btnCheckImage.Size = new System.Drawing.Size(159, 40);
            this.btnCheckImage.TabIndex = 18;
            this.btnCheckImage.TabStop = false;
            this.btnCheckImage.Text = "Kiểm tra url ảnh";
            this.btnCheckImage.UseVisualStyleBackColor = false;
            this.btnCheckImage.Click += new System.EventHandler(this.btnCheckImage_Click);
            // 
            // btnNewRow
            // 
            this.btnNewRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnNewRow.FlatAppearance.BorderSize = 0;
            this.btnNewRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewRow.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewRow.ForeColor = System.Drawing.Color.White;
            this.btnNewRow.Location = new System.Drawing.Point(359, 613);
            this.btnNewRow.Name = "btnNewRow";
            this.btnNewRow.Size = new System.Drawing.Size(123, 40);
            this.btnNewRow.TabIndex = 22;
            this.btnNewRow.TabStop = false;
            this.btnNewRow.Text = "Mới";
            this.btnNewRow.UseVisualStyleBackColor = false;
            this.btnNewRow.Click += new System.EventHandler(this.btnNewRow_Click);
            // 
            // btnApplyDelete
            // 
            this.btnApplyDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnApplyDelete.FlatAppearance.BorderSize = 0;
            this.btnApplyDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyDelete.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyDelete.ForeColor = System.Drawing.Color.White;
            this.btnApplyDelete.Location = new System.Drawing.Point(746, 613);
            this.btnApplyDelete.Name = "btnApplyDelete";
            this.btnApplyDelete.Size = new System.Drawing.Size(123, 40);
            this.btnApplyDelete.TabIndex = 21;
            this.btnApplyDelete.TabStop = false;
            this.btnApplyDelete.Text = "Xóa";
            this.btnApplyDelete.UseVisualStyleBackColor = false;
            this.btnApplyDelete.Click += new System.EventHandler(this.btnApplyDelete_Click);
            // 
            // btnApplyEdit
            // 
            this.btnApplyEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnApplyEdit.FlatAppearance.BorderSize = 0;
            this.btnApplyEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyEdit.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyEdit.ForeColor = System.Drawing.Color.White;
            this.btnApplyEdit.Location = new System.Drawing.Point(617, 613);
            this.btnApplyEdit.Name = "btnApplyEdit";
            this.btnApplyEdit.Size = new System.Drawing.Size(123, 40);
            this.btnApplyEdit.TabIndex = 20;
            this.btnApplyEdit.TabStop = false;
            this.btnApplyEdit.Text = "Cập nhật";
            this.btnApplyEdit.UseVisualStyleBackColor = false;
            this.btnApplyEdit.Click += new System.EventHandler(this.btnApplyEdit_Click);
            // 
            // btnApplyAdd
            // 
            this.btnApplyAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnApplyAdd.FlatAppearance.BorderSize = 0;
            this.btnApplyAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyAdd.Font = new System.Drawing.Font("Roboto", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyAdd.ForeColor = System.Drawing.Color.White;
            this.btnApplyAdd.Location = new System.Drawing.Point(488, 613);
            this.btnApplyAdd.Name = "btnApplyAdd";
            this.btnApplyAdd.Size = new System.Drawing.Size(123, 40);
            this.btnApplyAdd.TabIndex = 19;
            this.btnApplyAdd.TabStop = false;
            this.btnApplyAdd.Text = "Thêm";
            this.btnApplyAdd.UseVisualStyleBackColor = false;
            this.btnApplyAdd.Click += new System.EventHandler(this.btnApplyAdd_Click);
            // 
            // Intermediary_Image
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(881, 659);
            this.Controls.Add(this.btnCheckImage);
            this.Controls.Add(this.btnNewRow);
            this.Controls.Add(this.btnApplyDelete);
            this.Controls.Add(this.panel_Workspace);
            this.Controls.Add(this.btnApplyEdit);
            this.Controls.Add(this.btnApplyAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Intermediary_Image";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Intermediary_Image";
            this.Load += new System.EventHandler(this.Intermediary_Image_Load);
            this.panel_Workspace.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_DatabaseImage)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TargetImage)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DatabaseImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Workspace;
        private System.Windows.Forms.DataGridView dataGridView_TargetImage;
        private System.Windows.Forms.PictureBox pictureBox_Image;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_DatabaseImage;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txImageDescription;
        private System.Windows.Forms.TextBox tx_ImageURL;
        private System.Windows.Forms.Button btnCheckImage;
        private System.Windows.Forms.Button btnNewRow;
        private System.Windows.Forms.Button btnApplyDelete;
        private System.Windows.Forms.Button btnApplyEdit;
        private System.Windows.Forms.Button btnApplyAdd;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbxSearchDatabaseImageType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchDatabaseImage;
        private System.Windows.Forms.TextBox txValueSearchDatabaseImage;
        private System.Windows.Forms.Button btnAddImageFromDbToArtist;
        private System.Windows.Forms.PictureBox pictureBox_DatabaseImage;
    }
}