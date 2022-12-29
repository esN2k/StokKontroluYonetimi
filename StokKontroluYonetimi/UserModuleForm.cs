using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StokKontroluYonetimi
{
    public partial class UserModuleForm : Form
    {
        private readonly SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dodik\Documents\dblMS.mdf;Integrated Security=True;Connect Timeout=30");
        private SqlCommand cm = new SqlCommand();

        public UserModuleForm()
        {
            InitializeComponent();
        }

        private void pictureBoxKapat_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKullaniciAdi.Text == "" || txtSifre.Text == "" || txtSifreTekrar.Text == "")
                {
                    _ = MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (txtSifre.Text != txtSifreTekrar.Text)
                {
                    _ = MessageBox.Show("Şifreler uyuşmuyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                {
                    con.Open();
                    cm = new SqlCommand("insert into tblUser (username, fullname, password, phone) values (@username, @fullname, @password, @phone)", con);
                    _ = cm.Parameters.AddWithValue("@username", txtKullaniciAdi.Text);
                    _ = cm.Parameters.AddWithValue("@fullname", txtIsim.Text);
                    _ = cm.Parameters.AddWithValue("@password", txtSifre.Text);
                    _ = cm.Parameters.AddWithValue("@phone", txtTelefon.Text);
                    _ = cm.ExecuteNonQuery();
                    con.Close();
                    _ = MessageBox.Show("Kullanıcı başarıyla kaydedildi.", "Kaydedildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtKullaniciAdi.Clear();
                    txtSifre.Clear();
                    txtSifreTekrar.Clear();
                    txtTelefon.Clear();
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtIsim.Text = txtKullaniciAdi.Text = txtSifre.Text = txtTelefon.Text = txtSifreTekrar.Text = "";
        }
    }
}
