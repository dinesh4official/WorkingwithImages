using System;
using System.Threading.Tasks;
using Android.Runtime;

namespace RegenesysCore.Interfaces
{
    [Preserve(AllMembers = true)]
    public interface IHTTPService
    {
        #region Methods

        Task<T> GetPhotosAsync<T>(string url, string apiKey);

        Task<byte[]> DownloadImageAsync<T>(string imageURL, string apiKey);

        #endregion
    }
}
