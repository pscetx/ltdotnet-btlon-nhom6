using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLON_NHOM6
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        KetNoiCSDL kn = new KetNoiCSDL();

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            kn.KetNoi_DuLieu();
            string dn = txtName.Text;
            string mk = txtPass.Text;
            string sql_login;
            sql_login = "SELECT username, password FROM Account WHERE username = '" + dn + "' and password = '" + mk + "'";
            SqlCommand cmd = new SqlCommand(sql_login, kn.cnn);
            SqlDataReader ratRE = cmd.ExecuteReader();
            if (ratRE.Read() == true)
            {
                MessageBox.Show("Đăng nhập thành công!");
                FrmMain frm1 = new FrmMain();
                frm1.Show();
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập sai!");
            }
        }
    }
}
