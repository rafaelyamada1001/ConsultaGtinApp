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
                        var linhas = File.ReadAllLines(openFileDialog.FileName);
                        var gtins = new List<string>(linhas);

                        foreach (var gtin in gtins)
                        {
                            await ConsultarGtinAsync(gtin);
                        }

                        MessageBox.Show("Importação e consulta finalizadas com sucesso!","Sucesso!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao importar o arquivo: {ex.Message}");
                    }
                }
            }
        }
        private async Task ConsultarGtinAsync(string gtin)
        {
            var result = await _consultarGtinUseCase.ExecutarAsync(gtin);

            var ret = result.Dados.ccgConsGTINResponse.nfeResultMsg.retConsGTIN;

            if (result.Dados.ccgConsGTINResponse.nfeResultMsg.retConsGTIN != null)
            {

                if (_lista.Any(item => item.GTIN == gtin))
                {
                    //MessageBox.Show($"O GTIN: {gtin} já está na lista.","Erro",MessageBoxButtons.OK ,MessageBoxIcon.Warning);
                    return;
                }

                if (result.Dados.ccgConsGTINResponse.nfeResultMsg.retConsGTIN.xProd == null)
                {
                    //MessageBox.Show($"GTIN:{ret.GTIN} \n{ret.xMotivo}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var gtinResult = new GtinResult
                {
                    GTIN = ret.GTIN.ToString(),
                    Produto = ret.xProd,
                    NCM = ret.NCM.ToString(),
                    CEST = ret.CEST.ToString(),
                    Mensagem = ret.xMotivo,
                };

                _lista.Add(gtinResult);

                dgvConsultaGtin.DataSource = null;
                dgvConsultaGtin.DataSource = _lista;
            }
            else
            {
                //MessageBox.Show($"GTIN {gtin} inválido ou não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
                MessageBox.Show("Exportação concluída com sucesso!","Sucesso!", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Falha ao tentar exportar{ex.Message}","Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
