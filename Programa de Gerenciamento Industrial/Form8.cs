using System;
using Npgsql;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa_de_Gerenciamento_Industrial
{
    public partial class Form8 : Form
    {
        private readonly string connectionString =
            "Host=aws-0-sa-east-1.pooler.supabase.com;" +
            "Port=6543;" +
            "Username=postgres.stjotefgyhrhlobwldqs;" +
            "Password=Q9nWPZV8.reuyMC;" +
            "Database=postgres;" +
            "Pooling=true;" +  // Ativa o pooling para otimizar conexões
            "MinPoolSize=1;MaxPoolSize=10;Timeout=15;CommandTimeout=60;";

        public Form8()
        {
            InitializeComponent();
        }

        private async void Form8_Load(object sender, EventArgs e)
        {
            string query = "SELECT id_lote FROM lotes";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                comboBox1.Items.Add(reader["id_lote"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar lotes: {ex.Message}");
                }
            }
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Pegar o valor selecionado no ComboBox
            if (int.TryParse(comboBox1.SelectedItem.ToString(), out int idLoteSelecionado))
            {
                await CarregarDadosLoteAsync(idLoteSelecionado);
            }
        }

        private async Task CarregarDadosLoteAsync(int id_lote)
        {
            string query = "SELECT nome_lote, data_criação, status, quantidade FROM lotes WHERE id_lote = @id_lote";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id_lote", id_lote);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                textBox1.Text = reader["nome_lote"].ToString();
                                dateTimePicker1.Value = Convert.ToDateTime(reader["data_criação"]);
                                textBox3.Text = reader["status"].ToString();
                                textBox2.Text = reader["quantidade"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar dados do lote: {ex.Message}");
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Capturar os valores dos campos de edição
            string nome_lote = textBox1.Text;
            DateTime data_criação = dateTimePicker1.Value;
            string status = textBox3.Text;
            int quantidade = Convert.ToInt16(textBox2.Text);

            if (int.TryParse(comboBox1.SelectedItem.ToString(), out int idLoteSelecionado))
            {
                string query =
                    "UPDATE lotes SET nome_lote = @nome_lote, data_criação = @data_criação, status = @status, quantidade = @quantidade WHERE id_lote = @id_lote";


                using (var conn = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        await conn.OpenAsync();
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id_lote", idLoteSelecionado);
                            cmd.Parameters.AddWithValue("@nome_lote", nome_lote);
                            cmd.Parameters.AddWithValue("@data_criação", data_criação);
                            cmd.Parameters.AddWithValue("@status", status);
                            cmd.Parameters.AddWithValue("@quantidade", quantidade);

                            int affectedRows = await cmd.ExecuteNonQueryAsync();
                            MessageBox.Show(affectedRows > 0 ? "Lote atualizado com sucesso!" : "Nenhuma alteração realizada.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao atualizar lote: {ex.Message}");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
