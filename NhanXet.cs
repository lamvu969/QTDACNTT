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
    public partial class NhanXet : Form
    {
        public NhanXet()
        {
            InitializeComponent();
        }
        private void getdata()
        {
            SqlCommand cmd = new SqlCommand("Select * from NhanXet ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            add.Fill(ds, "nx");
            dgv.DataSource = ds.Tables["nx"];
            SBT.conn.Close();
        }

        private void ClearText()
        {
            txtmanhanxet.Clear();
            txtmadv.Clear();
            txtud.Clear();
            txtkd.Clear();
            txtxeploai.Clear();
            txtkt.Clear();
            txtnamhoc.Clear();
        }
        private void quayLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu frm = new TrangChu();
            frm.Show();
            this.Hide();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtmanhanxet.Enabled = true;
            getdata();
            ClearText();
        }

        private void NhanXet_Load(object sender, EventArgs e)
        {
            txtmanhanxet.Enabled = true;
            getdata();
            ClearText();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from NhanXet where manx='" + txttimkiem.Text + "' or madv='" + txttimkiem.Text + "' or uudiem='" + txttimkiem.Text + "' or khuyetdiem='" + txttimkiem.Text + "' or xeploai='" + txttimkiem.Text + "' or namhoc='" + txttimkiem.Text + "' ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet tim = new DataSet();
            add.Fill(tim, "tmi");
            dgv.DataSource = tim.Tables["tmi"];
            SBT.conn.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select count (*) from NhanXet where manx= @manx", SBT.conn);
            SBT.conn.Open();
            cmd.Parameters.AddWithValue("@manx", txtmanhanxet.Text);
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
                SqlCommand cmd1 = new SqlCommand("INSERT INTO NhanXet (manx, madv, uudiem, khuyetdiem, xeploai, khenthuong, namhoc) Values(@manx, @madv, @uudiem, @khuyetdiem, @xeploai, @khenthuong, @namhoc) ", SBT.conn);
                SBT.conn.Open();
                cmd1.Parameters.AddWithValue("@manx", txtmanhanxet.Text);
                cmd1.Parameters.AddWithValue("@madv", txtmadv.Text);
                cmd1.Parameters.AddWithValue("@uudiem", txtud.Text);
                cmd1.Parameters.AddWithValue("@khuyetdiem", txtkd.Text);
                cmd1.Parameters.AddWithValue("@xeploai", txtxeploai.Text);
                cmd1.Parameters.AddWithValue("@khenthuong", txtkt.Text);
                cmd1.Parameters.AddWithValue("@namhoc", txtnamhoc.Text);

                cmd1.ExecuteNonQuery();
                SBT.conn.Close();
                MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                getdata();
                ClearText();
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("UPDATE NhanXet SET manx=@manx, madv=@madv, uudiem=@uudiem, khuyetdiem=@khuyetdiem, xeploai=@xeploai, khenthuong=@khenthuong, namhoc=@namhoc WHERE manx=@manx", SBT.conn);
            SBT.conn.Open();
            cmd1.Parameters.AddWithValue("@manx", txtmanhanxet.Text);
            cmd1.Parameters.AddWithValue("@madv", txtmadv.Text);
            cmd1.Parameters.AddWithValue("@uudiem", txtud.Text);
            cmd1.Parameters.AddWithValue("@khuyetdiem", txtkd.Text);
            cmd1.Parameters.AddWithValue("@xeploai", txtxeploai.Text);
            cmd1.Parameters.AddWithValue("@khenthuong", txtkt.Text);
            cmd1.Parameters.AddWithValue("@namhoc", txtnamhoc.Text);

            cmd1.ExecuteNonQuery();
            SBT.conn.Close();
            MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            getdata();
            ClearText();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM NhanXet WHERE manx=@manx", SBT.conn);
            SBT.conn.Open();
            cmd.Parameters.AddWithValue("@manx", txtmanhanxet.Text);
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
                txtmanhanxet.Text = dgv.Rows[id].Cells["manx"].Value.ToString();
                txtmadv.Text = dgv.Rows[id].Cells["madv"].Value.ToString();
                txtud.Text = dgv.Rows[id].Cells["uudiem"].Value.ToString();
                txtkd.Text = dgv.Rows[id].Cells["khuyetdiem"].Value.ToString();
                txtxeploai.Text = dgv.Rows[id].Cells["xeploai"].Value.ToString();
                txtkt.Text = dgv.Rows[id].Cells["khenthuong"].Value.ToString();
                txtnamhoc.Text = dgv.Rows[id].Cells["namhoc"].Value.ToString();
            }
            txtmanhanxet.Enabled = false;
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
