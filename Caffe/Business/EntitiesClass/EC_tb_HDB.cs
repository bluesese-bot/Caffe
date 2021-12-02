using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffe.Business.EntitiesClass
{
    class EC_tb_HDB
    {
        private string mahdb;
        private string ngayban;
        private string manv;
        private string maban;
        private string tongtien;
        private string trangThai;
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
        public string NGAYBAN
        {
            get
            {
                return ngayban;
            }
            set
            {
                ngayban = value;
            }
        }
        public string MANV
        {
            get
            {
                return manv;
            }
            set
            {
                manv = value;
                if (manv == "")
                {
                    throw new Exception("Mã không để trống");
                }
            }
        }
        public string MABAN
        {
            get
            {
                return maban;
            }
            set
            {
                maban = value;
                if (maban == "")
                {
                    throw new Exception("Mã không để trống");
                }
            }
        }
        public string TONGTIEN
        {
            get
            {
                return tongtien;
            }
            set
            {
                tongtien = value;
            }
        }

        public string TrangThai { get => trangThai; set => trangThai = value; }

        public EC_tb_HDB(DataRow row)
        {
            this.mahdb = row["mahdb"].ToString();
        }

        public EC_tb_HDB()
        {
        }
    }
}
