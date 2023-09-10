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
    public partial class frmDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        Clsdatabase cls = new Clsdatabase();
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        public frmDoiMatKhau(string TenDangNhap) : this()
        {
            txtTaiKhoan.Text = TenDangNhap.ToString();
        }
        public void reset()
        {
            txtMatKhauCu.Clear();
            txtMatKhauMoi.Clear();
            txtXacNhan.Clear();
        }
      

        private void btnXacNhan_Click_1(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-2EEB116\SA;Initial Catalog=QLNS;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Select * From tb_TAIKHOAN where TAIKHOAN='" + txtTaiKhoan.Text + "'", cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string matkhaucu = dt.Rows[0][1].ToString();
            string update = "update tb_TAIKHOAN set MATKHAU='" + txtMatKhauMoi.Text + "' where(TAIKHOAN=N'" + txtTaiKhoan.Text + "' and MATKHAU='" + txtMatKhauCu.Text + "')";
            string ten = txtTaiKhoan.Text;

            if (txtMatKhauCu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mật khẩu cũ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtMatKhauMoi.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu mới", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (txtXacNhan.Text == "")
                    {
                        MessageBox.Show("Bạn chưa xác nhận lại lại mật khẩu", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (matkhaucu == txtMatKhauCu.Text)
                        {
                            if (txtMatKhauMoi.Text == txtXacNhan.Text)
                            {
                                cls.thucthiketnoi(update);
                                MessageBox.Show("Bạn đã thay đổi mật khẩu thành công", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                reset();
                            }
                            else
                            {
                                MessageBox.Show("Bạn nhập lại mật khẩu không đúng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu cũ sai", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                }
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}