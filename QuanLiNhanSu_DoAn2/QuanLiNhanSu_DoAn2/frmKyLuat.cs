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
    public partial class frmKyLuat : DevExpress.XtraEditors.XtraForm
    {
        public frmKyLuat()
        {
            InitializeComponent();
        }
        Clsdatabase cls = new Clsdatabase();
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
            txtSoQuyetDinhKL.Enabled = !kt;
            cboMaNV.Enabled = !kt;
            txtSoTienKL.Enabled = !kt;
            //dtNgayBatDau.Enabled = !kt;
            //dtNgayKetThuc.Enabled = !kt;
        }
        void reset()
        {
            txtSoQuyetDinhKL.Clear();
            cboMaNV.Text = string.Empty;
            txtLyDo.Clear();
            txtNoiDung.Clear();
            txtSoTienKL.Clear();
            //dtNgayKhenThuong.Value = DateTime.Now();
        }
        public void suatieude()
        {
            dtgvKyLuat.Columns[0].HeaderText = "Số QĐKL";
            dtgvKyLuat.Columns[1].HeaderText = "Mã nhân viên";
            dtgvKyLuat.Columns[2].HeaderText = "Lý do";
            dtgvKyLuat.Columns[3].HeaderText = "Nội dung";
            dtgvKyLuat.Columns[4].HeaderText = "Tiền kỷ luật";
            dtgvKyLuat.Columns[5].HeaderText = "Ngày kỷ luật";
        }
        private void frmKyLuat_Load(object sender, EventArgs e)
        {
            cls.loaddatagridview(dtgvKyLuat, "select * from tb_KYLUAT");
            cls.loadcombobox(cboMaNV, "select MaNV from tb_NHANVIEN", 0);
            suatieude();

            _them = false;
            _showHide(true);
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true; //Khi nhấn mới thêm
            _showHide(false);
            txtSoQuyetDinhKL.Enabled = false;
            reset();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string del = "delete from tb_KYLUAT where SOQDKL=N'" + txtSoQuyetDinhKL.Text + "'";
                if (txtSoQuyetDinhKL.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn số QĐKT cần xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (MessageBox.Show("Bạn có chắc chắn muốn xóa việc kỷ luật này không?", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cls.thucthiketnoi(del);
                    cls.loaddatagridview(dtgvKyLuat, "select * from tb_KYLUAT");
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset();
                    txtSoQuyetDinhKL.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = false;
            txtSoQuyetDinhKL.Enabled = false;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            _them = false;
            _showHide(true);
            txtSoQuyetDinhKL.Enabled = false;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            _them = false;
            reset();
            txtSoQuyetDinhKL.Enabled = false;
        }
        void SaveData()
        {
            if (_them)
            {
                try
                {
                    if (!cls.kttrungkhoa(txtSoQuyetDinhKL.Text, "select SOQDKL from tb_KYLUAT"))
                    {
                        string insert = "insert into tb_KYLUAT values(N'" + txtSoQuyetDinhKL.Text + "',N'" + cboMaNV.Text + "',N'" + txtLyDo.Text + "',N'" + txtNoiDung.Text + "',N'" + txtSoTienKL.Text + "',N'" + dtNgayKyLuat.Text + "')";
                        cls.thucthiketnoi(insert);
                        cls.loaddatagridview(dtgvKyLuat, "select * from tb_KYLUAT");
                        MessageBox.Show("Thêm thành công kỷ luật cho nhân viên mã "+cboMaNV.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                        txtSoQuyetDinhKL.Enabled = false;
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
                    if (txtSoQuyetDinhKL.Text == "")
                    {
                        MessageBox.Show("Chưa chọn số QĐKL cần sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        reset();
                    }
                    else
                    {
                        string update = "update tb_KYLUAT set MANV=N'" + cboMaNV.Text + "',LYDO=N'" + txtLyDo.Text + "',NOIDUNG=N'" + txtNoiDung.Text + "',TIENKYLUAT=N'" + txtSoTienKL.Text + "',NGAYKYLUAT=N'" + dtNgayKyLuat.Text + "' where SOQDKL=N'" + txtSoQuyetDinhKL.Text + "'";
                        cls.thucthiketnoi(update);
                        cls.loaddatagridview(dtgvKyLuat, "select * from tb_KYLUAT");
                        MessageBox.Show("Sửa thành công " + txtSoQuyetDinhKL.Text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                        txtSoQuyetDinhKL.Enabled = false;
                    }
                }
                catch
                {
                    MessageBox.Show("Dữ liệu đầu vào không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reset();
                }
            }
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void dtgvKyLuat_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;
                txtSoQuyetDinhKL.Text = dtgvKyLuat.Rows[i].Cells[0].Value.ToString();
                cboMaNV.Text = dtgvKyLuat.Rows[i].Cells[1].Value.ToString();
                txtLyDo.Text = dtgvKyLuat.Rows[i].Cells[2].Value.ToString();
                txtNoiDung.Text = dtgvKyLuat.Rows[i].Cells[3].Value.ToString();
                txtSoTienKL.Text = dtgvKyLuat.Rows[i].Cells[4].Value.ToString();
                dtNgayKyLuat.Text = dtgvKyLuat.Rows[i].Cells[5].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void cboMaNV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtSoQuyetDinhKL.Text = "KL" + cboMaNV.Text;
        }

        private void txtSoTienKL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}