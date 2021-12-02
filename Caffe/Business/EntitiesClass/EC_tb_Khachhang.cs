using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffe.Business.EntitiesClass
{
    class EC_tb_Khachhang
    {
        private string maban;
        private string tenBan;

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
        public string TENBAN
        {
            get
            {
                return tenBan;
            }
            set
            {
                tenBan = value;
            }
        }
    }
}
