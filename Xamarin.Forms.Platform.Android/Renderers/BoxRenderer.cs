using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;

namespace Xamarin.Forms.Platform.Android
{
	public class BoxRenderer : VisualElementRenderer<BoxView>
	{
		bool _disposed;
		GradientDrawable _backgroundDrawable;

		readonly MotionEventHelper _motionEventHelper = new MotionEventHelper();

		public BoxRenderer(Context context) : base(context)
		{
			AutoPackage = false;
		}

		[Obsolete("This constructor is obsolete as of version 2.5. Please use BoxRenderer(Context) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public BoxRenderer()
		{
			AutoPackage = false;
		}

		public override bool OnTouchEvent(MotionEvent e)
		{
			if (base.OnTouchEvent(e))
				return true;

			return _motionEventHelper.HandleMotionEvent(Parent, e);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
		{
			base.OnElementChanged(e);

			_motionEventHelper.UpdateElement(e.NewElement);

			UpdateBackgroundColor();
			UpdateCornerRadius();
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == BoxView.ColorProperty.PropertyName || e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
				UpdateBackgroundColor();
			else if (e.PropertyName == BoxView.CornerRadiusProperty.PropertyName)
				UpdateCornerRadius();
		}

		protected override void UpdateBackgroundColor()
		{
			Color colorToSet = Element.Color;

			if (colorToSet == Color.Default)
				colorToSet = Element.BackgroundColor;

			if (_backgroundDrawable != null) {

				if (colorToSet != Color.Default)
					_backgroundDrawable.SetColor(colorToSet.ToAndroid());
				else
					_backgroundDrawable.SetColor(colorToSet.ToAndroid(Color.Transparent));

				this.SetBackground(_backgroundDrawable);
			}
			else {
				if (colorToSet == Color.Default)
					colorToSet = Element.BackgroundColor;
				SetBackgroundColor(colorToSet.ToAndroid(Color.Transparent));
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (_disposed)
				return;

			_disposed = true;

			if (disposing)
			{
				if (_backgroundDrawable != null)
				{
					_backgroundDrawable.Dispose();
					_backgroundDrawable = null;
				}

				if (Element != null)
				{
					Element.PropertyChanged -= OnElementPropertyChanged;

					if (Platform.GetRenderer(Element) == this)
						Element.ClearValue(Platform.RendererProperty);
				}

			}

			base.Dispose(disposing);
		}

		void UpdateCornerRadius()
		{
			var cornerRadius = Element.CornerRadius;
<<<<<<< HEAD
<<<<<<< HEAD
			if (cornerRadius == new CornerRadius(0d))
			{
				_backgroundDrawable?.Dispose();
				_backgroundDrawable = null;
			}
			else
			{
				this.SetBackground(_backgroundDrawable = new GradientDrawable());
				if (Background is GradientDrawable backgroundGradient)
				{
					var cornerRadii = new[] {
						(float)(Context.ToPixels(cornerRadius.TopLeft)),
						(float)(Context.ToPixels(cornerRadius.TopLeft)),

						(float)(Context.ToPixels(cornerRadius.TopRight)),
						(float)(Context.ToPixels(cornerRadius.TopRight)),

						(float)(Context.ToPixels(cornerRadius.BottomRight)),
						(float)(Context.ToPixels(cornerRadius.BottomRight)),

						(float)(Context.ToPixels(cornerRadius.BottomLeft)),
						(float)(Context.ToPixels(cornerRadius.BottomLeft))
=======
			if (cornerRadius == new CornerRadius(0d)) {
=======
			if (cornerRadius == new CornerRadius(0d))
			{
>>>>>>> Update from origin (#11)
				_backgroundDrawable?.Dispose();
				_backgroundDrawable = null;
			}
			else
			{
				this.SetBackground(_backgroundDrawable = new GradientDrawable());
				if (Background is GradientDrawable backgroundGradient)
				{
					var cornerRadii = new[] {
						(float)(Context.ToPixels(cornerRadius.TopLeft)),
						(float)(Context.ToPixels(cornerRadius.TopLeft)),

						(float)(Context.ToPixels(cornerRadius.TopRight)),
						(float)(Context.ToPixels(cornerRadius.TopRight)),

						(float)(Context.ToPixels(cornerRadius.BottomRight)),
						(float)(Context.ToPixels(cornerRadius.BottomRight)),

<<<<<<< HEAD
						(float)(cornerRadius.BottomLeft),
						(float)(cornerRadius.BottomLeft)
>>>>>>> Update from origin (#8)
=======
						(float)(Context.ToPixels(cornerRadius.BottomLeft)),
						(float)(Context.ToPixels(cornerRadius.BottomLeft))
>>>>>>> Update from origin (#11)
					};

					backgroundGradient.SetCornerRadii(cornerRadii);
				}
			}

			UpdateBackgroundColor();
		}
	}
}