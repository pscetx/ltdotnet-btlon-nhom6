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

namespace BTLON_NHOM6
{
    public partial class FrmUserMatch : Form
    {
        public FrmUserMatch()
        {
            InitializeComponent();

            this.Load += FrmUserMatch_Load;
        }

        KetNoiCSDL kn = new KetNoiCSDL();

        private void FrmUserMatch_Load(object sender, EventArgs e)
        {
            DataTable dta = new DataTable();
            dta = kn.Lay_DuLieu("SELECT * FROM Team ORDER by full_name");
            cboTeam.DataSource = dta;
            cboTeam.DisplayMember = "full_name";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dta = new DataTable();
            string teamname = cboTeam.Text;
            string teamid;
            string ketnoi = @"Data Source=PSCETX\SQLEXPRESS;Initial Catalog=LTDOTNET_BTLON;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(ketnoi))
            {
                conn.Open();
                teamid = new SqlCommand("Select id From Team WHERE full_name = '" + teamname + "'", conn).ExecuteScalar()?.ToString();
            }
            string sqlsearch = "SELECT * FROM Match WHERE home_team_id = '" + teamid + "'" +
                " OR away_team_id = '" + teamid + "'";
            dta = kn.Lay_DuLieu(sqlsearch);
            DGVTeam.DataSource = dta;
        }
    }
}
