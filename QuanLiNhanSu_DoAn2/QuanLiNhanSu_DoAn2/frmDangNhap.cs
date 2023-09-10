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
using System.Data.SqlClient;
namespace QuanLiNhanSu_DoAn2
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter();
        int i;

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-2EEB116\SA;Initial Catalog=QLNS;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Select * From tb_TAIKHOAN where TAIKHOAN='" + txtTaiKhoan.Text + "' and MATKHAU='" + txtMatKhau.Text + "'", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (i < 2)
            {

                if (dt.Rows.Count > 0)
                {
                    this.Hide();
                    MainFrm frmMain = new MainFrm(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString());
                    frmMain.Show();
                }
                else
                {
                    i++;
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Bạn nhập sai quá nhiều lần!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Hệ thống sẽ tự động thoát", "Nghi vấn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}