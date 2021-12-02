using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caffe.Business.EntitiesClass
{
    class EC_tb_DatBan 
    {
        
        private string iD;
        private string name;
        private string trangThai;
        public EC_tb_DatBan(DataRow row)
        {
            this.ID = row["maBan"].ToString();
            this.Name = row["tenBan"].ToString();
            this.TrangThai = row["trangThai"].ToString();
        }
        public EC_tb_DatBan(string id, string name, string trangthai) {
            this.ID = id;
            this.Name = name;
            this.TrangThai = trangthai;
        }



        public string ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }


    }
}
