using System;
using System.Diagnostics;

namespace Xamarin.Forms
{

	[DebuggerDisplay("Location = {Location}")]
	public class ShellNavigationState
	{
		Uri _fullLocation;

		internal Uri FullLocation
		{
			get => _fullLocation;
			set
			{
				_fullLocation = value;
				Location = Routing.RemoveImplicit(value);
			}
		}

		public Uri Location
		{
			get;
			private set;
		}

		public ShellNavigationState() { }
<<<<<<< HEAD
		public ShellNavigationState(string location)
		{
			var uri = ShellUriHandler.CreateUri(location);

			if (uri.IsAbsoluteUri)
				uri = new Uri($"/{uri.PathAndQuery}", UriKind.Relative);

			FullLocation = uri;
		}

		public ShellNavigationState(Uri location) => FullLocation = location;
=======
		public ShellNavigationState(string location) => Location = new Uri(location, UriKind.RelativeOrAbsolute);
		public ShellNavigationState(Uri location) => Location = location;
>>>>>>> Update (#12)
		public static implicit operator ShellNavigationState(Uri uri) => new ShellNavigationState(uri);
		public static implicit operator ShellNavigationState(string value) => new ShellNavigationState(value);
	}
}
