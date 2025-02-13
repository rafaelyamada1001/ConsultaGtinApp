namespace Application.Interface
{
    public interface IApiService
    {
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
    }
}
