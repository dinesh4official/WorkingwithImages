using System;
using System.Threading.Tasks;
using Android.Runtime;
using RegenesysCore.Models;

namespace RegenesysCore.Interfaces
{
    [Preserve(AllMembers = true)]
    public interface ICuratedPhotoService
    {
        #region Methods

        Task<CuratedPhotoResponse> GetCuratedPhotoResponse(string nextPage = null);

        Task<byte[]> GetPhotoResponseAsBytes(string imageURL);

        #endregion
    }
}
