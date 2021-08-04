using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Regenesys.Helper.Utils;
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
                var photos = await PhotoDatabase.GetPhotosAsyncFromDB();
                await AddItemsinPhotosAsync(photos, null, null, false);
            }
            catch (Exception e)
            {
                AppUtils.ShowAlert(e.Message, true);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion

        #region Command Callbacks

        private async void OnPageAppearing()
        {
           await LoadItemsAsync();
        }

        #endregion
    }
}