using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SOLO
{
    public partial class frmSOLO : Form
    {
        private Button currentButton;
        private Form activeForm;
        public frmSOLO()
        {
            InitializeComponent();
        }

        private void ActivateButton(object btnSender) {
            if (btnSender != null) {
                if (currentButton != (Button)btnSender) {
                    DeactivateButton();

                    currentButton = (Button)btnSender;
                    //currentButton.BackColor = Color.FromArgb(113, 112, 118);
                    currentButton.BackColor = Color.MediumVioletRed;

                    currentButton.Font = new System.Drawing.Font("Candara", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                    lblHeader.Text = currentButton.Text;
                    //pnlHeader.BackColor = Color.LightPink;
                }
            }
        }

        private void DeactivateButton() {

            foreach (Control previousBtn in pnlMenu.Controls) {
                if (previousBtn.GetType() == typeof(Button)) {
                    previousBtn.BackColor = Color.FromArgb(35, 33, 32);
                    previousBtn.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
                }
            }
        }

        private void OpenChildForm(Form childForm,object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }

            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlParent.Controls.Add(childForm);
            this.pnlParent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnArticles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmArticles(), sender);
        }

        private void btnAddArticle_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmAddArticle(), sender);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmOrders(), sender);
        }

        private void btnAddReport_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNewOrder(), sender);
        }

        private void btnInStock_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmHerikteraj(), sender);
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCloseActiveForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            DeactivateButton();
            lblHeader.Text = "";
        }
    }
}
