namespace Programa_de_Gerenciamento_Industrial
{
    partial class Form8
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
            textBox2 = new TextBox();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label5 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Location = new Point(161, 431);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(255, 31);
            textBox2.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 437);
            label4.Name = "label4";
            label4.Size = new Size(105, 25);
            label4.TabIndex = 19;
            label4.Text = "Quantidade";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(184, 301);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 31);
            dateTimePicker1.TabIndex = 18;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(111, 370);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(293, 31);
            textBox3.TabIndex = 17;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(137, 224);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(293, 31);
            textBox1.TabIndex = 16;
            // 
            // button2
            // 
            button2.Location = new Point(356, 566);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 15;
            button2.Text = "Salvar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(52, 566);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 14;
            button1.Text = "Sair";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 370);
            label3.Name = "label3";
            label3.Size = new Size(60, 25);
            label3.TabIndex = 13;
            label3.Text = "Status";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 301);
            label2.Name = "label2";
            label2.Size = new Size(137, 25);
            label2.TabIndex = 12;
            label2.Text = "Data de Criaçao";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 227);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 11;
            label1.Text = "Conteúdo";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(268, 22);
            label5.Name = "label5";
            label5.Size = new Size(92, 25);
            label5.TabIndex = 21;
            label5.Text = "Editar lote";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(27, 143);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 22;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Form8
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Tela_Login;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(677, 637);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(textBox2);
            Controls.Add(label4);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            DoubleBuffered = true;
            Name = "Form8";
            Text = "Form8";
            Load += Form8_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox2;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox3;
        private TextBox textBox1;
        private Button button2;
        private Button button1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private ComboBox comboBox1;
    }
}