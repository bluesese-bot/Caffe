using Caffe.DataAccess;
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
using System.Data.SqlClient;
using Caffe.Properties;
using System.Globalization;

namespace Caffe.Presentation
{
    public partial class fr_DatBan : Form
    {
        SQL_tb_DatBan sqldb = new SQL_tb_DatBan();
        SQL_tb_CTHDB sqlcthdb = new SQL_tb_CTHDB();
        SQL_tb_HDB sqlhdb = new SQL_tb_HDB();
        E_tb_Menu Menu1 = new E_tb_Menu();
        ConnectDB sqlDB = new ConnectDB();
        EC_tb_HDB ck = new EC_tb_HDB();
        EC_tb_CTHDB ck1 = new EC_tb_CTHDB();
        E_tb_DatBan thucthi = new E_tb_DatBan();
        private string nameUser;
        public fr_DatBan()
        {
            InitializeComponent();
            loadTable();
            thucthi.loadTenLoai(comboBox1);
            sqlDB.LoadLenCombobox(comboBox2, "select tensp from tb_Sanpham", 0);

        }

        void loadTable()
        {
            flowLayoutPanel1.Controls.Clear();
            List<EC_tb_DatBan> tablist = sqldb.Loadtablelist();
            foreach (EC_tb_DatBan item in tablist)
            {
                Button btn = new Button() { Width = 135, Height = 95 };
                btn.Text = item.Name;
                btn.Click += btn_Click;
                btn.Tag = item;
                if (item.TrangThai == "Trống")
                {
                    btn.Image = Image.FromFile(@"E:\Quan_Ly_Caffe_C\Caffe\Caffe\Resources\NoBody.png");
                    btn.ImageAlign = ContentAlignment.MiddleCenter;
                    btn.TextAlign = ContentAlignment.BottomCenter;
                    btn.FlatStyle = FlatStyle.Flat;
                }
                else
                {
                    btn.Image = Image.FromFile(@"E:\Quan_Ly_Caffe_C\Caffe\Caffe\Resources\somebody.png");
                    btn.ImageAlign = ContentAlignment.MiddleCenter;
                    btn.TextAlign = ContentAlignment.BottomCenter;
                    btn.FlatStyle = FlatStyle.Flat;
                }
                flowLayoutPanel1.Controls.Add(btn);
            }
        }
        float Tong = 0;

        public string NameUser { get => nameUser; set => nameUser = value; }

        void showBill(string id)
        {
            listView1.Items.Clear();
            Tong = 0;
            List<EC_tb_Menu> listBillinfr = Menu1.GetTb_Menus(id);
            foreach (EC_tb_Menu item in listBillinfr)
            {
                ListViewItem list = new ListViewItem(item.TenMon.ToString());
                list.SubItems.Add(item.Soluong1.ToString());
                list.SubItems.Add(item.Gia.ToString());
                list.SubItems.Add(item.Tong.ToString());
                Tong += item.Tong;
                ListView listView = new ListView();
                listView1.Items.Add(list);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            label2.Text = Tong.ToString("c",culture);
            
        }
        public void btn_Click(object sender, EventArgs e)
        {
            string tabelID = ((sender as Button).Tag as EC_tb_DatBan).ID;
            listView1.Tag = (sender as Button).Tag;
            showBill(tabelID);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            thucthi.loadTensp(comboBox2, comboBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                EC_tb_DatBan table = listView1.Tag as EC_tb_DatBan;
                int idbill = sqlhdb.loadHoaDonChuaHoanThanh(table.ID);
                if (idbill != -1)
                {
                    if (MessageBox.Show("Bạn có muốn thanh toán cho bàn " + table.Name, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        string uptt = "update tb_HDB set tongtien=(SELECT sum(thanhtien) FROM tb_CTHDB where tb_CTHDB.mahdb=tb_HDB.mahdb) where tb_HDB.mahdb=N'" + idbill + "'";
                        sqlDB.ExcuteNonQuery(uptt);
                        sqlhdb.checkOut(idbill);
                        showBill(table.ID);
                        loadTable();
                    }
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Bạn Chưa Chọn Bàn Để Thanh Toán Hoặc Bàn Đang Trống", "Chú Ý", MessageBoxButtons.OK);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text !="")
            {
                if (comboBox2.Text !="")
                {

                        EC_tb_DatBan table = listView1.Tag as EC_tb_DatBan;
                            string idFood = sqlDB.returnscalarnumberString("SELECT masp FROM dbo.tb_Sanpham WHERE tensp = N'" + comboBox2.Text + "'");
                            int idBill = sqlhdb.loadHoaDonChuaHoanThanh(table.ID);
                            string idNV = sqlDB.returnscalarnumberString("SELECT manv FROM dbo.tb_Nhanvien WHERE tennv=N'" + nameUser + "'");
                            string GiaBan = sqlDB.returnscalarnumberString("SELECT giaban FROM dbo.tb_Sanpham WHERE masp = '" + idFood + "'");
                            string uptt = "";
                            string upsl = "";
                            string setBan = "";
                        if (idBill == -1)
                            {
                                try
                                {
                                    //Tạo Bill Mới
                                    int idbillnew = int.Parse(sqlDB.returnscalarnumberString("select max(mahdb) from tb_HDB")) + 1;
                                    ck.MABAN = table.ID;
                                    ck.MAHDB = idbillnew.ToString();
                                    ck.MANV = idNV;
                                    ck.NGAYBAN = txtngay.Text;
                                    ck.TONGTIEN = Tong.ToString();
                                    sqlhdb.themmoiHDB(ck);
                                    //Thêm Món Ăn Vào Bill Vừa Tạo
                                    ck1.MAHDB = idbillnew.ToString();
                                    ck1.MASP = idFood;
                                    ck1.SOLUONG = (numericUpDown1.Value).ToString();
                                    ck1.TENSP = comboBox2.Text;
                                    ck1.THANHTIEN = (int.Parse(GiaBan) * int.Parse(numericUpDown1.Value.ToString())).ToString();
                                    sqlcthdb.themmoicthdb(ck1);
                                    setBan = "UPDATE dbo.tb_slotBan SET dbo.tb_slotBan.trangThai = N'Có Người' FROM dbo.tb_slotBan INNER JOIN dbo.tb_HDB ON (tb_slotBan.maBan = tb_HDB.maBan) WHERE tb_slotBan.maBan='" + table.ID + "'";
                                    uptt = "update tb_HDB set tongtien=(SELECT sum(thanhtien) FROM tb_CTHDB where tb_CTHDB.mahdb=tb_HDB.mahdb) where tb_HDB.mahdb=N'" + idbillnew + "'";
                                    upsl = "UPDATE tb_Sanpham SET soluong =soluong - '" + (numericUpDown1.Value).ToString() + "' where masp='" + idFood + "'";
                                    sqlDB.ExcuteNonQuery(setBan);
                                    sqlDB.ExcuteNonQuery(uptt);
                                    sqlDB.ExcuteNonQuery(upsl);
                            }
                                catch (Exception ex)
                                {

                                     MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                try
                                {
                                    //Thêm Món Ăn Vào Bill Đã Có Sẵn
                                    ck1.MAHDB = idBill.ToString();
                                    ck1.MASP = idFood;
                                    ck1.SOLUONG = (numericUpDown1.Value).ToString();
                                    ck1.TENSP = comboBox2.Text;
                                    ck1.THANHTIEN = (int.Parse(GiaBan) * int.Parse(numericUpDown1.Value.ToString())).ToString();
                                    sqlcthdb.themmoicthdb(ck1);
                                    setBan = "UPDATE dbo.tb_slotBan SET dbo.tb_slotBan.trangThai = N'Có Người' FROM dbo.tb_slotBan INNER JOIN dbo.tb_HDB ON (tb_slotBan.maBan = tb_HDB.maBan) WHERE tb_slotBan.maBan='" + table.ID + "'";
                                    uptt = "update tb_HDB set tongtien=(SELECT sum(thanhtien) FROM tb_CTHDB where tb_CTHDB.mahdb=tb_HDB.mahdb) where tb_HDB.mahdb=N'" + idBill + "'";
                                    upsl = "UPDATE tb_Sanpham SET soluong =soluong - '" + (numericUpDown1.Value).ToString() + "' where masp='" + idFood + "'";
                                    sqlDB.ExcuteNonQuery(setBan);
                                    sqlDB.ExcuteNonQuery(uptt);
                                    sqlDB.ExcuteNonQuery(upsl);
                            }
                                catch (Exception ex)
                                {

                                    MessageBox.Show(ex.ToString(), "Chú Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            showBill(table.ID);
                            loadTable();
             
                }
                else
                {
                    MessageBox.Show("Tên Món Ăn Không Được Bỏ Trống!","Chú Ý",MessageBoxButtons.OK);
                    comboBox2.Focus();
                }
            }
            else
            {
                MessageBox.Show("Loại Thức Ăn Không Được Bỏ Trống!","Chú Ý",MessageBoxButtons.OK);
                comboBox1.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                EC_tb_DatBan table = listView1.Tag as EC_tb_DatBan;
                int idbill = sqlhdb.loadHoaDonChuaHoanThanh(table.ID);
                if (idbill != -1)
                {
                    if (MessageBox.Show("Bạn có muốn hủy đơn cho bàn " + table.Name, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {
                        string uptt = "update tb_HDB set tongtien=(SELECT sum(thanhtien) FROM tb_CTHDB where tb_CTHDB.mahdb=tb_HDB.mahdb) where tb_HDB.mahdb=N'" + idbill + "'";
                        sqlDB.ExcuteNonQuery(uptt);
                        sqlhdb.checkOUt1(idbill);
                        showBill(table.ID);
                        loadTable();
                    }
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Bạn Chưa Chọn Bàn Muốn Hủy Hoặc Bàn Còn Đang Trống!", "Chú Ý", MessageBoxButtons.OK);
            }
        }
    }
}
