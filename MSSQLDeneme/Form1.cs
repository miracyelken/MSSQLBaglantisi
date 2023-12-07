using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace MSSQLDeneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            SqlConnection cn = null;
            try
            {
                cn = new SqlConnection(@"Data Source = .\MSSQLSERVER02; Initial Catalog = OkulDb; Integrated Security = true");
                SqlCommand cmd = new SqlCommand($"Insert into tblOgrenciler values('{txtAd.Text.Trim()}', '{txtSoyad.Text.Trim()}', '{txtNumara.Text.Trim()}')", cn);
                cn.Open();
                int sonuc = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu numara daha �nce kaydedilmi�!");
                        break;
                    default:
                        MessageBox.Show("Veri Taban� Hatas�");
                        break;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata Olu�tu!");
            }
            finally
            {
                if (cn != null && cn.State != ConnectionState.Closed)
                    cn.Close(); 
            }            
        }
    }
}