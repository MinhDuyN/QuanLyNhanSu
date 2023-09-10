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
    public partial class MainFrm : DevExpress.XtraEditors.XtraForm
    {
        public MainFrm()
        {
            InitializeComponent();
            customizeDesing();//Chạy phần custom form
        }
       
        private void customizeDesing()
        {
            panel_taikhoan.Visible = false;
            panel_danhmuc.Visible = false;
            panel_chucnang.Visible = false;
            panel_quanly.Visible = false;
        }

        private void hideSubMenu() //Ẩn menu con
        {
            if (panel_taikhoan.Visible == true)
                panel_taikhoan.Visible = false;
            if (panel_danhmuc.Visible == true)
                panel_danhmuc.Visible = false;
            if (panel_chucnang.Visible == true)
                panel_chucnang.Visible = false;
            if (panel_quanly.Visible == true)
                panel_quanly.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        //public static string taikhoan;
        string laytaikhoan;
        string LayTenDangNhap = "", MatKhau = "", Quyen = "", TenThat = "";

        private void bt_danhmuc_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_chucnang);
           
        }

        private void bt_timkiem_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_quanly);
        }

        private void bt_trogiup_Click(object sender, EventArgs e)
        {
            frmTroGiup frmTroGiup = new frmTroGiup();
            frmTroGiup.Show();
        }

        private void bt_dangnhap_Click(object sender, EventArgs e)
        {
            frmDangNhap frmdangnhap = new frmDangNhap();
            frmdangnhap.Show();
            this.Hide();
        }

        private void bt_quanlytaikhoan_Click(object sender, EventArgs e)
        {
            frmQuanLiTaiKhoan frmquanlytaikhoan = new frmQuanLiTaiKhoan();
            frmquanlytaikhoan.Show();
        }

        private void bt_doimatkhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frmdoipass = new frmDoiMatKhau(lb_taikhoan.Text);
            frmdoipass.Show();
        }

        private void bt_dangxuat_Click(object sender, EventArgs e)
        {
            frmDangNhap frmdangnhap = new frmDangNhap();
            frmdangnhap.Show();
            this.Hide();
        }

        private void bt_bophan_Click(object sender, EventArgs e)
        {
            frmBoPhan frmbophan = new frmBoPhan();
            frmbophan.Show();
        }

        private void bt_luong_Click(object sender, EventArgs e)
        {
            frmLuong frmluong = new frmLuong();
            frmluong.Show();
        }

        private void bt_phongban_Click(object sender, EventArgs e)
        {
            frmPhongBan frmphongban = new frmPhongBan();
            frmphongban.Show();
        }

        private void bt_bangluong_Click(object sender, EventArgs e)
        {
            frmBangCong frmBangCong = new frmBangCong();
            frmBangCong.Show();
        }

        private void bt_thongtincanhan_Click(object sender, EventArgs e)
        {
           
        }

        private void bt_nhansu_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien frmnhanvien = new frmQuanLyNhanVien();
            frmnhanvien.Show();
        }

        private void btnKhenThuong_Click(object sender, EventArgs e)
        {
            frmKhenThuong frm = new frmKhenThuong();
            frm.Show();
        }

        private void btnKyLuat_Click(object sender, EventArgs e)
        {
            frmKyLuat frm = new frmKyLuat();
            frm.Show();
        }

        private void bt_nhanviennghiviec_Click(object sender, EventArgs e)
        {
            frmNhanVienNghiViec frmnghiviec = new frmNhanVienNghiViec();
            frmnghiviec.Show();
        }

        private void bt_luongnhanvien_Click(object sender, EventArgs e)
        {
            frmTimKiemLuong frm = new frmTimKiemLuong();
            frm.Show();
        }

        private void bt_thongtinnhanvien_Click(object sender, EventArgs e)
        {
            frmTimKiemTTNV frm = new frmTimKiemTTNV();
            frm.Show();
        }
        NHANVIEN _nhanvien;
        void loadSinhNhat()
        {
            lstSinhNhat.DataSource = _nhanvien.getSinhNhat();
            lstSinhNhat.DisplayMember = "HoTen";
            lstSinhNhat.ValueMember = "MaNV";
        }
        private void MainFrm_Load(object sender, EventArgs e)
        {
            _nhanvien = new NHANVIEN();
           

            bt_dangnhap.Enabled = true;
            bt_quanlytaikhoan.Enabled = false;
            bt_danhmuc.Enabled = false;
            bt_quanly.Enabled = false;
            bt_timkiem.Enabled = false;
            bt_doimatkhau.Enabled = false;
            bt_dangxuat.Enabled = false;

            if (Quyen == "admin")
            {
                MessageBox.Show("Xin chào " + lb_taikhoan.Text + " với quyền " + lb_quyen.Text + "", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadSinhNhat();
                bt_dangnhap.Enabled = false;
                bt_quanlytaikhoan.Enabled = true;
                bt_doimatkhau.Enabled = true;
                bt_danhmuc.Enabled = true;
                bt_timkiem.Enabled = true;
                bt_quanly.Enabled = true;
                bt_dangxuat.Enabled = true;
            }
            else if (Quyen == "user")
            {
                MessageBox.Show("Xin chào " + lb_taikhoan.Text + " với quyền " + lb_quyen.Text + "", "Chúc mừng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadSinhNhat();
                bt_dangnhap.Enabled = false;
                bt_danhmuc.Enabled = false;
                bt_quanly.Enabled = false;
                bt_timkiem.Enabled = true;
                bt_doimatkhau.Enabled = true;
                bt_dangxuat.Enabled = true;
            }
        }

        private void btnGuiMail_Click(object sender, EventArgs e)
        {
            frmGuiMail frmGuiMail = new frmGuiMail();
            frmGuiMail.Show();
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void bt_quanly_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_danhmuc);
        }

        private void bt_taikhoan_Click(object sender, EventArgs e)
        {
            showSubMenu(panel_taikhoan);
        }

        public MainFrm(string TenDangNhap, string MatKhau, string Quyen, string TenThat)
        {
            InitializeComponent();
            customizeDesing(); //Chạy phần custom form
            lb_taikhoan.Text = TenDangNhap;
            lb_quyen.Text = Quyen;
            this.LayTenDangNhap = TenDangNhap;
            this.MatKhau = MatKhau;
            this.Quyen = Quyen;
            this.TenThat = TenThat;
        }
    }
}