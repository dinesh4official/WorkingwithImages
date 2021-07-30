using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using RegenesysCore.Interfaces;
using RegenesysCore.Models;
using RegenesysCore.Utils;
using Xamarin.Forms.Internals;

namespace Regenesys.Services
{
    [Preserve(AllMembers = true)]
    public class FirebaseClientService : IFirebaseClient<PhotoResult>
    {
        #region Constructor

        public FirebaseClientService()
        {

        }

        #endregion

        #region Properties

        FirebaseClient FirebaseClient { get; set; }

        #endregion

        #region Interface Methods

        public void CreateFirebaseClient(string url)
        {
            if (FirebaseClient == null)
            {
                FirebaseClient = new FirebaseClient(url);
            }
        }

        public async Task StoreDatainFirebaseClient(PhotoResult item, string resourceName)
        {
            var encodedData = JSONUtils.SerializeObject(item);
            await FirebaseClient.Child(resourceName).PostAsync(encodedData);
        }

        public async Task<List<PhotoResult>> GetItemsFromFirebaseClient(string resourceName)
        {
            return (await FirebaseClient.Child(resourceName).OnceAsync<PhotoResult>()).Select(item => new PhotoResult
            {
                PhotoId = item.Object.PhotoId,
                Id = item.Object.Id,
                Width = item.Object.Width,
                Height = item.Object.Height,
                ImageURL = item.Object.ImageURL,
                Photographer = item.Object.Photographer,
                PhotographerURL = item.Object.PhotographerURL,
                PhotographerId = item.Object.PhotographerId,
                AverageColor = item.Object.AverageColor,
                Source = item.Object.Source,
                IsLiked = item.Object.IsLiked,
                ImageBytes = item.Object.ImageBytes
            }).ToList();
        }

        public async Task<bool> HasItemInDB(PhotoResult item, string resourceName)
        {
            bool hasItem = (await FirebaseClient.Child(resourceName).
                OnceAsync<PhotoResult>()).Any(x => x.Object.PhotoId == item.PhotoId
                || x.Object.Id == item.Id);
            return hasItem;
        }

        #endregion
    }
}