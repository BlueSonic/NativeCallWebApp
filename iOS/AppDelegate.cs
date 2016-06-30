using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace NativeCallWebApp.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}

		public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
		{
			//イベントをURLで判断して処理
			if (url != null)
			{
				//イベントをURLで判断してネイティブ処理実行
				if (url.AbsoluteString.Contains("nativecallwebapp://"))
				{
					global::Xamarin.Forms.Application.Current.MainPage.DisplayAlert("open url schemes", url.AbsoluteString, "ok");
				}
			}
			return false;
		}
	}
}

