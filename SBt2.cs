using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOAN.NET
{
    class SBt2
    {
        private SqlConnection conn;
        // Trả về đối tượng kết nối
        public SqlConnection Connected()
        {
            string conect = SystemInformation.UserDomainName.ToString();

            string source = @"Data Source=DESKTOP-EEAM3B1\SQLEXPRESS;Initial Catalog=QLDV_DoAn.NET;Integrated Security=True";
            conn = new SqlConnection(source);
            conn.Open();
            return conn;
        }
    }
}
