using System.Threading.Tasks;
using AImageView = Android.Widget.ImageView;

namespace Xamarin.Forms.Platform.Android
{
	internal static class ImageViewExtensions
	{
<<<<<<< HEAD
		public static Task UpdateBitmap(this AImageView imageView, IImageElement newView, IImageElement previousView) =>
=======
		public static Task UpdateBitmap(this AImageView imageView, IImageController newView, IImageController previousView) =>
>>>>>>> Update from origin (#11)
			imageView.UpdateBitmap(newView, previousView, null, null);

		public static Task UpdateBitmap(this AImageView imageView, ImageSource newImageSource, ImageSource previousImageSourc) =>
			imageView.UpdateBitmap(null, null, newImageSource, previousImageSourc);

<<<<<<< HEAD
		static async Task UpdateBitmap(
			this AImageView imageView,
			IImageElement newView,
			IImageElement previousView,
			ImageSource newImageSource,
			ImageSource previousImageSource)
		{

			IImageController imageController = newView as IImageController;
			newImageSource = newImageSource ?? newView?.Source;
			previousImageSource = previousImageSource ?? previousView?.Source;

			if (imageView.IsDisposed())
				return;

			if (newImageSource != null && Equals(previousImageSource, newImageSource))
=======
		// TODO hartez 2017/04/07 09:33:03 Review this again, not sure it's handling the transition from previousImage to 'null' newImage correctly
		static async Task UpdateBitmap(
			this AImageView imageView,
			IImageController newView,
			IImageController previousView,
			ImageSource newImageSource,
			ImageSource previousImageSource)
		{

			newImageSource = newView?.Source;
			previousImageSource = previousView?.Source;

			if (newImageSource == null || imageView.IsDisposed())
				return;

			if (Equals(previousImageSource, newImageSource))
>>>>>>> Update from origin (#11)
				return;

			newView?.SetIsLoading(true);

			(imageView as IImageRendererController)?.SkipInvalidate();
			imageView.SetImageResource(global::Android.Resource.Color.Transparent);

<<<<<<< HEAD
=======
			bool setByImageViewHandler = false;
			Bitmap bitmap = null;

>>>>>>> Update from origin (#11)
			try
			{
				if (newImageSource != null)
				{
					var imageViewHandler = Internals.Registrar.Registered.GetHandlerForObject<IImageViewHandler>(newImageSource);
					if (imageViewHandler != null)
					{
						await imageViewHandler.LoadImageAsync(newImageSource, imageView);
<<<<<<< HEAD
					}
					else
					{
						using (var drawable = await imageView.Context.GetFormsDrawableAsync(newImageSource))
						{
							// only set the image if we are still on the same one
							if (!imageView.IsDisposed() && Equals(newView?.Source, newImageSource))
								imageView.SetImageDrawable(drawable);
						}
					}
				}
				else
				{
					imageView.SetImageBitmap(null);
				}
			}
			finally
			{
				// only mark as finished if we are still working on the same image
				if (Equals(newView?.Source, newImageSource))
				{
					imageController?.SetIsLoading(false);
					imageController?.NativeSizeChanged();
				}
			}
=======
						setByImageViewHandler = true;
					}
					else
					{
						var imageSourceHandler = Internals.Registrar.Registered.GetHandlerForObject<IImageSourceHandler>(newImageSource);
						bitmap = await imageSourceHandler.LoadImageAsync(newImageSource, imageView.Context);
					}
				}
			}
			catch (TaskCanceledException)
			{
				newView?.SetIsLoading(false);
			}

			// Check if the source on the new image has changed since the image was loaded
			if (newView != null && !Equals(newView?.Source, newImageSource))
			{
				bitmap?.Dispose();
				return;
			}

			if (!setByImageViewHandler && !imageView.IsDisposed())
			{
				if (bitmap == null && newImageSource is FileImageSource)
					imageView.SetImageResource(ResourceManager.GetDrawableByName(((FileImageSource)newImageSource).File));
				else
					imageView.SetImageBitmap(bitmap);
			}

			bitmap?.Dispose();
			newView?.SetIsLoading(false);
>>>>>>> Update from origin (#11)
		}
	}
}
