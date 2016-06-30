using System;

using Xamarin.Forms;

namespace NativeCallWebApp
{
	public class CustomWebView : WebView { }

	public interface IBaseUrl { string Get(); }

	public class App : Application
	{
		public App()
		{
			CustomWebView FormsWebView = new CustomWebView { Source = GetHTML() };

			// The root page of your application
			var content = new ContentPage
			{
				Title = "NativeCallWebApp",
				Content = FormsWebView
			};
			MainPage = content;
		}

		private HtmlWebViewSource GetHTML()
		{
			HtmlWebViewSource html = new HtmlWebViewSource
			{
				Html = @"<!DOCTYPE html>
						 <meta http-equiv=""refresh"" content=""0;URL=./page-a.html""/>
						 </html>",
				BaseUrl = DependencyService.Get<IBaseUrl>().Get()
			};
			return html;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

