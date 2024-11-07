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
    public partial class FrmUserPlayer : Form
    {
        public FrmUserPlayer()
        {
            InitializeComponent();
        }

        KetNoiCSDL kn = new KetNoiCSDL();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dta = new DataTable();
            string sqlsearch = "SELECT * from Player WHERE name like '%" + txtPlayer.Text + "%'";
            dta = kn.Lay_DuLieu(sqlsearch);
            DGVUserPlayer.DataSource = dta;
        }
    }
}
