using Npgsql;
using System;
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

        private void Form9_Load(object sender, EventArgs e)
        {
            CarregarLotes();
        }

        private void CarregarLotes()
        {
            const string query = "SELECT id_lote, nome_lote FROM lotes";

            using var conn = new NpgsqlConnection(ConnectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(new
                {
                    Id = reader["id_lote"],
                    Conteudo = reader["nome_lote"]
                });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is not null)
            {
                ExcluirLote(comboBox1.SelectedItem);
            }
            else
            {
                MessageBox.Show("Selecione um lote para excluir.");
            }
        }

        private void ExcluirLote(object loteSelecionado)
        {
            var lote = (dynamic)loteSelecionado;
            int idLote = Convert.ToInt32(lote.Id);
            const string query = "DELETE FROM lotes WHERE id_lote = @id_lote";

            using var conn = new NpgsqlConnection(ConnectionString);
            conn.Open();

            using var cmd = new NpgsqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id_lote", idLote);

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Lote excluído com sucesso!");
                comboBox1.Items.Remove(loteSelecionado);
            }
            else
            {
                MessageBox.Show("Erro ao excluir o lote.");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
