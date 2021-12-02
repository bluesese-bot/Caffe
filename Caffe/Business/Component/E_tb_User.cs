using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caffe.Business.EntitiesClass;
using Caffe.DataAccess;
using System.Windows.Forms;
using System.Data;

namespace Caffe.Business.Component
{
    class E_tb_User
    {
        ConnectDB cn = new ConnectDB();
        EC_tb_User ck = new EC_tb_User();
        SQL_tb_User sql = new SQL_tb_User();
        public bool kiemtrauser(string user, string pass)
        {
            ck.USERNAME = user;
            ck.PASSWORD = pass;
            return sql.Kiemtrauser(ck);
        }
        public List<EC_tb_User> GetTb_Menus(string Username,string pass)
        {
            List<EC_tb_User> listmenu = new List<EC_tb_User>();
            DataTable data = cn.taobang("select * from tb_User where Username = N'"+Username+"' and Password = N'"+pass+"'");
            foreach (DataRow item in data.Rows)
            {
                EC_tb_User menu = new EC_tb_User(item);
                listmenu.Add(menu);
            }
            return listmenu;
        }
        SQL_tb_User nvsql = new SQL_tb_User();
        public void themoinv(EC_tb_User nv)
        {
            if (kiemtrauser(nv.USERNAME,nv.PASSWORD) == true)
            {
                sql.themmoinv(nv);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void suanv(EC_tb_User nv)
        {
            sql.suanv(nv);
        }
        public void xoanv(EC_tb_User nv)
        {
            sql.xoanv(nv);
        }
        public void suamk(EC_tb_User nv)
        {
            sql.suaMK(nv);
        }
        public void loadTKMK(TextBox tk, TextBox mk, string TK)
        {
            sql.loadTKMK(tk,mk,TK);
        }
    }
}
