
namespace ArtistMNG.Subform
{
    partial class Intermediary_Label
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
            this.btnClearLabel = new System.Windows.Forms.Button();
            this.btnAddLabelFromDbToArtist = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchDatabaseLabel = new System.Windows.Forms.Button();
            this.txValueSearchDatabaseLabel = new System.Windows.Forms.TextBox();
            this.cbxSearchDatabaseLabelType = new System.Windows.Forms.ComboBox();
            this.groupBox_CurrentLabelInfor = new System.Windows.Forms.GroupBox();
            this.label_selectedLabelInfor = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_DatabaseLabel = new System.Windows.Forms.DataGridView();
            this.panel_Workspace.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox_CurrentLabelInfor.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DatabaseLabel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Workspace
            // 
            this.panel_Workspace.Controls.Add(this.btnClearLabel);
            this.panel_Workspace.Controls.Add(this.btnAddLabelFromDbToArtist);
            this.panel_Workspace.Controls.Add(this.groupBox6);
            this.panel_Workspace.Controls.Add(this.groupBox_CurrentLabelInfor);
            this.panel_Workspace.Controls.Add(this.groupBox2);
            this.panel_Workspace.Location = new System.Drawing.Point(12, 44);
            this.panel_Workspace.Name = "panel_Workspace";
            this.panel_Workspace.Size = new System.Drawing.Size(1132, 723);
            this.panel_Workspace.TabIndex = 0;
            // 
            // btnClearLabel
            // 
            this.btnClearLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnClearLabel.FlatAppearance.BorderSize = 0;
            this.btnClearLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLabel.ForeColor = System.Drawing.Color.White;
            this.btnClearLabel.Location = new System.Drawing.Point(4, 503);
            this.btnClearLabel.Name = "btnClearLabel";
            this.btnClearLabel.Size = new System.Drawing.Size(535, 40);
            this.btnClearLabel.TabIndex = 24;
            this.btnClearLabel.TabStop = false;
            this.btnClearLabel.Text = "Không chọn công ty";
            this.btnClearLabel.UseVisualStyleBackColor = false;
            this.btnClearLabel.Click += new System.EventHandler(this.btnClearFandom_Click);
            // 
            // btnAddLabelFromDbToArtist
            // 
            this.btnAddLabelFromDbToArtist.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddLabelFromDbToArtist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnAddLabelFromDbToArtist.FlatAppearance.BorderSize = 0;
            this.btnAddLabelFromDbToArtist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLabelFromDbToArtist.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.btnAddLabelFromDbToArtist.ForeColor = System.Drawing.Color.White;
            this.btnAddLabelFromDbToArtist.Location = new System.Drawing.Point(545, 24);
            this.btnAddLabelFromDbToArtist.Name = "btnAddLabelFromDbToArtist";
            this.btnAddLabelFromDbToArtist.Size = new System.Drawing.Size(39, 39);
            this.btnAddLabelFromDbToArtist.TabIndex = 8;
            this.btnAddLabelFromDbToArtist.Text = "<<";
            this.btnAddLabelFromDbToArtist.UseVisualStyleBackColor = false;
            this.btnAddLabelFromDbToArtist.Click += new System.EventHandler(this.btnAddLabelFromDbToArtist_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.btnSearchDatabaseLabel);
            this.groupBox6.Controls.Add(this.txValueSearchDatabaseLabel);
            this.groupBox6.Controls.Add(this.cbxSearchDatabaseLabelType);
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
            // btnSearchDatabaseLabel
            // 
            this.btnSearchDatabaseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchDatabaseLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnSearchDatabaseLabel.FlatAppearance.BorderSize = 0;
            this.btnSearchDatabaseLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchDatabaseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchDatabaseLabel.ForeColor = System.Drawing.Color.White;
            this.btnSearchDatabaseLabel.Location = new System.Drawing.Point(406, 125);
            this.btnSearchDatabaseLabel.Name = "btnSearchDatabaseLabel";
            this.btnSearchDatabaseLabel.Size = new System.Drawing.Size(123, 40);
            this.btnSearchDatabaseLabel.TabIndex = 23;
            this.btnSearchDatabaseLabel.TabStop = false;
            this.btnSearchDatabaseLabel.Text = "Tìm";
            this.btnSearchDatabaseLabel.UseVisualStyleBackColor = false;
            this.btnSearchDatabaseLabel.Click += new System.EventHandler(this.btnSearchDatabaseFandom_Click);
            // 
            // txValueSearchDatabaseLabel
            // 
            this.txValueSearchDatabaseLabel.Location = new System.Drawing.Point(6, 92);
            this.txValueSearchDatabaseLabel.Name = "txValueSearchDatabaseLabel";
            this.txValueSearchDatabaseLabel.Size = new System.Drawing.Size(523, 24);
            this.txValueSearchDatabaseLabel.TabIndex = 1;
            // 
            // cbxSearchDatabaseLabelType
            // 
            this.cbxSearchDatabaseLabelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSearchDatabaseLabelType.FormattingEnabled = true;
            this.cbxSearchDatabaseLabelType.Items.AddRange(new object[] {
            "Tất cả",
            "Id",
            "Tên ",
            "Người thành lập",
            "Mô tả"});
            this.cbxSearchDatabaseLabelType.Location = new System.Drawing.Point(6, 55);
            this.cbxSearchDatabaseLabelType.Name = "cbxSearchDatabaseLabelType";
            this.cbxSearchDatabaseLabelType.Size = new System.Drawing.Size(523, 26);
            this.cbxSearchDatabaseLabelType.TabIndex = 0;
            this.cbxSearchDatabaseLabelType.SelectedIndexChanged += new System.EventHandler(this.cbxSearchDatabaseFandomType_SelectedIndexChanged);
            // 
            // groupBox_CurrentLabelInfor
            // 
            this.groupBox_CurrentLabelInfor.Controls.Add(this.label_selectedLabelInfor);
            this.groupBox_CurrentLabelInfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox_CurrentLabelInfor.ForeColor = System.Drawing.Color.White;
            this.groupBox_CurrentLabelInfor.Location = new System.Drawing.Point(4, 3);
            this.groupBox_CurrentLabelInfor.Name = "groupBox_CurrentLabelInfor";
            this.groupBox_CurrentLabelInfor.Size = new System.Drawing.Size(535, 494);
            this.groupBox_CurrentLabelInfor.TabIndex = 4;
            this.groupBox_CurrentLabelInfor.TabStop = false;
            this.groupBox_CurrentLabelInfor.Text = "Công ty hiện tại";
            // 
            // label_selectedLabelInfor
            // 
            this.label_selectedLabelInfor.AutoSize = true;
            this.label_selectedLabelInfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label_selectedLabelInfor.Location = new System.Drawing.Point(6, 21);
            this.label_selectedLabelInfor.Name = "label_selectedLabelInfor";
            this.label_selectedLabelInfor.Size = new System.Drawing.Size(140, 18);
            this.label_selectedLabelInfor.TabIndex = 10;
            this.label_selectedLabelInfor.Text = "Không có công ty";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_DatabaseLabel);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(590, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 717);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Công ty trong database";
            // 
            // dataGridView_DatabaseLabel
            // 
            this.dataGridView_DatabaseLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_DatabaseLabel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(55)))), ((int)(((byte)(59)))));
            this.dataGridView_DatabaseLabel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DatabaseLabel.Location = new System.Drawing.Point(6, 21);
            this.dataGridView_DatabaseLabel.Name = "dataGridView_DatabaseLabel";
            this.dataGridView_DatabaseLabel.RowHeadersWidth = 51;
            this.dataGridView_DatabaseLabel.RowTemplate.Height = 24;
            this.dataGridView_DatabaseLabel.Size = new System.Drawing.Size(527, 690);
            this.dataGridView_DatabaseLabel.TabIndex = 1;
            // 
            // Intermediary_Label
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1156, 779);
            this.Controls.Add(this.panel_Workspace);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(1174, 826);
            this.MinimumSize = new System.Drawing.Size(1174, 826);
            this.Name = "Intermediary_Label";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Công ty";
            this.Load += new System.EventHandler(this.Intermediary_Fandom_Load);
            this.panel_Workspace.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox_CurrentLabelInfor.ResumeLayout(false);
            this.groupBox_CurrentLabelInfor.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DatabaseLabel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Workspace;
        private System.Windows.Forms.GroupBox groupBox_CurrentLabelInfor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_DatabaseLabel;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbxSearchDatabaseLabelType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchDatabaseLabel;
        private System.Windows.Forms.TextBox txValueSearchDatabaseLabel;
        private System.Windows.Forms.Button btnAddLabelFromDbToArtist;
        private System.Windows.Forms.Label label_selectedLabelInfor;
        private System.Windows.Forms.Button btnClearLabel;
    }
}