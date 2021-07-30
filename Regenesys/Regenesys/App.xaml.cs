using System;
using Autofac;
using Regenesys.Views;
using RegenesysCore.Container;
using RegenesysCore.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Regenesys
{
    [Preserve(AllMembers = true)]
    public partial class App : Application
    {
        #region Fields

        INetworkDetector networkDetector;

        #endregion

        #region Constructor

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        #endregion

        #region Override Methods

        protected override void OnStart()
        {
            networkDetector = AppContainer.Current.Resolve<INetworkDetector>();
            networkDetector.WireDetectorEvent();
        }

        protected override void OnSleep()
        {
            networkDetector.UnWireDetectorEvent();
        }

        protected override void OnResume()
        {
            networkDetector.WireDetectorEvent();
        }

        #endregion
    }
}
