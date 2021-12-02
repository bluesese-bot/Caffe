using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caffe.DataAccess;
using Caffe.Business.EntitiesClass;

namespace Caffe.Business.Component
{
    public class E_tb_Menu
    {
        ConnectDB cn = new ConnectDB();
        public List<EC_tb_Menu> GetTb_Menus(string id)
        {
            List<EC_tb_Menu> listmenu = new List<EC_tb_Menu>();
            DataTable data = cn.taobang("SELECT sp.tensp,cthd.soluong,sp.giaban, sp.giaban*cthd.soluong AS thanhTien FROM dbo.tb_HDB AS hdb,dbo.tb_CTHDB AS cthd,dbo.tb_Sanpham AS sp WHERE hdb.mahdb = cthd.mahdb AND cthd.masp = sp.masp AND hdb.trangThai = N'Chưa Hoàn Thành' AND hdb.maBan = " + id);
            foreach (DataRow item in data.Rows)
            {
                EC_tb_Menu menu = new EC_tb_Menu(item);
                listmenu.Add(menu);
            }
            return listmenu;
        }
    }
}
