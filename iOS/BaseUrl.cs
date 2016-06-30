using NativeCallWebApp.iOS;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl))]
namespace NativeCallWebApp.iOS
{
	public class BaseUrl : IBaseUrl
	{
		public string Get()
		{
			return NSBundle.MainBundle.BundlePath + "/webdir";
		}
	}
}