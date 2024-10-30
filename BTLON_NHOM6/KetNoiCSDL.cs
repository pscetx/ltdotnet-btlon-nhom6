using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BTLON_NHOM6
{
    internal class KetNoiCSDL
    {
        public SqlConnection cnn;
        public SqlCommand cmd;
        public DataTable dta;
        public SqlDataAdapter ada;

        public void KetNoi_DuLieu()
        {
            string strKetNoi = @"Data Source=PSCETX\SQLEXPRESS;Initial Catalog=LTDOTNET_BTLON;Integrated Security=True";
            cnn = new SqlConnection(strKetNoi);
            cnn.Open();
        }
        public void HuyKetNoi_DuLieu()
        {
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
        }
        public DataTable Lay_DuLieu(string Sql)
        {
            KetNoi_DuLieu();
            ada = new SqlDataAdapter(Sql, cnn);
            dta = new DataTable();
            ada.Fill(dta);
            return dta;
        }
        public void ThucThi(string Sql)
        {
            KetNoi_DuLieu();
            cmd = new SqlCommand(Sql, cnn);
            cmd.ExecuteNonQuery();
            HuyKetNoi_DuLieu();
        }
    }
}
