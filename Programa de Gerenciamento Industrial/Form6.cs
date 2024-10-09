using Npgsql;
using Npgsql.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;

namespace Programa_de_Gerenciamento_Industrial
{
    public partial class Form6 : Form
    {
        private string connectionString = "Host=aws-0-sa-east-1.pooler.supabase.com;Port=6543;Username=postgres.stjotefgyhrhlobwldqs;Password=Q9nWPZV8.reuyMC;Database=postgres;Pooling=true;Minimum Pool Size=5;Maximum Pool Size=100;";

        public Form6()
        {
            InitializeComponent();
            LoadClientes();
        }

        private void LoadClientes()
        {
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT id_cliente, nome FROM cliente";
                using (var da = new NpgsqlDataAdapter(query, con))
                {
                    DataTable dtClientes = new DataTable();
                    da.Fill(dtClientes);

                    // Exibe o nome dos clientes na ComboBox
                    comboBox1.DataSource = dtClientes;
                    comboBox1.DisplayMember = "nome";
                    comboBox1.ValueMember = "id_cliente"; // Armazena o id_cliente para usar depois
                }
            }
        }
        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Verifica se um cliente foi selecionado
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um cliente.");
                return;
            }

            int idClienteSelecionado = Convert.ToInt32(comboBox1.SelectedValue);


            // Busca os lotes do cliente selecionado
            using (var con = new NpgsqlConnection(connectionString))
            {
                con.Open();
                string query = @"
                SELECT l.id_lote, l.nome_lote, l.data_criação, c.nome as cliente, l.status
                FROM cliente_lote cl
                JOIN lotes l ON cl.id_lote = l.id_lote
                JOIN cliente c ON cl.id_cliente = c.id_cliente
                WHERE cl.id_cliente = @id_cliente";

                using (var cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id_cliente", idClienteSelecionado);
                    using (var da = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dtLotes = new DataTable();
                        da.Fill(dtLotes);
                        dataGridView1.DataSource = dtLotes;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Limpa o filtro e o DataGridView
            comboBox1.SelectedIndex = -1;
            dataGridView1.DataSource = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cria um documento PDF
            using (iTextSharp.text.Document doc = new iTextSharp.text.Document())
            {
                PdfWriter.GetInstance(doc, new FileStream("relatorio.pdf", FileMode.Create));
                doc.Open();

                // Cria a tabela no PDF com o número de colunas do DataGridView
                PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);

                // Adiciona os cabeçalhos
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    table.AddCell(new Phrase(column.HeaderText));
                }

                // Adiciona os dados
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        table.AddCell(new Phrase(cell.Value?.ToString() ?? string.Empty));
                    }
                }

                // Adiciona a tabela no documento
                doc.Add(table);
                doc.Close();
            }

            MessageBox.Show("Relatório exportado para PDF com sucesso!");
        }

    

    private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cria o documento Excel
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Relatório");

                // Adiciona os cabeçalhos
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dataGridView1.Columns[i].HeaderText;
                }

                // Adiciona os dados
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        var valor = dataGridView1.Rows[i].Cells[j].Value;
                        worksheet.Cell(i + 2, j + 1).Value = valor?.ToString() ?? string.Empty;
                    }
                }

                // Salva o arquivo
                workbook.SaveAs("relatorio.xlsx");
            }

            MessageBox.Show("Relatório exportado para Excel com sucesso!");
        }
    }
}


