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
    public partial class frmInLuong : DevExpress.XtraEditors.XtraForm
    {
        public frmInLuong()
        {
            InitializeComponent();
        }

        private void frmInLuong_Load(object sender, EventArgs e)
        {
            Clsdatabase connect = new Clsdatabase();
            SqlConnection conn = connect.ketnoicrystal();
            if (connect.getloi() == "")
            {
                SqlDataAdapter dap = new SqlDataAdapter("Select * from tb_LUONGNV", conn);
                DataSet ds = new DataSet();
                dap.Fill(ds);
                LuongNV rpt = new LuongNV();
                rpt.SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = rpt;
            }
        }
    }
}