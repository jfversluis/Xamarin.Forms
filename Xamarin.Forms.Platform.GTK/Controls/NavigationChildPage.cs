using System;

namespace Xamarin.Forms.Platform.GTK.Controls
{
<<<<<<< HEAD
	public class NavigationChildPage : IDisposable
=======
	public class NavigationChildPage : Gtk.Object
>>>>>>> Update from origin (#8)
	{
		bool _disposed;

		public NavigationChildPage(Xamarin.Forms.Page page)
		{
			Page = page;
			Identifier = Guid.NewGuid().ToString();
		}

<<<<<<< HEAD
		public void Dispose()
=======
		public override void Dispose()
>>>>>>> Update from origin (#8)
		{
			if (!_disposed)
			{
				_disposed = true;
				Page = null;
			}
<<<<<<< HEAD
		}

		public string Identifier { get; set; }

=======

			base.Dispose();
		}

		public string Identifier { get; set; }

>>>>>>> Update from origin (#8)
		public Xamarin.Forms.Page Page { get; private set; }
	}
}
