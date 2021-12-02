using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caffe.Business.EntitiesClass;
using Caffe.DataAccess;
using System.Windows.Forms;

namespace Caffe.Business.Component
{
    class E_tb_Que
    {
        SQL_tb_Que lgsql = new SQL_tb_Que();
        public void themoilg(EC_tb_Que lg)
        {
            if (!lgsql.Equals(lg.MAQUE))
            {
                lgsql.themmoi(lg);
            }
            else
            {
                MessageBox.Show("Mã này đã tồn tại,xin chọn Mã khác", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void sualg(EC_tb_Que lg)
        {
            lgsql.sua(lg);
        }
        public void xoalg(EC_tb_Que lg)
        {
            lgsql.xoa(lg);
        }
    }
}
