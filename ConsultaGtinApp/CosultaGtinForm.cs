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
        public CosultaGtinForm()
        {
            string url = "https://dfe-servico.svrs.rs.gov.br/ws/ccgConsGTIN/ccgConsGTIN.asmx";
            string soapAction = "http://www.portalfiscal.inf.br/nfe/wsdl/ccgConsGtin/ccgConsGTIN";
            string certificadoCaminho = @"C:\Users\dev4lions1\Desktop\Certificados(atualizado)\SUPERMERCADO CANTARELLAS LTDA00423676000198 - COM VENC 13012026 - SENHA 123456.pfx";
            string certificadoSenha = "123456";

            var consGtinService = new ConsGtinService(url, soapAction, certificadoCaminho, certificadoSenha);
            _consultarGtinUseCase = new ConsultarGtinUseCase(consGtinService);

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
            try
            {
                string gtin = txtConsultaGtin.Text;

                await ConsultarGtinAsync(gtin);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}");
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

                        await ConsultarListaGtinAsync(gtins, maxSimultaneousTasks: 5);

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

        private async Task ConsultarGtinAsync(string gtin)
        {
            try
            {
                var result = await _consultarGtinUseCase.ExecutarAsync(gtin);
                var ret = result.Dados.ccgConsGTINResponse.nfeResultMsg.retConsGTIN;

                if (ret != null && !_lista.Any(item => item.GTIN == gtin))
                {
                    if (result.Dados.ccgConsGTINResponse.nfeResultMsg.retConsGTIN.xProd == null) return;
 
                    var gtinResult = new GtinResult
                    {
                        GTIN = ret.GTIN.ToString(),
                        Produto = ret.xProd,
                        NCM = ret.NCM.ToString() ?? string.Empty,
                        CEST = ret.CEST.ToString() ?? string.Empty,
                        Mensagem = ret.xMotivo,
                    };

                    _lista.Add(gtinResult);

                    Invoke((MethodInvoker)(() =>
                    {
                        dgvConsultaGtin.DataSource = null;
                        dgvConsultaGtin.DataSource = _lista;
                    }));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na consulta GTIN {gtin}: {ex.Message}");
            }
        }

        private async Task ConsultarListaGtinAsync(IEnumerable<string> gtins, int maxSimultaneousTasks = 5)
        {
            var semaphore = new SemaphoreSlim(maxSimultaneousTasks); 
            var tasks = new List<Task>();

            foreach (var gtin in gtins)
            {
                await semaphore.WaitAsync();

                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        await ConsultarGtinAsync(gtin);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao consultar GTIN {gtin}: {ex.Message}");
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }));
            }

            await Task.WhenAll(tasks);
        }
    }
}
