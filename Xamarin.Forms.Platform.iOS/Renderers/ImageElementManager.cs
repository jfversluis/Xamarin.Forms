using System;
<<<<<<< HEAD
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Foundation;
using Xamarin.Forms.Internals;

#if __MOBILE__
using UIKit;
using NativeImage = UIKit.UIImage;
namespace Xamarin.Forms.Platform.iOS
#else
using AppKit;
using CoreAnimation;
using NativeImage = AppKit.NSImage;
namespace Xamarin.Forms.Platform.MacOS
#endif
=======
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace Xamarin.Forms.Platform.iOS
>>>>>>> Update from origin (#11)
{
	public static class ImageElementManager
	{
		public static void Init(IImageVisualElementRenderer renderer)
		{
			renderer.ElementPropertyChanged += OnElementPropertyChanged;
			renderer.ElementChanged += OnElementChanged;
			renderer.ControlChanged += OnControlChanged;
		}

		public static void Dispose(IImageVisualElementRenderer renderer)
		{
			renderer.ElementPropertyChanged -= OnElementPropertyChanged;
			renderer.ElementChanged -= OnElementChanged;
			renderer.ControlChanged -= OnControlChanged;
		}


		static void OnControlChanged(object sender, EventArgs e)
		{
			var renderer = sender as IImageVisualElementRenderer;
<<<<<<< HEAD
			var imageElement = renderer.Element as IImageElement;
=======
			var imageElement = renderer.Element as IImageController;
>>>>>>> Update from origin (#11)
			SetAspect(renderer, imageElement);
			SetOpacity(renderer, imageElement);
		}

		static void OnElementChanged(object sender, VisualElementChangedEventArgs e)
		{
			if (e.NewElement != null)
			{
				var renderer = sender as IImageVisualElementRenderer;
<<<<<<< HEAD
				var imageElement = renderer.Element as IImageElement;
=======
				var imageElement = renderer.Element as IImageController;
>>>>>>> Update from origin (#11)

				SetAspect(renderer, imageElement);
				SetOpacity(renderer, imageElement);
			}
		}

		static void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			var renderer = sender as IImageVisualElementRenderer;
<<<<<<< HEAD
			var imageElement = renderer.Element as IImageElement;

			if (e.PropertyName == Image.IsOpaqueProperty.PropertyName)
				SetOpacity(renderer, renderer.Element as IImageElement);
			else if (e.PropertyName == Image.AspectProperty.PropertyName)
				SetAspect(renderer, renderer.Element as IImageElement);
=======
			var imageElement = renderer.Element as IImageController;

			if (e.PropertyName == imageElement.IsOpaqueProperty?.PropertyName)
				SetOpacity(renderer, renderer.Element as IImageController);
			else if (e.PropertyName == imageElement.AspectProperty?.PropertyName)
				SetAspect(renderer, renderer.Element as IImageController);
>>>>>>> Update from origin (#11)
		}



<<<<<<< HEAD
		public static void SetAspect(IImageVisualElementRenderer renderer, IImageElement imageElement)
=======
		public static void SetAspect(IImageVisualElementRenderer renderer, IImageController imageElement)
>>>>>>> Update from origin (#11)
		{
			var Element = renderer.Element;
			var Control = renderer.GetImage();


			if (renderer.IsDisposed || Element == null || Control == null)
			{
				return;
			}
<<<<<<< HEAD
#if __MOBILE__
			Control.ContentMode = imageElement.Aspect.ToUIViewContentMode();
#else
			Control.Layer.ContentsGravity = imageElement.Aspect.ToNSViewContentMode();
#endif
		}

		public static void SetOpacity(IImageVisualElementRenderer renderer, IImageElement imageElement)
=======

			Control.ContentMode = imageElement.Aspect.ToUIViewContentMode();
		}

		public static void SetOpacity(IImageVisualElementRenderer renderer, IImageController imageElement)
>>>>>>> Update from origin (#11)
		{
			var Element = renderer.Element;
			var Control = renderer.GetImage();

			if (renderer.IsDisposed || Element == null || Control == null)
			{
				return;
			}
<<<<<<< HEAD
#if __MOBILE__
			Control.Opaque = imageElement.IsOpaque;
#else
			(Control as FormsNSImageView)?.SetIsOpaque(imageElement.IsOpaque);
#endif
		}

		public static async Task SetImage(IImageVisualElementRenderer renderer, IImageElement imageElement, Image oldElement = null)
		{
			_ = renderer ?? throw new ArgumentNullException(nameof(renderer), $"{nameof(ImageElementManager)}.{nameof(SetImage)} {nameof(renderer)} cannot be null");
			_ = imageElement ?? throw new ArgumentNullException(nameof(imageElement), $"{nameof(ImageElementManager)}.{nameof(SetImage)} {nameof(imageElement)} cannot be null");
<<<<<<< HEAD
=======

			Control.Opaque = imageElement.IsOpaque;
		}

		public static async Task SetImage(IImageVisualElementRenderer renderer, IImageController imageElement, Image oldElement = null)
		{
			_ = renderer ?? throw new ArgumentNullException($"{nameof(ImageElementManager)}.{nameof(SetImage)} {nameof(renderer)} cannot be null");
			_ = imageElement ?? throw new ArgumentNullException($"{nameof(ImageElementManager)}.{nameof(SetImage)} {nameof(imageElement)} cannot be null");
>>>>>>> Update from origin (#11)
=======
>>>>>>> Update (#12)

			var Element = renderer.Element;
			var Control = renderer.GetImage();

			if (renderer.IsDisposed || Element == null || Control == null)
			{
				return;
			}

<<<<<<< HEAD
			var imageController = imageElement as IImageController;

=======
>>>>>>> Update from origin (#11)
			var source = imageElement.Source;
		
#if __MOBILE__
			if (Control.Image?.Images != null && Control.Image.Images.Length > 1)
			{
				renderer.SetImage(null);
			} else
#endif
			if (oldElement != null)
			{
				var oldSource = oldElement.Source;
				if (Equals(oldSource, source))
					return;

<<<<<<< HEAD
				if (oldSource is FileImageSource oldFile && source is FileImageSource newFile && oldFile == newFile)
=======
				if (oldSource is FileImageSource && source is FileImageSource && ((FileImageSource)oldSource).File == ((FileImageSource)source).File)
>>>>>>> Update from origin (#11)
					return;

				renderer.SetImage(null);
			}

<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> Update (#12)
			imageController?.SetIsLoading(true);
			try
			{
				var uiimage = await source.GetNativeImageAsync();
<<<<<<< HEAD

				if (renderer.IsDisposed)
					return;

				// only set if we are still on the same image
				if (Control != null && imageElement.Source == source)
					renderer.SetImage(uiimage);
				else
					uiimage?.Dispose();
			}
			finally
			{
				// only mark as finished if we are still on the same image
				if (imageElement.Source == source)
					imageController?.SetIsLoading(false);
			}

			(imageElement as IViewController)?.NativeSizeChanged();
		}

		internal static async Task<NativeImage> GetNativeImageAsync(this ImageSource source, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (source == null || source.IsEmpty)
				return null;

			var handler = Internals.Registrar.Registered.GetHandlerForObject<IImageSourceHandler>(source);
			if (handler == null)
				return null;

			try
			{


#if __MOBILE__
				float scale = (float)UIScreen.MainScreen.Scale;
#else
				float scale = (float)NSScreen.MainScreen.BackingScaleFactor;
#endif

				return await handler.LoadImageAsync(source, scale: scale, cancelationToken: cancellationToken);
			}
			catch (OperationCanceledException)
			{
				Log.Warning("Image loading", "Image load cancelled");
			}
			catch (Exception ex)
			{
				Log.Warning("Image loading", $"Image load failed: {ex}");
			}

			return null;
		}

#if __MOBILE__
		internal static Task ApplyNativeImageAsync(this IShellContext shellContext, BindableObject bindable, BindableProperty imageSourceProperty, Action<UIImage> onSet, Action<bool> onLoading = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			_ = shellContext ?? throw new ArgumentNullException(nameof(shellContext));
			var renderer = shellContext as IVisualElementRenderer ?? throw new InvalidOperationException($"The shell context {shellContext.GetType()} must be a {typeof(IVisualElementRenderer)}.");

			return renderer.ApplyNativeImageAsync(bindable, imageSourceProperty, onSet, onLoading, cancellationToken);
		}
#endif
		internal static Task ApplyNativeImageAsync(this IVisualElementRenderer renderer, BindableProperty imageSourceProperty, Action<NativeImage> onSet, Action<bool> onLoading = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			return renderer.ApplyNativeImageAsync(null, imageSourceProperty, onSet, onLoading, cancellationToken);
		}

		internal static async Task ApplyNativeImageAsync(this IVisualElementRenderer renderer, BindableObject bindable, BindableProperty imageSourceProperty, Action<NativeImage> onSet, Action<bool> onLoading = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			_ = renderer ?? throw new ArgumentNullException(nameof(renderer));
			_ = imageSourceProperty ?? throw new ArgumentNullException(nameof(imageSourceProperty));
			_ = onSet ?? throw new ArgumentNullException(nameof(onSet));

			// TODO: it might be good to make sure the renderer has not been disposed

			// makse sure things are good before we start
			var element = bindable ?? renderer.Element;

			var nativeRenderer = renderer as IVisualNativeElementRenderer;

			if (element == null || renderer.NativeView == null || (nativeRenderer != null && nativeRenderer.Control == null))
				return;

			onLoading?.Invoke(true);
			if (element.GetValue(imageSourceProperty) is ImageSource initialSource && !initialSource.IsEmpty)
			{
				try
				{
					using (var drawable = await initialSource.GetNativeImageAsync(cancellationToken))
					{
						// TODO: it might be good to make sure the renderer has not been disposed

						// we are back, so update the working element
						element = bindable ?? renderer.Element;

						// makse sure things are good now that we are back
						if (element == null || renderer.NativeView == null || (nativeRenderer != null && nativeRenderer.Control == null))
							return;

						// only set if we are still on the same image
						if (element.GetValue(imageSourceProperty) == initialSource)
							onSet(drawable);
					}
				}
				finally
				{
					if (element != null && onLoading != null)
					{
						// only mark as finished if we are still on the same image
						if (element.GetValue(imageSourceProperty) == initialSource)
							onLoading.Invoke(false);
					}
				}
			}
			else
			{
				onSet(null);
				onLoading?.Invoke(false);
			}
		}

		internal static async Task ApplyNativeImageAsync(this BindableObject bindable, BindableProperty imageSourceProperty, Action<NativeImage> onSet, Action<bool> onLoading = null, CancellationToken cancellationToken = default(CancellationToken))
		{
			_ = bindable ?? throw new ArgumentNullException(nameof(bindable));
			_ = imageSourceProperty ?? throw new ArgumentNullException(nameof(imageSourceProperty));
			_ = onSet ?? throw new ArgumentNullException(nameof(onSet));

			onLoading?.Invoke(true);
			if (bindable.GetValue(imageSourceProperty) is ImageSource initialSource)
			{
				try
				{
					using (var nsimage = await initialSource.GetNativeImageAsync(cancellationToken))
					{
						// only set if we are still on the same image
						if (bindable.GetValue(imageSourceProperty) == initialSource)
							onSet(nsimage);
					}
				}
				finally
				{
					if (onLoading != null)
					{
						// only mark as finished if we are still on the same image
						if (bindable.GetValue(imageSourceProperty) == initialSource)
							onLoading.Invoke(false);
					}
				}
			}
			else
			{
				onSet(null);
				onLoading?.Invoke(false);
			}
		}
	}
}
=======
			IImageSourceHandler handler;
			imageElement.SetIsLoading(true);
			try
			{
				if (source != null &&
				   (handler = Internals.Registrar.Registered.GetHandlerForObject<IImageSourceHandler>(source)) != null)
				{
					UIImage uiimage;
					try
					{
						uiimage = await handler.LoadImageAsync(source, scale: (float)UIScreen.MainScreen.Scale);
					}
					catch (OperationCanceledException)
					{
						uiimage = null;
					}

					if (renderer.IsDisposed)
						return;

					var imageView = Control;
					if (imageView != null)
					{
						renderer.SetImage(uiimage);
					}
				}
				else
				{
					renderer.SetImage(null);
				}
=======
				if (renderer.IsDisposed)
					return;
>>>>>>> Update (#12)

				renderer.SetImage(Control == null ? null : uiimage);
			}
			finally
			{
				imageElement.SetIsLoading(false);
			}

			(imageElement as IViewController)?.NativeSizeChanged();
		}

		internal static async Task<UIImage> GetNativeImageAsync(this ImageSource source, CancellationToken cancellationToken = default(CancellationToken))
		{
			IImageSourceHandler handler;
			if (source != null && (handler = Internals.Registrar.Registered.GetHandlerForObject<IImageSourceHandler>(source)) != null)
			{
				try
				{
					return await handler.LoadImageAsync(source, scale: (float)UIScreen.MainScreen.Scale, cancelationToken: cancellationToken);
				}
				catch (OperationCanceledException ex)
				{
					Internals.Log.Warning(source.GetType().Name, "Error loading image: {0}", ex);
				}
			}

			return null;
		}
	}
}
>>>>>>> Update from origin (#11)
