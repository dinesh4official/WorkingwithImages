using System;
using Regenesys.Helper.Utils;
using RegenesysCore.Constants;
using RegenesysCore.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Regenesys.Services
{
    [Preserve(AllMembers = true)]
    public class NetworkDetector : INetworkDetector
    {
        #region Constructor

        public NetworkDetector()
        {
            HasNetworkConnection = Connectivity.NetworkAccess == NetworkAccess.Internet;
        }

        #endregion

        #region Properties

        public bool HasNetworkConnection { get; set; }

        #endregion

        #region Public Methods

        public void WireDetectorEvent()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }

        public void UnWireDetectorEvent()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }

        #endregion

        #region Callback Methods


        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            HasNetworkConnection = e.NetworkAccess == NetworkAccess.Internet;
            MessagingCenter.Send<INetworkDetector, bool>(this, AppConstants.NetworkDetector, HasNetworkConnection);
            if (HasNetworkConnection)
            {
                AppUtils.ShowAlert(AppConstants.AvailableConnection);
            }
            else
            {
                AppUtils.ShowAlert(AppConstants.NoConnection, true);
            }
        }

        #endregion

    }
}
