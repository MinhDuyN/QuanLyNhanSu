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

namespace QuanLiNhanSu_DoAn2
{
    public partial class frmQuanLiTaiKhoan : DevExpress.XtraEditors.XtraForm
    {
        Clsdatabase cls = new Clsdatabase();
        public frmQuanLiTaiKhoan()
        {
            InitializeComponent();
        }
        bool _them;
        void _showHide(bool kt)
        {
            btnHuy.Enabled = !kt;
            btnLuu.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnThoat.Enabled = kt;
            txtTaiKhoan.Enabled = !kt;
            txtMatKhau.Enabled = !kt;
            txtTenThat.Enabled = !kt;
            cboQuyen.Enabled = !kt;
            //dtNgayBatDau.Enabled = !kt;
            //dtNgayKetThuc.Enabled = !kt;
        }
        void reset()
        {
            txtTenThat.Clear();
            cboQuyen.Text = string.Empty;
            txtTaiKhoan.Clear();
            txtMatKhau.Clear();
        }
        public void suatieude()
        {
            dtgv.Columns[0].HeaderText = "Tên tài khoản";
            dtgv.Columns[1].HeaderText = "Mật khẩu";
            dtgv.Columns[2].HeaderText = "Quyền truy cập";
            dtgv.Columns[3].HeaderText = "Tên người dùng";
        }

        private void frmQuanLiTaiKhoan_Load(object sender, EventArgs e)
        {
            cls.loaddatagridview(dtgv, "select * from tb_TAIKHOAN");
            suatieude();
            _them = false;
            _showHide(true);
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true; //Khi nhấn mới thêm
            _showHide(false);
            reset();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string delete = "delete from tb_TAIKHOAN where TAIKHOAN=N'" + txtTaiKhoan.Text + "'";
            if (MessageBox.Show("Bạn có muốn xóa tài khoản này không", "Xóa dữ liệu ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cls.thucthiketnoi(delete);
                cls.loaddatagridview(dtgv, "select * from tb_TAIKHOAN");
                MessageBox.Show("Xóa thành công dữ liệu tài khoản " + txtTaiKhoan.Text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
            }
            else
                MessageBox.Show("Xóa không thành công", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            reset();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = false;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            _them = false;
            _showHide(true);
            reset();
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            _them = false;
            reset();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        void SaveData()
        {
            if (_them)
            {
                try
                {

                    string insert = "insert into tb_TAIKHOAN values(N'" + txtTaiKhoan.Text + "',N'" + txtMatKhau.Text + "',N'" + cboQuyen.Text + "',N'" + txtTenThat.Text + "')";
                    if (cls.kttrungkhoa(txtTaiKhoan.Text, "select * from tb_TAIKHOAN") == true)
                        MessageBox.Show("Tên đăng nhập này đã tồn tại. Bạn có thể thử tên khác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "" || txtTenThat.Text == "")
                    {
                        MessageBox.Show("Bạn vui lòng nhập đủ thông tin khi đăng ký!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        cls.thucthiketnoi(insert);
                        MessageBox.Show("Chúc mừng bạn đã đăng kí thành công tài khoản mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cls.loaddatagridview(dtgv, "select * from tb_TAIKHOAN");
                        //this.Close();
                        reset();
                    }
                }
                catch
                {
                    MessageBox.Show("Dữ liệu đầu vào không đúng","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    //reset();
                }
            }
            else
            {
                try
                {
                    string update = "update tb_TAIKHOAN set taikhoan=N'" + txtTaiKhoan.Text + "',matkhau=N'" + txtMatKhau.Text + "',quyen=N'" + cboQuyen.Text + "',tenthat=N'" + txtTenThat.Text + "' where taikhoan='" + txtTaiKhoan.Text + "'";
                    cls.thucthiketnoi(update);
                    cls.loaddatagridview(dtgv, "select * from tb_TAIKHOAN");
                    MessageBox.Show("Sửa thành công dữ liệu tài khoản " + txtTaiKhoan.Text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                }
                catch
                {
                    MessageBox.Show("Dữ liệu đầu vào không đúng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reset();
                }
            }
        }

        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int hang = e.RowIndex;
                txtTaiKhoan.Text = dtgv.Rows[hang].Cells[0].Value.ToString();
                txtMatKhau.Text = dtgv.Rows[hang].Cells[1].Value.ToString();
                txtTenThat.Text = dtgv.Rows[hang].Cells[3].Value.ToString();
                cboQuyen.Text = dtgv.Rows[hang].Cells[2].Value.ToString();
            }
            catch (Exception)
            {
            }
        }
    }
}