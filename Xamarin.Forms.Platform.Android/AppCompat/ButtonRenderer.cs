using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Util;
<<<<<<< HEAD
using Android.Views;
using Xamarin.Forms.Platform.Android.FastRenderers;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using AColor = Android.Graphics.Color;
using AView = Android.Views.View;

namespace Xamarin.Forms.Platform.Android.AppCompat
{
	public class ButtonRenderer : ViewRenderer<Button, AppCompatButton>,
		AView.IOnAttachStateChangeListener, AView.IOnClickListener, AView.IOnTouchListener,
		IBorderVisualElementRenderer, IButtonLayoutRenderer, IDisposedState
=======
using Object = Java.Lang.Object;
using AView = Android.Views.View;
using AMotionEvent = Android.Views.MotionEvent;
using AMotionEventActions = Android.Views.MotionEventActions;
using static System.String;
using AColor = Android.Graphics.Color;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Platform.Android.FastRenderers;

namespace Xamarin.Forms.Platform.Android.AppCompat
{
	public class ButtonRenderer : ViewRenderer<Button, AppCompatButton>, AView.IOnAttachStateChangeListener, IBorderVisualElementRenderer
>>>>>>> Update from origin (#11)
	{
		BorderBackgroundManager _backgroundTracker;
		TextColorSwitcher _textColorSwitcher;
		float _defaultFontSize;
		Typeface _defaultTypeface;
		bool _isDisposed;
<<<<<<< HEAD
		ButtonLayoutManager _buttonLayoutManager;
=======
		int _imageHeight = -1;
		Thickness _paddingDeltaPix = new Thickness();
		IVisualElementRenderer _visualElementRenderer;
>>>>>>> Update from origin (#11)
		string _defaultContentDescription;

		public ButtonRenderer(Context context) : base(context)
		{
			AutoPackage = false;
<<<<<<< HEAD
			_backgroundTracker = new BorderBackgroundManager(this);
			_buttonLayoutManager = new ButtonLayoutManager(this);
=======
			_visualElementRenderer = this;
			_backgroundTracker = new BorderBackgroundManager(this);
>>>>>>> Update from origin (#11)
		}

		[Obsolete("This constructor is obsolete as of version 2.5. Please use ButtonRenderer(Context) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ButtonRenderer()
		{
			AutoPackage = false;
<<<<<<< HEAD
			_backgroundTracker = new BorderBackgroundManager(this);
			_buttonLayoutManager = new ButtonLayoutManager(this);
=======
			_visualElementRenderer = this;
			_backgroundTracker = new BorderBackgroundManager(this);
>>>>>>> Update from origin (#11)
		}

		global::Android.Widget.Button NativeButton => Control;

		protected override void SetContentDescription()
			=> AutomationPropertiesProvider.SetBasicContentDescription(this, Element, ref _defaultContentDescription);
<<<<<<< HEAD
=======

		void AView.IOnAttachStateChangeListener.OnViewAttachedToWindow(AView attachedView)
		{
			UpdateText();
		}
>>>>>>> Update from origin (#11)

		void AView.IOnAttachStateChangeListener.OnViewAttachedToWindow(AView attachedView) =>
			_buttonLayoutManager?.OnViewAttachedToWindow(attachedView);

		void AView.IOnAttachStateChangeListener.OnViewDetachedFromWindow(AView detachedView) =>
			_buttonLayoutManager?.OnViewDetachedFromWindow(detachedView);

		protected override void OnLayout(bool changed, int l, int t, int r, int b)
		{
			_buttonLayoutManager?.OnLayout(changed, l, t, r, b);
			base.OnLayout(changed, l, t, r, b);
		}

		protected override AppCompatButton CreateNativeControl()
		{
			return new AppCompatButton(Context);
		}

		protected override void Dispose(bool disposing)
		{
			if (_isDisposed)
				return;

			_isDisposed = true;

			if (disposing)
			{
				if (Control != null)
				{
					Control.SetOnClickListener(null);
					Control.SetOnTouchListener(null);
					Control.RemoveOnAttachStateChangeListener(this);
					_textColorSwitcher = null;
				}
				_backgroundTracker?.Dispose();
				_backgroundTracker = null;
<<<<<<< HEAD
				_buttonLayoutManager?.Dispose();
				_buttonLayoutManager = null;
=======
				_visualElementRenderer = null;
>>>>>>> Update from origin (#11)
			}

			base.Dispose(disposing);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				if (Control == null)
				{
					AppCompatButton button = CreateNativeControl();

					button.SetOnClickListener(this);
					button.SetOnTouchListener(this);
					button.AddOnAttachStateChangeListener(this);
					_textColorSwitcher = new TextColorSwitcher(button.TextColors, e.NewElement.UseLegacyColorManagement());

					SetNativeControl(button);
				}

<<<<<<< HEAD
=======

>>>>>>> Update from origin (#11)
				_defaultFontSize = 0f;

				_buttonLayoutManager?.Update();
				UpdateAll();
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == Button.TextColorProperty.PropertyName)
				UpdateTextColor();
			else if (e.PropertyName == VisualElement.IsEnabledProperty.PropertyName)
				UpdateEnabled();
			else if (e.PropertyName == Button.FontProperty.PropertyName)
				UpdateFont();

			base.OnElementPropertyChanged(sender, e);
		}

		protected override void UpdateBackgroundColor()
		{
			if (Element == null || Control == null)
				return;

			_backgroundTracker?.UpdateDrawable();
		}

		void UpdateAll()
		{
			UpdateFont();
			UpdateTextColor();
			UpdateEnabled();
			UpdateBackgroundColor();
		}

		void UpdateEnabled()
		{
			Control.Enabled = Element.IsEnabled;
		}

		void UpdateFont()
		{
			Button button = Element;
			Font font = button.Font;

			if (font == Font.Default && _defaultFontSize == 0f)
				return;

			if (_defaultFontSize == 0f)
			{
				_defaultTypeface = NativeButton.Typeface;
				_defaultFontSize = NativeButton.TextSize;
			}

			if (font == Font.Default)
			{
				NativeButton.Typeface = _defaultTypeface;
				NativeButton.SetTextSize(ComplexUnitType.Px, _defaultFontSize);
			}
			else
			{
				NativeButton.Typeface = font.ToTypeface();
				NativeButton.SetTextSize(ComplexUnitType.Sp, font.ToScaledPixel());
			}
		}

		void UpdateTextColor()
		{
			_textColorSwitcher?.UpdateTextColor(Control, Element.TextColor);
		}

		void IOnClickListener.OnClick(AView v) => ButtonElementManager.OnClick(Element, Element, v);

<<<<<<< HEAD
		bool IOnTouchListener.OnTouch(AView v, MotionEvent e) => ButtonElementManager.OnTouch(Element, Element, v, e);
=======
		void UpdateContentEdge(Thickness? delta = null)
		{
			_paddingDeltaPix = delta ?? new Thickness();
			UpdatePadding();			
		}

		float IBorderVisualElementRenderer.ShadowRadius => Control.ShadowRadius;
		float IBorderVisualElementRenderer.ShadowDx => Control.ShadowDx;
		float IBorderVisualElementRenderer.ShadowDy => Control.ShadowDy;
		AColor IBorderVisualElementRenderer.ShadowColor => Control.ShadowColor;
		bool IBorderVisualElementRenderer.UseDefaultPadding() => Element.OnThisPlatform().UseDefaultPadding();
		bool IBorderVisualElementRenderer.UseDefaultShadow() => Element.OnThisPlatform().UseDefaultShadow();
		bool IBorderVisualElementRenderer.IsShadowEnabled() => true;
		VisualElement IBorderVisualElementRenderer.Element => Element;
		AView IBorderVisualElementRenderer.View => Control;
		event EventHandler<VisualElementChangedEventArgs> IBorderVisualElementRenderer.ElementChanged
		{
			add => _visualElementRenderer.ElementChanged += value;
			remove => _visualElementRenderer.ElementChanged -= value;
		}
>>>>>>> Update from origin (#11)

		float IBorderVisualElementRenderer.ShadowRadius => Control.ShadowRadius;
		float IBorderVisualElementRenderer.ShadowDx => Control.ShadowDx;
		float IBorderVisualElementRenderer.ShadowDy => Control.ShadowDy;
		AColor IBorderVisualElementRenderer.ShadowColor => Control.ShadowColor;
		bool IBorderVisualElementRenderer.UseDefaultPadding() => Element.OnThisPlatform().UseDefaultPadding();
		bool IBorderVisualElementRenderer.UseDefaultShadow() => Element.OnThisPlatform().UseDefaultShadow();
		bool IBorderVisualElementRenderer.IsShadowEnabled() => true;
		VisualElement IBorderVisualElementRenderer.Element => Element;
		AView IBorderVisualElementRenderer.View => Control;
		event EventHandler<VisualElementChangedEventArgs> IBorderVisualElementRenderer.ElementChanged
		{
			add => ((IVisualElementRenderer)this).ElementChanged += value;
			remove => ((IVisualElementRenderer)this).ElementChanged -= value;
		}

		event EventHandler<VisualElementChangedEventArgs> IButtonLayoutRenderer.ElementChanged
		{
			add => ((IVisualElementRenderer)this).ElementChanged += value;
			remove => ((IVisualElementRenderer)this).ElementChanged -= value;
		}

		AppCompatButton IButtonLayoutRenderer.View => Control;
		bool IDisposedState.IsDisposed => _isDisposed;
	}
}
