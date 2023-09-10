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
    public partial class frmTimKiemLuong : DevExpress.XtraEditors.XtraForm
    {
        public frmTimKiemLuong()
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
            dtgv.Columns[0].HeaderText = "Mã nhân viên";
            dtgv.Columns[1].HeaderText = "Mã phòng ban";
            dtgv.Columns[2].HeaderText = "Họ tên";
            dtgv.Columns[3].HeaderText = "Mã lương";
            dtgv.Columns[4].HeaderText = "LCB";
            dtgv.Columns[5].HeaderText = "PC Chức vụ";
            dtgv.Columns[6].HeaderText = "Thưởng";
            dtgv.Columns[7].HeaderText = "Kỷ luật";
            dtgv.Columns[8].HeaderText = "Tháng";
            dtgv.Columns[9].HeaderText = "Năm";
            dtgv.Columns[10].HeaderText = "Số ngày công trong tháng";
            dtgv.Columns[11].HeaderText = "Số ngày nghỉ";
            dtgv.Columns[12].HeaderText = "Số giờ làm thêm";
            dtgv.Columns[13].HeaderText = "Lương";
            dtgv.Columns[14].HeaderText = "Ghi chú";
        }

        private void frmTimKiemLuong_Load(object sender, EventArgs e)
        {
            cls.loaddatagridview(dtgv, "select * from tb_LUONGNV");
            suatieude();
        }
      
        private void btnTim_Click(object sender, EventArgs e)
        {
            dtgv.DataSource = XemDL("select * from tb_LUONGNV where HoTen like '%" + txtHoTen.Text.Trim() + "%'");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            cls.loaddatagridview(dtgv, "select * from tb_LUONGNV");
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}