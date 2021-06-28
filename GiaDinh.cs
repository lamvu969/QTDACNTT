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
    public partial class GiaDinh : Form
    {
        public GiaDinh()
        {
            InitializeComponent();
        }
        private void getdata()
        {
            SqlCommand cmd = new SqlCommand("Select * from GiaDinh ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            add.Fill(ds, "gd");
            dgv.DataSource = ds.Tables["gd"];
            SBT.conn.Close();
        }

        private void ClearText()
        {
            txtMaGD.Clear();
            txtMaDV.Clear();
            txtMaTT.Clear();
            txthotencha.Clear();
            txtngaysinhcha.ResetText();
            txtnghenghiepcha.Clear();
            txthotenme.Clear();
            txtngaysinhme.ResetText();
            txtnghenghiepme.Clear();
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

        private void button4_Click(object sender, EventArgs e)
        {
            txtMaGD.Enabled = true;
            getdata();
            ClearText();
            txttimkiem.Clear();
        }

        private void GiaDinh_Load(object sender, EventArgs e)
        {
            txtMaGD.Enabled = true;
            getdata();
            ClearText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from GiaDinh where magd='" + txttimkiem.Text + "' or madv='" + txttimkiem.Text + "' or matinhtrang='" + txttimkiem.Text + "' or hotencha='" + txttimkiem.Text + "' or hotenme='" + txttimkiem.Text + "' ", SBT.conn);
            SBT.conn.Open();
            SqlDataAdapter add = new SqlDataAdapter(cmd);
            DataSet tim = new DataSet();
            add.Fill(tim, "tmi");
            dgv.DataSource = tim.Tables["tmi"];
            SBT.conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select count (*) from GiaDinh where magd= @magd", SBT.conn);
            SBT.conn.Open();
            cmd.Parameters.AddWithValue("@magd", txtMaGD.Text);
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
                SqlCommand cmd1 = new SqlCommand("INSERT INTO GiaDinh (magd, madv, matinhtrang, hotencha, ngaysinhcuacha, nghenghiepcuacha, hotenme, ngaysinhcuame, nghenghiepcuame ) Values(@magd, @madv, @matinhtrang, @hotencha, @ngaysinhcuacha, @nghenghiepcuacha, @hotenme, @ngaysinhcuame, @nghenghiepcuame) ", SBT.conn);
                SBT.conn.Open();
                cmd1.Parameters.AddWithValue("@magd", txtMaGD.Text);
                cmd1.Parameters.AddWithValue("@madv", txtMaDV.Text);
                cmd1.Parameters.AddWithValue("@matinhtrang", txtMaTT.Text);
                cmd1.Parameters.AddWithValue("@hotencha", txthotencha.Text);
                cmd1.Parameters.AddWithValue("@ngaysinhcuacha", txtngaysinhcha.Value);
                cmd1.Parameters.AddWithValue("@nghenghiepcuacha", txtnghenghiepcha.Text);
                cmd1.Parameters.AddWithValue("@hotenme", txthotenme.Text);
                cmd1.Parameters.AddWithValue("@ngaysinhcuame", txtngaysinhme.Value);
                cmd1.Parameters.AddWithValue("@nghenghiepcuame", txtnghenghiepme.Text);

                cmd1.ExecuteNonQuery();
                SBT.conn.Close();
                MessageBox.Show("Thêm thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                getdata();
                ClearText();
            }
        }

        private void btnxuat_Click(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("UPDATE GiaDinh SET magd=@magd, madv=@madv, matinhtrang=@matinhtrang, hotencha=@hotencha, ngaysinhcuacha=@ngaysinhcuacha, nghenghiepcuacha=@nghenghiepcuacha, hotenme=@hotenme, ngaysinhcuame=@ngaysinhcuame, nghenghiepcuame=@nghenghiepcuame WHERE magd=@magd", SBT.conn);
            SBT.conn.Open();
            cmd1.Parameters.AddWithValue("@magd", txtMaGD.Text);
            cmd1.Parameters.AddWithValue("@madv", txtMaDV.Text);
            cmd1.Parameters.AddWithValue("@matinhtrang", txtMaTT.Text);
            cmd1.Parameters.AddWithValue("@hotencha", txthotencha.Text);
            cmd1.Parameters.AddWithValue("@ngaysinhcuacha", txtngaysinhcha.Value);
            cmd1.Parameters.AddWithValue("@nghenghiepcuacha", txtnghenghiepcha.Text);
            cmd1.Parameters.AddWithValue("@hotenme", txthotenme.Text);
            cmd1.Parameters.AddWithValue("@ngaysinhcuame", txtngaysinhme.Value);
            cmd1.Parameters.AddWithValue("@nghenghiepcuame", txtnghenghiepme.Text);

            cmd1.ExecuteNonQuery();
            SBT.conn.Close();
            MessageBox.Show("Sửa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            getdata();
            ClearText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM GiaDinh WHERE magd=@magd", SBT.conn);
            SBT.conn.Open();
            cmd.Parameters.AddWithValue("@magd", txtMaGD.Text);
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
                txtMaGD.Text = dgv.Rows[id].Cells["magd"].Value.ToString();
                txtMaDV.Text = dgv.Rows[id].Cells["madv"].Value.ToString();
                txtMaTT.Text = dgv.Rows[id].Cells["matinhtrang"].Value.ToString();
                txthotencha.Text = dgv.Rows[id].Cells["hotencha"].Value.ToString();
                txtngaysinhcha.Value = Convert.ToDateTime(dgv.Rows[id].Cells["ngaysinhcuacha"].Value.ToString());
                txtnghenghiepcha.Text = dgv.Rows[id].Cells["nghenghiepcuacha"].Value.ToString();
                txthotenme.Text = dgv.Rows[id].Cells["hotenme"].Value.ToString();
                txtngaysinhme.Value = Convert.ToDateTime(dgv.Rows[id].Cells["ngaysinhcuame"].Value.ToString());
                txtnghenghiepme.Text = dgv.Rows[id].Cells["nghenghiepcuame"].Value.ToString();
            }
            txtMaGD.Enabled = false;
        }
    }
}
