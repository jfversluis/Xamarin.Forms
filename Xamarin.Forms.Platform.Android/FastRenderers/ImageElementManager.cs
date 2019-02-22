using System.ComponentModel;
using System.Threading.Tasks;
using Android.Widget;
using AScaleType = Android.Widget.ImageView.ScaleType;
using ARect = Android.Graphics.Rect;
using System;
using Xamarin.Forms.Internals;
<<<<<<< HEAD
<<<<<<< HEAD
using AViewCompat = Android.Support.V4.View.ViewCompat;
=======
>>>>>>> Update from origin (#11)
=======
using AViewCompat = Android.Support.V4.View.ViewCompat;
>>>>>>> Update (#12)

namespace Xamarin.Forms.Platform.Android.FastRenderers
{
	public static class ImageElementManager
	{
		public static void Init(IVisualElementRenderer renderer)
		{
			renderer.ElementPropertyChanged += OnElementPropertyChanged;
			renderer.ElementChanged += OnElementChanged;
<<<<<<< HEAD

			if(renderer is ILayoutChanges layoutChanges)
				layoutChanges.LayoutChange += OnLayoutChange;
=======
			renderer.LayoutChange += OnLayoutChange;
>>>>>>> Update from origin (#11)
		}

		static void OnLayoutChange(object sender, global::Android.Views.View.LayoutChangeEventArgs e)
		{
			if(sender is IVisualElementRenderer renderer && renderer.View is ImageView imageView)
<<<<<<< HEAD
<<<<<<< HEAD
				AViewCompat.SetClipBounds(imageView, imageView.GetScaleType() == AScaleType.CenterCrop ? new ARect(0, 0, e.Right - e.Left, e.Bottom - e.Top) : null);
=======
				imageView.ClipBounds = imageView.GetScaleType() == AScaleType.CenterCrop ? new ARect(0, 0, e.Right - e.Left, e.Bottom - e.Top) : null;
>>>>>>> Update from origin (#11)
=======
				AViewCompat.SetClipBounds(imageView, imageView.GetScaleType() == AScaleType.CenterCrop ? new ARect(0, 0, e.Right - e.Left, e.Bottom - e.Top) : null);
>>>>>>> Update (#12)
		}

		public static void Dispose(IVisualElementRenderer renderer)
		{
			renderer.ElementPropertyChanged -= OnElementPropertyChanged;
			renderer.ElementChanged -= OnElementChanged;
<<<<<<< HEAD
			if (renderer is ILayoutChanges layoutChanges)
				layoutChanges.LayoutChange -= OnLayoutChange;

			if (renderer.View is ImageView imageView)
				imageView.SetImageDrawable(null);
=======
			renderer.LayoutChange -= OnLayoutChange;
>>>>>>> Update from origin (#11)
		}

		async static void OnElementChanged(object sender, VisualElementChangedEventArgs e)
		{
			var renderer = (sender as IVisualElementRenderer);
			var view = renderer.View as ImageView;
<<<<<<< HEAD
			var newImageElementManager = e.NewElement as IImageElement;
			var oldImageElementManager = e.OldElement as IImageElement;
=======
			var newImageElementManager = e.NewElement as IImageController;
			var oldImageElementManager = e.OldElement as IImageController;
>>>>>>> Update from origin (#11)
			var rendererController = renderer as IImageRendererController;

			await TryUpdateBitmap(rendererController, view, newImageElementManager, oldImageElementManager);
			UpdateAspect(rendererController, view, newImageElementManager, oldImageElementManager);

			if (!rendererController.IsDisposed)
			{
				ElevationHelper.SetElevation(view, renderer.Element);
			}
		}

		async static void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			var renderer = (sender as IVisualElementRenderer);
<<<<<<< HEAD
			var ImageElementManager = (IImageElement)renderer.Element;
			var imageController = (IImageController)renderer.Element;

			if (e.PropertyName == Image.SourceProperty.PropertyName ||
				e.PropertyName == Button.ImageSourceProperty.PropertyName)
			{
				try
				{
					await TryUpdateBitmap(renderer as IImageRendererController, (ImageView)renderer.View, (IImageElement)renderer.Element).ConfigureAwait(false);
=======
			var ImageElementManager = (IImageController)renderer.Element;
			if (e.PropertyName == ImageElementManager.SourceProperty?.PropertyName)
			{
				try
				{
					await TryUpdateBitmap(renderer as IImageRendererController, (ImageView)renderer.View, (IImageController)renderer.Element).ConfigureAwait(false);
>>>>>>> Update from origin (#11)
				}
				catch (Exception ex)
				{
					Log.Warning(renderer.GetType().Name, "Error loading image: {0}", ex);
				}
				finally
				{
<<<<<<< HEAD
					if(imageController != null)
						imageController?.SetIsLoading(false);
				}
			}
			else if (e.PropertyName == Image.AspectProperty.PropertyName)
			{
				UpdateAspect(renderer as IImageRendererController, (ImageView)renderer.View, (IImageElement)renderer.Element);
=======
					ImageElementManager?.SetIsLoading(false);
				}
			}
			else if (e.PropertyName == ImageElementManager.AspectProperty?.PropertyName)
			{
				UpdateAspect(renderer as IImageRendererController, (ImageView)renderer.View, (IImageController)renderer.Element);
>>>>>>> Update from origin (#11)
			}
		}


<<<<<<< HEAD
		async static Task TryUpdateBitmap(IImageRendererController rendererController, ImageView Control, IImageElement newImage, IImageElement previous = null)
=======
		async static Task TryUpdateBitmap(IImageRendererController rendererController, ImageView Control, IImageController newImage, IImageController previous = null)
>>>>>>> Update from origin (#11)
		{
			if (newImage == null || rendererController.IsDisposed)
			{
				return;
			}

			await Control.UpdateBitmap(newImage, previous).ConfigureAwait(false);
		}

<<<<<<< HEAD
		static void UpdateAspect(IImageRendererController rendererController, ImageView Control, IImageElement newImage, IImageElement previous = null)
=======
		static void UpdateAspect(IImageRendererController rendererController, ImageView Control, IImageController newImage, IImageController previous = null)
>>>>>>> Update from origin (#11)
		{
			if (newImage == null || rendererController.IsDisposed)
			{
				return;
			}

			ImageView.ScaleType type = newImage.Aspect.ToScaleType();
			Control.SetScaleType(type);
		}
	}
}