using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffe.Business.EntitiesClass
{
    class EC_tb_CTHDB
    {
        private string mahdb;
        private string masp;
        private string tensp;
        private string soluong;
        private string thanhtien;
        private string khuyenmai;

        public EC_tb_CTHDB()
        {
        }

        public EC_tb_CTHDB(DataRow row)
        {
            this.mahdb = row["mahdb"].ToString();
            this.masp = row["masp"].ToString();
            this.tensp = row["tensp"].ToString();
            this.soluong = row["soluong"].ToString();
            this.thanhtien = row["thanhtien"].ToString();
            this.khuyenmai = row["khuyenmai"].ToString();
        }

        public string MAHDB
        {
            get
            {
                return mahdb;
            }
            set
            {
                mahdb = value;
                if (mahdb == "")
                {
                    throw new Exception("Mã không để trống");
                }
            }
        }
        public string MASP
        {
            get
            {
                return masp;
            }
            set
            {
                masp = value;
                if (masp == "")
                {
                    throw new Exception("Mã không để trống");
                }
            }
        }
        public string TENSP
        {
            get
            {
                return tensp;
            }
            set
            {
                tensp = value;
                if (tensp == "")
                {
                    throw new Exception("Tên sản phẩm không để trống");
                }
            }
        }
        public string SOLUONG
        {
            get
            {
                return soluong;
            }
            set
            {
                soluong = value;
            }
        }
        public string THANHTIEN
        {
            get
            {
                return thanhtien;
            }
            set
            {
                thanhtien = value;
            }
        }
        public string KHUYENMAI
        {
            get
            {
                return khuyenmai;
            }
            set
            {
                khuyenmai = value;
            }
        }
    }
}
