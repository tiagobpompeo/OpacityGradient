using System;
using System.Runtime.Remoting.Contexts;
using Opacity;
using Opacity.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using System;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreAnimation;
using Foundation;

[assembly: ExportRenderer(typeof(ScrollViewCustomRenderer), typeof(SharedCustomScrollViews))]
namespace Opacity.iOS
{
    public class SharedCustomScrollViews : ScrollViewRenderer
    {
        private CAGradientLayer gradientLayer;
        private Double FadePercentage = 0.2;
        private CGColor OpaqueColor = UIColor.Black.CGColor;
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            //UpdateScrollView();
        }
        public override void ScrollRectToVisible(CGRect rect, bool animated)
        {
            base.ScrollRectToVisible(rect, animated);
        }
       
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            gradientLayer = new CAGradientLayer();
            gradientLayer.Frame = rect;
            var maskLayer = new CALayer();
            gradientLayer.Colors = new CGColor[] { topOpacity(), OpaqueColor, OpaqueColor, bottomOpacity() };
            gradientLayer.Locations = new NSNumber[] { 0, (NSNumber)FadePercentage, (NSNumber)(1 - FadePercentage), 1 };
            maskLayer.AddSublayer(gradientLayer);
            this.Layer.Mask = maskLayer;
            
        }


        private CGColor topOpacity()
        {
            var scrollViewHeight = Frame.Size.Height;
            var scrollContentSizeHeight = ContentSize.Height;
            var scrollOffset = ContentOffset.Y;
            nfloat alpha = (scrollViewHeight >= scrollContentSizeHeight || scrollOffset <= 0) ? 1 : 0;
            var color = new UIColor(white: 0, alpha: alpha);
            return color.CGColor;
        }

        private CGColor bottomOpacity()
        {
            var scrollViewHeight = Frame.Size.Height;
            var scrollContentSizeHeight = ContentSize.Height;
            var scrollOffset = ContentOffset.Y;
            nfloat alpha = (scrollViewHeight >= scrollContentSizeHeight || scrollOffset + scrollViewHeight >= scrollContentSizeHeight) ? 1 : 0;
            var color = new UIColor(white: 0, alpha: alpha);
            return color.CGColor;
        }

        private void UpdateScrollView()
        {
            // test with Bounces
            ContentInset = new UIKit.UIEdgeInsets(0, 0, 0, 0);
            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
                ContentInsetAdjustmentBehavior = UIKit.UIScrollViewContentInsetAdjustmentBehavior.Never;
            Bounces = false;
            ScrollIndicatorInsets = new UIKit.UIEdgeInsets(0, 0, 0, 0);
        }

    }
}
