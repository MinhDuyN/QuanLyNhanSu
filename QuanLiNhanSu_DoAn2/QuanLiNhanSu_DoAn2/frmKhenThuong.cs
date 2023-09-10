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
    public partial class frmKhenThuong : DevExpress.XtraEditors.XtraForm
    {
        Clsdatabase cls = new Clsdatabase();
        public frmKhenThuong()
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
            txtLyDo.Enabled = !kt;
            txtNoiDung.Enabled = !kt;
            txtSoQuyetDinhKT.Enabled = !kt;
            cboMaNV.Enabled = !kt;
            txtSoTienKT.Enabled = !kt;
            //dtNgayBatDau.Enabled = !kt;
            //dtNgayKetThuc.Enabled = !kt;
        }
        void reset()
        {
            txtSoQuyetDinhKT.Clear();
            cboMaNV.Text = string.Empty;
            txtLyDo.Clear();
            txtNoiDung.Clear();
            txtSoTienKT.Clear();
            //dtNgayKhenThuong.Value = DateTime.Now();
        }
        public void suatieude()
        {
            dtgvKhenThuong.Columns[0].HeaderText = "Số QĐKT";
            dtgvKhenThuong.Columns[1].HeaderText = "Mã nhân viên";
            dtgvKhenThuong.Columns[2].HeaderText = "Lý do";
            dtgvKhenThuong.Columns[3].HeaderText = "Nội dung";
            dtgvKhenThuong.Columns[4].HeaderText = "Tiền khen thưởng";
            dtgvKhenThuong.Columns[5].HeaderText = "Ngày khen thưởng";
        }
        private void frmKhenThuong_Load(object sender, EventArgs e)
        {
            cls.loaddatagridview(dtgvKhenThuong, "select * from tb_KHENTHUONG");
            cls.loadcombobox(cboMaNV, "select MaNV from tb_NHANVIEN", 0);
            suatieude();

            _them = false;
            _showHide(true);
        }
        private void dtgvKhenThuong_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;
                txtSoQuyetDinhKT.Text = dtgvKhenThuong.Rows[i].Cells[0].Value.ToString();
                cboMaNV.Text = dtgvKhenThuong.Rows[i].Cells[1].Value.ToString();
                txtLyDo.Text = dtgvKhenThuong.Rows[i].Cells[2].Value.ToString();
                txtNoiDung.Text = dtgvKhenThuong.Rows[i].Cells[3].Value.ToString();
                txtSoTienKT.Text = dtgvKhenThuong.Rows[i].Cells[4].Value.ToString();
                dtNgayKhenThuong.Text = dtgvKhenThuong.Rows[i].Cells[5].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void cboMaNV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtSoQuyetDinhKT.Text = "KT" + cboMaNV.Text;
        }

        private void btnThem_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true; //Khi nhấn mới thêm
            _showHide(false);
            txtSoQuyetDinhKT.Enabled = false;
            reset();
        }

        private void btnXoa_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string del = "delete from tb_KHENTHUONG where SOQDKT=N'" + txtSoQuyetDinhKT.Text + "'";
                if (txtSoQuyetDinhKT.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn số QĐKT cần xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (MessageBox.Show("Bạn có chắc chắn muốn xóa việc khen thưởng này không?", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cls.thucthiketnoi(del);
                    cls.loaddatagridview(dtgvKhenThuong, "select * from tb_KHENTHUONG");
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    txtSoQuyetDinhKT.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = false;
            txtSoQuyetDinhKT.Enabled = false;
        }

        private void btnLuu_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            _them = false;
            _showHide(true);
            txtSoQuyetDinhKT.Enabled = false;
        }

        private void btnHuy_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            _them = false;
            reset();
            txtSoQuyetDinhKT.Enabled = false;
        }
        void SaveData()
        {
            if (_them)
            {
                try
                {
                    if (!cls.kttrungkhoa(txtSoQuyetDinhKT.Text, "select SOQDKT from tb_KHENTHUONG"))
                    {
                        string insert = "insert into tb_KHENTHUONG values(N'" + txtSoQuyetDinhKT.Text + "',N'" + cboMaNV.Text + "',N'" + txtLyDo.Text + "',N'" + txtNoiDung.Text + "',N'" + txtSoTienKT.Text + "',N'" + dtNgayKhenThuong.Text + "')";
                        cls.thucthiketnoi(insert);
                        cls.loaddatagridview(dtgvKhenThuong, "select * from tb_KHENTHUONG");
                        MessageBox.Show("Thêm thành công khen thưởng cho nhân viên mã số "+cboMaNV.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                        txtSoQuyetDinhKT.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Trùng mã khen thưởng ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        reset();
                    }
                }
                catch
                {
                    MessageBox.Show("Dữ liệu đầu vào không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reset();
                }
            }
            else
            {
                try
                {
                    if (txtSoQuyetDinhKT.Text == "")
                    {
                        MessageBox.Show("Chưa chọn số QĐKT cần sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        reset();
                    }
                    else
                    {
                        string update = "update tb_KHENTHUONG set MANV=N'" + cboMaNV.Text + "',LYDO=N'" + txtLyDo.Text + "',NOIDUNG=N'" + txtNoiDung.Text + "',TIENKHENTHUONG=N'" + txtSoTienKT.Text + "',NGAYKHENTHUONG=N'" + dtNgayKhenThuong.Text + "' where SOQDKT=N'" + txtSoQuyetDinhKT.Text + "'";
                        cls.thucthiketnoi(update);
                        cls.loaddatagridview(dtgvKhenThuong, "select * from tb_KHENTHUONG");
                        MessageBox.Show("Sửa thành công " + txtSoQuyetDinhKT.Text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                        txtSoQuyetDinhKT.Enabled = false;
                    }
                }
                catch
                {
                    MessageBox.Show("Dữ liệu đầu vào không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reset();
                }
            }
        }
        private void btnThoat_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void txtSoTienKT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}