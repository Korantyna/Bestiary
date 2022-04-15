using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bestiary.DataAccess
{
    public class APIDataProvider : IDisposable
    {
        private readonly HttpClient _client;

        private bool _disposed;

        public APIDataProvider()
        {
            _client = new HttpClient();
        }

        public async Task<T> GetFromJsonAsync<T>(string url) where T : class
        {
            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonString) ?? throw new JsonSerializationException($"{typeof(T)} could not be deserialized.");
        }


        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _disposed == false)
            {
                _client.Dispose();
                _disposed = true;
            }
        }

        #endregion
    }
}