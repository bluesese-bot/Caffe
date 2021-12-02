using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caffe.Business.EntitiesClass;

namespace Caffe.DataAccess
{
    class SQL_tb_Khachhang
    {
        ConnectDB cn = new ConnectDB();
        public bool kiemtra(string tenBan)
        {
            return cn.kiemtra("select count(*) from [tb_slotBan] where tenBan=N'" + tenBan + "'");
        }
        public void themmoi(EC_tb_Khachhang q)
        {
            cn.ExcuteNonQuery(@"INSERT INTO tb_slotBan
                      (maBan, tenBan) VALUES   (N'" + q.MABAN + "',N'" + q.TENBAN + "')");
        }
        public void xoa(EC_tb_Khachhang q)
        {
            cn.ExcuteNonQuery("DELETE FROM [tb_slotBan] WHERE [maBan] = N'" + q.MABAN + "'");
        }

        public void sua(EC_tb_Khachhang q)
        {
            string sql = (@"UPDATE tb_slotBan
            SET tenBan =N'" + q.TENBAN + "' where  maBan =N'" + q.MABAN + "'");
            cn.ExcuteNonQuery(sql);
        }
    }
}
