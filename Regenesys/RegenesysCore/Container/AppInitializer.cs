using System;
using Android.Runtime;
using Autofac;
using RegenesysCore.Interfaces;
using RegenesysCore.Models;
using RegenesysCore.Services;

namespace RegenesysCore.Container
{
    [Preserve(AllMembers = true)]
    public static class AppInitializer
    {
        #region Methods

        public static void Init(ISetup setup)
        {
            RegisterDependencies(setup);
        }

        static void RegisterDependencies(ISetup setup)
        {
            var builder = new ContainerBuilder();

            //Helpers
            builder.RegisterType<HTTPService>().As<IHTTPService>().SingleInstance();
            builder.RegisterType<CuratedPhotoService>().As<ICuratedPhotoService>().SingleInstance();
            builder.RegisterType<PhotoDatabase>().As<IPhotoDatabase<PhotoResult>>().SingleInstance();

            //Forms UI
            setup.Init(builder);

            AppContainer.Current = builder.Build(Autofac.Builder.ContainerBuildOptions.None);
        }

        #endregion
    }
}
