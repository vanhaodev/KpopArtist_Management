
namespace ArtistMNG.Subform
{
    partial class Intermediary_Group
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
            this.panel_Description = new System.Windows.Forms.Panel();
            this.label_Information = new System.Windows.Forms.Label();
            this.pictureBox_GroupImage = new System.Windows.Forms.PictureBox();
            this.btnAddGroupFromDbToArtist = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchDatabaseGroup = new System.Windows.Forms.Button();
            this.txValueSearchDatabaseGroup = new System.Windows.Forms.TextBox();
            this.cbxSearchDatabaseGroupType = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_TargetGroup = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_DatabaseGroup = new System.Windows.Forms.DataGridView();
            this.btnApplyDelete = new System.Windows.Forms.Button();
            this.panel_Workspace.SuspendLayout();
            this.panel_Description.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_GroupImage)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TargetGroup)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DatabaseGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Workspace
            // 
            this.panel_Workspace.Controls.Add(this.panel_Description);
            this.panel_Workspace.Controls.Add(this.pictureBox_GroupImage);
            this.panel_Workspace.Controls.Add(this.btnAddGroupFromDbToArtist);
            this.panel_Workspace.Controls.Add(this.groupBox6);
            this.panel_Workspace.Controls.Add(this.groupBox3);
            this.panel_Workspace.Controls.Add(this.groupBox2);
            this.panel_Workspace.Location = new System.Drawing.Point(12, 12);
            this.panel_Workspace.Name = "panel_Workspace";
            this.panel_Workspace.Size = new System.Drawing.Size(1132, 714);
            this.panel_Workspace.TabIndex = 0;
            // 
            // panel_Description
            // 
            this.panel_Description.Controls.Add(this.label_Information);
            this.panel_Description.Location = new System.Drawing.Point(590, 546);
            this.panel_Description.Name = "panel_Description";
            this.panel_Description.Size = new System.Drawing.Size(539, 165);
            this.panel_Description.TabIndex = 9;
            // 
            // label_Information
            // 
            this.label_Information.AutoSize = true;
            this.label_Information.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label_Information.ForeColor = System.Drawing.Color.White;
            this.label_Information.Location = new System.Drawing.Point(3, 9);
            this.label_Information.Name = "label_Information";
            this.label_Information.Size = new System.Drawing.Size(51, 18);
            this.label_Information.TabIndex = 0;
            this.label_Information.Text = "Mô tả";
            // 
            // pictureBox_GroupImage
            // 
            this.pictureBox_GroupImage.Location = new System.Drawing.Point(374, 546);
            this.pictureBox_GroupImage.Name = "pictureBox_GroupImage";
            this.pictureBox_GroupImage.Size = new System.Drawing.Size(165, 165);
            this.pictureBox_GroupImage.TabIndex = 2;
            this.pictureBox_GroupImage.TabStop = false;
            // 
            // btnAddGroupFromDbToArtist
            // 
            this.btnAddGroupFromDbToArtist.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddGroupFromDbToArtist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnAddGroupFromDbToArtist.FlatAppearance.BorderSize = 0;
            this.btnAddGroupFromDbToArtist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGroupFromDbToArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnAddGroupFromDbToArtist.ForeColor = System.Drawing.Color.White;
            this.btnAddGroupFromDbToArtist.Location = new System.Drawing.Point(545, 24);
            this.btnAddGroupFromDbToArtist.Name = "btnAddGroupFromDbToArtist";
            this.btnAddGroupFromDbToArtist.Size = new System.Drawing.Size(39, 39);
            this.btnAddGroupFromDbToArtist.TabIndex = 8;
            this.btnAddGroupFromDbToArtist.Text = "<<";
            this.btnAddGroupFromDbToArtist.UseVisualStyleBackColor = false;
            this.btnAddGroupFromDbToArtist.Click += new System.EventHandler(this.btnAddGroupFromDbToArtist_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.btnSearchDatabaseGroup);
            this.groupBox6.Controls.Add(this.txValueSearchDatabaseGroup);
            this.groupBox6.Controls.Add(this.cbxSearchDatabaseGroupType);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(4, 540);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(364, 171);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tìm kiếm trong database";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 18);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tìm theo:";
            // 
            // btnSearchDatabaseGroup
            // 
            this.btnSearchDatabaseGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchDatabaseGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnSearchDatabaseGroup.FlatAppearance.BorderSize = 0;
            this.btnSearchDatabaseGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchDatabaseGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchDatabaseGroup.ForeColor = System.Drawing.Color.White;
            this.btnSearchDatabaseGroup.Location = new System.Drawing.Point(235, 125);
            this.btnSearchDatabaseGroup.Name = "btnSearchDatabaseGroup";
            this.btnSearchDatabaseGroup.Size = new System.Drawing.Size(123, 40);
            this.btnSearchDatabaseGroup.TabIndex = 23;
            this.btnSearchDatabaseGroup.TabStop = false;
            this.btnSearchDatabaseGroup.Text = "Tìm";
            this.btnSearchDatabaseGroup.UseVisualStyleBackColor = false;
            this.btnSearchDatabaseGroup.Click += new System.EventHandler(this.btnSearchDatabaseGroup_Click);
            // 
            // txValueSearchDatabaseGroup
            // 
            this.txValueSearchDatabaseGroup.Location = new System.Drawing.Point(6, 92);
            this.txValueSearchDatabaseGroup.Name = "txValueSearchDatabaseGroup";
            this.txValueSearchDatabaseGroup.Size = new System.Drawing.Size(352, 24);
            this.txValueSearchDatabaseGroup.TabIndex = 1;
            // 
            // cbxSearchDatabaseGroupType
            // 
            this.cbxSearchDatabaseGroupType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSearchDatabaseGroupType.FormattingEnabled = true;
            this.cbxSearchDatabaseGroupType.Items.AddRange(new object[] {
            "Tất cả",
            "Id",
            "Tên",
            "Mô tả"});
            this.cbxSearchDatabaseGroupType.Location = new System.Drawing.Point(6, 55);
            this.cbxSearchDatabaseGroupType.Name = "cbxSearchDatabaseGroupType";
            this.cbxSearchDatabaseGroupType.Size = new System.Drawing.Size(352, 26);
            this.cbxSearchDatabaseGroupType.TabIndex = 0;
            this.cbxSearchDatabaseGroupType.SelectedIndexChanged += new System.EventHandler(this.cbxSearchDatabaseGroupType_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView_TargetGroup);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(535, 531);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nhóm của nghệ sĩ";
            // 
            // dataGridView_TargetGroup
            // 
            this.dataGridView_TargetGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_TargetGroup.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(55)))), ((int)(((byte)(59)))));
            this.dataGridView_TargetGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TargetGroup.Location = new System.Drawing.Point(6, 21);
            this.dataGridView_TargetGroup.Name = "dataGridView_TargetGroup";
            this.dataGridView_TargetGroup.RowHeadersWidth = 51;
            this.dataGridView_TargetGroup.RowTemplate.Height = 24;
            this.dataGridView_TargetGroup.Size = new System.Drawing.Size(523, 504);
            this.dataGridView_TargetGroup.TabIndex = 0;
            this.dataGridView_TargetGroup.SelectionChanged += new System.EventHandler(this.dataGridView_TargetGroup_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_DatabaseGroup);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(590, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 531);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nhóm trong database";
            // 
            // dataGridView_DatabaseGroup
            // 
            this.dataGridView_DatabaseGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_DatabaseGroup.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(55)))), ((int)(((byte)(59)))));
            this.dataGridView_DatabaseGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DatabaseGroup.Location = new System.Drawing.Point(6, 21);
            this.dataGridView_DatabaseGroup.Name = "dataGridView_DatabaseGroup";
            this.dataGridView_DatabaseGroup.RowHeadersWidth = 51;
            this.dataGridView_DatabaseGroup.RowTemplate.Height = 24;
            this.dataGridView_DatabaseGroup.Size = new System.Drawing.Size(527, 504);
            this.dataGridView_DatabaseGroup.TabIndex = 1;
            this.dataGridView_DatabaseGroup.SelectionChanged += new System.EventHandler(this.dataGridView_DatabaseGroup_SelectionChanged);
            // 
            // btnApplyDelete
            // 
            this.btnApplyDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnApplyDelete.FlatAppearance.BorderSize = 0;
            this.btnApplyDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyDelete.ForeColor = System.Drawing.Color.White;
            this.btnApplyDelete.Location = new System.Drawing.Point(1021, 732);
            this.btnApplyDelete.Name = "btnApplyDelete";
            this.btnApplyDelete.Size = new System.Drawing.Size(123, 40);
            this.btnApplyDelete.TabIndex = 21;
            this.btnApplyDelete.TabStop = false;
            this.btnApplyDelete.Text = "Xóa";
            this.btnApplyDelete.UseVisualStyleBackColor = false;
            this.btnApplyDelete.Click += new System.EventHandler(this.btnApplyDelete_Click);
            // 
            // Intermediary_Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1156, 779);
            this.Controls.Add(this.btnApplyDelete);
            this.Controls.Add(this.panel_Workspace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Intermediary_Group";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhóm";
            this.Load += new System.EventHandler(this.Intermediary_Group_Load);
            this.panel_Workspace.ResumeLayout(false);
            this.panel_Description.ResumeLayout(false);
            this.panel_Description.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_GroupImage)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TargetGroup)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DatabaseGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Workspace;
        private System.Windows.Forms.DataGridView dataGridView_TargetGroup;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_DatabaseGroup;
        private System.Windows.Forms.Button btnApplyDelete;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbxSearchDatabaseGroupType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchDatabaseGroup;
        private System.Windows.Forms.TextBox txValueSearchDatabaseGroup;
        private System.Windows.Forms.Button btnAddGroupFromDbToArtist;
        private System.Windows.Forms.PictureBox pictureBox_GroupImage;
        private System.Windows.Forms.Panel panel_Description;
        private System.Windows.Forms.Label label_Information;
    }
}