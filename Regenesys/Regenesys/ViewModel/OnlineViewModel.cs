using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Autofac;
using Regenesys.Services;
using RegenesysCore.Constants;
using RegenesysCore.Container;
using RegenesysCore.Extensions;
using RegenesysCore.Interfaces;
using RegenesysCore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Regenesys.ViewModel
{
    [Preserve(AllMembers = true)]
    public class OnlineViewModel : BaseViewModel, IPhotoViewModel
    {
        #region Fields

        ICuratedPhotoService _fCuratedPhotoService;
        CuratedPhotoResponse _fCuratedPhotoResponse;
        IFirebaseClient<PhotoResult> _fIFirebaseClient;

        #endregion

        #region Constructor

        public OnlineViewModel() : base()
        {
            _fCuratedPhotoService = AppContainer.Current.Resolve<ICuratedPhotoService>();
            _fIFirebaseClient = AppContainer.Current.Resolve<IFirebaseClient<PhotoResult>>();
            LoadItemsInPage = new Command(async () => await LoadItemsAsync());
            _fIFirebaseClient.CreateFirebaseClient(APIConstants.FirebaseDBApiKey);
            _ = LoadItemsAsync();
        }

        #endregion

        #region Properties

        public int ItemsThreshold { get; set; } = 0;

        public ICommand LoadItemsInPage { get; }

        #endregion

        #region Load Pages

        async Task LoadItemsAsync()
        {
            if (IsBusy)
            {
                return;
            }
            else if (!NetworkDetector.HasNetworkConnection)
            {
                IsBusy = false;
                return;
            }

            IsBusy = true;

            if (ItemsThreshold <= 0)
            {
                await LoadPagesAsync();
            }
            else
            {
                await LoadPagesAsync(_fCuratedPhotoResponse?.NextPageURL);
            }

            ItemsThreshold = Photos.Count + 15;
        }

        async Task LoadPagesAsync(string url = null)
        {
            try
            {
                _fCuratedPhotoResponse = await _fCuratedPhotoService.GetCuratedPhotoResponse(url);

                if (_fCuratedPhotoResponse.IsNull() || _fCuratedPhotoResponse.Photos.IsNull()) { return; }

                await AddItemsinPhotosAsync(_fCuratedPhotoResponse.Photos, _fCuratedPhotoService, _fIFirebaseClient, true);

            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion
    }
}
