using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Programa_de_Gerenciamento_Industrial
{
    public partial class Form5 : Form
    {
        private const string ConnectionString = "Host=aws-0-sa-east-1.pooler.supabase.com;Port=6543;Username=postgres.stjotefgyhrhlobwldqs;Password=Q9nWPZV8.reuyMC;Database=postgres;Pooling=true;Minimum Pool Size=5;Maximum Pool Size=100;";
        public Form5()
        {
            InitializeComponent();
        }

        private bool IsValidCpfCnpj(string cpfCnpj)
        {
            // Remove caracteres não numéricos
            string cleaned = Regex.Replace(cpfCnpj, @"[^\d]", "");

            // Verifica o comprimento: CPF deve ter 11 dígitos e CNPJ deve ter 14 dígitos
            if (cleaned.Length == 11)
            {
                return ValidateCpf(cleaned);
            }
            else if (cleaned.Length == 14)
            {
                return ValidateCnpj(cleaned);
            }

            return false;
        }

        private bool ValidateCpf(string cpf)
        {
            // Lógica simplificada para verificar o formato de CPF
            if (cpf.Length != 11)
            {
                return false;
            }
            // Verifica se todos os dígitos são iguais (um CPF inválido comum)
            if (new string(cpf[0], cpf.Length) == cpf)
            {
                return false;
            }
            return true;
        }

        private bool ValidateCnpj(string cnpj)
        {
            // Lógica simplificada para verificar o formato de CNPJ
            if (cnpj.Length != 14)
            {
                return false;
            }
            // Verifica se todos os dígitos são iguais (um CNPJ inválido comum)
            if (new string(cnpj[0], cnpj.Length) == cnpj)
            {
                return false;
            }
            return true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            string nome = textBox2.Text;
            string telefone = textBox4.Text;
            string endereço = textBox5.Text;
            string tipoCadastro = textBox6.Text.Trim(); // Pega o valor digitado ("Cliente" ou "Indústria")

            // String de conexão ao banco de dados
            NpgsqlConnection conn = new NpgsqlConnection("Host=aws-0-sa-east-1.pooler.supabase.com;Port=6543;Username=postgres.stjotefgyhrhlobwldqs;Password=Q9nWPZV8.reuyMC;Database=postgres;Pooling=true;Minimum Pool Size=5;Maximum Pool Size=100;");

            try
            {
                conn.Open();

                // Verifica se o tipo de cadastro é "Cliente" ou "Indústria" e insere na tabela correspondente
                if (tipoCadastro.Equals("Cliente", StringComparison.OrdinalIgnoreCase))
                {
                    string query = "INSERT INTO cliente (nome, telefone, endereço) VALUES (@nome, @telefone, @endereço)";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nome", nome);
                    cmd.Parameters.AddWithValue("@telefone", telefone);
                    cmd.Parameters.AddWithValue("@endereço", endereço);
                    cmd.ExecuteNonQuery();
                }
                if (tipoCadastro.Equals("Indústria", StringComparison.OrdinalIgnoreCase))
                {
                    string query = "INSERT INTO indústria (nome_indústria, telefone, endereço) VALUES (@nome_indústria, @telefone, @endereço)";
                    NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nome_indústria", nome);
                    cmd.Parameters.AddWithValue("@telefone", telefone);
                    cmd.Parameters.AddWithValue("@endereço", endereço);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Por favor, digite 'Cliente' ou 'Indústria' no campo de tipo de cadastro.");
                    return;
                }

                MessageBox.Show("Cadastro realizado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
