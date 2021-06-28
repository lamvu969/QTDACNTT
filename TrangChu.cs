using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN.NET
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void btn_dangxuat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không !", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fDangNhap frm = new fDangNhap();
                frm.Show();
                this.Hide();
            }
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoanVien frm = new DoanVien();
            frm.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KyLuat frm = new KyLuat();
            frm.Show();
            this.Hide();
        }

        private void quảnLýĐoànViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoanVien frm = new DoanVien();
            frm.Show();
            this.Hide();
        }

        private void quảnLýKỷLuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KyLuat frm = new KyLuat();
            frm.Show();
            this.Hide();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không !", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fDangNhap frm = new fDangNhap();
                frm.Show();
                this.Hide();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoanPhi frm = new DoanPhi();
            frm.Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HinhThucKyLuat frm = new HinhThucKyLuat();
            frm.Show();
            this.Hide();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViPham frm = new ViPham();
            frm.Show();
            this.Hide();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NhanXet frm = new NhanXet();
            frm.Show();
            this.Hide();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void quảnLýĐoànPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoanPhi frm = new DoanPhi();
            frm.Show();
            this.Hide();
        }

        private void quảnLýHìnhThứcKỷLuậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HinhThucKyLuat frm = new HinhThucKyLuat();
            frm.Show();
            this.Hide();
        }

        private void quảnLýViPhạmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViPham frm = new ViPham();
            frm.Show();
            this.Hide();
        }

        private void quảnLýNhậnXétToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanXet frm = new NhanXet();
            frm.Show();
            this.Hide();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau frm = new DoiMatKhau();
            frm.Show();
            this.Hide();
        }
        public static string quyen;

        private void TrangChu_Load(object sender, EventArgs e)
        {
            if (quyen == "Admin")
            {
                
            }
            else if (quyen == "User")
            {
                đổiMậtKhẩuToolStripMenuItem.Enabled = false;
                link_doimatkhau.Enabled = false;
            }
        }

        private void bấmNgayĐêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            ThongTin frm = new ThongTin();
            frm.Show();
            this.Hide();
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TimKiemDV frm = new TimKiemDV();
            frm.Show();
            this.Hide();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            TimKiemDV frm = new TimKiemDV();
            frm.Show();
            this.Hide();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimKiemDV frm = new TimKiemDV();
            frm.Show();
            this.Hide();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTin frm = new ThongTin();
            frm.Show();
            this.Hide();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            GiaDinh frm = new GiaDinh();
            frm.Show();
            this.Hide();
        }

        private void quảnLýTìnhTrạngGiaĐìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TinhTrangGiaDinh frm = new TinhTrangGiaDinh();
            frm.Show();
            this.Hide();
        }

        private void link_doimatkhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoiMatKhau frm = new DoiMatKhau();
            frm.Show();
            this.Hide();
        }

        private void link_quanlydv_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoanVien frm = new DoanVien();
            frm.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            KyLuat frm = new KyLuat();
            frm.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DoanPhi frm = new DoanPhi();
            frm.Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HinhThucKyLuat frm = new HinhThucKyLuat();
            frm.Show();
            this.Hide();
        }

        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ViPham frm = new ViPham();
            frm.Show();
            this.Hide();
        }

        private void linkLabel6_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NhanXet frm = new NhanXet();
            frm.Show();
            this.Hide();
        }

        private void linkLabel5_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GiaDinh frm = new GiaDinh();
            frm.Show();
            this.Hide();
        }

        private void linkLabel7_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TinhTrangGiaDinh frm = new TinhTrangGiaDinh();
            frm.Show();
            this.Hide();
        }

        private void btn_dangxuat_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không !", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fDangNhap frm = new fDangNhap();
                frm.Show();
                this.Hide();
            }
        }
    }
}
