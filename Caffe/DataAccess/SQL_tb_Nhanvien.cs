using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caffe.Business.EntitiesClass;
using System.Windows.Forms;
using Caffe.DataAccess;

namespace Caffe.DataAccess
{
    class SQL_tb_Nhanvien
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtranv(string manv)
        {
            return cn.kiemtra("select count(*) from [tb_Nhanvien] where manv=N'" + manv + "'");
        }
        public void themmoinv(EC_tb_Nhanvien nv)
        {
            string sql = @"INSERT INTO tb_Nhanvien
                      (manv, tennv, diachi, gioitinh, ngaysinh, maque, sdt)
                        VALUES   (N'" + nv.MANV + "',N'" + nv.TENNV + "',N'" + nv.DIACHI + "',N'" + nv.GIOITINH + "',N'" + nv.NGAYSINH + "',N'" + nv.MAQUE + "',N'" + nv.SDT + "')";
            cn.ExcuteNonQuery(sql);
        }
        public void xoanv(EC_tb_Nhanvien nv)
        {
            cn.ExcuteNonQuery("DELETE FROM [tb_Nhanvien] WHERE manv=N'" + nv.MANV + "'");
        }

        public void suanv(EC_tb_Nhanvien nv)
        {
            string sql = (@"UPDATE    tb_Nhanvien
                    SET tennv =N'" + nv.TENNV + "', gioitinh =N'" + nv.GIOITINH + "', ngaysinh =N'" + nv.NGAYSINH + "', sdt =N'" + nv.SDT + "', diachi =N'" + nv.DIACHI + "',maque =N'" + nv.MAQUE + "'  where manv=N'" + nv.MANV + "'");
            cn.ExcuteNonQuery(sql);
        }
        //load quê
        public void loadmaque(ComboBox maq)
        {
            cn.LoadLenCombobox(maq, "SELECT     maque FROM tb_Que", 0);
        }
        public string Loadtenq(string tenq, string maq)
        {
            tenq = cn.LoadLable("SELECT [tenque] From [tb_Que] where maque= N'" + maq + "'");
            return tenq;
        }
        public void loadProfileNV(TextBox manv,TextBox tenNV,DateTimePicker dateTime,ComboBox cbGT,ComboBox cbMAque,TextBox que,TextBox sdt,TextBox diachi,string tennv)
        {
            cn.LoadTextBox(manv, "SELECT manv FROM dbo.tb_Nhanvien WHERE tennv =N'"+tennv+"'");
            dateTime.Text = cn.returnscalarnumberString("SELECT ngaysinh FROM dbo.tb_Nhanvien WHERE tennv =N'"+tennv+"'");
            cbGT.Text = cn.returnscalarnumberString("SELECT gioitinh FROM dbo.tb_Nhanvien WHERE tennv =N'" + tennv + "'");
            cn.LoadTextBox(que, "SELECT tenque FROM dbo.tb_Nhanvien,dbo.tb_Que WHERE tb_Nhanvien.maque=tb_Que.maque AND tennv =N'"+tennv+"'");
            cn.LoadTextBox(sdt, "SELECT sdt FROM dbo.tb_Nhanvien WHERE tennv =N'"+tennv+"'");
            cbMAque.Text = cn.returnscalarnumberString("SELECT maque FROM dbo.tb_Nhanvien WHERE tennv = N'"+tennv+"'");
            cn.LoadTextBox(diachi,"SELECT diachi FROM dbo.tb_Nhanvien WHERE tennv = N'"+tennv+"'");
            tenNV.Text = tennv;
        }
    }
}
