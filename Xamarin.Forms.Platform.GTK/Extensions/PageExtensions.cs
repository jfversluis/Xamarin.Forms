using System;

namespace Xamarin.Forms.Platform.GTK.Extensions
{
	public static class PageExtensions
	{
<<<<<<< HEAD
		public static GtkFormsContainer CreateContainer(this Page view)
=======
		internal static bool ShouldDisplayNativeWindow(this Page page)
		{
			var parentPage = page.Parent as Page;

			if (parentPage != null)
			{
				return string.IsNullOrEmpty(parentPage.BackgroundImage);
			}

			return true;
		}

<<<<<<< HEAD
		public static Gtk.EventBox CreateContainer(this Page view)
>>>>>>> Update from origin (#8)
=======
		public static GtkFormsContainer CreateContainer(this Page view)
>>>>>>> Update from origin (#11)
		{
			if (!Forms.IsInitialized)
				throw new InvalidOperationException("call Forms.Init() before this");

			if (!(view.RealParent is Application))
			{
				Application app = new DefaultApplication();
				app.MainPage = view;
			}

			var result = new Platform();
			result.SetPage(view);

			return result.PlatformRenderer;
		}

		class DefaultApplication : Application
		{
		}
	}
}
