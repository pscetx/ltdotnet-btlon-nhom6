using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BTLON_NHOM6
{
    public partial class FrmMatch : Form
    {
            public FrmMatch()
            {
                InitializeComponent();
            }
            KetNoiCSDL kn = new KetNoiCSDL();

            private void FrmMatch_Load(object sender, EventArgs e)
            {
                BangMatch();
                BangLeague();
            }

            private void label17_Click(object sender, EventArgs e)
            {

            }

            private void HienThiDuLieu()
            {
                txtId.DataBindings.Clear();
                txtId.DataBindings.Add("Text", DGVmatch.DataSource, "id");
                cboLeagueId.DataBindings.Clear();
                cboLeagueId.DataBindings.Add("Text", DGVmatch.DataSource, "league_id");
                cboHId.DataBindings.Clear();
                cboHId.DataBindings.Add("Text", DGVmatch.DataSource, "home_team_id");
                cboAId.DataBindings.Clear();
                cboAId.DataBindings.Add("Text", DGVmatch.DataSource, "away_team_id");
                txtHScore.DataBindings.Clear();
                txtHScore.DataBindings.Add("Text", DGVmatch.DataSource, "home_team_score");
                txtAScore.DataBindings.Clear();
                txtAScore.DataBindings.Add("Text", DGVmatch.DataSource, "away_team_score");
                txtDate.DataBindings.Clear();
                txtDate.DataBindings.Add("Text", DGVmatch.DataSource, "match_date");
                txtHAttempts.DataBindings.Clear();
                txtHAttempts.DataBindings.Add("Text", DGVmatch.DataSource, "home_team_shots_attempted");
                txtAAttempts.DataBindings.Clear();
                txtAAttempts.DataBindings.Add("Text", DGVmatch.DataSource, "away_team_shots_attempted");
                txtHPossession.DataBindings.Clear();
                txtHPossession.DataBindings.Add("Text", DGVmatch.DataSource, "home_team_possession");
                txtAPossession.DataBindings.Clear();
                txtAPossession.DataBindings.Add("Text", DGVmatch.DataSource, "away_team_possession");
                txtHYellow.DataBindings.Clear();
                txtHYellow.DataBindings.Add("Text", DGVmatch.DataSource, "home_team_yellow_cards");
                txtAYellow.DataBindings.Clear();
                txtAYellow.DataBindings.Add("Text", DGVmatch.DataSource, "away_team_yellow_cards");
                txtHRed.DataBindings.Clear();
                txtHRed.DataBindings.Add("Text", DGVmatch.DataSource, "home_team_red_cards");
                txtARed.DataBindings.Clear();
                txtARed.DataBindings.Add("Text", DGVmatch.DataSource, "away_team_red_cards");
            }
            public void BangMatch()
            {
                DataTable dta = new DataTable();
                dta = kn.Lay_DuLieu("select * from Match");
                DGVmatch.DataSource = dta;
                HienThiDuLieu();
            }

            public void BangLeague()
            {
                DataTable dta = new DataTable();
                dta = kn.Lay_DuLieu("select * from League order by id");
                cboLeagueId.DataSource = dta;
                cboLeagueId.DisplayMember = "id";
                cboLeagueId.ValueMember = "id";
            }

            public void BangHId()
            {
                DataTable dta = new DataTable();
                dta = kn.Lay_DuLieu("select * from Team where league_id = '" + cboLeagueId.Text + "' order by id");
                cboHId.DataSource = dta;
                cboHId.DisplayMember = "id";
            }

            public void BangAId()
            {
                DataTable dta = new DataTable();
                dta = kn.Lay_DuLieu("select * from Team where league_id = '" + cboLeagueId.Text + "' order by id");
                cboAId.DataSource = dta;
                cboAId.DisplayMember = "id";
            }

        private void cboLeagueId_SelectedIndexChanged(object sender, EventArgs e)
        {
            BangHId();
            BangAId();
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
            cboLeagueId.Text = "";
            cboHId.Text = "";
            cboAId.Text = "";
            txtDate.Text = "";
            txtHScore.Text = "0";
            txtAScore.Text = "0";
            txtHAttempts.Text = "0";
            txtAAttempts.Text = "0";
            txtHPossession.Text = "0";
            txtAPossession.Text = "0";
            txtHYellow.Text = "0";
            txtAYellow.Text = "0";
            txtHRed.Text = "0";
            txtARed.Text = "0";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult thongbao;
            thongbao = MessageBox.Show("Bạn có muốn xóa dữ liệu không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (thongbao == DialogResult.OK)
            {
                string sql_Xoa = "Delete Match where id = '" + txtId.Text + "'";
                kn.ThucThi(sql_Xoa);
                BangMatch();
            }
        }

        private void btnChen_Click(object sender, EventArgs e)
        {
            string sql_Chen = "Insert into Match values ('" + txtId.Text + "', '" + cboLeagueId.Text + "', '" + cboHId.Text + "', '" + cboAId.Text + "', '" + txtHScore.Text + "', '" + txtAScore.Text + "', '" + txtDate.Text + "', '" + txtHAttempts.Text + "', '" + txtAAttempts.Text + "', '" + txtHPossession.Text + "', '" + txtAPossession.Text + "', '" + txtHYellow.Text + "', '" + txtAYellow.Text + "', '" + txtHRed.Text + "', '" + txtARed.Text + "')";
            kn.ThucThi(sql_Chen);
            BangMatch();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql_Sua = "UPDATE Match SET league_id = '" + cboLeagueId.Text + "'";
            sql_Sua += ", home_team_id = '" + cboHId.Text + "'";
            sql_Sua += ", away_team_id = '" + cboAId.Text + "'";
            sql_Sua += ", home_team_score = '" + txtHScore.Text + "'";
            sql_Sua += ", away_team_score = '" + txtAScore.Text + "'";
            sql_Sua += ", match_date = '" + txtDate.Text + "'";
            sql_Sua += ", home_team_shots_attempted = '" + txtHAttempts.Text + "'";
            sql_Sua += ", away_team_shots_attempted = '" + txtAAttempts.Text + "'";
            sql_Sua += ", home_team_possession = '" + txtHPossession.Text + "'";
            sql_Sua += ", away_team_possession = '" + txtAPossession.Text + "'";
            sql_Sua += ", home_team_yellow_cards = '" + txtHYellow.Text + "'";
            sql_Sua += ", away_team_yellow_cards = '" + txtAYellow.Text + "'";
            sql_Sua += ", home_team_red_cards = '" + txtHRed.Text + "'";
            sql_Sua += ", away_team_red_cards = '" + txtARed.Text + "'";
            sql_Sua += " WHERE id = '" + txtId.Text + "'";
            kn.ThucThi(sql_Sua);
            BangMatch();
        }
    }
}
