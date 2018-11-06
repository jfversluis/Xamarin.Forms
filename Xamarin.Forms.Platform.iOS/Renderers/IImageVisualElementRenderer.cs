<<<<<<< HEAD
﻿#if __MOBILE__
using NativeImageView = UIKit.UIImageView;
using NativeImage = UIKit.UIImage;
namespace Xamarin.Forms.Platform.iOS
#else
using NativeImageView = AppKit.NSImageView;
using NativeImage = AppKit.NSImage;
namespace Xamarin.Forms.Platform.MacOS
#endif
{
	public interface IImageVisualElementRenderer : IVisualNativeElementRenderer
	{
		void SetImage(NativeImage image);
		bool IsDisposed { get; }
		NativeImageView GetImage();
=======
﻿using UIKit;

namespace Xamarin.Forms.Platform.iOS
{
	public interface IImageVisualElementRenderer : IVisualNativeElementRenderer
	{
		void SetImage(UIImage image);
		bool IsDisposed { get; }
		UIImageView GetImage();
>>>>>>> Update from origin (#11)
	}
}