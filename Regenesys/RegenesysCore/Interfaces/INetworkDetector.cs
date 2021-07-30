using System;
using Android.Runtime;

namespace RegenesysCore.Interfaces
{
    [Preserve(AllMembers = true)]
    public interface INetworkDetector
    {
        #region Properties

        bool HasNetworkConnection { get; set; }

        #endregion

        #region Methods

        void WireDetectorEvent();

        void UnWireDetectorEvent();

        #endregion
    }
}
