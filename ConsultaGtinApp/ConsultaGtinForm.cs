using Application.Interface;
using Application.UseCase;
using Domain;
using Infra.Service;
using Microsoft.VisualBasic;
using System.Xml.XPath;


namespace ConsultaGtinApp
{
    public partial class ConsultaGtinForm : Form
    {
        private readonly ConsultarGtinUseCase _consultarGtinUseCase;
        private readonly ConsultarListaGtinUseCase _consultarListaGtinUseCase;
        private readonly ICriarArquivoServico _criarArquivo = new ArquivoService();
        private readonly ExportarConsultaUseCase _exportarConsultaUseCase;
        private readonly ProcessarGtinUseCase _processarGtin = new ProcessarGtinUseCase();
        private List<GtinResult> _lista;

        public ConsultaGtinForm(ConsultarGtinUseCase consultarGtinUseCase, ConsultarListaGtinUseCase consultarListaGtinUseCase, ICriarArquivoServico criarArquivo, ExportarConsultaUseCase exportarConsultaUseCase, ProcessarGtinUseCase processarGtin)
        {
            _consultarGtinUseCase = consultarGtinUseCase;
            _consultarListaGtinUseCase = consultarListaGtinUseCase;
            _criarArquivo = criarArquivo;
            _exportarConsultaUseCase = exportarConsultaUseCase;
            _processarGtin = processarGtin;


            _lista = new List<GtinResult>();

            InitializeComponent();

            dgvConsultaGtin.AutoGenerateColumns = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblConsultaGtin_Click(object sender, EventArgs e)
        {

        }
        
        private bool HasGtinList(string gtin)
        {
            var hasGtin = from a in _lista where a.GTIN == gtin select a;
            return hasGtin.Count() == 0 ? false : true;
        }

        private async void btnConsultaGtin_Click(object sender, EventArgs e)
        {
            string gtin = txtConsultaGtin.Text;

            if (HasGtinList(gtin))
            {
                MessageBox.Show("Gtin já existe na lista", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = await _consultarGtinUseCase.ExecuteIIAsync(gtin);
            if (result.Produto == null) 
            {
                MessageBox.Show(result.Mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            
            _lista.Add(result);

            AtualizarGrid();
        }

        private async void btnImportCSV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos CSV (*.csv)|*.csv";

                if (openFileDialog.ShowDialog() != DialogResult.OK) { return; }

                try
                {
                    var gtins = File.ReadAllLines(openFileDialog.FileName);
                    var responses = await _consultarListaGtinUseCase.Execute(gtins, maxSimultaneousTasks: 4);
                    //var sucess = (from a in responses where a.Sucesso == true select a).ToList();

                    //foreach (var response in sucess)
                    //    _lista.Add(_processarGtin.Execute(response));

                    AtualizarGrid();

                    MessageBox.Show("Importação e consulta finalizadas com sucesso!", "Sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao importar o arquivo: {ex.Message}");
                }
            }
        }

        private void btnExportarCSV_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dirDialog = new FolderBrowserDialog())
            {
                // Mostra a janela de escolha do directorio
                DialogResult res = dirDialog.ShowDialog();
                if (res == DialogResult.OK)
                {
                    // Como o utilizador carregou no OK, o directorio escolhido pode ser acedido da seguinte forma:
                    string directorio = dirDialog.SelectedPath;
                    _exportarConsultaUseCase.Executar(_lista, directorio);
                    MessageBox.Show("Exportação finalizada com sucesso!", "Sucesso!");
                }
            }
        }
        private void AtualizarGrid()
        {
            dgvConsultaGtin.DataSource = Refresh;
            dgvConsultaGtin.DataSource = _lista;
        }
    }
}
