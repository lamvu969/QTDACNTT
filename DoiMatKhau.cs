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
    public partial class DoiMatKhau : Form
    {
        private SBt2 cc = new SBt2();
        SqlConnection conn = null;
        public DoiMatKhau()
        {
            InitializeComponent();
        }

        private void quayLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu frm = new TrangChu();
            frm.Show();
            this.Hide();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
        }


        private void btndoimk_Click(object sender, EventArgs e)
        {
            string select2 = "Select * From NguoiDung where taikhoan='" + txttk.Text + "' and matkhau='" + txtmkcu.Text + "' ";
            SqlCommand cmd2 = new SqlCommand(select2, conn);
            SqlDataReader reader2;
            reader2 = cmd2.ExecuteReader();




            errorProvider1.Clear();
            if (txttk.Text == "")
                errorProvider1.SetError(txttk, "Chưa nhập tên tài khoản !");
            else if (txtmkcu.Text == "")
            {
                errorProvider1.SetError(txtmkcu, "!");
            }
            else if (txtmkmoi.Text == "")
            {
                errorProvider1.SetError(txtmkmoi, "!");
                //txtmkmoi.Focus();
            }
            else if (txtgolai.Text == "")
            {
                errorProvider1.SetError(txtgolai, "!");
                //txtgolai.Focus();
            }
            
            else if (txtgolai.Text != txtmkmoi.Text)
                MessageBox.Show("Bạn nhập lại password không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (reader2.Read())
            {
                cmd2.Dispose();
                reader2.Dispose();
                // Thực hiện truy vấn
                string update = "Update NguoiDung Set matkhau='" + txtmkmoi.Text + "' where taikhoan='" + txttk.Text + "'";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đổi mật khẩu thành công", "Thông báo!");

                // Trả tài nguyên
                cmd.Dispose();
                ClearText();
            }

            else
            {
                MessageBox.Show("Tên tài khoản không tồn tại hoặc mật khẩu sai! ", "Thông báo !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txttk.Focus();

            }
            cmd2.Dispose();
            reader2.Dispose();
        }
        private void ClearText()
        {
            txttk.Clear();
            txtmkcu.Clear();
            txtmkmoi.Clear();
            txtgolai.Clear();
        }
            private void btnnhaplai_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            conn = cc.Connected();
        }
    }
}
