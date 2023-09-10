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
    public partial class frmTinhLuongNhanVien : DevExpress.XtraEditors.XtraForm
    {
        Clsdatabase cls = new Clsdatabase();
        public static SqlConnection Con;
        public frmTinhLuongNhanVien()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds3 = new DataSet();
        DataSet ds4 = new DataSet();
        DataSet ds5 = new DataSet();

        public static void FillCombo(string sql, System.Windows.Forms.ComboBox cbo, string ma, string ten)
        {

            SqlDataAdapter Mydata = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            Mydata.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma; //Trường giá trị
            cbo.DisplayMember = ten; //Trường hiển thị
        }

        public void reset()
        {
            txtMaLuong.Clear();
            txtHoTen.Clear();
            txtLCB.Clear();
            txtPC.Clear();
            txtThuong.Clear();
            txtKyLuat.Clear();
            txtThang.Clear();
            txtNam.Clear();
            txtSoNgayCong.Clear();
            txtSoNgayNghi.Clear();
            txtSoGioLamThem.Clear();
            txtTongLuong.Text = "";
            txtGhiChu.Clear();
        }

        public frmTinhLuongNhanVien(string LayThang, string LayNam) : this()
        {
            txtThang.Text = LayThang.ToString();
            txtNam.Text = LayNam.ToString();
        }

        LUONGNV _luongnv;
        void load()
        {

                gcDanhSach.DataSource = _luongnv.getList();
                gvDanhSach.OptionsBehavior.Editable = false;
        }
        private void frmTinhLuongNhanVien_Load(object sender, EventArgs e)
        {
            Con = new SqlConnection();
            Con.ConnectionString = "Data Source=DESKTOP-2EEB116\\SA;Initial Catalog=QLNS;Integrated Security=True";
            
            cls.loadcombobox(cboMaNV, "select MaNV from tb_NHANVIEN", 0);
            _luongnv = new LUONGNV();
            load();
            //cls.loaddatagridview1(dtgv, ds, "select * from tb_LUONGNV");
            btnThem.Enabled = false;
            //suatieude_luongtv();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string insert = "insert into tb_LUONGNV values(N'" + cboMaNV.Text + "',N'" + txtMaPhong.Text + "',N'" + txtHoTen.Text + "',N'" + txtMaLuong.Text + "',N'" + txtLCB.Text + "',N'" + txtPC.Text + "',N'" + txtThuong.Text + "',N'" + txtKyLuat.Text + "',N'" + txtThang.Text + "',N'" + txtNam.Text + "',N'" + txtSoNgayCong.Text + "',N'" + txtSoNgayNghi.Text + "',N'" + txtSoGioLamThem.Text + "',N'" + txtTongLuong.Text + "',N'" + txtGhiChu.Text + "')";
            if (!cls.kttrungkhoa(cboMaNV.Text, "select MaNV from tb_LUONGNV"))
            {
                if (cboMaNV.Text != "")
                {
                    cls.thucthiketnoi(insert);
                    gcDanhSach.DataSource = _luongnv.getList();
                    //dtgv.Refresh();
                    //cls.loaddatagridview1(dtgv, ds, "select * from tb_LUONGNV");
                    MessageBox.Show("Thêm thành công lương chính thức của nhân viên mã số " + cboMaNV.Text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnThem.Enabled = false;
                    reset();
                }
                else MessageBox.Show("Bạn chưa nhập Mã nhân viên", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Mã nhân viên này đã tồn tại", "Thêm thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            try
            {
                string update = "update tb_LUONGNV set TenPhong=N'" + txtMaPhong.Text + "',HoTen=N'" + txtHoTen.Text + "',MaLuong=N'" + txtMaLuong.Text + "',LCB=N'" + txtLCB.Text + "',PCChucVu='" + txtPC.Text + "',Thuong=N'" + txtThuong.Text + "',KyLuat=N'" + txtKyLuat.Text + "',Thang=N'" + txtThang.Text + "',Nam=N'" + txtNam.Text + "',SoNgayCongThang=N'" + txtSoNgayCong.Text + "',SoNgayNghi=N'" + txtSoNgayNghi.Text + "',SoGioLamThem=N'" + txtSoGioLamThem.Text + "',Luong=N'" + txtTongLuong.Text + "',GhiChu='" + txtGhiChu.Text + "' where MaNV=N'" + cboMaNV.Text + "'";
                cls.thucthiketnoi(update);
                gcDanhSach.DataSource = _luongnv.getList();
                //cls.loaddatagridview1(dtgv, ds, "select * from tb_LUONGNV");
                MessageBox.Show("Sửa thành công lương chính thức của nhân viên mã số " + cboMaNV.Text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnThem.Enabled = false;
                reset();
            }

            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (cboMaNV.Text == "")
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa bảng lương", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string delete = "delete from tb_LUONGNV where MaNV=N'" + cboMaNV.Text + "'";
                    if (MessageBox.Show("Bạn có muốn xóa bảng lương nhân viên chính thức của nhân viên mã số " + cboMaNV.Text + " không?", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cls.thucthiketnoi(delete);
                        gcDanhSach.DataSource = _luongnv.getList();
                        //cls.loaddatagridview1(dtgv, ds, "select * from tb_LUONGNV");
                        MessageBox.Show("Xóa thành công lương chính thức của nhân viên mã số " + cboMaNV.Text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                reset();
            }
        }

        private void cboMaNV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cls.loadtextboxchiso(txtMaPhong, "select * from tb_PHONGBAN b,tb_NHANVIEN a where a.MaPhong=b.MaPhong and MaNV='" + cboMaNV.Text + "'", 1);
            //cls.loadtextboxchiso(tb_tenbophan, "select * from TblBoPhan,TblPhongBan where TblPhongBan.MaBoPhan=TblBoPhan.MaBoPhan and TenPhong=N'" + cb_manhanvienct.Text + "'", 1);
            cls.loadtextboxchiso(txtHoTen, "select * from tb_NHANVIEN where MaNV='" + cboMaNV.Text + "'", 3);
            cls.loadtextboxchiso(txtMaLuong, "select * from tb_NHANVIEN where MaNV='" + cboMaNV.Text + "'", 4);
            cls.loadtextboxchiso(txtLCB, "select * from tb_BANGLUONG l where l.MaLuong='" + txtMaLuong.Text + "'", 1);
            cls.loadtextboxchiso(txtPC, "select * from tb_BANGLUONG l where l.MaLuong='" + txtMaLuong.Text + "'", 2);
            ////cls.loadtextboxchiso(tb_phucapkhacct, "select * from TblTinhLuongNV where MaNV='" + cb_manhanvienct.Text + "'", 6);
            //cls.loadtextboxchiso(txtThuong, "select * from tb_LUONGNV where MaNV='" + cboMaNV.Text + "'", 6);
            //cls.loadtextboxchiso(txtKyLuat, "select * from tb_LUONGNV where MaNV='" + cboMaNV.Text + "'", 7);
            cls.loadtextboxchiso(txtThang, "select * from tb_LUONGNV where MaNV='" + cboMaNV.Text + "'", 8);
            cls.loadtextboxchiso(txtNam, "select * from tb_LUONGNV where MaNV='" + cboMaNV.Text + "'", 9);
            cls.loadtextboxchiso(txtThuong, "select * from tb_KHENTHUONG where MaNV='" + cboMaNV.Text + "'", 4);
            cls.loadtextboxchiso(txtKyLuat, "select * from tb_KYLUAT where MaNV='" + cboMaNV.Text + "'", 4);
            cls.loadtextboxchiso(txtSoNgayCong, "select * from tb_KYCONGCHITIET where MaNV='" + cboMaNV.Text + "'", 35);
            ////cls.loadtextboxchiso(tb_songaynghict, "select * from tb_KYCONGCHITIET where MaNV='" + cb_manhanvienct.Text + "'", 36);
            cls.loadtextboxchiso(txtSoGioLamThem, "select * from tb_LUONGNV where MaNV='" + cboMaNV.Text + "'", 12);
            cls.loadtextboxchiso(txtTongLuong, "select * from tb_LUONGNV where MaNV='" + cboMaNV.Text + "'", 13);
            cls.loadtextboxchiso(txtGhiChu, "select * from tb_LUONGNV where MaNV='" + cboMaNV.Text + "'", 14);
            if (txtThuong.Text == "")
            {
                txtThuong.Text = "0";
            }
            if (txtKyLuat.Text == "")
            {
                txtKyLuat.Text = "0";
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void btnTinhLuong_Click_1(object sender, EventArgs e)
        {

            int lcb = Convert.ToInt32(txtLCB.Text);
            int pc = Convert.ToInt32(txtPC.Text);
            int nc = Convert.ToInt32(txtSoNgayCong.Text);
            int lt = Convert.ToInt32(txtSoGioLamThem.Text);
            int nn = Convert.ToInt32(txtSoNgayNghi.Text);
            int th = Convert.ToInt32(txtThuong.Text);
            int kl = Convert.ToInt32(txtKyLuat.Text);

            float luong = ((lcb / nc - nn) + (lt * 40000) + pc + th - kl );
            txtTongLuong.Text = luong.ToString();
            btnThem.Enabled = true;
        }

        private void gvDanhSach_Click_1(object sender, EventArgs e)
        {
            try
            {

                cboMaNV.Text = gvDanhSach.GetFocusedRowCellValue("MaNV").ToString();
                txtLCB.Text = gvDanhSach.GetFocusedRowCellValue("LCB").ToString();
                txtHoTen.Text = gvDanhSach.GetFocusedRowCellValue("HoTen").ToString();
                txtMaLuong.Text = gvDanhSach.GetFocusedRowCellValue("MaLuong").ToString();
                txtMaPhong.Text = gvDanhSach.GetFocusedRowCellValue("TenPhong").ToString();
                txtPC.Text = gvDanhSach.GetFocusedRowCellValue("PCChucVu").ToString();
                //tb_phucapkhacct.Text = dtgv_luongct.Rows[i].Cells[6].Value.ToString();
                txtThuong.Text = gvDanhSach.GetFocusedRowCellValue("Thuong").ToString();
                txtKyLuat.Text = gvDanhSach.GetFocusedRowCellValue("KyLuat").ToString();
                txtThang.Text = gvDanhSach.GetFocusedRowCellValue("Thang").ToString();
                txtNam.Text = gvDanhSach.GetFocusedRowCellValue("Nam").ToString();
                txtSoNgayCong.Text = gvDanhSach.GetFocusedRowCellValue("SoNgayCongThang").ToString();
                txtSoNgayNghi.Text = gvDanhSach.GetFocusedRowCellValue("SoNgayNghi").ToString();
                txtSoGioLamThem.Text = gvDanhSach.GetFocusedRowCellValue("SoGioLamThem").ToString();
                txtTongLuong.Text = gvDanhSach.GetFocusedRowCellValue("Luong").ToString();
                txtGhiChu.Text = gvDanhSach.GetFocusedRowCellValue("GhiChu").ToString();
            }
            catch (Exception) { }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            frmInLuong frmInLuong = new frmInLuong();
            frmInLuong.Show();
        }

        private void txtSoNgayNghi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoGioLamThem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}