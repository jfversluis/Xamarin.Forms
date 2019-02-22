<<<<<<< HEAD
using System;
=======
﻿using System;
>>>>>>> Update from origin (#11)
using System.ComponentModel;
using Android.Content;
using Android.Support.V7.Widget;
using AView = Android.Views.View;
using Android.Views;
using Xamarin.Forms.Internals;
using AColor = Android.Graphics.Color;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Android.Graphics.Drawables;
using Android.Graphics;
using Xamarin.Forms.Platform.Android.FastRenderers;
using Android.OS;

namespace Xamarin.Forms.Platform.Android
{
	public class ImageButtonRenderer :
		AppCompatImageButton,
		IVisualElementRenderer,
		IBorderVisualElementRenderer,
		IImageRendererController,
		AView.IOnFocusChangeListener,
		AView.IOnClickListener,
<<<<<<< HEAD
		AView.IOnTouchListener,
		ILayoutChanges,
		IDisposedState
=======
		AView.IOnTouchListener
>>>>>>> Update from origin (#11)
	{
		bool _inputTransparent;
		bool _disposed;
		bool _skipInvalidate;
		int? _defaultLabelFor;
		VisualElementTracker _tracker;
		VisualElementRenderer _visualElementRenderer;
		BorderBackgroundManager _backgroundTracker;
		IPlatformElementConfiguration<PlatformConfiguration.Android, ImageButton> _platformElementConfiguration;
		private ImageButton _imageButton;

		public event EventHandler<VisualElementChangedEventArgs> ElementChanged;
		public event EventHandler<PropertyChangedEventArgs> ElementPropertyChanged;

		void IVisualElementRenderer.UpdateLayout() => _tracker?.UpdateLayout();
<<<<<<< HEAD
		VisualElement IVisualElementRenderer.Element => Element;
		AView IVisualElementRenderer.View => this;
		ViewGroup IVisualElementRenderer.ViewGroup => null;
		VisualElementTracker IVisualElementRenderer.Tracker => _tracker;		
		bool IDisposedState.IsDisposed => _disposed;

		public ImageButton Element
		{
			get => _imageButton;
			private set
=======
		VisualElement IVisualElementRenderer.Element => ImageButton;
		AView IVisualElementRenderer.View => this;
		ViewGroup IVisualElementRenderer.ViewGroup => null;
		VisualElementTracker IVisualElementRenderer.Tracker => _tracker;

		ImageButton ImageButton
		{
			get => _imageButton;
			set
>>>>>>> Update from origin (#11)
			{
				_imageButton = value;
				_platformElementConfiguration = null;
			}
		}

		void IImageRendererController.SkipInvalidate() => _skipInvalidate = true;
		bool IImageRendererController.IsDisposed => _disposed;

		AppCompatImageButton Control => this;
		public ImageButtonRenderer(Context context) : base(context)
		{
			// These set the defaults so visually it matches up with other platforms
			SetPadding(0, 0, 0, 0);
			SoundEffectsEnabled = false;
			SetOnClickListener(this);
			SetOnTouchListener(this);
			OnFocusChangeListener = this;

<<<<<<< HEAD
			// Setting the tag will break Glide
			// Tag = this;

=======
			Tag = this;
>>>>>>> Update from origin (#11)
			_backgroundTracker = new BorderBackgroundManager(this, false);
		}

		protected override void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			_disposed = true;

			if (disposing)
			{

				ImageElementManager.Dispose(this);

				_tracker?.Dispose();
				_tracker = null;

				_backgroundTracker?.Dispose();
				_backgroundTracker = null;

<<<<<<< HEAD
				if (Element != null)
				{
					Element.PropertyChanged -= OnElementPropertyChanged;

					if (Android.Platform.GetRenderer(Element) == this)
					{
						Element.ClearValue(Android.Platform.RendererProperty);
					}

					Element = null;
=======
				if (ImageButton != null)
				{
					ImageButton.PropertyChanged -= OnElementPropertyChanged;

					if (Android.Platform.GetRenderer(ImageButton) == this)
					{
						ImageButton.ClearValue(Android.Platform.RendererProperty);
					}

					ImageButton = null;
>>>>>>> Update from origin (#11)
				}
			}

			base.Dispose(disposing);
		}

		public override void Invalidate()
		{
			if (_skipInvalidate)
			{
				_skipInvalidate = false;
				return;
			}

			base.Invalidate();
		}

		Size MinimumSize()
		{
			return new Size();
		}

		SizeRequest IVisualElementRenderer.GetDesiredSize(int widthConstraint, int heightConstraint)
		{
			if (_disposed)
			{
				return new SizeRequest();
			}
			Measure(widthConstraint, heightConstraint);
			return new SizeRequest(new Size(MeasuredWidth, MeasuredHeight), MinimumSize());
		}

		void IVisualElementRenderer.SetElement(VisualElement element)
		{

			if (element == null)
			{
				throw new ArgumentNullException(nameof(element));
			}

			if (!(element is ImageButton image))
			{
				throw new ArgumentException("Element is not of type " + typeof(ImageButton), nameof(element));
			}

<<<<<<< HEAD
			ImageButton oldElement = Element;
			Element = image;
=======
			ImageButton oldElement = ImageButton;
			ImageButton = image;
>>>>>>> Update from origin (#11)

			Performance.Start(out string reference);

			if (oldElement != null)
			{
				oldElement.PropertyChanged -= OnElementPropertyChanged;
			}

			element.PropertyChanged += OnElementPropertyChanged;

			if (_tracker == null)
			{
				_tracker = new VisualElementTracker(this);
				ImageElementManager.Init(this);

			}

			if (_visualElementRenderer == null)
			{
				_visualElementRenderer = new VisualElementRenderer(this);
			}

			Performance.Stop(reference);
			this.EnsureId();

			UpdateInputTransparent();
			UpdatePadding();

<<<<<<< HEAD
			OnElementChanged(new ElementChangedEventArgs<ImageButton>(oldElement, Element));
			Element?.SendViewInitialized(Control);
		}

		protected virtual void OnElementChanged(ElementChangedEventArgs<ImageButton> e)
		{
			ElementChanged?.Invoke(this, new VisualElementChangedEventArgs(e.OldElement, e.NewElement));
=======
			ElementChanged?.Invoke(this, new VisualElementChangedEventArgs(oldElement, ImageButton));
			ImageButton?.SendViewInitialized(Control);
>>>>>>> Update from origin (#11)
		}

		public override void Draw(Canvas canvas)
		{
<<<<<<< HEAD
			if (Element == null)
				return;

			var backgroundDrawable = _backgroundTracker?.BackgroundDrawable;
<<<<<<< HEAD
			RectF drawableBounds = null;

			if(Drawable != null)
			{
				if ((int)Build.VERSION.SdkInt >= 18 && backgroundDrawable != null)
				{
					var outlineBounds = backgroundDrawable.GetPaddingBounds(canvas.Width, canvas.Height);
					var width = (float)MeasuredWidth;
					var height = (float)MeasuredHeight;

					var widthRatio = 1f;
					var heightRatio = 1f;

					if (Element.Aspect == Aspect.AspectFill && OnThisPlatform().GetIsShadowEnabled())
						Internals.Log.Warning(nameof(ImageButtonRenderer), "AspectFill isn't fully supported when using shadows. Image may be clipped incorrectly to Border");

					switch (Element.Aspect)
					{
						case Aspect.Fill:
							break;
						case Aspect.AspectFill:
						case Aspect.AspectFit:
							heightRatio = (float)Drawable.IntrinsicHeight / height;
							widthRatio = (float)Drawable.IntrinsicWidth / width;
							break;
					}

					drawableBounds = new RectF(outlineBounds.Left * widthRatio, outlineBounds.Top * heightRatio, outlineBounds.Right * widthRatio, outlineBounds.Bottom * heightRatio);
				}

				if (drawableBounds != null)
					Drawable.SetBounds((int)drawableBounds.Left, (int)drawableBounds.Top, (int)drawableBounds.Right, (int)drawableBounds.Bottom);
			}

			base.Draw(canvas);
			if (_backgroundTracker?.BackgroundDrawable != null)
=======
			if (ImageButton == null)
				return;

			var backgroundDrawable = _backgroundTracker?.BackgroundDrawable;

=======
>>>>>>> Update (#12)
			RectF drawableBounds = null;

			if(Drawable != null)
			{
				if ((int)Build.VERSION.SdkInt >= 18 && backgroundDrawable != null)
				{
					var outlineBounds = backgroundDrawable.GetPaddingBounds(canvas.Width, canvas.Height);
					var width = (float)MeasuredWidth;
					var height = (float)MeasuredHeight;

					var widthRatio = 1f;
					var heightRatio = 1f;

<<<<<<< HEAD
				if (ImageButton.Aspect == Aspect.AspectFill && OnThisPlatform().GetIsShadowEnabled())
					Internals.Log.Warning(nameof(ImageButtonRenderer), "AspectFill isn't fully supported when using shadows. Image may be clipped incorrectly to Border");

				switch (ImageButton.Aspect)
				{
					case Aspect.Fill:
						break;
					case Aspect.AspectFill:
					case Aspect.AspectFit:
						heightRatio = (float)Drawable.IntrinsicHeight / height;
						widthRatio = (float)Drawable.IntrinsicWidth / width;
						break;
=======
					if (Element.Aspect == Aspect.AspectFill && OnThisPlatform().GetIsShadowEnabled())
						Internals.Log.Warning(nameof(ImageButtonRenderer), "AspectFill isn't fully supported when using shadows. Image may be clipped incorrectly to Border");

					switch (Element.Aspect)
					{
						case Aspect.Fill:
							break;
						case Aspect.AspectFill:
						case Aspect.AspectFit:
							heightRatio = (float)Drawable.IntrinsicHeight / height;
							widthRatio = (float)Drawable.IntrinsicWidth / width;
							break;
					}

					drawableBounds = new RectF(outlineBounds.Left * widthRatio, outlineBounds.Top * heightRatio, outlineBounds.Right * widthRatio, outlineBounds.Bottom * heightRatio);
>>>>>>> Update (#12)
				}

				if (drawableBounds != null)
					Drawable.SetBounds((int)drawableBounds.Left, (int)drawableBounds.Top, (int)drawableBounds.Right, (int)drawableBounds.Bottom);
			}

			base.Draw(canvas);
<<<<<<< HEAD
			if (_backgroundTracker.BackgroundDrawable != null)
>>>>>>> Update from origin (#11)
=======
			if (_backgroundTracker?.BackgroundDrawable != null)
>>>>>>> Update (#12)
				_backgroundTracker.BackgroundDrawable.DrawOutline(canvas, canvas.Width, canvas.Height);
		}

		void IVisualElementRenderer.SetLabelFor(int? id)
		{
			if (_defaultLabelFor == null)
				_defaultLabelFor = LabelFor;

			LabelFor = (int)(id ?? _defaultLabelFor);
		}

		public override bool OnTouchEvent(MotionEvent e)
		{
			if (!Enabled || (_inputTransparent && Enabled))
				return false;

			return base.OnTouchEvent(e);
		}


		void UpdatePadding()
		{
			SetPadding(
<<<<<<< HEAD
				(int)(Context.ToPixels(Element.Padding.Left)),
				(int)(Context.ToPixels(Element.Padding.Top)),
				(int)(Context.ToPixels(Element.Padding.Right)),
				(int)(Context.ToPixels(Element.Padding.Bottom))
=======
				(int)(Context.ToPixels(ImageButton.Padding.Left)),
				(int)(Context.ToPixels(ImageButton.Padding.Top)),
				(int)(Context.ToPixels(ImageButton.Padding.Right)),
				(int)(Context.ToPixels(ImageButton.Padding.Bottom))
>>>>>>> Update from origin (#11)
			);
		}

		void UpdateInputTransparent()
		{
<<<<<<< HEAD
			if (Element == null || _disposed)
=======
			if (ImageButton == null || _disposed)
>>>>>>> Update from origin (#11)
			{
				return;
			}

<<<<<<< HEAD
			_inputTransparent = Element.InputTransparent;
		}

		protected virtual void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
=======
			_inputTransparent = ImageButton.InputTransparent;
		}

		// Image related
		void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
>>>>>>> Update from origin (#11)
		{
			if (e.PropertyName == VisualElement.InputTransparentProperty.PropertyName)
				UpdateInputTransparent();
			else if (e.PropertyName == ImageButton.PaddingProperty.PropertyName)
				UpdatePadding();

			ElementPropertyChanged?.Invoke(this, e);
		}


		// general state related
		void IOnFocusChangeListener.OnFocusChange(AView v, bool hasFocus)
		{
<<<<<<< HEAD
			((IElementController)Element).SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, hasFocus);
=======
			((IElementController)ImageButton).SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, hasFocus);
>>>>>>> Update from origin (#11)
		}
		// general state related


		// Button related
		void IOnClickListener.OnClick(AView v) =>
<<<<<<< HEAD
			ButtonElementManager.OnClick(Element, Element, v);

		bool IOnTouchListener.OnTouch(AView v, MotionEvent e) =>
			ButtonElementManager.OnTouch(Element, Element, v, e);
=======
			ButtonElementManager.OnClick(ImageButton, ImageButton, v);

		bool IOnTouchListener.OnTouch(AView v, MotionEvent e) =>
			ButtonElementManager.OnTouch(ImageButton, ImageButton, v, e);
>>>>>>> Update from origin (#11)
		// Button related


		float IBorderVisualElementRenderer.ShadowRadius => Context.ToPixels(OnThisPlatform().GetShadowRadius());
		float IBorderVisualElementRenderer.ShadowDx => Context.ToPixels(OnThisPlatform().GetShadowOffset().Width);
		float IBorderVisualElementRenderer.ShadowDy => Context.ToPixels(OnThisPlatform().GetShadowOffset().Height);
		AColor IBorderVisualElementRenderer.ShadowColor => OnThisPlatform().GetShadowColor().ToAndroid();
		bool IBorderVisualElementRenderer.IsShadowEnabled() => OnThisPlatform().GetIsShadowEnabled();
		bool IBorderVisualElementRenderer.UseDefaultPadding() => false;
		bool IBorderVisualElementRenderer.UseDefaultShadow() => false;
<<<<<<< HEAD
		VisualElement IBorderVisualElementRenderer.Element => Element;
=======
		VisualElement IBorderVisualElementRenderer.Element => ImageButton;
>>>>>>> Update from origin (#11)
		AView IBorderVisualElementRenderer.View => this;

		IPlatformElementConfiguration<PlatformConfiguration.Android, ImageButton> OnThisPlatform()
		{
			if (_platformElementConfiguration == null)
<<<<<<< HEAD
				_platformElementConfiguration = Element.OnThisPlatform();
=======
				_platformElementConfiguration = ImageButton.OnThisPlatform();
>>>>>>> Update from origin (#11)

			return _platformElementConfiguration;
		}
	}
}
