namespace ConsultaGtinApp
{
    partial class CosultaGtinForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CosultaGtinForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgvConsultaGtin = new DataGridView();
            btnConsultaGtin = new Button();
            lblConsultaGtin = new Label();
            pnlConsultaGtin = new Panel();
            btnImportCSV = new Button();
            txtConsultaGtin = new TextBox();
            btnExportarCSV = new Button();
            pictureBox1 = new PictureBox();
            Descricao = new DataGridViewTextBoxColumn();
            Gtin = new DataGridViewTextBoxColumn();
            Cest = new DataGridViewTextBoxColumn();
            Ncm = new DataGridViewTextBoxColumn();
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
            dgvConsultaGtin.Size = new Size(810, 259);
            dgvConsultaGtin.TabIndex = 0;
            // 
            // btnConsultaGtin
            // 
            btnConsultaGtin.Location = new Point(241, 54);
            btnConsultaGtin.Name = "btnConsultaGtin";
            btnConsultaGtin.Size = new Size(95, 23);
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
            pnlConsultaGtin.Controls.Add(btnImportCSV);
            pnlConsultaGtin.Controls.Add(txtConsultaGtin);
            pnlConsultaGtin.Controls.Add(lblConsultaGtin);
            pnlConsultaGtin.Controls.Add(btnConsultaGtin);
            pnlConsultaGtin.Location = new Point(15, 14);
            pnlConsultaGtin.Name = "pnlConsultaGtin";
            pnlConsultaGtin.Size = new Size(519, 132);
            pnlConsultaGtin.TabIndex = 3;
            // 
            // btnImportCSV
            // 
            btnImportCSV.Location = new Point(342, 54);
            btnImportCSV.Name = "btnImportCSV";
            btnImportCSV.Size = new Size(95, 23);
            btnImportCSV.TabIndex = 4;
            btnImportCSV.Text = "Importar CSV";
            btnImportCSV.UseVisualStyleBackColor = true;
            btnImportCSV.Click += btnImportCSV_Click;
            // 
            // txtConsultaGtin
            // 
            txtConsultaGtin.Location = new Point(18, 54);
            txtConsultaGtin.Name = "txtConsultaGtin";
            txtConsultaGtin.PlaceholderText = "Digite aqui...";
            txtConsultaGtin.Size = new Size(217, 23);
            txtConsultaGtin.TabIndex = 3;
            // 
            // btnExportarCSV
            // 
            btnExportarCSV.Location = new Point(727, 453);
            btnExportarCSV.Name = "btnExportarCSV";
            btnExportarCSV.Size = new Size(95, 27);
            btnExportarCSV.TabIndex = 5;
            btnExportarCSV.Text = "Exportar CSV";
            btnExportarCSV.UseVisualStyleBackColor = true;
            btnExportarCSV.Click += btnExportarCSV_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(557, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(196, 159);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
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
            Ncm.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Ncm.DataPropertyName = "NCM";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Ncm.DefaultCellStyle = dataGridViewCellStyle1;
            Ncm.HeaderText = "NCM";
            Ncm.Name = "Ncm";
            Ncm.ReadOnly = true;
            Ncm.Width = 60;
            // 
            // CosultaGtinForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(834, 492);
            Controls.Add(btnExportarCSV);
            Controls.Add(pictureBox1);
            Controls.Add(pnlConsultaGtin);
            Controls.Add(dgvConsultaGtin);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            Name = "CosultaGtinForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consultar Gtin";
            TopMost = true;
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
        private Button btnImportCSV;
        private Button btnExportarCSV;
        private DataGridViewTextBoxColumn Descricao;
        private DataGridViewTextBoxColumn Gtin;
        private DataGridViewTextBoxColumn Cest;
        private DataGridViewTextBoxColumn Ncm;
    }
}
