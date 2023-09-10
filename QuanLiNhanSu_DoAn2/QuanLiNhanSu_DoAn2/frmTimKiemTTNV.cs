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
    public partial class frmTimKiemTTNV : DevExpress.XtraEditors.XtraForm
    {
        public frmTimKiemTTNV()
        {
            InitializeComponent();
        }
        Clsdatabase cls = new Clsdatabase();
        public SqlConnection cn = new SqlConnection();
        public void Ketnoi()
        {
            try
            {
                if (cn.State == 0)
                {
                    cn.ConnectionString = "Data Source=DESKTOP-2EEB116\\SA;Initial Catalog=QLNS;Integrated Security=True";
                    cn.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Ngatketnoi()
        {
            if (cn.State != 0)
            {
                cn.Close();
            }
        }

        //Phương thức truy vấn để xem dữ liệu
        public DataTable XemDL(string sql)
        {
            Ketnoi();

            SqlDataAdapter adap = new SqlDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            return dt;

            Ngatketnoi();
        }

        //Phương thức truy vấn dữ liệu: Insert, Update, Delete
        public SqlCommand ThucThiDl(string sql)
        {
            Ketnoi();

            SqlCommand cm = new SqlCommand(sql, cn);
            cm.ExecuteNonQuery();

            return cm;

            Ngatketnoi();
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
        private void btnTim_Click(object sender, EventArgs e)
        {
            dtgv.DataSource = XemDL("select * from tb_NHANVIEN where HoTen like '%" + txtHoTen.Text.Trim() + "%'");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            cls.loaddatagridview(dtgv, "select * from tb_NHANVIEN");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTimKiemTTNV_Load(object sender, EventArgs e)
        {
            cls.loaddatagridview(dtgv, "select * from tb_NHANVIEN");
            suatieude();
        }
    }
}