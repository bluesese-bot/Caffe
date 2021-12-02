using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caffe.Business.EntitiesClass;
using System.Windows.Forms;

namespace Caffe.DataAccess
{
    class SQL_tb_User
    {
        ConnectDB cn = new ConnectDB();

        public bool Kiemtrauser(EC_tb_User user)
        {
            string sql = "select count(*) from tb_User where Username ='" + user.USERNAME + "' and Password = '" + user.PASSWORD + "'";
            return cn.KiemtraUsername(sql);  
        }

        public void themmoinv(EC_tb_User nv)
        {
            string sql = @"INSERT INTO dbo.tb_User (Username,Password,LoaiTaiKhoan,TenUser) VALUES   (N'" + nv.USERNAME + "',N'" + nv.PASSWORD + "',N'" + nv.Loaitk + "',N'" + nv.Tenuser + "')";
            cn.ExcuteNonQuery(sql);
        }
        public void xoanv(EC_tb_User nv)
        {
            cn.ExcuteNonQuery("DELETE FROM [tb_User] WHERE Username=N'" + nv.USERNAME + "'");
        }

        public void suanv(EC_tb_User nv)
        {
            string sql = (@"UPDATE    tb_User
                    SET  Password =N'" + nv.PASSWORD + "', LoaiTaiKhoan =N'" + nv.Loaitk + "', TenUser =N'" + nv.Tenuser + "' where Username =N'" + nv.USERNAME + "'");
            cn.ExcuteNonQuery(sql);
        }
        public void suaMK(EC_tb_User mk)
        {
            string sql = (@"UPDATE dbo.tb_User SET Password = N'"+mk.PASSWORD+"'WHERE Username = N'"+mk.USERNAME+"'");
            cn.ExcuteNonQuery(sql);
        }
        public void loadTKMK(TextBox tk,TextBox mk,string TK)
        {
            tk.Text = TK;
            cn.LoadTextBox(mk, @"SELECT Password FROM dbo.tb_User WHERE Username = N'"+TK+"'");
        }
    }
}
