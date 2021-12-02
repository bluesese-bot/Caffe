using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caffe.Business.EntitiesClass;
using System.Data;
using System.Windows.Forms;

namespace Caffe.DataAccess
{
    class SQL_tb_DatBan
    {
        ConnectDB cn = new ConnectDB();
        public object Datatable { get; private set; }

        public List<EC_tb_DatBan> Loadtablelist()
        {
            List<EC_tb_DatBan> tablelist = new List<EC_tb_DatBan>();
            DataTable data = cn.taobang("SELECT * FROM dbo.tb_slotBan");
            foreach (DataRow item in data.Rows)
            {
                EC_tb_DatBan table = new EC_tb_DatBan(item);
                tablelist.Add(table);
            }
            return tablelist;
        }
        public void loadtensp(ComboBox masp,string tenloai)
        {
            cn.LoadLenCombobox(masp, "SELECT tensp FROM dbo.tb_Loai,dbo.tb_Sanpham WHERE tb_Loai.maloai=tb_Sanpham.maloai and tenloai = N'"+tenloai+"'", 0);
        }
        public void loadtenloai(ComboBox maloai)
        {
            cn.LoadLenCombobox(maloai, "SELECT tenloai FROM dbo.tb_Loai", 0);
        }
    }
}
