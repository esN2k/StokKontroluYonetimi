using System;
using System.Windows.Forms;

namespace StokKontroluYonetimi
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void checkBoxSifre_CheckedChanged(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = checkBoxSifre.Checked == false;
        }

        private void lblTemizle_Click(object sender, EventArgs e)
        {
            txtIsim.Clear();
            txtSifre.Clear();
        }

        private void pictureBoxKapat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Programı kapatmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
