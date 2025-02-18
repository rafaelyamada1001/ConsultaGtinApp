using Application.Interface;
using Application.UseCase;
using Infra.Builder;
using Infra.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultaGtinApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Configura��o do cont�iner de servi�os
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                // Resolve o formul�rio principal
                var cosultaGtinForm = serviceProvider.GetRequiredService<ConsultaGtinForm>();
                System.Windows.Forms.Application.Run(cosultaGtinForm);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Adicionando depend�ncias espec�ficas
            string url = "https://dfe-servico.svrs.rs.gov.br/ws/ccgConsGTIN/ccgConsGTIN.asmx";
            string soapAction = "http://www.portalfiscal.inf.br/nfe/wsdl/ccgConsGtin/ccgConsGTIN";
            string certificadoCaminho = @"C:\Users\dev4lions1\Desktop\Certificados(atualizado)\SUPERMERCADO CANTARELLAS LTDA00423676000198 - COM VENC 13012026 - SENHA 123456.pfx";
            string certificadoSenha = "123456";

            // Injetando as implementa��es e casos de uso
            services.AddTransient<ICriarArquivoServico, ArquivoService>();
            services.AddTransient<IConsGtinService>(provider => new ConsGtinService(url, soapAction, certificadoCaminho, certificadoSenha));
            services.AddTransient<ISoapEnvelopeBuilder, SoapEnvelopeBuilder>();
            services.AddTransient<ConsultarGtinUseCase>();
            services.AddTransient<ConsultarListaGtinUseCase>();
            services.AddTransient<ExportarConsultaUseCase>();

            // Registro do formul�rio principal
            services.AddTransient<ConsultaGtinForm>();
        }
    }
}