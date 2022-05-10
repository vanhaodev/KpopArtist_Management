
namespace ArtistMNG.Subform
{
    partial class TrashTable
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_Grid = new System.Windows.Forms.Panel();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.btnApplyRestore = new System.Windows.Forms.Button();
            this.btnApplyRestoreAll = new System.Windows.Forms.Button();
            this.btnApplyDeleteAll = new System.Windows.Forms.Button();
            this.btnApplyDelete = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel_Grid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Grid
            // 
            this.panel_Grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Grid.Controls.Add(this.dataGridViewData);
            this.panel_Grid.Location = new System.Drawing.Point(12, 12);
            this.panel_Grid.Name = "panel_Grid";
            this.panel_Grid.Size = new System.Drawing.Size(723, 573);
            this.panel_Grid.TabIndex = 0;
            // 
            // dataGridViewData
            // 
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dataGridViewData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewData.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(55)))), ((int)(((byte)(59)))));
            this.dataGridViewData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewData.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewData.GridColor = System.Drawing.SystemColors.ControlText;
            this.dataGridViewData.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewData.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewData.RowHeadersWidth = 51;
            this.dataGridViewData.RowTemplate.Height = 24;
            this.dataGridViewData.Size = new System.Drawing.Size(717, 567);
            this.dataGridViewData.TabIndex = 3;
            this.toolTip1.SetToolTip(this.dataGridViewData, "Có thể bôi đen nhiều dòng để thao tác");
            // 
            // btnApplyRestore
            // 
            this.btnApplyRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnApplyRestore.FlatAppearance.BorderSize = 0;
            this.btnApplyRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyRestore.ForeColor = System.Drawing.Color.White;
            this.btnApplyRestore.Location = new System.Drawing.Point(741, 15);
            this.btnApplyRestore.Name = "btnApplyRestore";
            this.btnApplyRestore.Size = new System.Drawing.Size(164, 40);
            this.btnApplyRestore.TabIndex = 6;
            this.btnApplyRestore.TabStop = false;
            this.btnApplyRestore.Text = "Khôi phục";
            this.toolTip1.SetToolTip(this.btnApplyRestore, "Có thể bôi đen nhiều dòng để thao tác");
            this.btnApplyRestore.UseVisualStyleBackColor = false;
            this.btnApplyRestore.Click += new System.EventHandler(this.btnApplyRestore_Click);
            // 
            // btnApplyRestoreAll
            // 
            this.btnApplyRestoreAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyRestoreAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnApplyRestoreAll.FlatAppearance.BorderSize = 0;
            this.btnApplyRestoreAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyRestoreAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyRestoreAll.ForeColor = System.Drawing.Color.White;
            this.btnApplyRestoreAll.Location = new System.Drawing.Point(741, 61);
            this.btnApplyRestoreAll.Name = "btnApplyRestoreAll";
            this.btnApplyRestoreAll.Size = new System.Drawing.Size(164, 40);
            this.btnApplyRestoreAll.TabIndex = 7;
            this.btnApplyRestoreAll.TabStop = false;
            this.btnApplyRestoreAll.Text = "Khôi phục tất cả";
            this.btnApplyRestoreAll.UseVisualStyleBackColor = false;
            this.btnApplyRestoreAll.Click += new System.EventHandler(this.btnApplyRestoreAll_Click);
            // 
            // btnApplyDeleteAll
            // 
            this.btnApplyDeleteAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyDeleteAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnApplyDeleteAll.FlatAppearance.BorderSize = 0;
            this.btnApplyDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyDeleteAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyDeleteAll.ForeColor = System.Drawing.Color.White;
            this.btnApplyDeleteAll.Location = new System.Drawing.Point(741, 542);
            this.btnApplyDeleteAll.Name = "btnApplyDeleteAll";
            this.btnApplyDeleteAll.Size = new System.Drawing.Size(164, 40);
            this.btnApplyDeleteAll.TabIndex = 9;
            this.btnApplyDeleteAll.TabStop = false;
            this.btnApplyDeleteAll.Text = "Xóa tất cả";
            this.btnApplyDeleteAll.UseVisualStyleBackColor = false;
            this.btnApplyDeleteAll.Click += new System.EventHandler(this.btnApplyDeleteAll_Click);
            // 
            // btnApplyDelete
            // 
            this.btnApplyDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(66)))));
            this.btnApplyDelete.FlatAppearance.BorderSize = 0;
            this.btnApplyDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyDelete.ForeColor = System.Drawing.Color.White;
            this.btnApplyDelete.Location = new System.Drawing.Point(741, 496);
            this.btnApplyDelete.Name = "btnApplyDelete";
            this.btnApplyDelete.Size = new System.Drawing.Size(164, 40);
            this.btnApplyDelete.TabIndex = 8;
            this.btnApplyDelete.TabStop = false;
            this.btnApplyDelete.Text = "Xóa";
            this.toolTip1.SetToolTip(this.btnApplyDelete, "Có thể bôi đen nhiều dòng để thao tác");
            this.btnApplyDelete.UseVisualStyleBackColor = false;
            this.btnApplyDelete.Click += new System.EventHandler(this.btnApplyDelete_Click);
            // 
            // TrashTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(910, 597);
            this.Controls.Add(this.btnApplyDeleteAll);
            this.Controls.Add(this.btnApplyDelete);
            this.Controls.Add(this.btnApplyRestoreAll);
            this.Controls.Add(this.btnApplyRestore);
            this.Controls.Add(this.panel_Grid);
            this.MinimumSize = new System.Drawing.Size(928, 644);
            this.Name = "TrashTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thùng rác";
            this.Load += new System.EventHandler(this.TrashTable_Load);
            this.panel_Grid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Grid;
        private System.Windows.Forms.Button btnApplyRestore;
        private System.Windows.Forms.Button btnApplyRestoreAll;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.Button btnApplyDeleteAll;
        private System.Windows.Forms.Button btnApplyDelete;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}