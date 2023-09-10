using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Deployment.Application;
using Guna.UI2.WinForms;

namespace QuanLiNhanSu_DoAn2
{
    class Clsdatabase
    {
        string strconnect = "Data Source=DESKTOP-2EEB116\\SA;Initial Catalog=QLNS;Integrated Security=True";
        SqlConnection sqlcon;
        SqlCommand sqlcom;
        SqlDataAdapter sqlda;
        SqlDataReader sqldr;
        DataSet ds = new DataSet();


        void ketnoi()
        {
            sqlcon = new SqlConnection(strconnect);
            sqlcon.Open();
        }

        void ngatketnoi()
        {
            sqlcon.Close();
        }

        public void thucthiketnoi(string strsql)
        {
            ketnoi();
            sqlcom = new SqlCommand(strsql, sqlcon);
            sqlcom.ExecuteNonQuery();
            ngatketnoi();

        }

        public void loaddatagridview(DataGridView dg, string strselect)
        {
            ds.Clear();
            sqlda = new SqlDataAdapter(strselect, strconnect);
            sqlda.Fill(ds, "tenbang");
            dg.DataSource = ds.Tables[0];
        }

        public void loaddatagridview1(DataGridView dg, DataSet ds1, string strselect)
        {
            ds1.Clear();
            sqlda = new SqlDataAdapter(strselect, strconnect);
            sqlda.Fill(ds1, "tenbang");
            dg.DataSource = ds1.Tables[0];
        }

        public void loadcombobox(ComboBox cb, string strselect, byte chiso)
        {
            ketnoi();
            sqlcom = new SqlCommand(strselect, sqlcon);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                cb.Items.Add(sqldr[chiso].ToString());
            }
            ngatketnoi();
        }


        public string getdata(string dauvao, string strsql)
        {
            string strketqua = "";
            ketnoi();
            sqlcom = new SqlCommand(strsql, sqlcon);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                if (sqldr[0].ToString().ToLower() == dauvao.ToLower())
                    strketqua = sqldr[1].ToString();
            }
            ngatketnoi();
            return strketqua;
        }

        public bool kt(string dauvao, string strsql, byte chiso)
        {
            bool ok = false;
            ketnoi();
            sqlcom = new SqlCommand(strsql, sqlcon);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                if (sqldr[chiso].ToString().ToLower() == dauvao.ToLower())
                    ok = true;
            }
            ngatketnoi();
            return ok;
        }

        public string thu(string dauvao, string strsql)
        {
            string strketqua = "";
            ketnoi();
            sqlcom = new SqlCommand(strsql, sqlcon);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                if (sqldr[0].ToString().ToLower() == dauvao.ToLower())
                    strketqua = sqldr[0].ToString();
            }
            ngatketnoi();
            return strketqua;
        }

        public bool kttrungkhoa(string dauvao, string strsql)
        {
            bool ok = false;
            ketnoi();
            sqlcom = new SqlCommand(strsql, sqlcon);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                if (sqldr[0].ToString().ToLower() == dauvao.ToLower())
                    ok = true;
            }
            ngatketnoi();
            return ok;
        }

       

        public void loatextbox(TextBox tb, string strselect, byte chiso)
        {
            ketnoi();
            sqlcom = new SqlCommand(strselect, sqlcon);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                tb.Lines[0] = (sqldr[chiso].ToString());
            }
            ngatketnoi();
        }

        public void loadtextboxchiso(Guna2TextBox cb, string strselect, byte chiso)
        {
            ketnoi();
            sqlcom = new SqlCommand(strselect, sqlcon);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                cb.Text = sqldr[chiso].ToString();
            }
            ngatketnoi();
            
        }

        public void loadtextbox(Guna2TextBox cb, string strselect)
        {
            ketnoi();
            sqlcom = new SqlCommand(strselect, sqlcon);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                cb.Text = sqldr[0].ToString();
            }
            ngatketnoi();
        }

        public void loaddatetime(Guna2DateTimePicker cb, string strselect, byte chiso)
        {
            ketnoi();
            sqlcom = new SqlCommand(strselect, sqlcon);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                cb.Text = sqldr[chiso].ToString();
            }
            ngatketnoi();
        }

        public void loadtextboxchiso(Guna2DateTimePicker cb, string strselect, byte chiso)
        {
            ketnoi();
            sqlcom = new SqlCommand(strselect, sqlcon);
            sqldr = sqlcom.ExecuteReader();
            while (sqldr.Read())
            {
                cb.Text = sqldr[chiso].ToString();
            }
            ngatketnoi();
        }
        //Đếm số ngày làm việc trong tháng
        public static int demSoNgayLamViecTrongThang(int thang, int nam)
        {
            int dem = 0;
            DateTime f = new DateTime(nam, thang, 01);
            int x = f.Month + 1;
            while (f.Month < x)
            {
                dem = dem + 1;
                if (f.DayOfWeek == DayOfWeek.Sunday)
                {
                    dem = dem - 1;
                }
                f = f.AddDays(1);
            }
            return dem;
        }
        public static int laySoNgayCuaThang(int thang, int nam)
        {
            return DateTime.DaysInMonth(nam, thang);
        }
        public static string layThuTrongTuan(int nam, int thang, int ngay)
        {
            string thu = "";
            DateTime newDate = new DateTime(nam, thang, ngay);
            switch (newDate.DayOfWeek.ToString())
            {
                case "Monday":
                    thu = "Thứ hai";
                    break;
                case "Tuesday":
                    thu = "Thứ ba";
                    break;

                case "Wednesday":
                    thu = "Thứ tư";
                    break;
                case "Thursday":
                    thu = "Thứ năm";
                    break;
                case "Friday":
                    thu = "Thứ sáu";
                    break;
                case "Saturday":
                    thu = "Thứ bảy";
                    break;
                case "Sunday":
                    thu = "Chủ nhật";
                    break;
            }
            return thu;
        }


        //Crystal
        SqlConnection connect;
        String loi;
        public SqlConnection ketnoicrystal()
        {
            connect = new SqlConnection();
            connect.ConnectionString = "server=DESKTOP-2EEB116\\SA; user=sa; password=131001; database=QLNS";
            loi = "";
            try
            {
                connect.Open();
            }
            catch (SqlException ex)
            {
                loi = "Server fail";
            }
            return connect;
        }
        public String getloi()
        {
            return loi;
        }
       
    }
}
