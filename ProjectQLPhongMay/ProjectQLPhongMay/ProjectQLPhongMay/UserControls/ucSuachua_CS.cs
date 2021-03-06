﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectQLPhongMay.uc
{
    public partial class ucSuachua_CS : UserControl
    {
        private SqlConnection strconnect;
        public ucSuachua_CS(SqlConnection strconnect)
        {
            InitializeComponent();
            this.strconnect = strconnect;
        }

        private void ucSuachua_CS_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SP_THONGKESUACHUA_CHUASUA", strconnect);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da_thongkesuachua_chuasua = new SqlDataAdapter(command);
            DataTable dt_thongkesuachua_chuasua = new DataTable();
            da_thongkesuachua_chuasua.Fill(dt_thongkesuachua_chuasua);

            gridCSuachuaCS.DataSource = dt_thongkesuachua_chuasua;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < gridView1.Columns.Count + 1; i++)
                    excel.Cells[1, i] = gridView1.Columns[i - 1].GetTextCaption();
                for (int i = 1; i < gridView1.Columns.Count + 1; i++)
                    for (int j = 1; j < gridView1.RowCount; j++)
                        excel.Cells[j + 1, i] = gridView1.GetRowCellValue(j - 1, gridView1.Columns[i - 1]).ToString();
                excel.ActiveWorkbook.SaveCopyAs("D:\\Danhsachthietbichuasua.xlsx");
                excel.ActiveWorkbook.Saved = true;
                MessageBox.Show("Bạn đã xuất dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
