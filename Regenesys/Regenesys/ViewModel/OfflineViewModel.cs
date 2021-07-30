using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RegenesysCore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Regenesys.ViewModel
{
    [Preserve(AllMembers = true)]
    public class OfflineViewModel : BaseViewModel
    {
        #region Constructor

        public OfflineViewModel() : base()
        {
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
                var photos = await PhotoDatabase.GetPhotosAsync();
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