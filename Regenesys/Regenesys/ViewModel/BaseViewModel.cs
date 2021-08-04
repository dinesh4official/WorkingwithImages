using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using RegenesysCore.Constants;
using RegenesysCore.Container;
using RegenesysCore.Interfaces;
using RegenesysCore.Models;
using Xamarin.Forms.Internals;

namespace Regenesys.ViewModel
{
    [Preserve(AllMembers = true)]
    public class BaseViewModel : NotifyListener
    {
        #region Fields

        bool _fIsBusy;

        #endregion

        #region Constructor

        public BaseViewModel()
        {
            Photos = new ObservableCollection<PhotoResult>();
            NetworkDetector = AppContainer.Current.Resolve<INetworkDetector>();
            PhotoDatabase = AppContainer.Current.Resolve<IPhotoDatabase<PhotoResult>>();
        }

        #endregion

        #region Properties

        public bool IsBusy
        {
            get => _fIsBusy;
            set
            {
                _fIsBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public INetworkDetector NetworkDetector { get; }

        public ObservableCollection<PhotoResult> Photos { get; }

        public IPhotoDatabase<PhotoResult> PhotoDatabase { get; }

        public ICommand PageAppearingCommand { get; set; }

        public ICommand PageDisappearingCommand { get; set; }

        #endregion

        #region Methods

        public async Task AddItemsinPhotosAsync(List<PhotoResult> photos,
            ICuratedPhotoService service, IFirebaseClient<PhotoResult> firebaseClient,
            bool addDataInDB)
        {
            var tempPhotos = Photos.ToList();
            var databaseItems = addDataInDB ? await PhotoDatabase.GetPhotosAsyncFromDB() : null;

            photos.ForEach((PhotoResult obj) =>
            {
                bool hasitem = HasItem(tempPhotos, obj);
                if (!hasitem)
                {
                    Photos.Add(obj);

                    if (addDataInDB)
                    {
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                        {
                            await StoreItemsInDatabase(databaseItems, obj, service);
                            await StoreItemsInFirebase(obj, firebaseClient);
                        });
                    }
                }
            });
        }

        bool HasItem(List<PhotoResult> photoResults, PhotoResult photoResult)
        {
            return photoResults != null && photoResults.Any(x => x.PhotoId == photoResult.PhotoId);
        }

        async Task StoreItemsInDatabase(List<PhotoResult> photoResults, PhotoResult photoResult, ICuratedPhotoService service)
        {
            bool hasIteminDB = HasItem(photoResults, photoResult);
            if (!hasIteminDB)
            {
                byte[] imageBytes = await service.GetPhotoResponseAsBytes(photoResult.Source.Medium);
                photoResult.ImageBytes = imageBytes;
                await PhotoDatabase.StorePhotoAsyncInDB(photoResult);
            }
        }

        async Task StoreItemsInFirebase(PhotoResult photoResult, IFirebaseClient<PhotoResult> service)
        {
            bool hasIteminDB = await service.HasItemInDB(photoResult, AppConstants.PhotoResult);
            if (!hasIteminDB)
            {
                await service.StoreDatainFirebaseClient(photoResult, AppConstants.PhotoResult);
            }
        }

        #endregion
    }
}
