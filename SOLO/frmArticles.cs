using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOLO
{
    public partial class frmArticles : Form
    {
        string sn = "Data Source=DESKTOP-QB4O65F;Initial Catalog=SOLO;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter sda;
        DataTable dt;

        public frmArticles()
        {
            InitializeComponent();
        }

        private void btnSelectArticle_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(sn);
            conn.Open();
            if (string.IsNullOrEmpty(txtArtikalIzbor.Text))
            {
                MessageBox.Show("Niste uneli šifru artikla!");
            }
            else
            {
                SqlCommand cmdNalog = new SqlCommand("Select COUNT(*) From Artikl Where IdArtikl = '" + txtArtikalIzbor.Text + "'", conn);
                int count = int.Parse(cmdNalog.ExecuteScalar().ToString());
                if (count > 0)
                {
                    txtArtikalIzbor.Enabled = true;
                    txtDjon.Enabled = true;
                    txtKalup.Enabled = true;
                    txtTabanica.Enabled = true;
                    txtBranzol.Enabled = true;
                    txtTrapunto.Enabled = true;
                    txtGrancice.Enabled = true;
                    txtKapna.Enabled = true;
                    txtPBranzol.Enabled = true;
                    txtPPrsti.Enabled = true;
                    txtLub.Enabled = true;
                    txtFlekica.Enabled = true;
                    txtPeta.Enabled = true;
                    btnUpdate.Enabled = true;

                    SqlCommand cmdDjon = new SqlCommand("SELECT Djon FROM Artikl WHERE IdArtikl = " + int.Parse(txtArtikalIzbor.Text), conn);
                    txtDjon.Text = cmdDjon.ExecuteScalar().ToString();

                    SqlCommand cmdKalup = new SqlCommand("SELECT Kalup FROM Artikl WHERE IdArtikl = " + int.Parse(txtArtikalIzbor.Text), conn);
                    txtKalup.Text = cmdKalup.ExecuteScalar().ToString();

                    SqlCommand cmdFlekica = new SqlCommand("SELECT Flekice FROM Artikl WHERE IdArtikl = " + int.Parse(txtArtikalIzbor.Text), conn);
                    txtFlekica.Text = cmdFlekica.ExecuteScalar().ToString();

                    SqlCommand cmdBranzol = new SqlCommand("SELECT Branzol FROM Artikl WHERE IdArtikl = " + int.Parse(txtArtikalIzbor.Text), conn);
                    txtBranzol.Text = cmdBranzol.ExecuteScalar().ToString();

                    SqlCommand cmdTrapunto = new SqlCommand("SELECT Trapunto FROM Artikl WHERE IdArtikl = " + int.Parse(txtArtikalIzbor.Text), conn);
                    txtTrapunto.Text = cmdTrapunto.ExecuteScalar().ToString();

                    SqlCommand cmdGrancice = new SqlCommand("SELECT CNCgrancice FROM Artikl WHERE IdArtikl = " + int.Parse(txtArtikalIzbor.Text), conn);
                    txtGrancice.Text = cmdGrancice.ExecuteScalar().ToString();

                    SqlCommand cmdKapne = new SqlCommand("SELECT Kapna FROM Artikl WHERE IdArtikl = " + int.Parse(txtArtikalIzbor.Text), conn);
                    txtKapna.Text = cmdKapne.ExecuteScalar().ToString();

                    SqlCommand cmdPB = new SqlCommand("SELECT PresvlakeBranzola FROM Artikl WHERE IdArtikl = " + int.Parse(txtArtikalIzbor.Text), conn);
                    txtPBranzol.Text = cmdPB.ExecuteScalar().ToString();

                    SqlCommand cmdPP = new SqlCommand("SELECT Prsti FROM Artikl WHERE IdArtikl = " + int.Parse(txtArtikalIzbor.Text), conn);
                    txtPPrsti.Text = cmdPP.ExecuteScalar().ToString();

                    SqlCommand cmdLub = new SqlCommand("SELECT Lub FROM Artikl WHERE IdArtikl = " + int.Parse(txtArtikalIzbor.Text), conn);
                    txtLub.Text = cmdLub.ExecuteScalar().ToString();

                    SqlCommand cmdPeta = new SqlCommand("SELECT Pete FROM Artikl WHERE IdArtikl = " + int.Parse(txtArtikalIzbor.Text), conn);
                    txtPeta.Text = cmdPeta.ExecuteScalar().ToString();

                    SqlCommand cmdTabanica = new SqlCommand("SELECT Tabanica FROM Artikl WHERE IdArtikl = " + int.Parse(txtArtikalIzbor.Text), conn);
                    txtTabanica.Text = cmdTabanica.ExecuteScalar().ToString();


                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(sn);
            conn.Open();
            //SqlCommand cmdArtikl = new SqlCommand("Select COUNT(*) From Artikl Where IdArtikl = " + int.Parse(txtArtikal.Text), conn);
            //int count = int.Parse(cmdArtikl.ExecuteScalar().ToString());
            //if (count > 0)
            //{
            SqlCommand sqlCmd = new SqlCommand("izmenaArtikl", conn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@IDArtikla", txtArtikalIzbor.Text);
            sqlCmd.Parameters.AddWithValue("@Kalup", txtKalup.Text);
            sqlCmd.Parameters.AddWithValue("@Djon", txtDjon.Text);
            sqlCmd.Parameters.AddWithValue("@Branzol", txtBranzol.Text);
            sqlCmd.Parameters.AddWithValue("@Trapunto", txtTrapunto.Text);
            sqlCmd.Parameters.AddWithValue("@Pete", txtPeta.Text);
            sqlCmd.Parameters.AddWithValue("@Flekice", txtFlekica.Text);
            sqlCmd.Parameters.AddWithValue("@Tabanica", txtTabanica.Text);
            sqlCmd.Parameters.AddWithValue("@Lub", txtLub.Text);
            sqlCmd.Parameters.AddWithValue("@Kapna", txtKapna.Text);
            sqlCmd.Parameters.AddWithValue("@Prsti", txtPPrsti.Text);
            sqlCmd.Parameters.AddWithValue("@PresvlakeBranzola", txtPBranzol.Text);
            sqlCmd.Parameters.AddWithValue("@CNC", txtGrancice.Text);
            int rowsAffected = sqlCmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Uspešno ste izmenili artikl!");
            }
        }
    }
}
