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
    public partial class frmPhongBan : DevExpress.XtraEditors.XtraForm
    {
        Clsdatabase cls = new Clsdatabase();
        public frmPhongBan()
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
            cboMaBoPhan.Enabled = !kt;
            txtTenPhongBan.Enabled = !kt;
            txtMaPhongBan.Enabled = !kt;
            dtNgayThanhLap.Enabled = !kt;
            txtGhiChu.Enabled = !kt;
            //dtNgayBatDau.Enabled = !kt;
            //dtNgayKetThuc.Enabled = !kt;
        }
        void reset()
        {
            txtMaPhongBan.Clear();
            cboMaBoPhan.Text = string.Empty;
            txtTenPhongBan.Clear();
            txtGhiChu.Clear();
        }
        public void suatieude()
        {
            dtgv.Columns[0].HeaderText = "Mã bộ phận";
            dtgv.Columns[1].HeaderText = "Mã phòng ban";
            dtgv.Columns[2].HeaderText = "Tên phòng ban";
            dtgv.Columns[3].HeaderText = "Ngày thành lập";
            dtgv.Columns[4].HeaderText = "Ghi chú";
        }
        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            cls.loaddatagridview(dtgv, "select * from tb_PHONGBAN");
            cls.loadcombobox(cboMaBoPhan, "select * from tb_BOPHAN", 0);
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
            try
            {
                string del = "delete from tb_PHONGBAN where MaPhong=N'" + txtMaPhongBan.Text + "'";
                if (txtMaPhongBan.Text == "")
                {
                    MessageBox.Show("Bạn chưa chọn phòng ban cần xóa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (MessageBox.Show("Bạn có chắc chắn muốn xóa phòng ban " + txtTenPhongBan.Text + " không?", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cls.thucthiketnoi(del);
                    cls.loaddatagridview(dtgv, "select * from tb_PHONGBAN");
                    MessageBox.Show("Xóa thành công phòng ban " + txtTenPhongBan.Text,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    reset();
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
                    if (!cls.kttrungkhoa(txtMaPhongBan.Text, "select MaPhong from tb_PHONGBAN"))
                    {
                        string insert = "insert into tb_PHONGBAN values('" + cboMaBoPhan.Text + "',N'" + txtMaPhongBan.Text + "',N'" + txtTenPhongBan.Text + "',N'" + dtNgayThanhLap.Text + "',N'" + txtGhiChu.Text + "')";
                        cls.thucthiketnoi(insert);
                        cls.loaddatagridview(dtgv, "select * from tb_PHONGBAN");
                        MessageBox.Show("Thêm thành công phòng ban mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("Mã phòng này đã tồn tại bạn có thể thử mã phòng khác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch
                {
                    MessageBox.Show("Dữ liệu đầu vào không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (txtMaPhongBan.Text == "")
                        MessageBox.Show("Chưa chọn mã phòng ban cần sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        string update = "update tb_PHONGBAN set MaBoPhan=N'" + cboMaBoPhan.Text + "',TenPhong=N'" + txtTenPhongBan.Text + "',NgayThanhLap=N'" + dtNgayThanhLap.Text + "',GhiChu=N'" + txtGhiChu.Text + "' where MaPhong=N'" + txtMaPhongBan.Text + "'";
                        cls.thucthiketnoi(update);
                        cls.loaddatagridview(dtgv, "select * from tb_PHONGBAN");
                        MessageBox.Show("Sửa thành công phòng ban " + txtTenPhongBan.Text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                cboMaBoPhan.Text = dtgv.Rows[i].Cells[0].Value.ToString();
                txtMaPhongBan.Text = dtgv.Rows[i].Cells[1].Value.ToString();
                txtTenPhongBan.Text = dtgv.Rows[i].Cells[2].Value.ToString();
                dtNgayThanhLap.Text = dtgv.Rows[i].Cells[3].Value.ToString();
                txtGhiChu.Text = dtgv.Rows[i].Cells[4].Value.ToString();
            }
            catch (Exception ex) { }
        }
    }
}