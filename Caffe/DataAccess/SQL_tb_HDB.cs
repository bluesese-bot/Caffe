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
    class SQL_tb_HDB
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtraHDB(string mahdb)
        {
            return cn.kiemtra("select count(*) from [tb_HDB] where mahdb=N'" + mahdb + "'");
        }
        public void themmoiHDB(EC_tb_HDB hdb)
        {
            cn.ExcuteNonQuery(@"INSERT INTO tb_HDB
                      (mahdb,ngayban, manv, maBan, tongtien,trangThai) VALUES   (N'" + hdb.MAHDB + "',N'" + hdb.NGAYBAN + "',N'" + hdb.MANV + "',N'" + hdb.MABAN + "',N'" + hdb.TONGTIEN + "',N'Chưa Hoàn Thành')");
        }
        public void xoaHDB(EC_tb_HDB hdb)
        {
            cn.ExcuteNonQuery("DELETE FROM [tb_HDB] WHERE [mahdb] = N'" + hdb.MAHDB + "'");
        }

        public void suaHDB(EC_tb_HDB hdb)
        {
            string sql = (@"UPDATE tb_HDB
            SET manv =N'" + hdb.MANV + "',ngayban =N'" + hdb.NGAYBAN + "',maBan =N'" + hdb.MABAN + "' where  mahdb =N'" + hdb.MAHDB + "'");
            cn.ExcuteNonQuery(sql);
        }
        //load nhân viên
        public string loadmanv(string manv, string tennv)
        {
            manv = cn.LoadLable("select manv from tb_Nhanvien where tennv = N'" + tennv + "'");
            return manv;
        }
        public void Loadtennv(ComboBox box, string manv)
        {
           box.Text= cn.returnscalarnumberString("select tennv from tb_Nhanvien where manv = N'"+manv+"'");
        }
        public void loadALLnv(ComboBox box)
        {
            cn.LoadLenCombobox(box, "SELECT tennv FROM dbo.tb_Nhanvien", 0);
        }
        //load mã Ban
        public string loadmakhach(string maB, string tenB)
        {
            maB = cn.LoadLable("select maBan from tb_slotBan where tenBan = N'" + tenB + "'");
            return maB;
        }
        public void LoadtenBan(ComboBox box, string manv)
        {
            box.Text = cn.returnscalarnumberString("select tenBan from tb_slotBan where maBan = N'"+manv+"'");
        }
        public void loadALLBan(ComboBox box)
        {
            cn.LoadLenCombobox(box, "SELECT tenBan FROM dbo.tb_slotBan", 0);
        }
        public void MaHDAuto(TextBox box)
        {
             cn.LoadTextBox(box, "select max(mahdb) from tb_HDB");

        }
        public int loadHoaDonChuaHoanThanh(string id)
        {
            DataTable data = cn.taobang("SELECT mahdb FROM dbo.tb_HDB WHERE maBan="+id+ " AND trangThai = N'Chưa Hoàn Thành'");
            if (data.Rows.Count > 0)
            {
                EC_tb_HDB bill = new EC_tb_HDB(data.Rows[0]);
                int mAHDB = int.Parse(bill.MAHDB);
                return mAHDB;
            }
            return -1;
        }

        public void insertBill(string mahdb,string maban,string manv)
        {
            cn.ExcuteNonQuery("exec USP_InsertBill @idBan='" + maban + "',@idHBD='" + mahdb + "',@idNhanVien='" + manv+"'");
        }
        public void checkOut(int id)
        {
            string query = "UPDATE dbo.tb_HDB SET trangThai=N'Hoàn Thành' WHERE mahdb = N'" + id + "'";
            cn.ExcuteNonQuery(query);
        }
        public void checkOUt1(int id)
        {
            string query = "UPDATE dbo.tb_HDB SET trangThai = N'Hủy Đơn' WHERE mahdb = N'" + id + "'";
            cn.ExcuteNonQuery(query);
        }
    }
}
