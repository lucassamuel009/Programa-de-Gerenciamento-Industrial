using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace Programa_de_Gerenciamento_Industrial
{
    public partial class Form3 : Form
    {
        private string connectionString = "Host=aws-0-sa-east-1.pooler.supabase.com;Port=6543;Username=postgres.stjotefgyhrhlobwldqs;Password=Q9nWPZV8.reuyMC;Database=postgres";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridViewLotes.Rows.Clear();
            CarregarLotes(); 
        }

        private void CarregarLotes()
        {
            string query = "SELECT id_lote, nome_lote AS conteudo, data_criação AS dataCriacao, status, quantidade FROM lotes"; // Renomear as colunas diretamente na consulta

            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var adapter = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt); 

                        dataGridViewLotes.DataSource = dt;
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show($"Erro ao carregar lotes: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}");
            }
        
        }

        private void dataGridViewLotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();

            
            form7.Show();// Adicionar lote
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridViewLotes.Rows.Clear();
            CarregarLotes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();


            form8.Show();// Editar lote
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();


            form9.Show();// Excluir lote
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
