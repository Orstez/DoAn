using QLKS.rpt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS.Report
{
    public partial class HoaDon : Form
    {
        private string p_ID;
        //private string p_MaPhieuThue;
        //private string p_DatCoc;
        //private DateTime p_NgayNhanPhong;
        //private DateTime p_NgayTraPhong;
        //private string p_NgayThue;
        //private string p_TienDV;
        //private string p_TienPhong;
        //private string p_TongTien;
      
        new Ketnoi data = new Ketnoi();
        public HoaDon()
        {
            InitializeComponent();
        }

       // public HoaDon(string p_ID, string p_MaPhieuThue, string p_DatCoc, DateTime p_NgayNhanPhong, DateTime p_NgayTraPhong, string p_NgayThue, string p_TienDV, string p_TienPhong, string p_TongTien) : this()

        public HoaDon(string p_ID) : this()
        {
            this.p_ID = p_ID;
            //this.p_MaPhieuThue = p_MaPhieuThue;
            //this.p_DatCoc = p_DatCoc;
            //this.p_NgayNhanPhong = p_NgayNhanPhong;
            //this.p_NgayTraPhong = p_NgayTraPhong;
            //this.p_NgayThue = p_NgayThue;
            //this.p_TienDV = p_TienDV;
            //this.p_TienPhong = p_TienPhong;
            //this.p_TongTien = p_TongTien;
        }


        private void HoaDon_Load(object sender, EventArgs e)
        {
            rptHoaDon rpt = new rptHoaDon();
            SqlConnection MyConnect = data.getConnect();
            SqlCommand cmd = new SqlCommand("REPORT_HOADON_TONG", MyConnect);
            cmd.Parameters.AddWithValue("@ID", p_ID);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            rpt.SetDataSource(tb);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
