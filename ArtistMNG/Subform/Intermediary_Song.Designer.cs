
namespace ArtistMNG.Subform
{
    partial class Intermediary_Song
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
            this.btnAddGroupFromDbToArtist = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchDatabaseSong = new System.Windows.Forms.Button();
            this.txValueSearchDatabaseSong = new System.Windows.Forms.TextBox();
            this.cbxSearchDatabaseSongType = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_TargetSong = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_DatabaseSong = new System.Windows.Forms.DataGridView();
            this.btnApplyDelete = new System.Windows.Forms.Button();
            this.panel_Workspace.SuspendLayout();
            this.panel_Description.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TargetSong)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DatabaseSong)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Workspace
            // 
            this.panel_Workspace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Workspace.Controls.Add(this.panel_Description);
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
            this.panel_Description.AutoScroll = true;
            this.panel_Description.Controls.Add(this.label_Information);
            this.panel_Description.Location = new System.Drawing.Point(590, 540);
            this.panel_Description.Name = "panel_Description";
            this.panel_Description.Size = new System.Drawing.Size(539, 171);
            this.panel_Description.TabIndex = 9;
            // 
            // label_Information
            // 
            this.label_Information.AutoSize = true;
            this.label_Information.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label_Information.ForeColor = System.Drawing.Color.White;
            this.label_Information.Location = new System.Drawing.Point(3, 9);
            this.label_Information.Name = "label_Information";
            this.label_Information.Size = new System.Drawing.Size(0, 18);
            this.label_Information.TabIndex = 0;
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
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.btnSearchDatabaseSong);
            this.groupBox6.Controls.Add(this.txValueSearchDatabaseSong);
            this.groupBox6.Controls.Add(this.cbxSearchDatabaseSongType);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(4, 540);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(535, 171);
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
            // btnSearchDatabaseSong
            // 
            this.btnSearchDatabaseSong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchDatabaseSong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnSearchDatabaseSong.FlatAppearance.BorderSize = 0;
            this.btnSearchDatabaseSong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchDatabaseSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchDatabaseSong.ForeColor = System.Drawing.Color.White;
            this.btnSearchDatabaseSong.Location = new System.Drawing.Point(406, 125);
            this.btnSearchDatabaseSong.Name = "btnSearchDatabaseSong";
            this.btnSearchDatabaseSong.Size = new System.Drawing.Size(123, 40);
            this.btnSearchDatabaseSong.TabIndex = 23;
            this.btnSearchDatabaseSong.TabStop = false;
            this.btnSearchDatabaseSong.Text = "Tìm";
            this.btnSearchDatabaseSong.UseVisualStyleBackColor = false;
            this.btnSearchDatabaseSong.Click += new System.EventHandler(this.btnSearchDatabaseSong_Click);
            // 
            // txValueSearchDatabaseSong
            // 
            this.txValueSearchDatabaseSong.Location = new System.Drawing.Point(6, 92);
            this.txValueSearchDatabaseSong.Name = "txValueSearchDatabaseSong";
            this.txValueSearchDatabaseSong.Size = new System.Drawing.Size(523, 24);
            this.txValueSearchDatabaseSong.TabIndex = 1;
            // 
            // cbxSearchDatabaseSongType
            // 
            this.cbxSearchDatabaseSongType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSearchDatabaseSongType.FormattingEnabled = true;
            this.cbxSearchDatabaseSongType.Items.AddRange(new object[] {
            "Tất cả",
            "Id",
            "Tên",
            "Producer"});
            this.cbxSearchDatabaseSongType.Location = new System.Drawing.Point(6, 55);
            this.cbxSearchDatabaseSongType.Name = "cbxSearchDatabaseSongType";
            this.cbxSearchDatabaseSongType.Size = new System.Drawing.Size(523, 26);
            this.cbxSearchDatabaseSongType.TabIndex = 0;
            this.cbxSearchDatabaseSongType.SelectedIndexChanged += new System.EventHandler(this.cbxSearchDatabaseSongType_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dataGridView_TargetSong);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(535, 531);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bài hát";
            // 
            // dataGridView_TargetSong
            // 
            this.dataGridView_TargetSong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_TargetSong.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(55)))), ((int)(((byte)(59)))));
            this.dataGridView_TargetSong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TargetSong.Location = new System.Drawing.Point(6, 21);
            this.dataGridView_TargetSong.Name = "dataGridView_TargetSong";
            this.dataGridView_TargetSong.RowHeadersWidth = 51;
            this.dataGridView_TargetSong.RowTemplate.Height = 24;
            this.dataGridView_TargetSong.Size = new System.Drawing.Size(523, 504);
            this.dataGridView_TargetSong.TabIndex = 0;
            this.dataGridView_TargetSong.SelectionChanged += new System.EventHandler(this.dataGridView_TargetSong_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView_DatabaseSong);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(590, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 531);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bài hát trong database";
            // 
            // dataGridView_DatabaseSong
            // 
            this.dataGridView_DatabaseSong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_DatabaseSong.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(55)))), ((int)(((byte)(59)))));
            this.dataGridView_DatabaseSong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DatabaseSong.Location = new System.Drawing.Point(6, 21);
            this.dataGridView_DatabaseSong.Name = "dataGridView_DatabaseSong";
            this.dataGridView_DatabaseSong.RowHeadersWidth = 51;
            this.dataGridView_DatabaseSong.RowTemplate.Height = 24;
            this.dataGridView_DatabaseSong.Size = new System.Drawing.Size(527, 504);
            this.dataGridView_DatabaseSong.TabIndex = 1;
            this.dataGridView_DatabaseSong.SelectionChanged += new System.EventHandler(this.dataGridView_DatabaseSong_SelectionChanged);
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
            // Intermediary_Song
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1156, 779);
            this.Controls.Add(this.btnApplyDelete);
            this.Controls.Add(this.panel_Workspace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(1174, 826);
            this.MinimumSize = new System.Drawing.Size(1174, 826);
            this.Name = "Intermediary_Song";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bài hát";
            this.Load += new System.EventHandler(this.Intermediary_Group_Load);
            this.panel_Workspace.ResumeLayout(false);
            this.panel_Description.ResumeLayout(false);
            this.panel_Description.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TargetSong)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DatabaseSong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Workspace;
        private System.Windows.Forms.DataGridView dataGridView_TargetSong;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_DatabaseSong;
        private System.Windows.Forms.Button btnApplyDelete;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbxSearchDatabaseSongType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchDatabaseSong;
        private System.Windows.Forms.TextBox txValueSearchDatabaseSong;
        private System.Windows.Forms.Button btnAddGroupFromDbToArtist;
        private System.Windows.Forms.Panel panel_Description;
        private System.Windows.Forms.Label label_Information;
    }
}