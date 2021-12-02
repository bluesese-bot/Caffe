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
namespace Caffe.Presentation
{
    public partial class fr_Info : Form
    {
        
        E_tb_Nhanvien thucthi = new E_tb_Nhanvien();
        E_tb_User thucthi1 = new E_tb_User();
        EC_tb_Nhanvien ck = new EC_tb_Nhanvien();
        EC_tb_User ck1 = new EC_tb_User();

        string tk = "", tenNV = "";
        bool doiINfo;
        public fr_Info()
        {
            InitializeComponent();
        }
        public fr_Info(string TK, string TENNV)
        {
            InitializeComponent();
            this.tk = TK;
            this.tenNV = TENNV;
        }

        void Locktext()
        {
            txtMANV.ReadOnly = true;
            txtTenNV.ReadOnly = true;
            txtQue.ReadOnly = true;
            txtSDT.ReadOnly = true;
            cbGioiTinh.Enabled = false;
            TimeDAY.Enabled = false;
            cbQUE.Enabled = false;
            txtDiaChi.ReadOnly = true;

            TxtTK.ReadOnly = true;
            txtMK.Enabled = false;
            txtMK.UseSystemPasswordChar = true;

            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }
        void unlockEditInfor ()
        {
            txtTenNV.ReadOnly = false;
            txtQue.ReadOnly = false;
            txtSDT.ReadOnly = false;
            cbGioiTinh.Enabled = true;
            TimeDAY.Enabled = true;
            cbQUE.Enabled = true;
            txtDiaChi.ReadOnly = false;

            txtMK.Enabled = true;

            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void fr_Info_Load(object sender, EventArgs e)
        {
            Locktext();
            thucthi.loadmaq(cbQUE);
            thucthi.loadInfor(txtMANV,txtTenNV,TimeDAY, cbGioiTinh,cbQUE, txtQue, txtSDT,txtDiaChi, tenNV);
            thucthi1.loadTKMK(TxtTK,txtMK,tk);
        }

        private void btnEDITinfo_Click(object sender, EventArgs e)
        {
            unlockEditInfor();
            txtMK.Enabled = false;
            txtMK.UseSystemPasswordChar = true;
            doiINfo = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (doiINfo==true) {
                ck.MANV = txtMANV.Text;
                ck.TENNV = txtTenNV.Text;
                ck.NGAYSINH = TimeDAY.Text;
                ck.MAQUE = cbQUE.Text;
                ck.DIACHI = txtDiaChi.Text;
                ck.SDT = txtSDT.Text;
                ck.GIOITINH = cbGioiTinh.Text;

                thucthi.suanv(ck);
                MessageBox.Show("Đã Sửa Thành Công Thành Công in", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ck1.USERNAME = TxtTK.Text;
                ck1.PASSWORD = txtMK.Text;

                thucthi1.suamk(ck1);
                MessageBox.Show("Đã Sửa Thành Công Thành Công mk", "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Locktext();
            thucthi.loadInfor(txtMANV, txtTenNV, TimeDAY, cbGioiTinh, cbQUE, txtQue, txtSDT, txtDiaChi, tenNV);
            thucthi1.loadTKMK(TxtTK, txtMK, tk);
        }

        private void cbQUE_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQue.Text = thucthi.loadtenq(txtQue.Text,cbQUE.Text);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Locktext();
            thucthi.loadInfor(txtMANV, txtTenNV, TimeDAY, cbGioiTinh, cbQUE, txtQue, txtSDT, txtDiaChi, tenNV);
            thucthi1.loadTKMK(TxtTK, txtMK, tk);
        }

        private void btnEditMK_Click(object sender, EventArgs e)
        {
            Locktext();
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            txtMK.Enabled = true;
            txtMK.UseSystemPasswordChar = false;
            doiINfo = false;
        }
    }
}
