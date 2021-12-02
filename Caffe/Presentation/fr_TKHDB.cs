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
    public partial class fr_TKHDB : Form
    {
        public fr_TKHDB()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        public void khoitaoluoi()
        {
            msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].HeaderText = "Số HDB";
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 100;
            msds.Columns[1].HeaderText = "Ngày Bán";
            msds.Columns[1].Width = 100;
            msds.Columns[2].HeaderText = "Nhân Viên";
            msds.Columns[2].Width = 70;
            msds.Columns[3].HeaderText = "Mã Bàn";
            msds.Columns[3].Width = 70;
            msds.Columns[4].HeaderText = "Tổng Tiền";
            msds.Columns[4].Width = 70;
            msds.Columns[5].HeaderText = "Trạng Thái";
            msds.Columns[5].Width = 100;

        }
        public void hienthi()
        {
            string sql = "SELECT     mahdb, ngayban,manv, maBan,tongtien,trangThai FROM tb_HDB";
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
                string sql = @"SELECT tb_HDB.mahdb, tb_HDB.ngayban, tb_HDB.manv, tb_HDB.maBan, tb_HDB.tongtien FROM dbo.tb_HDB INNER JOIN dbo.tb_CTHDB ON tb_HDB.mahdb = tb_CTHDB.mahdb WHERE dbo.tb_CTHDB.masp=N'" + txtthongtin.Text + "'";
                msds.DataSource = cn.taobang(sql);

                SqlConnection con = cn.getcon();
                con.Open();
            }
            if (op2.Checked)
            {
                string sql = @"SELECT     tb_HDB.mahdb, tb_HDB.ngayban, tb_HDB.manv, tb_HDB.maBan, tb_HDB.tongtien FROM tb_HDB INNER JOIN tb_CTHDB ON tb_HDB.mahdb = tb_CTHDB.mahdb WHERE tb_HDB.ngayban = '" + txtthongtin.Text + "'";
                msds.DataSource = cn.taobang(sql);

                SqlConnection con = cn.getcon();
                con.Open();
            }
            if (op3.Checked)
            {
                string sql = @"SELECT     tb_HDB.mahdb, tb_HDB.ngayban, tb_HDB.manv, tb_HDB.maBan, tb_HDB.tongtien FROM tb_HDB INNER JOIN tb_CTHDB ON tb_HDB.mahdb = tb_CTHDB.mahdb WHERE tb_HDB.manv = '" + txtthongtin.Text + "'";
                msds.DataSource = cn.taobang(sql);

                SqlConnection con = cn.getcon();
                con.Open();
            }
            if (op4.Checked)
            {
                string sql = @"SELECT  tb_HDB.mahdb, tb_HDB.ngayban, tb_HDB.manv, tb_HDB.maBan, tb_HDB.tongtien, tb_HDB.trangThai FROM dbo.tb_HDB WHERE trangThai = N'Hoàn Thành'";
                msds.DataSource = cn.taobang(sql);

                SqlConnection con = cn.getcon();
                con.Open();
            }
            if (op5.Checked)
            {
                string sql = @"SELECT  tb_HDB.mahdb, tb_HDB.ngayban, tb_HDB.manv, tb_HDB.maBan, tb_HDB.tongtien, tb_HDB.trangThai FROM dbo.tb_HDB WHERE trangThai = N'Chưa Hoàn Thành'";
                msds.DataSource = cn.taobang(sql);

                SqlConnection con = cn.getcon();
                con.Open();
            }
            if (op6.Checked)
            {
                string sql = @"SELECT  tb_HDB.mahdb, tb_HDB.ngayban, tb_HDB.manv, tb_HDB.maBan, tb_HDB.tongtien, tb_HDB.trangThai FROM dbo.tb_HDB WHERE trangThai = N'Hủy Đơn'";
                msds.DataSource = cn.taobang(sql);

                SqlConnection con = cn.getcon();
                con.Open();
            }
        }

        private void fr_TKHDB_Load(object sender, EventArgs e)
        {
            hienthi();
            khoitaoluoi();
        }
    }
}
