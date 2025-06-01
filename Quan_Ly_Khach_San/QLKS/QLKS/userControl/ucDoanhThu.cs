using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLKS.rpt;
using QLKS.Report;
using DevExpress.XtraCharts.Native;

namespace QLKS.userControl
{
    public partial class ucDoanhThu : UserControl
    {
        Ketnoi data= new Ketnoi();
        public ucDoanhThu()
        {
            InitializeComponent();
        }
        #region Connect UC
        public static ucDoanhThu _instrance;
        public static ucDoanhThu Instrance
        {

            get
            {
                if (_instrance == null)
                    _instrance = new ucDoanhThu();
                return _instrance;
            }
        }
        #endregion

        #region Variables
        #endregion
        SqlConnection conn;
        private void ucDoanhThu_Load(object sender, EventArgs e)
        {
            rptDoanhThu rpt = new rptDoanhThu();
            conn = data.getConnect(); 
            SqlCommand cmd = new SqlCommand("REPORT_DOANHTHU", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);

            cmd.Dispose();
            conn.Close(); 

            rpt.SetDataSource(tb); 
            crystalReportViewer1.ReportSource = rpt;
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
