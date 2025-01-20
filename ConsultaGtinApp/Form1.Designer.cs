namespace ConsultaGtinApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dgvConsultaGtin = new DataGridView();
            Descricao = new DataGridViewTextBoxColumn();
            Gtin = new DataGridViewTextBoxColumn();
            Cest = new DataGridViewTextBoxColumn();
            Ncm = new DataGridViewTextBoxColumn();
            btnConsultaGtin = new Button();
            lblConsultaGtin = new Label();
            pnlConsultaGtin = new Panel();
            txtConsultaGtin = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvConsultaGtin).BeginInit();
            pnlConsultaGtin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dgvConsultaGtin
            // 
            dgvConsultaGtin.AllowUserToAddRows = false;
            dgvConsultaGtin.AllowUserToDeleteRows = false;
            dgvConsultaGtin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaGtin.Columns.AddRange(new DataGridViewColumn[] { Descricao, Gtin, Cest, Ncm });
            dgvConsultaGtin.Location = new Point(12, 179);
            dgvConsultaGtin.Name = "dgvConsultaGtin";
            dgvConsultaGtin.ReadOnly = true;
            dgvConsultaGtin.Size = new Size(776, 259);
            dgvConsultaGtin.TabIndex = 0;
            // 
            // Descricao
            // 
            Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Descricao.DataPropertyName = "Produto";
            Descricao.HeaderText = "Descrição";
            Descricao.Name = "Descricao";
            Descricao.ReadOnly = true;
            // 
            // Gtin
            // 
            Gtin.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Gtin.DataPropertyName = "GTIN";
            Gtin.HeaderText = "GTIN";
            Gtin.Name = "Gtin";
            Gtin.ReadOnly = true;
            // 
            // Cest
            // 
            Cest.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Cest.DataPropertyName = "CEST";
            Cest.HeaderText = "CEST";
            Cest.Name = "Cest";
            Cest.ReadOnly = true;
            // 
            // Ncm
            // 
            Ncm.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Ncm.DataPropertyName = "NCM";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Ncm.DefaultCellStyle = dataGridViewCellStyle1;
            Ncm.HeaderText = "NCM";
            Ncm.Name = "Ncm";
            Ncm.ReadOnly = true;
            // 
            // btnConsultaGtin
            // 
            btnConsultaGtin.Location = new Point(241, 54);
            btnConsultaGtin.Name = "btnConsultaGtin";
            btnConsultaGtin.Size = new Size(75, 23);
            btnConsultaGtin.TabIndex = 1;
            btnConsultaGtin.Text = "Consultar";
            btnConsultaGtin.UseVisualStyleBackColor = true;
            btnConsultaGtin.Click += btnConsultaGtin_Click;
            // 
            // lblConsultaGtin
            // 
            lblConsultaGtin.AutoSize = true;
            lblConsultaGtin.Location = new Point(18, 25);
            lblConsultaGtin.Name = "lblConsultaGtin";
            lblConsultaGtin.Size = new Size(129, 15);
            lblConsultaGtin.TabIndex = 2;
            lblConsultaGtin.Text = "Digite um GTIN válido :";
            lblConsultaGtin.Click += lblConsultaGtin_Click;
            // 
            // pnlConsultaGtin
            // 
            pnlConsultaGtin.BorderStyle = BorderStyle.FixedSingle;
            pnlConsultaGtin.Controls.Add(txtConsultaGtin);
            pnlConsultaGtin.Controls.Add(lblConsultaGtin);
            pnlConsultaGtin.Controls.Add(btnConsultaGtin);
            pnlConsultaGtin.Location = new Point(15, 14);
            pnlConsultaGtin.Name = "pnlConsultaGtin";
            pnlConsultaGtin.Size = new Size(493, 132);
            pnlConsultaGtin.TabIndex = 3;
            // 
            // txtConsultaGtin
            // 
            txtConsultaGtin.Location = new Point(18, 54);
            txtConsultaGtin.Name = "txtConsultaGtin";
            txtConsultaGtin.Size = new Size(217, 23);
            txtConsultaGtin.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(558, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(196, 159);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(pnlConsultaGtin);
            Controls.Add(dgvConsultaGtin);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConsultaGtin).EndInit();
            pnlConsultaGtin.ResumeLayout(false);
            pnlConsultaGtin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvConsultaGtin;
        private Button btnConsultaGtin;
        private Label lblConsultaGtin;
        private Panel pnlConsultaGtin;
        private TextBox txtConsultaGtin;
        private PictureBox pictureBox1;
        private DataGridViewTextBoxColumn Descricao;
        private DataGridViewTextBoxColumn Gtin;
        private DataGridViewTextBoxColumn Cest;
        private DataGridViewTextBoxColumn Ncm;
    }
}
