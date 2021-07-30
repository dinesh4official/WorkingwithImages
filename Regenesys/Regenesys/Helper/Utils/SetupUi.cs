using System;
using Autofac;
using Regenesys.Services;
using RegenesysCore.Interfaces;
using RegenesysCore.Models;
using Xamarin.Forms.Internals;

namespace Regenesys.Helper.Utils
{
    [Preserve(AllMembers = true)]
    public class SetupUi : ISetup
    {
        #region Methods

        public void Init(ContainerBuilder builder)
        {
            //Network Detector
            builder.RegisterType<NetworkDetector>().As<INetworkDetector>().SingleInstance();

            //Firebase Database
            builder.RegisterType<FirebaseClientService>().As<IFirebaseClient<PhotoResult>>().SingleInstance();
        }

        public void MakeOSSpecificUpdates()
        {

        }

        #endregion
    }
}
