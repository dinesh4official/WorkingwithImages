using System;
using CoreGraphics;
using Foundation;
using Regenesys.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(ExTabbedPageRenderer))]
namespace Regenesys.iOS.Renderer
{
    [Preserve(AllMembers = true)]
    public class ExTabbedPageRenderer : TabbedRenderer
    {
        #region Constructor

        public ExTabbedPageRenderer()
        {

        }

        #endregion

        #region Override Methods

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            foreach (var item in TabBar.Items)
            {
                item.Image = ScalingImageToSize(item.Image, new CGSize(40, 40));
            }
        }

        #endregion

        #region Methods

        UIImage ScalingImageToSize(UIImage sourceImage, CGSize newSize)
        {
            if (UIScreen.MainScreen.Scale == 2.0)
            {
                UIGraphics.BeginImageContextWithOptions(newSize, false, 2.0f);
            }
            else if (UIScreen.MainScreen.Scale == 3.0)
            {
                UIGraphics.BeginImageContextWithOptions(newSize, false, 3.0f);
            }
            else
            {
                UIGraphics.BeginImageContext(newSize);
            }

            sourceImage.Draw(new CGRect(0, 0, newSize.Width, newSize.Height));
            UIImage newImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();
            return newImage;
        }

        #endregion
    }
}
