using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using NativeCallWebApp;
using NativeCallWebApp.Droid;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace NativeCallWebApp.Droid
{
	public class CustomWebViewRenderer : WebViewRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
		{
			base.OnElementChanged(e);
			if (Control == null) return;

			Control.Settings.DomStorageEnabled = true;
			Control.Settings.JavaScriptEnabled = true;

			//javascriptのfileスキームへのアクセス許可
			Control.Settings.AllowFileAccessFromFileURLs = true;
			Control.Settings.AllowUniversalAccessFromFileURLs = true;

			//Xamarin.Formのコントロール(CustomWebView)
			CustomWebView _formsWebView = (CustomWebView)e.NewElement;
			//ネイティブコントロール(Android.Webkit.WebView)
			Android.Webkit.WebView _droidWebView = this.Control;

			//Xamarin.FormのWebViewではNavigateのイベントを拾えないためWebViewClientを上書きする
			_droidWebView.SetWebViewClient(new CustomWebViewClient(_formsWebView));
		}
	}

	public class CustomWebViewClient : Android.Webkit.WebViewClient
	{
		private readonly CustomWebView _formsWebView;

		public CustomWebViewClient(CustomWebView formsWebView)
		{
			_formsWebView = formsWebView;
		}

		public override bool ShouldOverrideUrlLoading(Android.Webkit.WebView view, string url)
		{
			if (url != null) { 
				Console.WriteLine(url);

				//イベントをURLで判断してネイティブ処理実行
				if (url.Contains("nativecallwebapp://")) {
					
					Application.Current.MainPage.DisplayAlert("open url schemes", url, "ok");

					//Web処理のキャンセル
					view.StopLoading();
				}

			}
			return false;
		}
	}
}