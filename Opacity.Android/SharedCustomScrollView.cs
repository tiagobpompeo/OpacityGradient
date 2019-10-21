using System;
using Android.Content;
using Opacity;
using Opacity.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ScrollViewCustomRenderer), typeof(SharedCustomScrollViews))]
namespace Opacity.Droid
{
	public class SharedCustomScrollViews : ScrollViewRenderer
	{
		public SharedCustomScrollViews(Context context) : base(context)
		{
			this.SetFadingEdgeLength(300);
			this.VerticalFadingEdgeEnabled = true;
		}
	}
}
