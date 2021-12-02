using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffe.Business.EntitiesClass
{
    public class EC_tb_Menu
    {
        private string tenMon;
        private int soluong;
        private float gia;
        private float tong;


        public EC_tb_Menu(DataRow row)
        {
            this.tenMon = row["tensp"].ToString();
            this.soluong = (int)Convert.ToDouble(row["soluong"].ToString());
            this.gia = (float)Convert.ToDouble(row["giaban"].ToString());
            this.tong = (float)Convert.ToDouble(row["thanhTien"].ToString());
        }

        public EC_tb_Menu(string tenMon, int soluong, float gia, float tong)
        {
            this.tenMon = tenMon;
            this.soluong = soluong;
            this.gia = gia;
            this.tong = tong;
        }

        public string TenMon { get => tenMon; set => tenMon = value; }
        public int Soluong1 { get => soluong; set => soluong = value; }
        public float Gia { get => gia; set => gia = value; }
        public float Tong { get => tong; set => tong = value; }
    }
}
