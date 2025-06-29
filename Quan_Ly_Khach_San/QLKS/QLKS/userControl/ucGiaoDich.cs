﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKS.rpt;
using System.Data.SqlClient;
using QLKS.Report;

namespace QLKS.userControl
{
    public partial class ucGiaoDich : UserControl
    {
        Ketnoi data= new Ketnoi();
        public ucGiaoDich()
        {
            InitializeComponent();
        }
        #region Connect UC
        public static ucGiaoDich _instrance;
        public static ucGiaoDich Instrance
        {

            get
            {
                if (_instrance == null)
                    _instrance = new ucGiaoDich();
                return _instrance;
            }
        }
        #endregion

        #region Variables
        #endregion
        private void ucGiaoDich_Load(object sender, EventArgs e)
        {
            rptKhachHang rpt = new rptKhachHang();

            
            SqlConnection con = data.getConnect();
            con.Open();

            SqlCommand cmd = new SqlCommand("REPORT_KHACHHANG", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);

            cmd.Dispose();
            con.Close(); 

            rpt.SetDataSource(tb); 
            crystalReportViewer1.ReportSource = rpt;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
