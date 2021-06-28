using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DOAN.NET
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void txt_hienthi_CheckedChanged_1(object sender, EventArgs e)
        {
            if (txt_hienthi.Checked)
            {
                txt_mk.UseSystemPasswordChar = false;
            }
            else
            {
                txt_mk.UseSystemPasswordChar = true;
            }
        }

        private void fDangNhap_Load_1(object sender, EventArgs e)
        {
            txt_mk.UseSystemPasswordChar = true;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-EEAM3B1\SQLEXPRESS;Initial Catalog=QLDV_DoAn.NET;Integrated Security=True");
            try
            {
                conn.Open();
                string tk = txt_tk.Text;
                string mk = txt_mk.Text;
                string sql = "select *from NguoiDung where taikhoan ='" + tk + "' and matkhau = '" + mk + "' and quyen='Admin' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();

                if (dta.Read())
                {
                    MessageBox.Show("Đăng nhập thành công (Quyền Admin)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TrangChu.quyen = "Admin";
                    TrangChu frm = new TrangChu();

                    frm.Show();
                    string k = txt_tk.Text;
                    frm.Text = "Chào Mừng " + txt_tk.Text + " Đã Quay Trở Lại Với Chương Trình Quản Lý Đoàn Viên Trường Đại Học Điện Lực";
                    this.Hide();
                    cmd.Dispose();
                    dta.Close();
                    dta.Dispose();
                }
                else
                {
                    cmd.Dispose();
                    dta.Close();
                    dta.Dispose();
                    string sql1 = "select *from NguoiDung where taikhoan ='" + tk + "' and matkhau = '" + mk + "' and quyen='user' ";
                    SqlCommand cmd1 = new SqlCommand(sql1, conn);
                    SqlDataReader dta1;
                    dta1 = cmd1.ExecuteReader();

                    if (dta1.Read())
                    {
                        MessageBox.Show("Đăng nhập thành công (Quyền user)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TrangChu.quyen = "User";
                        TrangChu frm = new TrangChu();

                        frm.Show();
                        string k = txt_tk.Text;
                        frm.Text = "Chào Mừng " + txt_tk.Text + " Đã Quay Trở Lại Với Chương Trình Quản Lý Đoàn Viên Trường Đại Học Điện Lực";
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    cmd1.Dispose();
                    dta1.Close();
                    dta1.Dispose();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi kết nối!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}