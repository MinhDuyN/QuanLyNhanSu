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
    public partial class frmLuong : DevExpress.XtraEditors.XtraForm
    {
        Clsdatabase cls = new Clsdatabase();
        public frmLuong()
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
            txtMaLuong.Enabled = !kt;
            txtLCB.Enabled = !kt;
            txtPCCV.Enabled = !kt;
            dtNgayThanhLap.Enabled = !kt;
            txtGhiChu.Enabled = !kt;
            //dtNgayBatDau.Enabled = !kt;
            //dtNgayKetThuc.Enabled = !kt;
        }
        void reset()
        {
            txtMaLuong.Clear();
            txtLCB.Text = string.Empty;
            txtPCCV.Clear();
            txtGhiChu.Clear();
        }
        public void suatieude()
        {
            dtgv.Columns[0].HeaderText = "Mã lương";
            dtgv.Columns[1].HeaderText = "Lương cơ bản";
            dtgv.Columns[2].HeaderText = "Phân cấp chúc vụ";
            dtgv.Columns[3].HeaderText = "Ngày thành lập";
            dtgv.Columns[4].HeaderText = "Ghi chú";
        }
        private void frmLuong_Load(object sender, EventArgs e)
        {
            cls.loaddatagridview(dtgv, "select * from tb_BANGLUONG");
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
            string delete = "delete from tb_BANGLUONG where MaLuong=N'" + txtMaLuong.Text + "'";
            if (txtMaLuong.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã lương cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MessageBox.Show("Bạn có muốn xóa mã lương " + txtMaLuong.Text + " không?", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cls.thucthiketnoi(delete);
                cls.loaddatagridview(dtgv, "select * from tb_BANGLUONG");
                MessageBox.Show("Xóa thành công mã lương " + txtMaLuong.Text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                try
                {

                    string insert = "insert into tb_BANGLUONG values(N'" + txtMaLuong.Text + "',N'" + txtLCB.Text + "',N'" + txtPCCV.Text + "',N'" + dtNgayThanhLap.Text + "',N'" + txtGhiChu.Text + "')";
                    if (!cls.kttrungkhoa(txtMaLuong.Text, "select MaLuong from tb_BANGLUONG"))
                    {
                        if (txtMaLuong.Text != "" && txtLCB.Text != "")
                        {
                            cls.thucthiketnoi(insert);
                            dtgv.Refresh();
                            cls.loaddatagridview(dtgv, "select * from tb_BANGLUONG");
                            MessageBox.Show("Thêm thành công mã lương mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reset();
                        }
                        else MessageBox.Show("Bạn chưa nhập mã lương hoặc tiền lương cơ bản", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Mã lương này đã tồn tại", "Thêm thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    if (txtMaLuong.Text == "")
                    {
                        MessageBox.Show("Bạn chưa chọn mã lương cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        string update = "update tb_BANGLUONG set LCB=N'" + txtLCB.Text + "',PCChucVu=N'" + txtPCCV.Text + "',NgayNhap='" + dtNgayThanhLap.Text + "',GhiChu=N'" + txtGhiChu.Text + "' where MaLuong=N'" + txtMaLuong.Text + "'";
                        cls.thucthiketnoi(update);
                        cls.loaddatagridview(dtgv, "select * from tb_BANGLUONG");
                        MessageBox.Show("Sửa thành công mã lương " + txtMaLuong.Text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                }
                catch
                {
                    MessageBox.Show("Dữ liệu đầu vào không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    reset();
                }
            }
        }
        private void dtgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                int i = e.RowIndex;
                txtMaLuong.Text = dtgv.Rows[i].Cells[0].Value.ToString();
                txtLCB.Text = dtgv.Rows[i].Cells[1].Value.ToString();
                txtPCCV.Text = dtgv.Rows[i].Cells[2].Value.ToString();
                dtNgayThanhLap.Text = dtgv.Rows[i].Cells[3].Value.ToString();
                txtGhiChu.Text = dtgv.Rows[i].Cells[4].Value.ToString();
            }
            catch (Exception ex) { }
        }

        private void txtLCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtPCCV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}