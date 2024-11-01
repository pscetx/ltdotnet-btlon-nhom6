using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLON_NHOM6
{
    public partial class FrmRanking : Form
    {
        public FrmRanking()
        {
            InitializeComponent();
        }
        KetNoiCSDL kn = new KetNoiCSDL();

        private void FrmRanking_Load(object sender, EventArgs e)
        {
            BangLeague();
        }
        public void BangRanking()
        {
            DataTable dta = new DataTable();
            dta = kn.Lay_DuLieu("SELECT * FROM LeagueRanking WHERE league_id = '" + cboLeagueId.Text + "'");
            DGVranking.DataSource = dta;
        }

        public void BangLeague()
        {
            DataTable dta = new DataTable();
            dta = kn.Lay_DuLieu("select * from League order by id");
            cboLeagueId.DataSource = dta;
            cboLeagueId.DisplayMember = "id";
            cboLeagueId.ValueMember = "id";
        }

        private void cboLeagueId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BangRanking();
        }
    }
}
