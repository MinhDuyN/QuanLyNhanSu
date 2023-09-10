using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhanSu_DoAn2
{
    public class NHANVIEN
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        public List<tb_NHANVIEN> getSinhNhat()
        {
            return db.tb_NHANVIEN.Where(x => x.NgaySinh.Value.Month == DateTime.Now.Month).ToList();
        }
       
    }
}
