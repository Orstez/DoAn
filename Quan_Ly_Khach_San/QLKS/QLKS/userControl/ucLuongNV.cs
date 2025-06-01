using System;
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
    public partial class ucLuongNV : UserControl
    {
        Ketnoi data = new Ketnoi();
        public ucLuongNV()
        {
            InitializeComponent();
        }
        #region Connect UC
        public static ucLuongNV _instrance;
        public static ucLuongNV Instrance
        {

            get
            {
                if (_instrance == null)
                    _instrance = new ucLuongNV();
                return _instrance;
            }
        }
        #endregion

        #region Variables
        #endregion
        private void ucLuongNV_Load(object sender, EventArgs e)
        {
            rptKhachHang rpt = new rptKhachHang();


            SqlConnection con = data.getConnect();
            con.Open();

            SqlCommand cmd = new SqlCommand("LUONG_NHANVIEN", con);
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
