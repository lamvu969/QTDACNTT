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
    public partial class ViPham : Form
    {
        public ViPham()
        {
            InitializeComponent();
        }
        private void getdata()
        {
            SqlCommand cmd = new SqlCommand("Select * from ViPham ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            add.Fill(ds, "dv");
            dgv.DataSource = ds.Tables["dv"];
            SBT.conn.Close();
        }

        private void ClearText()
        {
            txtsbb.Clear();
            txtmadv.Clear();
            txtmakl.Clear();
            txtngayvipham.Clear();
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
            txtsbb.Enabled = true;
            getdata();
            ClearText();
        }

        private void ViPham_Load(object sender, EventArgs e)
        {
            txtsbb.Enabled = true;
            getdata();
            ClearText();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from ViPham where sobienban='" + txttimkiem.Text + "' or madv='" + txttimkiem.Text + "' or makl='" + txttimkiem.Text + "' or ngayvipham='" + txttimkiem.Text + "' or namhoc='" + txttimkiem.Text + "' ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet tim = new DataSet();
            add.Fill(tim, "tmi");
            dgv.DataSource = tim.Tables["tmi"];
            SBT.conn.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select count (*) from ViPham where sobienban= @sobienban", SBT.conn);
            SBT.conn.Open();
            cmd.Parameters.AddWithValue("@sobienban", txtsbb.Text);
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
                SqlCommand cmd1 = new SqlCommand("INSERT INTO ViPham (sobienban, madv, makl, ngayvipham, namhoc) Values(@sobienban, @madv, @makl, @ngayvipham, @namhoc) ", SBT.conn);
                SBT.conn.Open();
                cmd1.Parameters.AddWithValue("@sobienban", txtsbb.Text);
                cmd1.Parameters.AddWithValue("@madv", txtmadv.Text);
                cmd1.Parameters.AddWithValue("@makl", txtmakl.Text);
                cmd1.Parameters.AddWithValue("@ngayvipham", txtngayvipham.Text);
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
            SqlCommand cmd1 = new SqlCommand("UPDATE ViPham SET sobienban=@sobienban, madv=@madv, makl=@makl, ngayvipham=@ngayvipham, namhoc=@namhoc WHERE sobienban=@sobienban", SBT.conn);
            SBT.conn.Open();
            cmd1.Parameters.AddWithValue("@sobienban", txtsbb.Text);
            cmd1.Parameters.AddWithValue("@madv", txtmadv.Text);
            cmd1.Parameters.AddWithValue("@makl", txtmakl.Text);
            cmd1.Parameters.AddWithValue("@ngayvipham", txtngayvipham.Text);
            cmd1.Parameters.AddWithValue("@namhoc", txtnamhoc.Text);

            cmd1.ExecuteNonQuery();
            SBT.conn.Close();
            MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            getdata();
            ClearText();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM ViPham WHERE sobienban=@sobienban", SBT.conn);
            SBT.conn.Open();
            cmd.Parameters.AddWithValue("@sobienban", txtsbb.Text);
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
                txtsbb.Text = dgv.Rows[id].Cells["sobienban"].Value.ToString();
                txtmadv.Text = dgv.Rows[id].Cells["madv"].Value.ToString();
                txtmakl.Text = dgv.Rows[id].Cells["makl"].Value.ToString();
                txtngayvipham.Text = dgv.Rows[id].Cells["ngayvipham"].Value.ToString();
                txtnamhoc.Text = dgv.Rows[id].Cells["namhoc"].Value.ToString();
            }
            txtsbb.Enabled = false;
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
