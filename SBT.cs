using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DOAN.NET
{
    class SBT
    {
        public const string con_str = @"Data Source=DESKTOP-EEAM3B1\SQLEXPRESS;Initial Catalog=QLDV_DoAn.NET;Integrated Security=True";
        public static SqlConnection conn = new SqlConnection(con_str);
        
    }
}
