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
    public partial class TinhTrangGiaDinh : Form
    {
        public TinhTrangGiaDinh()
        {
            InitializeComponent();
        }

        private void quayLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu frm = new TrangChu();
            frm.Show();
            this.Hide();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        private void getdata()
        {
            SqlCommand cmd = new SqlCommand("Select * from TinhTrangGiaDinh ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            add.Fill(ds, "tt");
            dgv.DataSource = ds.Tables["tt"];
            SBT.conn.Close();
        }

        private void ClearText()
        {
            txtMaTT.Clear();
            txtMaGD.Clear();
            txtMaDV.Clear();
            txthientai.Clear();
            txtsocon.Clear();
            txttimkiem.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtMaTT.Enabled = true;
            getdata();
            ClearText();
        }

        private void TinhTrangGiaDinh_Load(object sender, EventArgs e)
        {
            txtMaTT.Enabled = true;
            getdata();
            ClearText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from TinhTrangGiaDinh where matinhtrang='" + txttimkiem.Text + "' or magd='" + txttimkiem.Text + "' or madv='" + txttimkiem.Text + "' or hientai='" + txttimkiem.Text + "' or socon='" + txttimkiem.Text + "' ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet tim = new DataSet();
            add.Fill(tim, "tmi");
            dgv.DataSource = tim.Tables["tmi"];
            SBT.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select count (*) from TinhTrangGiaDinh where matinhtrang= @matinhtrang", SBT.conn);
            SBT.conn.Open();
            cmd.Parameters.AddWithValue("@matinhtrang", txtMaTT.Text);
            int Check = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            SBT.conn.Close();
            if (Check == 1)
            {
                MessageBox.Show("Đã tồn tại !", "thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearText();
            }
            if (Check == -1)
            {
                MessageBox.Show("Không được để trống các trường !", "thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearText();
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("INSERT INTO TinhTrangGiaDinh (matinhtrang, magd, madv, hientai, socon) Values(@matinhtrang, @magd, @madv, @hientai, @socon) ", SBT.conn);
                SBT.conn.Open();
                cmd1.Parameters.AddWithValue("@matinhtrang", txtMaTT.Text);
                cmd1.Parameters.AddWithValue("@magd", txtMaGD.Text);
                cmd1.Parameters.AddWithValue("@madv", txtMaDV.Text);
                cmd1.Parameters.AddWithValue("@hientai", txthientai.Text);
                cmd1.Parameters.AddWithValue("@socon", txtsocon.Text);

                cmd1.ExecuteNonQuery();
                SBT.conn.Close();
                MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                getdata();
                ClearText();
            }
        }

        private void btnxuat_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("UPDATE TinhTrangGiaDinh SET matinhtrang=@matinhtrang, magd=@magd, madv=@madv, hientai=@hientai, socon=@socon WHERE matinhtrang=@matinhtrang", SBT.conn);
            SBT.conn.Open();
            cmd1.Parameters.AddWithValue("@matinhtrang", txtMaTT.Text);
            cmd1.Parameters.AddWithValue("@magd", txtMaGD.Text);
            cmd1.Parameters.AddWithValue("@madv", txtMaDV.Text);
            cmd1.Parameters.AddWithValue("@hientai", txthientai.Text);
            cmd1.Parameters.AddWithValue("@socon", txtsocon.Text);

            cmd1.ExecuteNonQuery();
            SBT.conn.Close();
            MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            getdata();
            ClearText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM TinhTrangGiaDinh WHERE matinhtrang=@matinhtrang", SBT.conn);
            SBT.conn.Open();
            cmd.Parameters.AddWithValue("@matinhtrang", txtMaTT.Text);
            cmd.ExecuteNonQuery();
            SBT.conn.Close();
            MessageBox.Show("Xóa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            getdata();
            ClearText();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = e.RowIndex;
            if (id >= 0)
            {
                txtMaTT.Text = dgv.Rows[id].Cells["matinhtrang"].Value.ToString();
                txtMaGD.Text = dgv.Rows[id].Cells["magd"].Value.ToString();
                txtMaDV.Text = dgv.Rows[id].Cells["madv"].Value.ToString();
                txthientai.Text = dgv.Rows[id].Cells["hientai"].Value.ToString();
                txtsocon.Text = dgv.Rows[id].Cells["socon"].Value.ToString();
            }
            txtMaTT.Enabled = false;
        }
    }
}
