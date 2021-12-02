using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffe.Business.EntitiesClass
{
    class EC_tb_User
    {
        private string username;
        private string password;
        private string loaitk;
        private string tenuser;

        public EC_tb_User()
        {
        }

        public EC_tb_User(DataRow row)
        {
            this.username = row["Username"].ToString();
            this.password = row["Password"].ToString();
            this.loaitk = row["LoaiTaiKhoan"].ToString();
            this.tenuser = row["TenUser"].ToString();
        }

        public string USERNAME
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                if (username == "")
                {
                    throw new Exception("Tên Đăng Nhập Không Được Để Trống !");
                }
            }
        }
        public string PASSWORD
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                if (password == "")
                {
                    throw new Exception("Mật Khẩu Không Được Để Trống !");
                }
            }
        }

        public string Loaitk { get => loaitk; set => loaitk = value; }
        public string Tenuser { get => tenuser; set => tenuser = value; }
    }
}
