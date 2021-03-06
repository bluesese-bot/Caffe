using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caffe.DataAccess;
using System.Data.SqlClient;

namespace Caffe.Presentation
{
    public partial class fr_TK_SP : Form
    {
        public fr_TK_SP()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        public void khoitaoluoi()
        {
            //RepositoryItemPictureEdit image = msds.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].HeaderText = "Mã Sản Phẩm";
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 80;

            msds.Columns[1].HeaderText = "Tên Sản Phẩm";
            msds.Columns[1].Width = 140;

            msds.Columns[2].HeaderText = "Mã Loại";
            msds.Columns[2].Width = 80;

            msds.Columns[3].HeaderText = "Giá Nhập";
            msds.Columns[3].Width = 80;

            msds.Columns[4].HeaderText = "Giá Bán";
            msds.Columns[4].Width = 80;

            msds.Columns[5].HeaderText = "số Lượng";
            msds.Columns[5].Width = 80;



        }
        public void hienthi()
        {
            string sql = "SELECT masp, tensp, maloai, gianhap, giaban, soluong FROM tb_Sanpham";
            msds.DataSource = cn.taobang(sql);
            SqlConnection con = cn.getcon();
            con.Open();
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void txtthongtin_TextChanged(object sender, EventArgs e)
        {
                
            if (op1.Checked)
            {
                string sql = @"SELECT masp, tensp, maloai, gianhap, giaban, soluong FROM tb_Sanpham WHERE maloai= '" + txtthongtin.Text + "'";
                msds.DataSource = cn.taobang(sql);

                SqlConnection con = cn.getcon();
                con.Open();
            }
            if (op2.Checked)
            {
                string sql = @"SELECT masp, tensp, maloai, gianhap, giaban, soluong FROM tb_Sanpham WHERE gianhap= '" + txtthongtin.Text + "'";
                msds.DataSource = cn.taobang(sql);

                SqlConnection con = cn.getcon();
                con.Open();
            }
            if (op4.Checked)
            {
                string sql = @"SELECT masp, tensp, maloai, gianhap, giaban, soluong FROM tb_Sanpham where tensp  like N'%" + txtthongtin.Text + "%'";
                msds.DataSource = cn.taobang(sql);

                SqlConnection con = cn.getcon();
                con.Open();
            }
        }

        private void fr_TK_SP_Load(object sender, EventArgs e)
        {
            hienthi();
            khoitaoluoi();
        }
    }
}
