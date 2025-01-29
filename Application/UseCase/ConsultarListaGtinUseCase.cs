using Application.DTO;
using Domain;

namespace Application.UseCase
{
    public class ConsultarListaGtinUseCase
    {
        private readonly ConsultarGtinUseCase _consultarGtinUseCase;
 

        public ConsultarListaGtinUseCase(ConsultarGtinUseCase consultarGtinUseCase)
        {
            _consultarGtinUseCase = consultarGtinUseCase;

        }
        public async Task<List<ResponseDefault<retConsGTIN>>> Execute(IEnumerable<string> gtins, int maxSimultaneousTasks = 5)
        {
            var semaphore = new SemaphoreSlim(maxSimultaneousTasks);
            var tasks = new List<Task<ResponseDefault<retConsGTIN>>>();

            foreach (var gtin in gtins)
            {
                await semaphore.WaitAsync();

                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        return await _consultarGtinUseCase.ExecuteAsync(gtin);
                    }
                    catch (Exception ex)
                    {
                        return new ResponseDefault<retConsGTIN>(false, $"Erro ao consultar GTIN {gtin}: {ex.Message}", null);
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }));
            }

            var results = await Task.WhenAll(tasks);

            return results.ToList();
        }
    }
}