using System;
using System.Threading.Tasks;
using Autofac;
using RegenesysCore.Constants;
using RegenesysCore.Container;
using RegenesysCore.Interfaces;
using RegenesysCore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Regenesys.ViewModel
{
    [Preserve(AllMembers = true)]
    public class FirebaseViewModel : BaseViewModel
    {
        #region Fields

        IFirebaseClient<PhotoResult> _fIFirebaseClient;

        #endregion

        #region Constructor

        public FirebaseViewModel()
        {
            _fIFirebaseClient = AppContainer.Current.Resolve<IFirebaseClient<PhotoResult>>();
            PageAppearingCommand = new Command(OnPageAppearing);
        }

        #endregion

        #region Load Pages

        async Task LoadItemsAsync()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                Photos.Clear();
                var photos = await _fIFirebaseClient.GetItemsFromFirebaseClient(AppConstants.PhotoResult);
                await AddItemsinPhotosAsync(photos, null, null, false);
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion

        #region Command Callbacks

        private void OnPageAppearing()
        {
            IsDBCollection = true;
            _ = LoadItemsAsync();
        }

        #endregion
    }
}
