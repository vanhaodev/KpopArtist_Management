using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtistMNG.Module
{
    public static class DatagridViewStyle
    {
        /// <summary>
        /// Chuyển đổi màu sắc của datagird về màu Dark (Design by NVH2001 - Vanhaodev)
        /// </summary>
        /// <param name="dataGridView"></param>
        public static void DarkStyle(DataGridView dataGridView)
        {
            dataGridView.DefaultCellStyle.BackColor = Color.FromArgb(73, 73, 77);
            dataGridView.DefaultCellStyle.ForeColor = Color.FromArgb(230, 230, 230);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.FromArgb(222, 196, 0);
            dataGridView.DefaultCellStyle.Font = new Font("Roboto", 10, FontStyle.Bold);
            dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView.GridColor = Color.Black;

            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(96, 96, 102);
            dataGridView.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(230, 230, 230);
            dataGridView.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(30, 30, 30);
            dataGridView.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(222, 196, 0);
            dataGridView.AlternatingRowsDefaultCellStyle.Font = new Font("Roboto", 10, FontStyle.Bold);
            dataGridView.AlternatingRowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Roboto", 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(230, 230, 230);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dataGridView.AllowUserToAddRows = false;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public static void MinimumWidth(DataGridView dataGridView, int width)
        {
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                dataGridView.Columns[i].MinimumWidth = width;
            }
        }
    }
}
