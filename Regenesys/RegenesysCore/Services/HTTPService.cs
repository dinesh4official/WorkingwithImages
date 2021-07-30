using System;
using System.Net.Http;
using System.Threading.Tasks;
using Android.Runtime;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RegenesysCore.Constants;
using RegenesysCore.Extensions;
using RegenesysCore.Interfaces;

namespace RegenesysCore.Services
{
    [Preserve(AllMembers = true)]
    public class HTTPService : IHTTPService
    {
        #region Constructor

        public HTTPService()
        {

        }

        #endregion

        #region Interface Methods

        public async Task<T> GetPhotosAsync<T>(string url, string apiKey)
        {
            using (var client = new HttpClient())
            {
                if (!apiKey.IsBlank())
                {
                    client.DefaultRequestHeaders.Add(AppConstants.Authorization, apiKey);
                }
                using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    using (var response = await client.SendAsync(request))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            return default;
                        }

                        var result = await response.Content.ReadAsStringAsync();

                        if (result.IsBlank()) { return default; }

                        if (result != AppConstants.Error)
                        {
                            return JsonConvert.DeserializeObject<T>(result, new JsonSerializerSettings
                            {
                                Error = HandleDeserializationError
                            });
                        }

                        return default;
                    }
                }
            }
        }

        public async Task<byte[]> DownloadImageAsync<T>(string imageURL, string apiKey)
        {
            using (var client = new HttpClient())
            {
                if (!apiKey.IsBlank())
                {
                    client.DefaultRequestHeaders.Add(AppConstants.Authorization, apiKey);
                }
                using (var request = new HttpRequestMessage(HttpMethod.Get, imageURL))
                {
                    using (var response = await client.SendAsync(request))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            return null;
                        }

                        var result = await response.Content.ReadAsByteArrayAsync();
                        return result;
                    }
                }
            }
        }

        #endregion

        #region Methods

        void HandleDeserializationError(object sender, ErrorEventArgs e)
        {
            e.ErrorContext.Handled = true;
        }

        #endregion
    }
}
