
namespace ArtistMNG.Subform
{
    partial class Intermediary_Fandom
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
            this.btnClearFandom = new System.Windows.Forms.Button();
            this.btnAddFandomFromDbToArtist = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchDatabaseFandom = new System.Windows.Forms.Button();
            this.txValueSearchDatabaseFandom = new System.Windows.Forms.TextBox();
            this.cbxSearchDatabaseFandomType = new System.Windows.Forms.ComboBox();
            this.groupBox_CurrentFandomInfor = new System.Windows.Forms.GroupBox();
            this.label_selectedFandomInfor = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_DatabaseFandom = new System.Windows.Forms.DataGridView();
            this.panel_Workspace.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox_CurrentFandomInfor.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DatabaseFandom)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Workspace
            // 
            this.panel_Workspace.Controls.Add(this.btnClearFandom);
            this.panel_Workspace.Controls.Add(this.btnAddFandomFromDbToArtist);
            this.panel_Workspace.Controls.Add(this.groupBox6);
            this.panel_Workspace.Controls.Add(this.groupBox_CurrentFandomInfor);
            this.panel_Workspace.Controls.Add(this.groupBox2);
            this.panel_Workspace.Location = new System.Drawing.Point(12, 44);
            this.panel_Workspace.Name = "panel_Workspace";
            this.panel_Workspace.Size = new System.Drawing.Size(1132, 723);
            this.panel_Workspace.TabIndex = 0;
            // 
            // btnClearFandom
            // 
            this.btnClearFandom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFandom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnClearFandom.FlatAppearance.BorderSize = 0;
            this.btnClearFandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFandom.ForeColor = System.Drawing.Color.White;
            this.btnClearFandom.Location = new System.Drawing.Point(4, 503);
            this.btnClearFandom.Name = "btnClearFandom";
            this.btnClearFandom.Size = new System.Drawing.Size(535, 40);
            this.btnClearFandom.TabIndex = 24;
            this.btnClearFandom.TabStop = false;
            this.btnClearFandom.Text = "Không chọn fandom";
            this.btnClearFandom.UseVisualStyleBackColor = false;
            this.btnClearFandom.Click += new System.EventHandler(this.btnClearFandom_Click);
            // 
            // btnAddFandomFromDbToArtist
            // 
            this.btnAddFandomFromDbToArtist.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddFandomFromDbToArtist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnAddFandomFromDbToArtist.FlatAppearance.BorderSize = 0;
            this.btnAddFandomFromDbToArtist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFandomFromDbToArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnAddFandomFromDbToArtist.ForeColor = System.Drawing.Color.White;
            this.btnAddFandomFromDbToArtist.Location = new System.Drawing.Point(545, 24);
            this.btnAddFandomFromDbToArtist.Name = "btnAddFandomFromDbToArtist";
            this.btnAddFandomFromDbToArtist.Size = new System.Drawing.Size(39, 39);
            this.btnAddFandomFromDbToArtist.TabIndex = 8;
            this.btnAddFandomFromDbToArtist.Text = "<<";
            this.btnAddFandomFromDbToArtist.UseVisualStyleBackColor = false;
            this.btnAddFandomFromDbToArtist.Click += new System.EventHandler(this.btnAddFandomFromDbToArtist_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.btnSearchDatabaseFandom);
            this.groupBox6.Controls.Add(this.txValueSearchDatabaseFandom);
            this.groupBox6.Controls.Add(this.cbxSearchDatabaseFandomType);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(4, 549);
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
            // btnSearchDatabaseFandom
            // 
            this.btnSearchDatabaseFandom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchDatabaseFandom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnSearchDatabaseFandom.FlatAppearance.BorderSize = 0;
            this.btnSearchDatabaseFandom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchDatabaseFandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchDatabaseFandom.ForeColor = System.Drawing.Color.White;
            this.btnSearchDatabaseFandom.Location = new System.Drawing.Point(406, 125);
            this.btnSearchDatabaseFandom.Name = "btnSearchDatabaseFandom";
            this.btnSearchDatabaseFandom.Size = new System.Drawing.Size(123, 40);
            this.btnSearchDatabaseFandom.TabIndex = 23;
            this.btnSearchDatabaseFandom.TabStop = false;
            this.btnSearchDatabaseFandom.Text = "Tìm";
            this.btnSearchDatabaseFandom.UseVisualStyleBackColor = false;
            this.btnSearchDatabaseFandom.Click += new System.EventHandler(this.btnSearchDatabaseFandom_Click);
            // 
            // txValueSearchDatabaseFandom
            // 
            this.txValueSearchDatabaseFandom.Location = new System.Drawing.Point(6, 92);
            this.txValueSearchDatabaseFandom.Name = "txValueSearchDatabaseFandom";
            this.txValueSearchDatabaseFandom.Size = new System.Drawing.Size(523, 24);
            this.txValueSearchDatabaseFandom.TabIndex = 1;
            // 
            // cbxSearchDatabaseFandomType
            // 
            this.cbxSearchDatabaseFandomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSearchDatabaseFandomType.FormattingEnabled = true;
            this.cbxSearchDatabaseFandomType.Items.AddRange(new object[] {
            "Tất cả",
            "Id",
            "Tên ",
            "Mô tả"});
            this.cbxSearchDatabaseFandomType.Location = new System.Drawing.Point(6, 55);
            this.cbxSearchDatabaseFandomType.Name = "cbxSearchDatabaseFandomType";
            this.cbxSearchDatabaseFandomType.Size = new System.Drawing.Size(523, 26);
            this.cbxSearchDatabaseFandomType.TabIndex = 0;
            this.cbxSearchDatabaseFandomType.SelectedIndexChanged += new System.EventHandler(this.cbxSearchDatabaseFandomType_SelectedIndexChanged);
            // 
            // groupBox_CurrentFandomInfor
            // 
            this.groupBox_CurrentFandomInfor.Controls.Add(this.label_selectedFandomInfor);
            this.groupBox_CurrentFandomInfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox_CurrentFandomInfor.ForeColor = System.Drawing.Color.White;
            this.groupBox_CurrentFandomInfor.Location = new System.Drawing.Point(4, 3);
            this.groupBox_CurrentFandomInfor.Name = "groupBox_CurrentFandomInfor";
            this.groupBox_CurrentFandomInfor.Size = new System.Drawing.Size(535, 494);
            this.groupBox_CurrentFandomInfor.TabIndex = 4;
            this.groupBox_CurrentFandomInfor.TabStop = false;
            this.groupBox_CurrentFandomInfor.Text = "Fandom hiện tại";
            // 
            // label_selectedFandomInfor
            // 
            this.label_selectedFandomInfor.AutoSize = true;
            this.label_selectedFandomInfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label_selectedFandomInfor.Location = new System.Drawing.Point(6, 21);
            this.label_selectedFandomInfor.Name = "label_selectedFandomInfor";
            this.label_selectedFandomInfor.Size = new System.Drawing.Size(141, 18);
            this.label_selectedFandomInfor.TabIndex = 10;
            this.label_selectedFandomInfor.Text = "Không có fandom";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_DatabaseFandom);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(590, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 717);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fandom trong database";
            // 
            // dataGridView_DatabaseFandom
            // 
            this.dataGridView_DatabaseFandom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_DatabaseFandom.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(55)))), ((int)(((byte)(59)))));
            this.dataGridView_DatabaseFandom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DatabaseFandom.Location = new System.Drawing.Point(6, 21);
            this.dataGridView_DatabaseFandom.Name = "dataGridView_DatabaseFandom";
            this.dataGridView_DatabaseFandom.RowHeadersWidth = 51;
            this.dataGridView_DatabaseFandom.RowTemplate.Height = 24;
            this.dataGridView_DatabaseFandom.Size = new System.Drawing.Size(527, 690);
            this.dataGridView_DatabaseFandom.TabIndex = 1;
            // 
            // Intermediary_Fandom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1156, 779);
            this.Controls.Add(this.panel_Workspace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(1174, 826);
            this.MinimumSize = new System.Drawing.Size(1174, 826);
            this.Name = "Intermediary_Fandom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Intermediary_Image";
            this.Load += new System.EventHandler(this.Intermediary_Fandom_Load);
            this.panel_Workspace.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox_CurrentFandomInfor.ResumeLayout(false);
            this.groupBox_CurrentFandomInfor.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DatabaseFandom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Workspace;
        private System.Windows.Forms.GroupBox groupBox_CurrentFandomInfor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_DatabaseFandom;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbxSearchDatabaseFandomType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchDatabaseFandom;
        private System.Windows.Forms.TextBox txValueSearchDatabaseFandom;
        private System.Windows.Forms.Button btnAddFandomFromDbToArtist;
        private System.Windows.Forms.Label label_selectedFandomInfor;
        private System.Windows.Forms.Button btnClearFandom;
    }
}