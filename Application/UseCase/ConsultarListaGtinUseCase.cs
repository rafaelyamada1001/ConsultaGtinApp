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
        public async Task<List<GtinResult>> ExecuteAsync(IEnumerable<string> gtins, int maxSimultaneousTasks = 5)
        {
            var semaphore = new SemaphoreSlim(maxSimultaneousTasks);
            var tasks = new List<Task<GtinResult>>();

            foreach (var gtin in gtins)
            {
                tasks.Add(Task.Run(async () =>
                {
                    await semaphore.WaitAsync();
                    var result = await _consultarGtinUseCase.ExecuteIIAsync(gtin);
                    semaphore.Release();
                    return result;
                }));
            }

            var results = await Task.WhenAll(tasks);

            return results.Where(r => r.Produto != null).ToList();
        }
    }
}