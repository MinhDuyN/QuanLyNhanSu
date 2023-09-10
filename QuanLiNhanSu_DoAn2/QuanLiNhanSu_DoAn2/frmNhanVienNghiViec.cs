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
    public partial class frmNhanVienNghiViec : DevExpress.XtraEditors.XtraForm
    {
        Clsdatabase cls = new Clsdatabase();
        public frmNhanVienNghiViec()
        {
            InitializeComponent();
        }
        bool _them;
        void _showHide(bool kt)
        {
            btnHuy.Enabled = !kt;
            btnLuu.Enabled = !kt;
            btnXoa.Enabled = kt;
            btnThoat.Enabled = kt;
            txtTenNV.Enabled = !kt;
            txtCCCD.Enabled = !kt;
            
        }
        void reset()
        {
            txtTenNV.Clear();
            txtCCCD.Clear();
        }
        public void suatieude()
        {
            dtgv.Columns[0].HeaderText = "Tên nhân viên";
            dtgv.Columns[1].HeaderText = "CMND/CCCD";
        }
        private void frmNhanVienNghiViec_Load(object sender, EventArgs e)
        {
            cls.loaddatagridview(dtgv, "select * from tb_NGHIVIEC");
            suatieude();
            txtTenNV.Enabled = false;
            txtCCCD.Enabled = false;
            _them = false;
            _showHide(true);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = false;
            txtTenNV.Enabled = false;
            txtCCCD.Enabled = false;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (txtTenNV.Text == "")
                    MessageBox.Show("Chưa chọn nhân viên cần xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    string del = "delete from tb_NGHIVIEC where CMTND='" + txtCCCD.Text + "'";
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên " + txtTenNV.Text + " vĩnh viễn không", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cls.thucthiketnoi(del);
                        cls.loaddatagridview(dtgv, "select * from tb_NGHIVIEC");
                        MessageBox.Show("Xóa thành công thông tin nhân viên " + txtTenNV.Text + " vĩnh viễn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                        _showHide(true);
                        _them = false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Dữ liệu đầu vào không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


        private void dtgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int hang = e.RowIndex;
                txtTenNV.Text = dtgv.Rows[hang].Cells[0].Value.ToString();
                txtCCCD.Text = dtgv.Rows[hang].Cells[1].Value.ToString();
            }
            catch (Exception) { }
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
}