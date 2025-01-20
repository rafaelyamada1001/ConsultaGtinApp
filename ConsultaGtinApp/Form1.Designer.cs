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
            dgvConsultaGtin = new DataGridView();
            btnConsultaGtin = new Button();
            lblConsultaGtin = new Label();
            pnlConsultaGtin = new Panel();
            txtConsultaGtin = new TextBox();
            Descricao = new DataGridViewTextBoxColumn();
            Gtin = new DataGridViewTextBoxColumn();
            Cest = new DataGridViewTextBoxColumn();
            Ncm = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvConsultaGtin).BeginInit();
            pnlConsultaGtin.SuspendLayout();
            SuspendLayout();
            // 
            // dgvConsultaGtin
            // 
            dgvConsultaGtin.AllowUserToAddRows = false;
            dgvConsultaGtin.AllowUserToDeleteRows = false;
            dgvConsultaGtin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaGtin.Columns.AddRange(new DataGridViewColumn[] { Descricao, Gtin, Cest, Ncm });
            dgvConsultaGtin.Location = new Point(12, 199);
            dgvConsultaGtin.Name = "dgvConsultaGtin";
            dgvConsultaGtin.ReadOnly = true;
            dgvConsultaGtin.Size = new Size(776, 239);
            dgvConsultaGtin.TabIndex = 0;
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
            pnlConsultaGtin.Size = new Size(493, 159);
            pnlConsultaGtin.TabIndex = 3;
            // 
            // txtConsultaGtin
            // 
            txtConsultaGtin.Location = new Point(18, 54);
            txtConsultaGtin.Name = "txtConsultaGtin";
            txtConsultaGtin.Size = new Size(217, 23);
            txtConsultaGtin.TabIndex = 3;
            // 
            // Descricao
            // 
            Descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Descricao.DataPropertyName = "Produto";
            Descricao.HeaderText = "Descrição";
            Descricao.Name = "Descricao";
            Descricao.ReadOnly = true;
            Descricao.Width = 83;
            // 
            // Gtin
            // 
            Gtin.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Gtin.DataPropertyName = "GTIN";
            Gtin.HeaderText = "GTIN";
            Gtin.Name = "Gtin";
            Gtin.ReadOnly = true;
            Gtin.Width = 58;
            // 
            // Cest
            // 
            Cest.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Cest.DataPropertyName = "CEST";
            Cest.HeaderText = "CEST";
            Cest.Name = "Cest";
            Cest.ReadOnly = true;
            Cest.Width = 58;
            // 
            // Ncm
            // 
            Ncm.DataPropertyName = "NCM";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Ncm.DefaultCellStyle = dataGridViewCellStyle1;
            Ncm.HeaderText = "NCM";
            Ncm.Name = "Ncm";
            Ncm.ReadOnly = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlConsultaGtin);
            Controls.Add(dgvConsultaGtin);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvConsultaGtin).EndInit();
            pnlConsultaGtin.ResumeLayout(false);
            pnlConsultaGtin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvConsultaGtin;
        private Button btnConsultaGtin;
        private Label lblConsultaGtin;
        private Panel pnlConsultaGtin;
        private TextBox txtConsultaGtin;
        private DataGridViewTextBoxColumn Descricao;
        private DataGridViewTextBoxColumn Gtin;
        private DataGridViewTextBoxColumn Cest;
        private DataGridViewTextBoxColumn Ncm;
    }
}
