using System.Data.SqlClient;
using System.Windows.Forms;

namespace StokKontroluYonetimi
{
    public partial class UserForm : Form
    {
        private readonly SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dodik\Documents\dblMS.mdf;Integrated Security=True;Connect Timeout=30");
        private SqlCommand cm = new SqlCommand();
        private SqlDataReader dr;
        public UserForm()
        {
            InitializeComponent();
            LoadUser();
        }

        public void LoadUser()
        {
            int i = 0;
            dgvUser.Rows.Clear();
            con.Open();
            cm = new SqlCommand("select * from tblUser", con);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                _ = dgvUser.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            con.Close();
        }
    }
}
