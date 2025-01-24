using Application.DTO;
using Application.UseCase;
using Domain;
using Infra.Service;
using System.Text;

namespace ConsultaGtinApp
{
    public partial class CosultaGtinForm : Form
    {
        private readonly ConsultarGtinUseCase _consultarGtinUseCase;
        private readonly List<GtinResult> _lista;
        private readonly ConsultarListaGtinUseCase _consultarListaGtinUseCase;
        public CosultaGtinForm()
        {
            string url = "https://dfe-servico.svrs.rs.gov.br/ws/ccgConsGTIN/ccgConsGTIN.asmx";
            string soapAction = "http://www.portalfiscal.inf.br/nfe/wsdl/ccgConsGtin/ccgConsGTIN";
            string certificadoCaminho = @"C:\Users\dev4lions1\Desktop\Certificados(atualizado)\SUPERMERCADO CANTARELLAS LTDA00423676000198 - COM VENC 13012026 - SENHA 123456.pfx";
            string certificadoSenha = "123456";

            var consGtinService = new ConsGtinService(url, soapAction, certificadoCaminho, certificadoSenha);
            _consultarGtinUseCase = new ConsultarGtinUseCase(consGtinService);

            var consultarListaGtinUseCase = new ConsultarListaGtinUseCase(_consultarGtinUseCase);
            _consultarListaGtinUseCase = consultarListaGtinUseCase;

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
                MessageBox.Show($"Erro:{response.Mensagem}","Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
            }
            if (response.Sucesso)
            {               
                ProcessarGtinResult(response);
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

                        var responses = await _consultarListaGtinUseCase.Execute(gtins, maxSimultaneousTasks: 5);

                        foreach (var response in responses)
                        {
                            ProcessarGtinResult(response);
                        }

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
            string diretorio = "C:\\Arquivos CSV";
            try
            {
                string nomeArquivo = $"dados_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                string caminhoArquivo = Path.Combine(diretorio, nomeArquivo);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("GTIN; Produto; NCM; CEST; Mesagem");
                foreach (var linha in _lista)
                {
                    sb.AppendLine($"{linha.GTIN};{linha.Produto};{linha.NCM};{linha.CEST};{linha.Mensagem}");
                }
                File.WriteAllText(caminhoArquivo, sb.ToString());
                MessageBox.Show("Exportação concluída com sucesso!", "Sucesso!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao tentar exportar{ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ProcessarGtinResult(ResponseDefault<retConsGTIN> response)
        {
            if (response.Sucesso && !_lista.Any(item => item.GTIN == response.Dados.GTIN.ToString()))
            {
                var gtinResult = new GtinResult
                {
                    GTIN = response.Dados.GTIN.ToString(),
                    Produto = response.Dados.xProd,
                    NCM = response.Dados.NCM.ToString(),
                    CEST = response.Dados.CEST.ToString(),
                    Mensagem = response.Dados.xMotivo,
                };

                _lista.Add(gtinResult);

                Invoke((MethodInvoker)(() =>
                {
                    dgvConsultaGtin.DataSource = null;
                    dgvConsultaGtin.DataSource = _lista;
                }));
            }
        }
    }
}
