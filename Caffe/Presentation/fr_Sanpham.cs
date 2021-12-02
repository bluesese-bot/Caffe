using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Caffe.Business.Component;
using Caffe.Business.EntitiesClass;
using Caffe.DataAccess;
using System.IO;
using System.Data.SqlClient;


namespace Caffe.Presentation
{
    public partial class fr_Sanpham : Form
    {
        public fr_Sanpham()
        {
            InitializeComponent();
        }
        E_tb_Sanpham thucthi = new E_tb_Sanpham();
        ConnectDB cn = new ConnectDB();
        EC_tb_Sanpham ck = new EC_tb_Sanpham();
        bool themmoi;
        int dong = 0;

        public void setnull()
        {
            txtma.Text = "";
            txtten.Text = "";
            txtdgb.Text = "0";
            txtdgn.Text = "0";
            txtsl.Text = "0";
            cbloai.SelectedIndex=-1;
            
        }
        public void locktext()
        {
            txtma.Enabled = false;
            txtten.Enabled = false;
            cbloai.Enabled = false;
            txtdgb.Enabled = false;
            txtsl.Enabled = false;

            btmoi.Enabled = true;
            btluu.Enabled = false;
            btsua.Enabled = true;
            btxoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtma.Enabled = true;
            txtten.Enabled = true;
            cbloai.Enabled = true;
            txtdgb.Enabled = true;
            txtsl.Enabled = true;

            btmoi.Enabled = false;
            btluu.Enabled = true;
            btsua.Enabled = false;
            btxoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
            //RepositoryItemPictureEdit image = msds.RepositoryItems.Add("PictureEdit") as RepositoryItemPictureEdit;
            msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].HeaderText = "Mã Sản Phẩm";
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 80;

            msds.Columns[1].HeaderText = "Tên Sản Phẩm";
            msds.Columns[1].Width = 150;

            msds.Columns[2].HeaderText = "Mã Loại";
            msds.Columns[2].Width = 50;

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
        private void btmoi_Click(object sender, EventArgs e)
        {
            themmoi = true;
            un_locktext();
            setnull();
            txtma.Enabled = true;
            txtma.Focus();
        }
        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtma.Text != "")
            {
                if (cbloai.Text != "")
                {
                        if (themmoi == true)
                        {
                            try
                            {
                                ck.MASP = txtma.Text;
                                ck.TENSP = txtten.Text;
                                ck.MALOAI = cbloai.Text;
                                ck.GIABAN = txtdgb.Text;
                                ck.GIANHAP = txtdgn.Text;
                                ck.SOLUONG = txtsl.Text;

                                thucthi.themoi(ck);
                                locktext();
                                hienthi();
                                MessageBox.Show("Đã Lưu Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                            try
                            {
                                ck.MASP = txtma.Text;
                                ck.TENSP = txtten.Text;
                                ck.MALOAI = cbloai.Text;
                                ck.GIABAN = txtdgb.Text;
                                ck.GIANHAP = txtdgn.Text;
                                ck.SOLUONG = txtsl.Text;

                                thucthi.sua(ck);
                                MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        txtma.Enabled = true;
                        locktext();
                        hienthi();
               
                }
                else
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    cbloai.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtma.Focus();
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txtma.Enabled = false;
            txtten.Focus();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.MASP = txtma.Text;

                    thucthi.xoa(ck);
                    MessageBox.Show("Đã Xóa Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    hienthi();
                    setnull();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        }
        private void fr_Sanpham_Load(object sender, EventArgs e)
        {
            thucthi.loadmal(cbloai);
            locktext();
            hienthi();
            khoitaoluoi();
        }

        private void msds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txtma.Text = msds.Rows[dong].Cells[0].Value.ToString();
            txtten.Text = msds.Rows[dong].Cells[1].Value.ToString();
            cbloai.Text = msds.Rows[dong].Cells[2].Value.ToString();
            txtdgn.Text = msds.Rows[dong].Cells[3].Value.ToString();
            txtdgb.Text = msds.Rows[dong].Cells[4].Value.ToString();
            txtsl.Text = msds.Rows[dong].Cells[5].Value.ToString();
            locktext();
        }
       

        private void cbloai_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl.Text = thucthi.loadtenl(lbl.Text, cbloai.Text);
            if(cbloai.SelectedIndex == -1)
            {
                lbl.Text = "---";
            }
        }

    }
}
