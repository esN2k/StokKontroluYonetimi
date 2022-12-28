using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (checkBoxSifre.Checked == false)
                txtSifre.UseSystemPasswordChar = true;
            else
                txtSifre.UseSystemPasswordChar = false;
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
