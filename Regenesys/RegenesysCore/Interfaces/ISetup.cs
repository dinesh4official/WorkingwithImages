using System;
using Android.Runtime;
using Autofac;

namespace RegenesysCore.Interfaces
{
    [Preserve(AllMembers = true)]
    public interface ISetup
    {
        #region Methods

        void Init(ContainerBuilder builder);

        #endregion
    }

}
