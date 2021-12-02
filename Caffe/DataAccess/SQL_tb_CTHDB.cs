using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caffe.Business.EntitiesClass;
using System.Windows.Forms;
using System.Data;

namespace Caffe.DataAccess
{
    class SQL_tb_CTHDB
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtratb_CTHBD(string mahdb, string masp)
        {
            return cn.kiemtra("select count(*) from [tb_CTHDB] where mahdb=N'" + mahdb + "'and masp=N'" + masp + "'");
        }
        public void themmoicthdb(EC_tb_CTHDB cthdb)
        {
            cn.ExcuteNonQuery(@"INSERT INTO tb_CTHDB
                      (mahdb, masp, tensp, soluong, thanhtien, khuyenmai) VALUES   (N'" + cthdb.MAHDB + "',N'" + cthdb.MASP + "',N'" + cthdb.TENSP + "',N'" + cthdb.SOLUONG + "',N'" + cthdb.THANHTIEN + "',N'" + cthdb.KHUYENMAI + "')");
        }
        public void xoacthdb(EC_tb_CTHDB cthdb)
        {
            cn.ExcuteNonQuery("DELETE FROM [tb_CTHDB] WHERE  mahdb=N'" + cthdb.MAHDB + "' and masp=N'" + cthdb.MASP + "' ");
        }

        public void suacthdb(EC_tb_CTHDB cthdb)
        {
            string sql = (@"UPDATE tb_CTHDB
            SET soluong =N'" + cthdb.SOLUONG + "', khuyenmai = N'" + cthdb.KHUYENMAI + "', thanhtien = N'" + cthdb.THANHTIEN + "' where  [mahdb]=N'" + cthdb.MAHDB + "' and masp=N'" + cthdb.MASP + "'");
            cn.ExcuteNonQuery(sql);
        }
        //load sp
        public void loadmasp(ComboBox masp)
        {
            cn.LoadLenCombobox(masp, "SELECT     masp FROM tb_Sanpham", 0);
        }
        public string Loadtenhang(string tenhang, string masp)
        {
            tenhang = cn.LoadLable("SELECT [tensp] From [tb_Sanpham] where masp= N'" + masp + "'");
            return tenhang;
        }
        //load THD
        public void loadmahd(ComboBox mahdb)
        {
            cn.LoadLenCombobox(mahdb, "SELECT sohdb FROM tb_HDB", 0);
        }
        //load đơn giá bán
        public string Loaddgb(string dg, string masp)
        {
            dg = cn.LoadLable("SELECT [giaban] From [tb_Sanpham] where masp= N'" + masp + "'");
            return dg;
        }
        //load chi tiet hoa don
        public List<EC_tb_CTHDB> GetListBillin4 (int id)
        {
            List<EC_tb_CTHDB> listBillInf = new List<EC_tb_CTHDB>();
            DataTable data = cn.taobang("SELECT * FROM dbo.tb_CTHDB WHERE mahdb = "+id);
            foreach (DataRow item in data.Rows)
            {
                EC_tb_CTHDB info = new EC_tb_CTHDB(item);
                listBillInf.Add(info);
            }
            return listBillInf;
        }
        public void insertBillinfo(string mahdb,string masp, string tenSp, float sl)
        {
            cn.ExcuteNonQuery("exec USP_InsertBillInfo @mahdb=N'" + mahdb + "',@masp = N'"+masp+"',@tensp=N'" + tenSp + "',@sl=" + sl);
        }
    }
}
