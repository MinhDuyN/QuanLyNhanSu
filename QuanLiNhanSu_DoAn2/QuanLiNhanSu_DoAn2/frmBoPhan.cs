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
    public partial class frmBoPhan : DevExpress.XtraEditors.XtraForm
    {
        Clsdatabase cls = new Clsdatabase();
        public frmBoPhan()
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
            txtMaBoPhan.Enabled = !kt;
            txtTenBoPhan.Enabled = !kt;
            dtNgayThanhLap.Enabled = !kt;
            txtGhiChu.Enabled = !kt;
            //dtNgayBatDau.Enabled = !kt;
            //dtNgayKetThuc.Enabled = !kt;
        }
        void reset()
        {
            txtMaBoPhan.Clear();
            txtTenBoPhan.Clear();
            txtGhiChu.Clear();
        }
        public void suatieude()
        {
            dtgv.Columns[0].HeaderText = "Mã bộ phận";
            dtgv.Columns[1].HeaderText = "Tên bộ phận";
            dtgv.Columns[2].HeaderText = "Ngày thành lập";
            dtgv.Columns[3].HeaderText = "Ghi chú";
        }
        private void frmBoPhan_Load(object sender, EventArgs e)
        {
            cls.loaddatagridview(dtgv, "select * from tb_BOPHAN");
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
            string del = "delete from tb_BOPHAN where MaBoPhan='" + txtMaBoPhan.Text + "'";
            string del1 = "delete from tb_PHONGBAN where MaBoPhan='" + txtMaBoPhan.Text + "'";
            if (txtMaBoPhan.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã bộ phận để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MessageBox.Show("Bạn có chắc chắn muốn xóa bộ phận " + txtTenBoPhan.Text + "không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                cls.thucthiketnoi(del1);
                cls.thucthiketnoi(del);
                cls.loaddatagridview(dtgv, "select * from tb_BOPHAN");
                MessageBox.Show("Xóa thành công bộ phận " + txtTenBoPhan.Text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (!cls.kttrungkhoa(txtMaBoPhan.Text, "select MaBoPhan from tb_BOPHAN"))
                    {
                        string insert = "insert into tb_BOPHAN values(N'" + txtMaBoPhan.Text + "',N'" + txtTenBoPhan.Text + "',N'" + dtNgayThanhLap.Text + "',N'" + txtGhiChu.Text + "')";
                        cls.thucthiketnoi(insert);
                        cls.loaddatagridview(dtgv, "select * from tb_BOPHAN");
                        MessageBox.Show("Thêm thành công bộ phận mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("Bộ phận này đã tồn tại ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    if (txtMaBoPhan.Text == "")
                        MessageBox.Show("Chưa chọn mã bộ phận cần sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        string update = "update tb_BOPHAN set TenBoPhan=N'" + txtTenBoPhan.Text + "',NgayThanhLap=N'" + dtNgayThanhLap.Text + "',GhiChu=N'" + txtGhiChu.Text + "' where MaBoPhan='" + txtMaBoPhan.Text + "'";
                        cls.thucthiketnoi(update);
                        cls.loaddatagridview(dtgv, "select * from tb_BOPHAN");
                        MessageBox.Show("Sửa thành công bộ phận " + txtTenBoPhan.Text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                }
                catch
                {
                    MessageBox.Show("Dữ liệu đầu vào không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    

        private void dtgv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;
                txtMaBoPhan.Text = dtgv.Rows[i].Cells[0].Value.ToString();
                txtTenBoPhan.Text = dtgv.Rows[i].Cells[1].Value.ToString();
                txtGhiChu.Text = dtgv.Rows[i].Cells[3].Value.ToString();
                dtNgayThanhLap.Text = dtgv.Rows[i].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }
    }
}