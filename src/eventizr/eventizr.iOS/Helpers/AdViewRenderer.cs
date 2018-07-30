using System;
using CoreGraphics;
using eventizr.Controls;
using eventizr.iOS.Helpers;
using Google.MobileAds;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(AdControlView), typeof(AdViewRenderer))]
namespace eventizr.iOS.Helpers
{
    public class AdViewRenderer: ViewRenderer<Controls.AdControlView, BannerView>
    {

        string bannerId = "KEY";
        BannerView adView;

        BannerView CreateNativeAdControl()
        {
            if (adView != null)
                return adView;

            adView = new BannerView(AdSizeCons.SmartBannerPortrait)
            {
                AdUnitID = bannerId
            };
           
            adView.LoadRequest(GetRequest());
            return adView;
        }

        Request GetRequest()
        {
            var request = Request.GetDefaultRequest();
            return request;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdControlView> e)
        {
            base.OnElementChanged(e);
           

            UIViewController viewCtrl = null;

            foreach (UIWindow v in UIApplication.SharedApplication.Windows)
            {
                if (v.RootViewController != null)
                {
                    viewCtrl = v.RootViewController;
                }
            }
                      
            adView = new BannerView(size: AdSizeCons.SmartBannerPortrait, origin: new CGPoint(-10, 0))
            {
                AdUnitID = bannerId,
                RootViewController = viewCtrl
            };

            adView.LoadRequest(GetRequest());
            base.SetNativeControl(adView);
        }



    }
}
