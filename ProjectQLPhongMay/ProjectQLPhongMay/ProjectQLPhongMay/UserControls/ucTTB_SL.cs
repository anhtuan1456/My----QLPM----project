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
    public partial class ucTTB_SL : UserControl
    {
        private SqlConnection strconnect;
        public ucTTB_SL(SqlConnection strconnect)
        {
            InitializeComponent();
            this.strconnect = strconnect;
        }

        private void ucTTB_Ct_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SP_THONGKESOLUONG_PHUONGMAY", strconnect);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da_thongke = new SqlDataAdapter(command);
            DataTable dt_thongke = new DataTable();
            da_thongke.Fill(dt_thongke);

            gridControl1.DataSource = dt_thongke;
        }

        private void barButtonItem1_ItemClick(object sender, string  title, DevExpress.XtraBars.ItemClickEventArgs e)
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
                excel.ActiveWorkbook.SaveCopyAs("D:\\Danhsachsotbpm.xlsx");
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
