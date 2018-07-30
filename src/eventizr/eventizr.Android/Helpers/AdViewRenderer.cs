using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Gms.Ads;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using eventizr.Controls;
using eventizr.Droid.Helpers;

[assembly: ExportRenderer(typeof(AdControlView), typeof(AdViewRenderer))]
namespace eventizr.Droid.Helpers
{ 
    public class AdViewRenderer : ViewRenderer<AdControlView, AdView>
    {
        string adUnitId = "KEY";
        AdSize adSize = AdSize.SmartBanner;
        AdView adView;

        AdView createAdView()
        {
            if (adView != null)
                return adView;


            adView = new AdView(Forms.Context);
            adView.AdSize = adSize;
            adView.AdUnitId = adUnitId;

            var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            adView.LayoutParameters = adParams;

            adView.LoadAd(new AdRequest.Builder().Build());

            return adView;


        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdControlView> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                createAdView();
                SetNativeControl(adView);
            }
        }

    }

}