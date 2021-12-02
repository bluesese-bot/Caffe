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
    class E_tb_HDB
    {
        SQL_tb_HDB hdbsql = new SQL_tb_HDB();
        public void themoihdb(EC_tb_HDB hdb)
        {
            if (!hdbsql.kiemtraHDB(hdb.MAHDB))
            {
                hdbsql.themmoiHDB(hdb);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void suahdb(EC_tb_HDB hdb)
        {
            hdbsql.suaHDB(hdb);
        }
        public void xoahdb(EC_tb_HDB hdb)
        {
            hdbsql.xoaHDB(hdb);
        }
        //load nv
        public string loadmanv(string manv,string tennv)
        {
            hdbsql.loadmanv(manv,tennv);
            return manv;
        }
        public void loadtennv(ComboBox Tennv, string Manv)
        {
            hdbsql.Loadtennv(Tennv, Manv);
        }
        public void loadAllnv(ComboBox box)
        {
            hdbsql.loadALLnv(box);
        }
        //load khách
        public string loadmakh(string maBan, string tenBan)
        {
            hdbsql.loadmakhach(maBan,tenBan);
            return maBan;
        }
        public void loadtenkh(ComboBox box, string Mak)
        {
            hdbsql.LoadtenBan(box,Mak);
        }
        public void loadAllban(ComboBox box)
        {
            hdbsql.loadALLBan(box);
        }
        //Load mã hóa đơn tự sinh
        public void loadhdAuto (TextBox box)
        {
            hdbsql.MaHDAuto(box);
        }
    }
}
