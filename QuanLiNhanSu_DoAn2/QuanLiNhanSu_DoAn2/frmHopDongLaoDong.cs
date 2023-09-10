using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiNhanSu_DoAn2
{
    public partial class frmHopDongLaoDong : DevExpress.XtraEditors.XtraForm
    {
        Clsdatabase cls = new Clsdatabase();
        public frmHopDongLaoDong()
        {
            InitializeComponent();
        }
        bool _them;
        void _showHide(bool kt)
        {
            btnHuy.Enabled = !kt;
            btnLuu.Enabled = !kt;
            btnThem.Enabled = kt;
            btnXoa.Enabled = kt;
            btnThoat.Enabled = kt;
            txtMaHD.Enabled = !kt;
            txtMaLuong.Enabled = !kt;
            spLanKy.Enabled = !kt;
            //txtGhiChu.Enabled = !kt;
            //dtNgayBatDau.Enabled = !kt;
            //dtNgayKetThuc.Enabled = !kt;
        }
        void reset()
        {
            txtMaHD.Clear();
            txtMaLuong.Clear();
            spLanKy.Text="0";
            dtNgayBatDau.Value = DateTime.Now;
        }
        public void suatieude()
        {
            dtgv.Columns[0].HeaderText = "Số hợp đồng";
            dtgv.Columns[1].HeaderText = "Ngày bắt đầu";
            dtgv.Columns[2].HeaderText = "Ngày kết thúc";
            dtgv.Columns[3].HeaderText = "Ngày ký";
            dtgv.Columns[4].HeaderText = "Nội dung";
            dtgv.Columns[5].HeaderText = "Lần ký";
            dtgv.Columns[6].HeaderText = "Thời hạn";
            dtgv.Columns[7].HeaderText = "Mã lương";
            dtgv.Columns[8].HeaderText = "Mã nhân viên";
        }
        private void frmHopDongLaoDong_Load(object sender, EventArgs e)
        {
            cls.loadcombobox(cboMaNV, "select MaNV from tb_NHANVIEN", 0);
            cls.loaddatagridview(dtgv, "select * from tb_HOPDONG");
            suatieude();
            _them = false;
            _showHide(true);
        }

        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            cls.loadtextboxchiso(dtNgayBatDau, "select * from tb_NHANVIEN where MaNV='" + cboMaNV.Text + "'", 13);
            cls.loadtextboxchiso(dtNgayHetHan, "select * from tb_NHANVIEN where MaNV='" + cboMaNV.Text + "'", 14);
            cls.loadtextboxchiso(txtThoiHan, "select * from tb_NHANVIEN where MaNV='" + cboMaNV.Text + "'", 4);
            cls.loadtextboxchiso(txtMaLuong, "select * from tb_NHANVIEN where MaNV='" + cboMaNV.Text + "'", 12);
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true; //Khi nhấn mới thêm
            _showHide(false);
            reset();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string del = "delete from tb_HOPDONG where SOHD='" + txtMaHD.Text + "'";
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn mã hợp đồng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (MessageBox.Show("Bạn có chắc chắn muốn xóa " + txtMaHD.Text + "không?", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            { 
                cls.thucthiketnoi(del);
                cls.loaddatagridview(dtgv, "select * from tb_HOPDONG");
                MessageBox.Show("Xóa thành công " + txtMaHD.Text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
            }
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
                    if (!cls.kttrungkhoa(txtMaHD.Text, "select SoHD from tb_HOPDONG"))
                    {
                        string insert = "insert into tb_HOPDONG values(N'" + txtMaHD.Text + "',N'" + dtNgayBatDau.Text + "',N'" + dtNgayHetHan.Text + "',N'" + dtNgayKy.Text + "',N'" + txtNoiDung.Text + "',N'" + spLanKy.Text + "',N'" + txtThoiHan.Text + "',N'" + txtMaLuong.Text + "',N'" + cboMaNV.Text + "')";
                        cls.loaddatagridview(dtgv, "select * from tb_HOPDONG");
                        MessageBox.Show("Thêm thành công hợp đồng mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                    else
                    {
                        MessageBox.Show("Hợp đồng này đã tồn tại ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    if (txtMaHD.Text == "")
                        MessageBox.Show("Chưa chọn hợp đồng cần sửa", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        string update = "update tb_BOPHAN set NOIDUNG=N'" + txtNoiDung.Text + "' where SOHD='" + txtMaHD.Text + "'";
                        cls.thucthiketnoi(update);
                        cls.loaddatagridview(dtgv, "select * from tb_BOPHAN");
                        MessageBox.Show("Sửa thành công" + txtMaHD.Text + "", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reset();
                    }
                }
                catch
                {
                    MessageBox.Show("Dữ liệu đầu vào không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i = e.RowIndex;
                txtMaHD.Text = dtgv.Rows[i].Cells[0].Value.ToString();
                dtNgayBatDau.Text = dtgv.Rows[i].Cells[1].Value.ToString();
                dtNgayHetHan.Text = dtgv.Rows[i].Cells[2].Value.ToString();
                dtNgayKy.Text = dtgv.Rows[i].Cells[3].Value.ToString();
                txtNoiDung.Text = dtgv.Rows[i].Cells[4].Value.ToString();
                spLanKy.Text = dtgv.Rows[i].Cells[5].Value.ToString();
                txtThoiHan.Text = dtgv.Rows[i].Cells[6].Value.ToString();
                txtMaLuong.Text = dtgv.Rows[i].Cells[7].Value.ToString();
                cboMaNV.Text = dtgv.Rows[i].Cells[8].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaHD.Enabled = false;
            txtMaLuong.Enabled = false;
            txtThoiHan.Enabled = false;
            txtNoiDung.Enabled = true;
            spLanKy.Enabled = false;
            dtNgayBatDau.Enabled = false;
            dtNgayHetHan.Enabled = false;
            dtNgayKy.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThoat.Enabled = false;
        }
    }
    }