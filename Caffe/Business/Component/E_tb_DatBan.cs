using Caffe.Business.EntitiesClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caffe.DataAccess;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Caffe.Business.Component
{
    class E_tb_DatBan
    {
        SQL_tb_DatBan sqldb = new SQL_tb_DatBan();
        SQL_tb_CTHDB sqlcthdb = new SQL_tb_CTHDB();
        SQL_tb_HDB sqlhdb = new SQL_tb_HDB();
        public void loadTensp(ComboBox box, string tenloai)
        {
            sqldb.loadtensp(box,tenloai);
        }
        public void loadTenLoai(ComboBox box)
        {
            sqldb.loadtenloai(box);
        }
    }
}
