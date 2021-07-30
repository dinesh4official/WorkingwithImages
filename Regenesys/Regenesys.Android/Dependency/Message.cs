using System;
using Android.App;
using Android.Widget;
using RegenesysCore.Interfaces;
using Regenesys.Droid.Dependency;
using Xamarin.Forms.Internals;

[assembly: Xamarin.Forms.Dependency(typeof(Message))]
namespace Regenesys.Droid.Dependency
{
    [Preserve(AllMembers = true)]
    public class Message : IMessage
    {
        #region Constructor

        public Message()
        {

        }

        #endregion

        #region Interface Methods

        public void LongAlert(string message)
        {
            Android.Widget.Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }

        #endregion
    }
}
