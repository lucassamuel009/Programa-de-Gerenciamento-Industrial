using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa_de_Gerenciamento_Industrial
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nome_lote = textBox1.Text;
            DateTime data_criação = dateTimePicker1.Value;
            string status = textBox3.Text;
            int quantidade = Convert.ToInt32(textBox2.Text);

            string connectionString = "Host=aws-0-sa-east-1.pooler.supabase.com;Port=6543;Username=postgres.stjotefgyhrhlobwldqs;Password=Q9nWPZV8.reuyMC;Database=postgres";

            using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO lotes (nome_lote, data_criação, status, quantidade) VALUES (@nome_lote, @data_criação, @status, @quantidade)";

                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nome_lote", nome_lote);
                    cmd.Parameters.AddWithValue("@data_criação", data_criação);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("quantidade", quantidade);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lote adicionado com sucesso!");

                    this.Close(); 
                }
                catch (NpgsqlException ex)
                {
                    MessageBox.Show("Erro ao adicionar lote: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
