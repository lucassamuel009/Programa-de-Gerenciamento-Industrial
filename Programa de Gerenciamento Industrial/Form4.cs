using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;

namespace Programa_de_Gerenciamento_Industrial
{
    public partial class Form4 : Form
    {
        private const string ConnectionString = "Host=aws-0-sa-east-1.pooler.supabase.com;Port=6543;Username=postgres.stjotefgyhrhlobwldqs;Password=Q9nWPZV8.reuyMC;Database=postgres;Pooling=true;Minimum Pool Size=5;Maximum Pool Size=100;Timeout=30;CommandTimeout=30";

        public Form4()
        {
            InitializeComponent();
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                LoadComboBoxData(comboBox1, conn, "SELECT nome_lote FROM lotes");
                LoadComboBoxData(comboBox2, conn, "SELECT nome_indústria FROM indústria");
                LoadComboBoxData(comboBox3, conn, "SELECT nome FROM cliente");
            }
        }

        private void LoadComboBoxData(ComboBox comboBox, NpgsqlConnection conn, string query)
        {
            using (var cmd = new NpgsqlCommand(query, conn))
            using (var da = new NpgsqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                da.Fill(dt);
                comboBox.DataSource = dt;
                comboBox.DisplayMember = dt.Columns[0].ColumnName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione todos os campos.");
                return;
            }

            string nomeLote = comboBox1.Text;
            string nomeIndústria = comboBox2.Text;
            string nomeCliente = comboBox3.Text;

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();

                    int idLote = GetId(conn, "SELECT id_lote FROM lotes WHERE nome_lote = @nome", nomeLote);
                    int idIndústria = GetId(conn, "SELECT id_indústria FROM indústria WHERE nome_indústria = @nome", nomeIndústria);
                    int idCliente = GetId(conn, "SELECT id_cliente FROM cliente WHERE nome = @nome", nomeCliente);

                    ExecuteInsert(conn, "INSERT INTO cliente_lote (id_lote, id_cliente) VALUES (@id_lote, @id_cliente)", idLote, idCliente);
                    ExecuteInsert(conn, "INSERT INTO indústria_lote (id_lote, id_indústria) VALUES (@id_lote, @id_indústria)", idLote, idIndústria);

                    MessageBox.Show("Lote encomendado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao encomendar lote: " + ex.Message);
                }
            }
        }

        private int GetId(NpgsqlConnection conn, string query, string nome)
        {
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@nome", nome);
                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : throw new Exception("ID não encontrado.");
            }
        }

        private void ExecuteInsert(NpgsqlConnection conn, string query, int idLote, int idOutro)
        {
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id_lote", idLote);
                cmd.Parameters.AddWithValue("@id_cliente", idOutro); 
                cmd.ExecuteNonQuery();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
           
        }
    }
}
