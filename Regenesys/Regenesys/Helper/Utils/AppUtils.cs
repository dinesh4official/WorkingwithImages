using System;
using System.Threading.Tasks;
using Regenesys.Views;
using RegenesysCore.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Regenesys.Helper.Utils
{
    [Preserve(AllMembers = true)]
    public static class AppUtils
    {
        #region Public Methods

        public static void ShowAlert(string message, bool isLong = false)
        {
            if (isLong)
            {
                DependencyService.Get<IMessage>().LongAlert(message);
            }
            else
            {
                DependencyService.Get<IMessage>().ShortAlert(message);
            }
        }

        public static async Task ShowAlertwithCancel(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public static void NavigateToTabbedPage()
        {
            Application.Current.MainPage = new TabPage();
        }

        #endregion
    }
}

