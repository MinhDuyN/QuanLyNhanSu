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
    public partial class frmBangCong : DevExpress.XtraEditors.XtraForm
    {
        public frmBangCong()
        {
            InitializeComponent();
        }
        KYCONG _kycong;
        bool _them;
        int _makycong;
        private void frmBangCong_Load(object sender, EventArgs e)
        {
            _them = false; //Mặc định khi form load là không thêm
            _kycong = new KYCONG();
            _showHide(true);
            cboNam.Text = DateTime.Now.Year.ToString();
            cboThang.Text = DateTime.Now.Month.ToString();
            loadData();
        }
        void _showHide(bool kt)
        {
            btnHuy.Enabled = !kt;
            btnLuu.Enabled = !kt;
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            

        }
        
        void loadData()
        {
            gcDanhSach.DataSource = _kycong.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        void reset()
        {
            //txtTen.Text = "";
            //spHeSo.EditValue = 0;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true; //Khi nhấn mới thêm
            _showHide(false);
            cboNam.Enabled = false;
            cboThang.Enabled = false;
            //cboNam.Text = DateTime.Now.Year.ToString();
            //cboThang.Text = DateTime.Now.Month.ToString();
            reset();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtMaKyCong.Text == "")
            {
                MessageBox.Show("Vui lòng chọn kỳ công cần xóa!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn xóa kỳ công tháng "+cboThang.Text+" năm "+cboNam.Text+"  không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _kycong.Delete(_makycong, 1);
                string delete = "delete from tb_KYCONGCHITIET where MAKYCONG=N'" + txtMaKyCong.Text + "'";
                cls.thucthiketnoi(delete);
                MessageBox.Show("Đã xóa kỳ công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                reset();
            }
            
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            loadData();
            _them = false;
            _showHide(true);
            cboNam.Enabled = true;
            cboThang.Enabled = true;
            reset();
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
            _them = false;
            cboNam.Enabled = true;
            cboThang.Enabled = true;
            reset();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _makycong = int.Parse(gvDanhSach.GetFocusedRowCellValue("MAKYCONG").ToString());
                cboNam.Text = gvDanhSach.GetFocusedRowCellValue("NAM").ToString();
                cboThang.Text = gvDanhSach.GetFocusedRowCellValue("THANG").ToString();
                chkKhoa.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("KHOA").ToString());
                chkTrangThai.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("TRANGTHAI").ToString());
                txtMaKyCong.Text = gvDanhSach.GetFocusedRowCellValue("MAKYCONG").ToString();
            }
        }
        Clsdatabase cls = new Clsdatabase();
        void SaveData()
        {
            if (_them)
            {
                tb_KYCONG kc = new tb_KYCONG();
                kc.MAKYCONG = int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text);
                kc.NAM = int.Parse(cboNam.Text);
                kc.THANG = int.Parse(cboThang.Text);
                kc.KHOA = chkKhoa.Checked;
                kc.TRANGTHAI = chkTrangThai.Checked;
                kc.MACTY = 1;
                kc.NGAYCONGTRONGTHANG = Clsdatabase.demSoNgayLamViecTrongThang(int.Parse(cboThang.Text), int.Parse(cboNam.Text));
                kc.NGAYTINHCONG = DateTime.Now;
                _kycong.Add(kc);


            }
            else
            {
                var kc = _kycong.getItem(_makycong);
                kc.MAKYCONG = int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text);
                kc.NAM = int.Parse(cboNam.Text);
                kc.THANG = int.Parse(cboThang.Text);
                kc.KHOA = chkKhoa.Checked;
                kc.TRANGTHAI = chkTrangThai.Checked;
                kc.NGAYCONGTRONGTHANG = Clsdatabase.demSoNgayLamViecTrongThang(int.Parse(cboThang.Text), int.Parse(cboNam.Text));
                kc.NGAYTINHCONG = DateTime.Now;
               
                _kycong.Update(kc);
            }
        }

        private void btnXemBangCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmBangCongChiTiet frm = new frmBangCongChiTiet();
            frm._makycong = _makycong;
            frm._thang = int.Parse(cboThang.Text);
            frm._nam = int.Parse(cboNam.Text);
            frm._macty = 1;
            frm.ShowDialog();
        }
    }
}