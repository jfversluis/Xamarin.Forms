using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Foundation;
using UIKit;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Specifics = Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using SizeF = CoreGraphics.CGSize;

namespace Xamarin.Forms.Platform.iOS
{
<<<<<<< HEAD
<<<<<<< HEAD
	public class ButtonRenderer : ViewRenderer<Button, UIButton>, IImageVisualElementRenderer, IButtonLayoutRenderer
=======
	public class ButtonRenderer : ViewRenderer<Button, UIButton>, IImageVisualElementRenderer
>>>>>>> Update from origin (#11)
=======
	public class ButtonRenderer : ViewRenderer<Button, UIButton>, IImageVisualElementRenderer, IButtonLayoutRenderer
>>>>>>> Update (#12)
	{
		bool _isDisposed;
		UIColor _buttonTextColorDefaultDisabled;
		UIColor _buttonTextColorDefaultHighlighted;
		UIColor _buttonTextColorDefaultNormal;
		bool _useLegacyColorManagement;

		ButtonLayoutManager _buttonLayoutManager;

		// This looks like it should be a const under iOS Classic,
		// but that doesn't work under iOS 
		// ReSharper disable once BuiltInTypeReferenceStyle
		// Under iOS Classic Resharper wants to suggest this use the built-in type ref
		// but under iOS that suggestion won't work
		readonly nfloat _minimumButtonHeight = 44; // Apple docs 

		static readonly UIControlState[] s_controlStates = { UIControlState.Normal, UIControlState.Highlighted, UIControlState.Disabled };

		public bool IsDisposed => _isDisposed;

<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> Update (#12)
		IImageVisualElementRenderer IButtonLayoutRenderer.ImageVisualElementRenderer => this;
		nfloat IButtonLayoutRenderer.MinimumHeight => _minimumButtonHeight;

		public ButtonRenderer()
<<<<<<< HEAD
=======
		public ButtonRenderer() : base()
=======
>>>>>>> Update (#12)
		{
			BorderElementManager.Init(this);

			_buttonLayoutManager = new ButtonLayoutManager(this);
		}

		public override SizeF SizeThatFits(SizeF size)
>>>>>>> Update from origin (#11)
		{
<<<<<<< HEAD
			BorderElementManager.Init(this);

<<<<<<< HEAD
			_buttonLayoutManager = new ButtonLayoutManager(this);
		}
=======
			if (result.Height < _minimumButtonHeight)
			{
				result.Height = _minimumButtonHeight;
			}
>>>>>>> Update from origin (#11)

		public override SizeF SizeThatFits(SizeF size)
		{
=======
>>>>>>> Update (#12)
			var measured = base.SizeThatFits(size);
			return _buttonLayoutManager?.SizeThatFits(size, measured) ?? measured;
		}

		protected override void Dispose(bool disposing)
		{
			if (_isDisposed)
				return;
			if (Control != null)
			{
				Control.TouchUpInside -= OnButtonTouchUpInside;
				Control.TouchDown -= OnButtonTouchDown;
				BorderElementManager.Dispose(this);
<<<<<<< HEAD
<<<<<<< HEAD
				_buttonLayoutManager?.Dispose();
				_buttonLayoutManager = null;
=======
				ImageElementManager.Dispose(this);
>>>>>>> Update from origin (#11)
=======
				_buttonLayoutManager?.Dispose();
				_buttonLayoutManager = null;
>>>>>>> Update (#12)
			}

			_isDisposed = true;

			base.Dispose(disposing);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(CreateNativeControl());

					Debug.Assert(Control != null, "Control != null");

					SetControlPropertiesFromProxy();

					_useLegacyColorManagement = e.NewElement.UseLegacyColorManagement();

					_buttonTextColorDefaultNormal = Control.TitleColor(UIControlState.Normal);
					_buttonTextColorDefaultHighlighted = Control.TitleColor(UIControlState.Highlighted);
					_buttonTextColorDefaultDisabled = Control.TitleColor(UIControlState.Disabled);

					Control.TouchUpInside += OnButtonTouchUpInside;
					Control.TouchDown += OnButtonTouchDown;
				}

				UpdateFont();
<<<<<<< HEAD
<<<<<<< HEAD
=======
				UpdateImage();
>>>>>>> Update from origin (#11)
=======
>>>>>>> Update (#12)
				UpdateTextColor();
				_buttonLayoutManager?.Update();
			}
		}

		protected override UIButton CreateNativeControl()
		{
			return new UIButton(UIButtonType.System);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == Button.TextColorProperty.PropertyName)
				UpdateTextColor();
			else if (e.PropertyName == Button.FontProperty.PropertyName)
				UpdateFont();
<<<<<<< HEAD
<<<<<<< HEAD
=======
			else if (e.PropertyName == Button.ImageProperty.PropertyName)
				UpdateImage();
			else if (e.PropertyName == Button.PaddingProperty.PropertyName)
				UpdatePadding();
>>>>>>> Update from origin (#11)
=======
>>>>>>> Update (#12)
		}

		protected override void SetAccessibilityLabel()
		{
			// If we have not specified an AccessibilityLabel and the AccessibilityLabel is currently bound to the Title,
			// exit this method so we don't set the AccessibilityLabel value and break the binding.
			// This may pose a problem for users who want to explicitly set the AccessibilityLabel to null, but this
			// will prevent us from inadvertently breaking UI Tests that are using Query.Marked to get the dynamic Title 
			// of the Button.

			var elemValue = (string)Element?.GetValue(AutomationProperties.NameProperty);
			if (string.IsNullOrWhiteSpace(elemValue) && Control?.AccessibilityLabel == Control?.Title(UIControlState.Normal))
				return;

			base.SetAccessibilityLabel();
		}

		void SetControlPropertiesFromProxy()
		{
			foreach (UIControlState uiControlState in s_controlStates)
			{
				Control.SetTitleColor(UIButton.Appearance.TitleColor(uiControlState), uiControlState); // if new values are null, old values are preserved.
				Control.SetTitleShadowColor(UIButton.Appearance.TitleShadowColor(uiControlState), uiControlState);
				Control.SetBackgroundImage(UIButton.Appearance.BackgroundImageForState(uiControlState), uiControlState);
			}
		}

		void OnButtonTouchUpInside(object sender, EventArgs eventArgs)
		{
			ButtonElementManager.OnButtonTouchUpInside(this.Element);
		}

		void OnButtonTouchDown(object sender, EventArgs eventArgs)
		{
			ButtonElementManager.OnButtonTouchDown(this.Element);
		}

		void UpdateFont()
		{
			Control.TitleLabel.Font = Element.ToUIFont();
		}

<<<<<<< HEAD
<<<<<<< HEAD
		public void SetImage(UIImage image) => _buttonLayoutManager.SetImage(image);

		public UIImageView GetImage() => Control?.ImageView;
=======
		async void UpdateImage()
		{
			try
			{
				await ImageElementManager.SetImage(this, Element);
			}
			catch (Exception ex)
			{
				Internals.Log.Warning(nameof(ImageRenderer), "Error loading image: {0}", ex);
			}
		}

		public void SetImage(UIImage image)
		{
			if (image != null)
			{
				UIButton button = Control;
				button.SetImage(image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal), UIControlState.Normal);
				button.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
				ComputeEdgeInsets(Control, Element.ContentLayout);
			}
			else
			{
				Control.SetImage(null, UIControlState.Normal);
				ClearEdgeInsets(Control);
			}
		}

		public UIImageView GetImage() => Control?.ImageView;

		void UpdateText()
		{
			var newText = Element.Text;

			if (Control.Title(UIControlState.Normal) != newText)
			{
				Control.SetTitle(Element.Text, UIControlState.Normal);
				_titleChanged = true;
			}
		}
>>>>>>> Update from origin (#11)

=======
		public void SetImage(UIImage image) => _buttonLayoutManager.SetImage(image);

		public UIImageView GetImage() => Control?.ImageView;

>>>>>>> Update (#12)
		void UpdateTextColor()
		{
			if (Element.TextColor == Color.Default)
			{
				Control.SetTitleColor(_buttonTextColorDefaultNormal, UIControlState.Normal);
				Control.SetTitleColor(_buttonTextColorDefaultHighlighted, UIControlState.Highlighted);
				Control.SetTitleColor(_buttonTextColorDefaultDisabled, UIControlState.Disabled);
			}
			else
			{
				var color = Element.TextColor.ToUIColor();

				Control.SetTitleColor(color, UIControlState.Normal);
				Control.SetTitleColor(color, UIControlState.Highlighted);
				Control.SetTitleColor(_useLegacyColorManagement ? _buttonTextColorDefaultDisabled : color, UIControlState.Disabled);

				Control.TintColor = color;
			}
		}
	}
}
