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
    public partial class FrmPlayer : Form
    {
        public FrmPlayer()
        {
            InitializeComponent();
        }
        KetNoiCSDL kn = new KetNoiCSDL();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmPlayer_Load(object sender, EventArgs e)
        {
            BangPlayer();
            BangTeam();
        }

        private void HienThiDuLieu()
        {
            txtId.DataBindings.Clear();
            txtId.DataBindings.Add("Text", DGVplayer.DataSource, "id");
            txtName.DataBindings.Clear();
            txtName.DataBindings.Add("Text", DGVplayer.DataSource, "name");
            txtPosition.DataBindings.Clear();
            txtPosition.DataBindings.Add("Text", DGVplayer.DataSource, "position");
            txtNationality.DataBindings.Clear();
            txtNationality.DataBindings.Add("Text", DGVplayer.DataSource, "nationality");
            txtAge.DataBindings.Clear();
            txtAge.DataBindings.Add("Text", DGVplayer.DataSource, "age");
            cboTeamId.DataBindings.Clear();
            cboTeamId.DataBindings.Add("Text", DGVplayer.DataSource, "team_id");
            txtGoals.DataBindings.Clear();
            txtGoals.DataBindings.Add("Text", DGVplayer.DataSource, "goals");
            txtAssists.DataBindings.Clear();
            txtAssists.DataBindings.Add("Text", DGVplayer.DataSource, "assists");
            txtYellow.DataBindings.Clear();
            txtYellow.DataBindings.Add("Text", DGVplayer.DataSource, "yellow_cards");
            txtRed.DataBindings.Clear();
            txtRed.DataBindings.Add("Text", DGVplayer.DataSource, "red_cards");
            txtMinPlayed.DataBindings.Clear();
            txtMinPlayed.DataBindings.Add("Text", DGVplayer.DataSource, "minutes_played");
        }

        public void BangPlayer()
        {
            DataTable dta = new DataTable();
            dta = kn.Lay_DuLieu("select * from Player");
            DGVplayer.DataSource = dta;
            HienThiDuLieu();
        }

        public void BangTeam()
        {
            DataTable dta = new DataTable();
            dta = kn.Lay_DuLieu("select * from Team order by id");
            cboTeamId.DataSource = dta;
            cboTeamId.DisplayMember = "id";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (thongbao == DialogResult.OK)
                this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtId.Focus();
            txtId.Text = "";
            txtName.Text = "";
            txtPosition.Text = "";
            txtNationality.Text = "";
            txtAge.Text = "";
            cboTeamId.Text = "";
            txtGoals.Text = "0";
            txtAssists.Text = "0";
            txtYellow.Text = "0";
            txtRed.Text = "0";
            txtMinPlayed.Text = "0";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (thongbao == DialogResult.OK)
            {
                string sql_Xoa = "Delete Player where id = '" + txtId.Text + "'";
                kn.ThucThi(sql_Xoa);
                BangPlayer();
            }
        }

        private void btnChen_Click(object sender, EventArgs e)
        {
            string sql_Chen = "Insert into Player values ('" + txtId.Text + "', '" + txtName.Text + "', '" + txtPosition.Text + "', '" + cboTeamId.Text + "', '" + txtNationality.Text + "', '" + txtAge.Text + "', '" + txtGoals.Text + "', '" + txtAssists.Text + "', '" + txtYellow.Text + "', '" + txtRed.Text + "', '" + txtMinPlayed.Text + "')";
            kn.ThucThi(sql_Chen);
            BangPlayer();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql_Sua = "UPDATE Player SET name = '" + txtName.Text + "'";
            sql_Sua += ", position = '" + txtPosition.Text + "'";
            sql_Sua += ", team_id = '" + cboTeamId.Text + "'";
            sql_Sua += ", nationality = '" + txtNationality.Text + "'";
            sql_Sua += ", age = '" + txtAge.Text + "'";
            sql_Sua += ", goals = '" + txtGoals.Text + "'";
            sql_Sua += ", assists = '" + txtAssists.Text + "'";
            sql_Sua += ", yellow_cards = '" + txtYellow.Text + "'";
            sql_Sua += ", red_cards = '" + txtRed.Text + "'";
            sql_Sua += ", minutes_played = '" + txtMinPlayed.Text + "'";
            sql_Sua += " WHERE id = '" + txtId.Text + "'";
            kn.ThucThi(sql_Sua);
            BangPlayer();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            DataTable dta = new DataTable();
            string sqltk = "Select * from Player where id like '%" + txtId.Text + "%'";
            dta = kn.Lay_DuLieu(sqltk);
            DGVplayer.DataSource = dta;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
