namespace Xamarin.Forms.Platform.GTK
{
<<<<<<< HEAD
	internal class PlatformRenderer : GtkFormsContainer
=======
	internal class PlatformRenderer : EventBox
>>>>>>> Update from origin (#8)
	{
		public PlatformRenderer(Platform platform)
		{
			Platform = platform;
		}

		public Platform Platform { get; set; }
	}
}
