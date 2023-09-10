using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data;
using System.Data.SqlClient;
namespace QuanLiNhanSu_DoAn2
{
    public partial class frmInBangChamCong : DevExpress.XtraEditors.XtraForm
    {
        public frmInBangChamCong()
        {
            InitializeComponent();
        }

        private void frmInBangChamCong_Load(object sender, EventArgs e)
        {
            Clsdatabase connect = new Clsdatabase();
            SqlConnection conn = connect.ketnoicrystal();
            if (connect.getloi() == "")
            {
                SqlDataAdapter dap = new SqlDataAdapter("Select * from tb_KYCONGCHITIET", conn);
                DataSet ds = new DataSet();
                dap.Fill(ds);
                BangChamCong rpt = new BangChamCong();
                rpt.SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = rpt;
            }
        }
    }
}