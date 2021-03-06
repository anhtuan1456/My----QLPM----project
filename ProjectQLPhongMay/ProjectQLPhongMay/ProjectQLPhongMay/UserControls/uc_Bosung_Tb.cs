﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
namespace ProjectQLPhongMay.UserControls
{
     
    public partial class uc_Bosung_Tb : UserControl
    {
        public ICallBack ICall { get; set; }
        private SqlConnection strconnect;
        public uc_Bosung_Tb(SqlConnection strconnect)
        {
            InitializeComponent();
            this.strconnect = strconnect;
        }

        private void uc_Bosung_Tb_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SP_THONGKE_BOSUNGTB_TB", strconnect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@time1", dateTime1.Value));
            command.Parameters.Add(new SqlParameter("@time2", dateTime2.Value));
            SqlDataAdapter da_thongke = new SqlDataAdapter(command);
            DataTable dt_thongkebosung_Ct = new DataTable();
            da_thongke.Fill(dt_thongkebosung_Ct);

            gridControl1.DataSource = dt_thongkebosung_Ct;
        }

        private void btnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                excel.ActiveWorkbook.SaveCopyAs("D:\\Danhsachbosungtb.xlsx");
                excel.ActiveWorkbook.Saved = true;
                MessageBox.Show("Bạn đã xuất dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
           
        }

        private void btnThongke_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlCommand command = new SqlCommand("SP_THONGKE_BOSUNGTB_TB", strconnect);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@time1", dateTime1.Value));
            command.Parameters.Add(new SqlParameter("@time2", dateTime2.Value));
            SqlDataAdapter da_thongke = new SqlDataAdapter(command);
            DataTable dt_thongkebosung_Ct = new DataTable();
            da_thongke.Fill(dt_thongkebosung_Ct);

            gridControl1.DataSource = dt_thongkebosung_Ct;
        }

     

          
       
    }
}
