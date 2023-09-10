using DevExpress.XtraEditors;
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

namespace QuanLiNhanSu_DoAn2
{
    public partial class frmInDanhSachNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmInDanhSachNhanVien()
        {
            InitializeComponent();
        }

        private void frmInDanhSachNhanVien_Load(object sender, EventArgs e)
        {
            Clsdatabase connect = new Clsdatabase();
            SqlConnection conn = connect.ketnoicrystal();
            if (connect.getloi() == "")
            {
                SqlDataAdapter dap = new SqlDataAdapter("Select * from tb_NHANVIEN", conn);
                DataSet ds = new DataSet();
                dap.Fill(ds);
                DanhSachNhanVien rpt = new DanhSachNhanVien();
                rpt.SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = rpt;
            }
        }
    }
}