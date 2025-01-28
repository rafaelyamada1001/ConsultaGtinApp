using Application.DTO;
using Application.Interface;
using Application.UseCase;
using Domain;
using Infra.Service;


namespace ConsultaGtinApp
{
    public partial class CosultaGtinForm : Form
    {
        private readonly ConsultarGtinUseCase _consultarGtinUseCase;
        private readonly ConsultarListaGtinUseCase _consultarListaGtinUseCase;
        private readonly ICriarArquivoServico _criarArquivo = new ArquivoService();
        private readonly ExportarConsultaUseCase _exportarConsultaUseCase;
        private readonly GtinResultProcessor _gtinResultProcessor = new GtinResultProcessor();
        private List<GtinResult> _lista;
        public CosultaGtinForm
            (ConsultarGtinUseCase consultarGtinUseCase, ConsultarListaGtinUseCase consultarListaGtinUseCase, ExportarConsultaUseCase exportarConsultaUseCase, ICriarArquivoServico criarArquivoServico, GtinResultProcessor gtinResultProcessor)
        {
            string url = "https://dfe-servico.svrs.rs.gov.br/ws/ccgConsGTIN/ccgConsGTIN.asmx";
            string soapAction = "http://www.portalfiscal.inf.br/nfe/wsdl/ccgConsGtin/ccgConsGTIN";
            string certificadoCaminho = @"C:\Users\dev4lions1\Desktop\Certificados(atualizado)\SUPERMERCADO CANTARELLAS LTDA00423676000198 - COM VENC 13012026 - SENHA 123456.pfx";
            string certificadoSenha = "123456";

            _consultarGtinUseCase = consultarGtinUseCase;
            _consultarListaGtinUseCase = consultarListaGtinUseCase;
            _exportarConsultaUseCase = exportarConsultaUseCase;
            _criarArquivo = criarArquivoServico;
            _gtinResultProcessor = gtinResultProcessor;

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

        private async void btnConsultaGtin_Click(object sender, EventArgs e)
        {
            string gtin = txtConsultaGtin.Text;

            var response = await _consultarGtinUseCase.Execute(gtin);
            if (!response.Sucesso)
            {
                MessageBox.Show($"Erro:{response.Mensagem}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (response.Sucesso)
            {
                var gtinResult = _gtinResultProcessor.Processar(response);
                _lista.Add(gtinResult);
                AtualizarGrid();
            }
        }

        private async void btnImportCSV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos CSV (*.csv)|*.csv";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var gtins = File.ReadAllLines(openFileDialog.FileName);

                        var responses = await _consultarListaGtinUseCase.Execute(gtins, maxSimultaneousTasks: 4);

                        foreach (var response in responses)
                        {
                            if (response.Sucesso)
                            {
                                var gtinResult = _gtinResultProcessor.Processar(response);
                                _lista.Add(gtinResult);
                            }
                        }
                        AtualizarGrid();

                        MessageBox.Show("Importação e consulta finalizadas com sucesso!", "Sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao importar o arquivo: {ex.Message}");
                    }
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
                else
                {

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
