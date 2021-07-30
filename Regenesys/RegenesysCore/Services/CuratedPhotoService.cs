using System;
using System.Threading.Tasks;
using Android.Runtime;
using RegenesysCore.Constants;
using RegenesysCore.Extensions;
using RegenesysCore.Interfaces;
using RegenesysCore.Models;

namespace RegenesysCore.Services
{
    [Preserve(AllMembers = true)]
    public class CuratedPhotoService : ICuratedPhotoService
    {
        #region Fields

        private readonly IHTTPService _fHttpHelper;

        #endregion

        #region Constructor

        public CuratedPhotoService(IHTTPService httpHelper)
        {
            _fHttpHelper = httpHelper;
        }

        #endregion

        #region Properties

        public async Task<CuratedPhotoResponse> GetCuratedPhotoResponse(string nextPage = null)
        {
            string url = nextPage.IsBlank() ? APIConstants.BaseUrl + APIConstants.FirstPageEndUrl : nextPage;
            return await _fHttpHelper.GetPhotosAsync<CuratedPhotoResponse>(url, APIConstants.PexelsApiKey);
        }

        public async Task<byte[]> GetPhotoResponseAsBytes(string imageURL)
        {
            return await _fHttpHelper.DownloadImageAsync<byte[]>(imageURL, APIConstants.PexelsApiKey);
        }

        #endregion

    }
}
