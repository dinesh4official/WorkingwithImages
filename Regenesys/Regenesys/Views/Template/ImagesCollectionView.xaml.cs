using System;
using Regenesys.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Regenesys.Views.Template
{
    [Preserve(AllMembers = true)]
    public partial class ImagesCollectionView : CollectionView
    {
        #region Bindable Properties

        public static readonly BindableProperty BaseViewModelProperty = BindableProperty.Create(nameof(BaseViewModel),
            typeof(BaseViewModel), typeof(ImagesCollectionView), null);


        #endregion

        #region Constructor

        public ImagesCollectionView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public BaseViewModel BaseViewModel
        {
            get => (BaseViewModel)GetValue(BaseViewModelProperty);
            set => SetValue(BaseViewModelProperty, value);
        }

        #endregion

    }
}
