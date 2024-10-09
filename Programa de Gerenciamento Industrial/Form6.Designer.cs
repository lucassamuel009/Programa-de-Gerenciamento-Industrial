namespace Programa_de_Gerenciamento_Industrial
{
    partial class Form6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            button5 = new Button();
            button1 = new Button();
            comboBox1 = new ComboBox();
            dataGridView1 = new DataGridView();
            Idlote = new DataGridViewTextBoxColumn();
            nome_lote = new DataGridViewTextBoxColumn();
            data_criação = new DataGridViewTextBoxColumn();
            cliente = new DataGridViewTextBoxColumn();
            status = new DataGridViewTextBoxColumn();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(17, 107);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(110, 40);
            label1.TabIndex = 1;
            label1.Text = "Filtros:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(34, 190);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 32);
            label2.TabIndex = 2;
            label2.Text = "Cliente:";
            // 
            // button5
            // 
            button5.BackColor = Color.OrangeRed;
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button5.Location = new Point(40, 522);
            button5.Margin = new Padding(4, 5, 4, 5);
            button5.Name = "button5";
            button5.Size = new Size(197, 67);
            button5.TabIndex = 7;
            button5.Text = "Gerar Relatório";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.OrangeRed;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(280, 522);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(197, 67);
            button1.TabIndex = 8;
            button1.Text = "Limpar filtro";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(213, 193);
            comboBox1.Margin = new Padding(4, 5, 4, 5);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(171, 33);
            comboBox1.TabIndex = 9;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Idlote, nome_lote, data_criação, cliente, status });
            dataGridView1.Location = new Point(17, 617);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(776, 363);
            dataGridView1.TabIndex = 12;
            // 
            // Idlote
            // 
            Idlote.HeaderText = "Idlote";
            Idlote.MinimumWidth = 8;
            Idlote.Name = "Idlote";
            Idlote.Width = 150;
            // 
            // nome_lote
            // 
            nome_lote.HeaderText = "nome_lote";
            nome_lote.MinimumWidth = 8;
            nome_lote.Name = "nome_lote";
            nome_lote.Width = 150;
            // 
            // data_criação
            // 
            data_criação.HeaderText = "data_criação";
            data_criação.MinimumWidth = 8;
            data_criação.Name = "data_criação";
            data_criação.Width = 150;
            // 
            // cliente
            // 
            cliente.HeaderText = "cliente";
            cliente.MinimumWidth = 8;
            cliente.Name = "cliente";
            cliente.Width = 150;
            // 
            // status
            // 
            status.HeaderText = "status";
            status.MinimumWidth = 8;
            status.Name = "status";
            status.Width = 150;
            // 
            // button2
            // 
            button2.BackColor = Color.OrangeRed;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(851, 699);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(237, 67);
            button2.TabIndex = 13;
            button2.Text = "Exportar para PDF";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.OrangeRed;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(851, 840);
            button3.Margin = new Padding(4, 5, 4, 5);
            button3.Name = "button3";
            button3.Size = new Size(237, 67);
            button3.TabIndex = 14;
            button3.Text = "Exportar par Excel";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Form6
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Tela_Login;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1143, 1000);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(button5);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form6";
            Text = "Form6";
            Load += Form6_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button5;
        private Button button1;
        private ComboBox comboBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Idlote;
        private DataGridViewTextBoxColumn nome_lote;
        private DataGridViewTextBoxColumn data_criação;
        private DataGridViewTextBoxColumn cliente;
        private DataGridViewTextBoxColumn status;
        private Button button2;
        private Button button3;
    }
}