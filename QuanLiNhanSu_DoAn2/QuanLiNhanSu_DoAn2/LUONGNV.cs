using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiNhanSu_DoAn2
{
    public class LUONGNV
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        //Lấy danh sách
        public List<tb_LUONGNV> getList()
        {
            return db.tb_LUONGNV.ToList();
        }
    }
}
