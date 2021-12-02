using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caffe.Presentation
{
    public partial class Fr_Main : Form
    {
        string username = "", pass = "", loaitk = "", nameuser = "";
        public Fr_Main()
        {
            InitializeComponent();
            
        }
        public Fr_Main(string TenDanghap,string MatKhau,string LoaiTaiKhoan,string Tenuser)
        {
            InitializeComponent();
            this.username = TenDanghap;
            this.pass = MatKhau;
            this.loaitk = LoaiTaiKhoan;
            this.nameuser = Tenuser;
        }
        private Form kiemtratontai(Type formtype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formtype)
                    return f;
            }
            return null;
        }

        private void quêQuánToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = kiemtratontai(typeof(fr_Que));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_Que fr = new fr_Que();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_Nhanvien));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_Nhanvien fr = new fr_Nhanvien();
                fr.MdiParent = this;
                fr.Show();
            }
        }



        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_NCC));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_NCC fr = new fr_NCC();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void loạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_Loai));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_Loai fr = new fr_Loai();
                fr.MdiParent = this;
                fr.Show();
            }
        }
        private void chiTiếtCafeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_Sanpham));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_Sanpham fr = new fr_Sanpham();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void hóaĐơnNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_HDN));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_HDN fr = new fr_HDN();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void hóaĐơnXuấtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_HDB));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_HDB fr = new fr_HDB();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_TKHDB));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_TKHDB fr = new fr_TKHDB();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void điệnThoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_TK_SP));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_TK_SP fr = new fr_TK_SP();
                fr.MdiParent = this;
                fr.Show();
            }
        }
        public void ThreadProc()
        {
            fr_DangNhap fr = new fr_DangNhap();
            Application.Run(fr);
        }
        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_DangNhap));
            if (frm != null)
                frm.Activate();
            else
            {
                System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(ThreadProc));
                t.Start();
                this.Close();
            }
        }
        private void quýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_BC_Quy_HDB));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_BC_Quy_HDB fr = new fr_BC_Quy_HDB();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void Fr_Main_Load(object sender, EventArgs e)
        {
             if (loaitk == "User")
            {
                hóaĐơnToolStripMenuItem.Visible = false;
                nhậpToolStripMenuItem.Visible = false;
                thốngKêToolStripMenuItem.Visible = false;
                quảnLýAccountToolStripMenuItem.Visible = false;
            }
            liênHệToolStripMenuItem_Click(sender, e);
            InfoUserToolStripMenuItem.Text = nameuser;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_Info));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_Info fr = new fr_Info(username,nameuser);
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_LienHe));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_LienHe fr = new fr_LienHe();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void qlBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_Ban));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_Ban fr = new fr_Ban();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void InfoUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_Info));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_Info fr = new fr_Info(username, nameuser);
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void quýHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_BC_Quy_HDN));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_BC_Quy_HDN fr = new fr_BC_Quy_HDN();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void quảnLýAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_TaiKhoan));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_TaiKhoan fr = new fr_TaiKhoan();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void quýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_BC_Quy_SP));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_BC_Quy_SP fr = new fr_BC_Quy_SP();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        private void đặtBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = kiemtratontai(typeof(fr_DatBan));
            if (frm != null)
                frm.Activate();
            else
            {
                fr_DatBan fr = new fr_DatBan();
                fr.NameUser = nameuser;
                fr.MdiParent = this;
                fr.Show();
            }
        }
    }
}
