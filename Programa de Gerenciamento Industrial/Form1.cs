using Npgsql;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace Programa_de_Gerenciamento_Industrial
{
    public partial class Form1 : Form
    {
        public bool usuarioLog { get; private set; }
        public Form1()
        {
            InitializeComponent();

        }
        
        private bool VerificarLogin(string usuario, string senha)
        {
            string connectionString = "Host=aws-0-sa-east-1.pooler.supabase.com;Port=6543;Username=postgres.stjotefgyhrhlobwldqs;Password=Q9nWPZV8.reuyMC;Database=postgres";

            string query = "SELECT COUNT(1) FROM admin WHERE nome=@usuario AND senha=@senha";

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Informações invalidas: " + ex.Message);
                    return false;
                }
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string usuario = textBox2.Text;
            string senha = textBox1.Text;

            usuarioLog = VerificarLogin(usuario, senha);

            if (usuarioLog != null)
            {
                MessageBox.Show("Login bem-sucedido!");

                Form2 interacao = new Form2();
                interacao.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
