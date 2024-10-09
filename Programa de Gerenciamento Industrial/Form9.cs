using Npgsql;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa_de_Gerenciamento_Industrial
{
    public partial class Form9 : Form
    {
        private const string ConnectionString = "Host=aws-0-sa-east-1.pooler.supabase.com;Port=6543;Username=postgres.stjotefgyhrhlobwldqs;Password=Q9nWPZV8.reuyMC;Database=postgres";

        public Form9()
        {
            InitializeComponent();
        }

        private async void Form9_Load(object sender, EventArgs e)
        {
            await CarregarLotesAsync();
        }

        private async Task CarregarLotesAsync()
        {
            const string query = "SELECT id_lote, nome_lote FROM lotes";

            try
            {
                using var conn = new NpgsqlConnection(ConnectionString);
                await conn.OpenAsync();

                using var cmd = new NpgsqlCommand(query, conn);
                using var reader = await cmd.ExecuteReaderAsync();

                comboBox1.BeginUpdate();
                comboBox1.Items.Clear();

                while (await reader.ReadAsync())
                {
                    comboBox1.Items.Add(new
                    {
                        Id = reader["id_lote"],
                        Conteudo = reader["nome_lote"]
                    });
                }

                comboBox1.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lotes: " + ex.Message);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is not null)
            {
                await ExcluirLoteAsync(comboBox1.SelectedItem);
            }
            else
            {
                MessageBox.Show("Selecione um lote para excluir.");
            }
        }

        private async Task ExcluirLoteAsync(object loteSelecionado)
        {
            var lote = (dynamic)loteSelecionado;
            int idLote = Convert.ToInt32(lote.Id);

            const string queryDelete = "DELETE FROM lotes WHERE id_lote = @id_lote";

            try
            {
                using var conn = new NpgsqlConnection(ConnectionString);
                await conn.OpenAsync();

                using var cmd = new NpgsqlCommand(queryDelete, conn);
                cmd.Parameters.AddWithValue("@id_lote", idLote);

                if (await VerificarReferenciasAsync(conn, idLote))
                {
                    MessageBox.Show("Este lote não pode ser excluído, pois está sendo referenciado.");
                    return;
                }

                if (await cmd.ExecuteNonQueryAsync() > 0)
                {
                    MessageBox.Show("Lote excluído com sucesso!");
                    comboBox1.Items.Remove(loteSelecionado);
                }
                else
                {
                    MessageBox.Show("Erro ao excluir o lote.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir lote: " + ex.Message);
            }
        }

        private async Task<bool> VerificarReferenciasAsync(NpgsqlConnection conn, int idLote)
        {
            const string query = "SELECT COUNT(*) FROM cliente_lote WHERE id_lote = @id_lote";
            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_lote", idLote);

            int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            return count > 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

