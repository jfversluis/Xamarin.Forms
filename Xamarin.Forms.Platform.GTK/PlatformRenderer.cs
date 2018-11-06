namespace Xamarin.Forms.Platform.GTK
{
<<<<<<< HEAD
<<<<<<< HEAD
	internal class PlatformRenderer : GtkFormsContainer
=======
	internal class PlatformRenderer : EventBox
>>>>>>> Update from origin (#8)
=======
	internal class PlatformRenderer : GtkFormsContainer
>>>>>>> Update from origin (#11)
	{
		public PlatformRenderer(Platform platform)
		{
			Platform = platform;
		}

		public Platform Platform { get; set; }
	}
}
