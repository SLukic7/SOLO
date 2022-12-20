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
namespace SOLO
{
    public partial class frmOrders : Form
    {
        string sn = "Data Source=DESKTOP-QB4O65F;Initial Catalog=SOLO;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter sda;
        DataTable dt;

        public frmOrders()
        {
            InitializeComponent();
        }

        private void frmOrders_Load(object sender, EventArgs e)
        {

        }

        private void btnSelectArticle_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(sn);
            conn.Open();
            if (string.IsNullOrEmpty(txtBrRadnogNaloga.Text))
            {
                MessageBox.Show("Niste uneli broj radnog naloga!");
            }
            else
            {
                SqlCommand cmdNalog = new SqlCommand("Select COUNT(*) From Nalog Where BrojNaloga = " + int.Parse(txtBrRadnogNaloga.Text), conn);
                int count = int.Parse(cmdNalog.ExecuteScalar().ToString());
                if (count > 0)
                {
                    int brojNaloga = int.Parse(txtBrRadnogNaloga.Text);

                    gbKrojacnica.Enabled = true;
                    gbHerikteraj.Enabled = true;
                    txtNapomena1.Enabled = true;
                    txtNapomena2.Enabled = true;
                    btnIzmeni.Enabled = true;

                    SqlCommand cmdArtikal = new SqlCommand("SELECT IDArtikl FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txtBrArtikla.Text = cmdArtikal.ExecuteScalar().ToString();

                    SqlCommand cmd36 = new SqlCommand("SELECT K36 FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txt36.Text = cmd36.ExecuteScalar().ToString();

                    SqlCommand cmd37 = new SqlCommand("SELECT K37 FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txt37.Text = cmd37.ExecuteScalar().ToString();

                    SqlCommand cmd38 = new SqlCommand("SELECT K38 FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txt38.Text = cmd38.ExecuteScalar().ToString();

                    SqlCommand cmd39 = new SqlCommand("SELECT K39 FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txt39.Text = cmd39.ExecuteScalar().ToString();

                    SqlCommand cmd40 = new SqlCommand("SELECT K40 FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txt40.Text = cmd40.ExecuteScalar().ToString();

                    SqlCommand cmd41 = new SqlCommand("SELECT K41 FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txt41.Text = cmd41.ExecuteScalar().ToString();

                    SqlCommand cmdDatum = new SqlCommand("SELECT DatumKrojacnica FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    dtpDatumUnosa.Value = Convert.ToDateTime(cmdDatum.ExecuteScalar().ToString());

                    SqlCommand cmdKUkupno = new SqlCommand("SELECT KUkupno FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txtUkupno.Text = cmdKUkupno.ExecuteScalar().ToString();

                    SqlCommand cmdH36 = new SqlCommand("SELECT H36 FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txtH36.Text = cmdH36.ExecuteScalar().ToString();

                    SqlCommand cmdH37 = new SqlCommand("SELECT H37 FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txtH37.Text = cmdH37.ExecuteScalar().ToString();

                    SqlCommand cmdH38 = new SqlCommand("SELECT H38 FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txtH38.Text = cmdH38.ExecuteScalar().ToString();

                    SqlCommand cmdH39 = new SqlCommand("SELECT H39 FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txtH39.Text = cmdH39.ExecuteScalar().ToString();

                    SqlCommand cmdH40 = new SqlCommand("SELECT H40 FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txtH40.Text = cmdH40.ExecuteScalar().ToString();

                    SqlCommand cmdH41 = new SqlCommand("SELECT H41 FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txtH41.Text = cmdH41.ExecuteScalar().ToString();

                    SqlCommand cmdDatumH = new SqlCommand("SELECT DatumHerikteraj FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    dtpHerikteraj.Value = Convert.ToDateTime(cmdDatumH.ExecuteScalar().ToString());

                    SqlCommand cmdHUkupno = new SqlCommand("SELECT HUkupno FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txtHUkupno.Text = cmdHUkupno.ExecuteScalar().ToString();

                    SqlCommand cmdBoja = new SqlCommand("SELECT Boja FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txtBoja.Text = cmdBoja.ExecuteScalar().ToString();

                    SqlCommand cmdMaterijal = new SqlCommand("SELECT Materijal FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txtMaterijal.Text = cmdMaterijal.ExecuteScalar().ToString();

                    SqlCommand cmdNapomena1 = new SqlCommand("SELECT Napomena1 FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txtNapomena1.Text = cmdNapomena1.ExecuteScalar().ToString();

                    SqlCommand cmdNapomena2 = new SqlCommand("SELECT Napomena2 FROM Nalog WHERE BrojNaloga = " + brojNaloga, conn);
                    txtNapomena2.Text = cmdNapomena2.ExecuteScalar().ToString();
                }
                else
                {
                    MessageBox.Show("Niste uneli ispravan broj naloga!");
                }
            }
            conn.Close();
        }
    }
}
