using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SOLO
{
    public partial class frmAddArticle : Form
    {
        string sn = "Data Source=DESKTOP-QB4O65F;Initial Catalog=SOLO;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter sda;
        DataTable dt;

        public frmAddArticle()
        {
            InitializeComponent();
        }

        private void frmAddArticle_Load(object sender, EventArgs e)
        {

        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(sn);
            conn.Open();
            SqlCommand cmdArtikl = new SqlCommand("Select COUNT(*) From Artikl Where IdArtikl = " + int.Parse(txtNoviArtikl.Text), conn);
            int count = int.Parse(cmdArtikl.ExecuteScalar().ToString());
            if (count == 0)
            {
                SqlCommand sqlCmd = new SqlCommand("noviArtikl", conn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@IDArtikla", int.Parse(txtNoviArtikl.Text));
                sqlCmd.Parameters.AddWithValue("@Kalup", txtNoviKalup.Text);
                sqlCmd.Parameters.AddWithValue("@Djon", txtNoviDjon.Text);
                sqlCmd.Parameters.AddWithValue("@Branzol", txtNoviBranzol.Text);
                sqlCmd.Parameters.AddWithValue("@Trapunto", txtNoviTrapunto.Text);
                sqlCmd.Parameters.AddWithValue("@Pete", txtNoviPeta.Text);
                sqlCmd.Parameters.AddWithValue("@Flekice", txtNoviFlekica.Text);
                sqlCmd.Parameters.AddWithValue("@Tabanica", txtNoviTabanica.Text);
                sqlCmd.Parameters.AddWithValue("@Lub", txtNoviLub.Text);
                sqlCmd.Parameters.AddWithValue("@Kapna", txtNoviKapna.Text);
                sqlCmd.Parameters.AddWithValue("@Prsti", txtNoviPPrsti.Text);
                sqlCmd.Parameters.AddWithValue("@PresvlakeBranzola", txtNoviPBranzol.Text);
                sqlCmd.Parameters.AddWithValue("@CNC", txtNoviGrancice.Text);
                int rowsAffected = sqlCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Artikl uspešno unet!");
                    txtNoviArtikl.Text = "";
                    txtNoviDjon.Text = "";
                    txtNoviKalup.Text = "";
                    txtNoviFlekica.Text = "";
                    txtNoviBranzol.Text = "";
                    txtNoviTrapunto.Text = "";
                    txtNoviGrancice.Text = "";
                    txtNoviKapna.Text = "";
                    txtNoviPBranzol.Text = "";
                    txtNoviPPrsti.Text = "";
                    txtNoviLub.Text = "";
                    txtNoviPeta.Text = "";
                    txtNoviTabanica.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Artikl sa izabranom šifrom već postoji!");
            }
            conn.Close();
        }
    }
}
