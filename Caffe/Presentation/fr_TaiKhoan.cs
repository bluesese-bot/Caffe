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
using Caffe.Business.Component;
using Caffe.Business.EntitiesClass;
using System.Data.SqlClient;

namespace Caffe.Presentation
{
    public partial class fr_TaiKhoan : Form
    {
        public fr_TaiKhoan()
        {
            InitializeComponent();
        }
        ConnectDB cn = new ConnectDB();
        E_tb_User thucthi = new E_tb_User();
        EC_tb_User ck = new EC_tb_User();
        bool themmoi;
        int dong = 0;
        public void setnull()
        {
            txtTk.Text = "";
            txtMk.Text = "";
            cbLoaiTk.Text = "";
            cbTenNhanVien.Text = "";
        }
        public void locktext()
        {
            txtTk.Enabled = false;
            txtMk.Enabled = false;
            cbLoaiTk.Enabled = false;
            cbTenNhanVien.Enabled = false;

            btmoi.Enabled = true;
            btluu.Enabled = false;
            btsua.Enabled = true;
            btxoa.Enabled = true;
        }
        public void un_locktext()
        {
            txtTk.Enabled = true;
            txtMk.Enabled = true;
            cbLoaiTk.Enabled = true;
            cbTenNhanVien.Enabled = true;

            btmoi.Enabled = false;
            btluu.Enabled = true;
            btsua.Enabled = false;
            btxoa.Enabled = false;
        }
        public void khoitaoluoi()
        {
            msds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].HeaderText = "Tên Đăng Nhập";
            msds.Columns[0].Frozen = true;
            msds.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            msds.Columns[0].Width = 100;
            msds.Columns[1].HeaderText = "Mật Khẩu";
            msds.Columns[1].Width = 150;
            msds.Columns[2].HeaderText = "Loại Tài Khoản";
            msds.Columns[2].Width = 100;
            msds.Columns[3].HeaderText = "Tên Chủ Khoản";
            msds.Columns[3].Width = 100;
        }
        public void hienthi()
        {
            string sql = "SELECT * FROM tb_User";
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
            txtTk.Enabled = true;
            txtTk.Focus();
        }
        private void btluu_Click(object sender, EventArgs e)
        {
            if (txtTk.Text != "")
            {
                if (txtMk.Text != "")
                {
                   if(cbLoaiTk.Text != "")
                    {
                        if(cbTenNhanVien.Text != "")
                        {
                            if (themmoi == true)
                            {
                                try
                                {
                                    ck.USERNAME = txtTk.Text;
                                    ck.PASSWORD = txtMk.Text;
                                    ck.Loaitk = cbLoaiTk.Text;
                                    ck.Tenuser = cbTenNhanVien.Text;

                                    thucthi.themoinv(ck);
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
                                    ck.USERNAME = txtTk.Text;
                                    ck.PASSWORD = txtMk.Text;
                                    ck.Loaitk = cbLoaiTk.Text;
                                    ck.Tenuser = cbTenNhanVien.Text;

                                    thucthi.suanv(ck);
                                    MessageBox.Show("Đã Sửa Thành Công Thành Công", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            txtTk.Enabled = true;
                            locktext();
                            hienthi();
                        }
                        else
                        {
                            MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                            cbTenNhanVien.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                        cbLoaiTk.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                    txtMk.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mã Không được để trống", "Chú Ý", MessageBoxButtons.OK);
                txtTk.Focus();
            }
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            themmoi = false;
            un_locktext();
            txtTk.Enabled = false;
            txtMk.Enabled = true;
            txtMk.Focus();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa dữ liệu này?", "Chú Ý", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    ck.USERNAME = txtTk.Text;
                    thucthi.xoanv(ck);
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
        private void fr_TaiKhoan_Load(object sender, EventArgs e)
        {
            cn.LoadLenCombobox(cbTenNhanVien, "SELECT tennv FROM dbo.tb_Nhanvien", 0);
            locktext();
            hienthi();
            khoitaoluoi();
        }

        private void msds_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            txtTk.Text = msds.Rows[dong].Cells[0].Value.ToString();
            txtMk.Text = msds.Rows[dong].Cells[1].Value.ToString();
            cbLoaiTk.Text = msds.Rows[dong].Cells[2].Value.ToString();
            cbTenNhanVien.Text = msds.Rows[dong].Cells[3].Value.ToString();
            locktext();
        }

    }
}