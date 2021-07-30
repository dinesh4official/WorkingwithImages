using System;
using System.Windows.Input;
using Autofac;
using Regenesys.Helper.Utils;
using RegenesysCore.Container;
using RegenesysCore.Interfaces;
using RegenesysCore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Regenesys.ViewModel
{
    [Preserve(AllMembers = true)]
    public class MainPageViewModel : NotifyListener
    {
        #region Fields

        bool _fIsBusy;

        #endregion

        #region Constructor

        public MainPageViewModel()
        {
            NavigateTo = new Command(NavigateToTabbedPage);
        }

        #endregion

        #region Properties

        public ICommand NavigateTo { get; set; }

        public bool IsBusy
        {
            get => _fIsBusy;
            set
            {
                _fIsBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        #endregion

        #region Callbacks

        async void NavigateToTabbedPage()
        {
            try
            {
                IsBusy = true;
                var database = AppContainer.Current.Resolve<IPhotoDatabase<PhotoResult>>();
                await database.CreateTableAsync();
            }
            catch (Exception e)
            {
                IsBusy = false;
                AppUtils.ShowAlert(e.Message);
            }
            finally
            {
                IsBusy = false;
                AppUtils.NavigateToTabbedPage();
            }
        }

        #endregion
    }
}

