using System;
using System.Windows.Input;
using Android.Runtime;

namespace RegenesysCore.Interfaces
{
    [Preserve(AllMembers = true)]
    public interface IPhotoViewModel
    {
        #region Properties

        int ItemsThreshold { get; set; }

        ICommand LoadItemsInPage { get; }

        #endregion
    }
}
