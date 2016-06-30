using NativeCallWebApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(BaseUrl))]
namespace NativeCallWebApp.Droid
{
	public class BaseUrl : IBaseUrl
	{
		public string Get()
		{
			return "file:///android_asset/webdir/";
		}
	}
}