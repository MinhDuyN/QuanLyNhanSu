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

using DevExpress.XtraReports.UI;
namespace QuanLiNhanSu_DoAn2
{
    public partial class frmQuanLyNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }
        Clsdatabase cls = new Clsdatabase();
        public static SqlConnection Con;
        NHANVIEN _nhanvien;
        bool _them;
        void _showHide(bool kt)
        {
            btnHuy.Enabled = !kt;
            btnLuu.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnThoat.Enabled = kt;
            cboMaBoPhan.Enabled = !kt;
            cboMaPhong.Enabled = !kt;
            cboMaLuong.Enabled = !kt;
            cboTinhTrangHonNhan.Enabled = !kt;
            cboGioiTinh.Enabled = !kt;
            txtHoTen.Enabled = !kt;
            txtMaNV.Enabled = !kt;
            txtCMND.Enabled = !kt;
            txtNoiCap.Enabled = !kt;
            txtChucVu.Enabled = !kt;
            txtLoaiHopDong.Enabled = !kt;
            txtThoiGian.Enabled = !kt;
            txtGhiChu.Enabled = !kt;
            dtNgaySinh.Enabled = !kt;
            dtNgayKy.Enabled = !kt;
            dtNgayHetHan.Enabled = !kt;
        }
        void reset()
        {
            cboMaBoPhan.Text = string.Empty;
            cboMaPhong.Text = string.Empty;
            cboMaLuong.Text = string.Empty;
            cboTinhTrangHonNhan.Text = string.Empty;
            cboGioiTinh.Text = string.Empty;
            txtHoTen.Clear();
            txtMaNV.Clear();
            txtCMND.Clear();
            txtNoiCap.Clear();
            txtChucVu.Clear();
            txtLoaiHopDong.Clear();
            txtThoiGian.Clear();
            txtGhiChu.Clear();
        }
        public void suatieude()
        {
            dtgv.Columns[0].HeaderText = "Mã bộ phận";
            dtgv.Columns[1].HeaderText = "Mã phòng ban";
            dtgv.Columns[2].HeaderText = "Mã nhân viên";
            dtgv.Columns[3].HeaderText = "Họ tên";
            dtgv.Columns[4].HeaderText = "Mã lương";
            dtgv.Columns[5].HeaderText = "Ngày sinh";
            dtgv.Columns[6].HeaderText = "Giới tính";
            dtgv.Columns[7].HeaderText = "Hôn nhân";
            dtgv.Columns[8].HeaderText = "CMND/CCCD";
            dtgv.Columns[9].HeaderText = "Nơi cấp";
            dtgv.Columns[10].HeaderText = "Chức vụ";
            dtgv.Columns[11].HeaderText = "Loại hợp đồng";
            dtgv.Columns[12].HeaderText = "Thời gian";
            dtgv.Columns[13].HeaderText = "Ngày ký";
            dtgv.Columns[14].HeaderText = "Ngày hết hạn";
            dtgv.Columns[15].HeaderText = "Ghi chú";
            dtgv.Columns[16].HeaderText = "Mã công ty";
        }
        public static void FillCombo(string sql, System.Windows.Forms.ComboBox cbo, string ma, string ten)
        {

            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị

        }



        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            _nhanvien = new NHANVIEN();
            _them = false;
            _showHide(true);
            Con = new SqlConnection();
            Con.ConnectionString = @"Data Source=DESKTOP-2EEB116\SA;Initial Catalog=QLNS;Integrated Security=True";
            cls.loadcombobox(cboMaLuong, "select MaLuong from tb_BANGLUONG", 0);
            frmQuanLyNhanVien.FillCombo("SELECT MaBoPhan FROM tb_BOPHAN", cboMaBoPhan, "MaBoPhan", "MaBoPhan");
            cboMaBoPhan.SelectedIndex = -1;
            cls.loaddatagridview(dtgv, "select * from tb_NHANVIEN");
            suatieude();
            txtMaCTY.Text = "1";
            txtMaCTY.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true; //Khi nhấn mới thêm
            _showHide(false);
            reset();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //MessageBox.Show("Thêm thành công dữ liệu vào bảng NVThoiViec");
            string delete = "delete from tb_NHANVIEN where MaNV=N'" + txtMaNV.Text + "'";
            if (MessageBox.Show("Bạn có muốn xóa nhân viên " + txtMaNV.Text + " không", "Xóa dữ liệu ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string insert = "insert into tb_NGHIVIEC(HoTen,CMTND) select HoTen,CMTND from tb_NHANVIEN where MaNV='" + txtMaNV.Text + "'";
                {
                    cls.thucthiketnoi(insert);
                    cls.loaddatagridview(dtgv, "select * from tb_NHANVIEN");
                }
                cls.thucthiketnoi(delete);
                cls.loaddatagridview(dtgv, "select * from tb_NHANVIEN");
                //cls.loaddatagridview(dtgv_thongtincanhan, "select * from TblTTNVCoBan");
                MessageBox.Show("Xóa thành công dữ liệu nhân viên " + txtHoTen.Text + " thành công và nhân viên này được thêm vào bảng thôi làm","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                dtgv.Refresh();
                reset();
            }
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
                string insert = "insert into tb_NHANVIEN values(N'" + cboMaBoPhan.Text + "',N'" + cboMaPhong.Text + "',N'" + txtMaNV.Text + "',N'" + txtHoTen.Text + "',N'" + cboMaLuong.Text + "',N'" + dtNgaySinh.Text + "',N'" + cboGioiTinh.Text + "',N'" + cboTinhTrangHonNhan.Text + "',N'" + txtCMND.Text + "',N'" + txtNoiCap.Text + "',N'" + txtChucVu.Text + "',N'" + txtLoaiHopDong.Text + "',N'" + txtThoiGian.Text + "',N'" + dtNgayKy.Text + "',N'" + dtNgayHetHan.Text + "',N'" + txtGhiChu.Text + "',N'" + txtMaCTY.Text + "')";

                if ((!cls.kttrungkhoa(txtMaNV.Text, "select MaNV from tb_NHANVIEN")) && (!cls.kttrungkhoa(txtCMND.Text, "select CMTND from tb_NGHIVIEC") && (!cls.kttrungkhoa(txtCMND.Text, "select CMTND from tb_NHANVIEN"))))
                {
                    if (txtMaNV.Text != "" && txtCMND.Text != "")
                    {
                        cls.thucthiketnoi(insert);
                        dtgv.Refresh();
                        cls.loaddatagridview(dtgv, "select * from tb_NHANVIEN");
                        MessageBox.Show("Thêm thành công nhân viên mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();

                    }

                    else if (cboMaBoPhan.Text == "") MessageBox.Show("Bạn chưa chọn mã bộ phận", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (txtMaNV.Text == "") MessageBox.Show("Bạn chưa nhập Mã nhân viên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (txtHoTen.Text == "") MessageBox.Show("Bạn chưa nhập số Họ tên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (cboMaLuong.Text == "") MessageBox.Show("Bạn chưa chọn mã lương", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (cboGioiTinh.Text == "") MessageBox.Show("Bạn chưa chọn giới tính", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (cboTinhTrangHonNhan.Text == "") MessageBox.Show("Bạn chưa chọn tình trạng hôn nhân", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (txtCMND.Text == "") MessageBox.Show("Bạn chưa nhập số CMND", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (txtNoiCap.Text == "") MessageBox.Show("Bạn chưa nhập số nơi cấp CMND", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (txtChucVu.Text == "") MessageBox.Show("Bạn chưa nhập chức vụ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (txtLoaiHopDong.Text == "") MessageBox.Show("Bạn chưa nhập loại hợp đồng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (txtThoiGian.Text == "") MessageBox.Show("Bạn chưa nhập thời gian hợp đồng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if ((!cls.kttrungkhoa(txtMaNV.Text, "select MaNV from tb_NHANVIEN")) && (cls.kttrungkhoa(txtCMND.Text, "select CMTND from tb_NGHIVIEC")))
                {
                    if (MessageBox.Show("Nhân viên này đã từng làm ở công ty, bạn có chắc muốn lại nhân viên thêm?", "Thêm thất bại", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cls.thucthiketnoi(insert);
                        cls.loaddatagridview(dtgv, "select * from tb_NHANVIEN");
                        MessageBox.Show("Thêm thành công nhân viên " + txtHoTen.Text + " vào làm việc lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        string delete = "delete from tb_NGHIVIEC where CMTND='" + txtCMND.Text + "'";
                        cls.thucthiketnoi(delete);
                        reset();
                    }
                }
            }
            else
            {
                string update = "update tb_NHANVIEN set MaBoPhan=N'" + cboMaBoPhan.Text + "',MaPhong=N'" + cboMaPhong.Text + "',HoTen=N'" + txtHoTen.Text + "',MaLuong=N'" + cboMaLuong.Text + "',NgaySinh='" + dtNgaySinh.Text + "',GioiTinh=N'" + cboGioiTinh.Text + "',TTHonNhan=N'" + cboTinhTrangHonNhan.Text + "',CMTND=N'" + txtCMND.Text + "',NoiCap=N'" + txtNoiCap.Text + "',ChucVu=N'" + txtChucVu.Text + "',LoaiHD=N'" + txtLoaiHopDong.Text + "',ThoiGian=N'" + txtThoiGian.Text + "',NgayKy='" + dtNgayKy.Text + "',NgayHetHan='" + dtNgayHetHan.Text + "',GhiChu=N'" + txtGhiChu.Text + "',MACTY=N'" + txtMaCTY.Text + "' where MaNV=N'" + txtMaNV.Text + "'";
                cls.thucthiketnoi(update);
                dtgv.Refresh();
                cls.loaddatagridview(dtgv, "select * from tb_NHANVIEN");
                MessageBox.Show("Sửa thành công thông tin nhân viên " + txtHoTen.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
                //Sửa dữ liệu table chấm công
                string upd = "update tb_LUONGNV set HoTen=N'" + txtHoTen.Text + "',MaLuong=N'" + cboMaLuong.Text + "' where MaNV=N'" + txtMaNV.Text + "'";
                cls.thucthiketnoi(upd);
                cls.loaddatagridview(dtgv, "select * from tb_NHANVIEN");
                string ds = "update tb_LUONGNV set TenPhong = (select top(1) TenPhong from tb_PHONGBAN a,tb_NHANVIEN b where a.MaPhong=b.MaPhong and a.MaPhong=N'" + cboMaPhong.Text + "' group by TenPhong) where MaNV='" + txtMaNV.Text + "'";

                cls.thucthiketnoi(ds);
                dtgv.Refresh();
            }
        }
        
        private void btnDanhSachNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmInDanhSachNhanVien frmInDanhSachNhanVien = new frmInDanhSachNhanVien();
            frmInDanhSachNhanVien.Show();

        }

        private void dtgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int hang = e.RowIndex;
                cboMaBoPhan.Text = dtgv.Rows[hang].Cells[0].Value.ToString();
                cboMaPhong.Text = dtgv.Rows[hang].Cells[1].Value.ToString();
                txtMaNV.Text = dtgv.Rows[hang].Cells[2].Value.ToString();
                txtHoTen.Text = dtgv.Rows[hang].Cells[3].Value.ToString();
                cboMaLuong.Text = dtgv.Rows[hang].Cells[4].Value.ToString();
                dtNgaySinh.Text = dtgv.Rows[hang].Cells[5].Value.ToString();
                cboGioiTinh.Text = dtgv.Rows[hang].Cells[6].Value.ToString();
                cboTinhTrangHonNhan.Text = dtgv.Rows[hang].Cells[7].Value.ToString();
                txtCMND.Text = dtgv.Rows[hang].Cells[8].Value.ToString();
                txtNoiCap.Text = dtgv.Rows[hang].Cells[9].Value.ToString();
                txtChucVu.Text = dtgv.Rows[hang].Cells[10].Value.ToString();
                txtLoaiHopDong.Text = dtgv.Rows[hang].Cells[11].Value.ToString();
                txtThoiGian.Text = dtgv.Rows[hang].Cells[12].Value.ToString();
                dtNgayKy.Text = dtgv.Rows[hang].Cells[13].Value.ToString();
                dtNgayHetHan.Text = dtgv.Rows[hang].Cells[14].Value.ToString();
                txtGhiChu.Text = dtgv.Rows[hang].Cells[15].Value.ToString();
            }
            catch (Exception)
            {
            }
        }

        private void cboMaBoPhan_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            frmQuanLyNhanVien.FillCombo("select p.MaPhong from tb_BOPHAN b,tb_PHONGBAN p where b.MaBoPhan=p.MaBoPhan and p.MaBoPhan=N'" + cboMaBoPhan.SelectedValue + "'", cboMaPhong, "MaPhong", "MaPhong");
            cboMaPhong.DisplayMember = "MaPhong";
            cboMaPhong.ValueMember = "MaPhong";
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}