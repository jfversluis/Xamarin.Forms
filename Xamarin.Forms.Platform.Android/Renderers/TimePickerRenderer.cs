using System;
using System.ComponentModel;
using Android.App;
using Android.Content;
using Android.Util;
using Android.Text.Format;
using ATimePicker = Android.Widget.TimePicker;
using Android.OS;
<<<<<<< HEAD
using Android.Widget;
using AColor = Android.Graphics.Color;
=======
using Android.Views;
using System.Collections.Generic;
using Android.Text;
>>>>>>> Update from origin (#8)

namespace Xamarin.Forms.Platform.Android
{
	public abstract class TimePickerRendererBase<TControl> : ViewRenderer<TimePicker, TControl>, TimePickerDialog.IOnTimeSetListener, IPickerRenderer
		where TControl : global::Android.Views.View
	{
		int _originalHintTextColor;
		AlertDialog _dialog;
<<<<<<< HEAD
=======
		TextColorSwitcher _textColorSwitcher;
		 

		HashSet<Keycode> availableKeys = new HashSet<Keycode>(new[] {
			Keycode.Tab, Keycode.Forward, Keycode.Back, Keycode.DpadDown, Keycode.DpadLeft, Keycode.DpadRight, Keycode.DpadUp
		});
>>>>>>> Update from origin (#8)

		bool Is24HourView
		{
			get => (DateFormat.Is24HourFormat(Context) && Element.Format == (string)TimePicker.FormatProperty.DefaultValue) || Element.Format == "HH:mm";
		}

		public TimePickerRendererBase(Context context) : base(context)
		{
			AutoPackage = false;
		}

		[Obsolete("This constructor is obsolete as of version 2.5. Please use TimePickerRenderer(Context) instead.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public TimePickerRendererBase()
		{
			AutoPackage = false;
		}

		protected abstract EditText EditText { get; }

		IElementController ElementController => Element as IElementController;

		void TimePickerDialog.IOnTimeSetListener.OnTimeSet(ATimePicker view, int hourOfDay, int minute)
		{
			ElementController.SetValueFromRenderer(TimePicker.TimeProperty, new TimeSpan(hourOfDay, minute, 0));
			ElementController.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, false);

			if (Forms.IsLollipopOrNewer)
				_dialog.CancelEvent -= OnCancelButtonClicked;

			_dialog = null;
		}

<<<<<<< HEAD
=======
		protected override EditText CreateNativeControl()
		{
			return new EditText(Context) { Focusable = true, Clickable = true, Tag = this };
		}

>>>>>>> Update from origin (#8)
		protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement == null)
			{
				var textField = CreateNativeControl();

<<<<<<< HEAD
=======
				textField.SetOnClickListener(TimePickerListener.Instance);
				textField.InputType = InputTypes.Null;
				textField.KeyPress += TextFieldKeyPress;
>>>>>>> Update from origin (#8)
				SetNativeControl(textField);
				_originalHintTextColor = EditText.CurrentHintTextColor;
			}

			SetTime(e.NewElement.Time);
			UpdateTextColor();
			UpdateFont();

			if ((int)Build.VERSION.SdkInt > 16)
				Control.TextAlignment = global::Android.Views.TextAlignment.ViewStart;
		}

		void TextFieldKeyPress(object sender, KeyEventArgs e)
		{
			if (availableKeys.Contains(e.KeyCode))
			{
				e.Handled = false;
				return;
			}
			e.Handled = true;
			OnClick();
		}

		internal override void OnNativeFocusChanged(bool hasFocus)
		{
			base.OnNativeFocusChanged(hasFocus);
			if (hasFocus)
				OnClick();
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == TimePicker.TimeProperty.PropertyName || e.PropertyName == TimePicker.FormatProperty.PropertyName)
				SetTime(Element.Time);
			else if (e.PropertyName == TimePicker.TextColorProperty.PropertyName)
				UpdateTextColor();
			else if (e.PropertyName == TimePicker.FontAttributesProperty.PropertyName || e.PropertyName == TimePicker.FontFamilyProperty.PropertyName || e.PropertyName == TimePicker.FontSizeProperty.PropertyName)
				UpdateFont();
		}

		protected override void OnFocusChangeRequested(object sender, VisualElement.FocusRequestArgs e)
		{
			base.OnFocusChangeRequested(sender, e);

			if (e.Focus)
				CallOnClick();
			else if (_dialog != null)
			{
				_dialog.Hide();
				ElementController.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, false);

				if (Forms.IsLollipopOrNewer)
					_dialog.CancelEvent -= OnCancelButtonClicked;

				_dialog = null;
			}
		}

		protected virtual TimePickerDialog CreateTimePickerDialog(int hours, int minutes)
		{
			var dialog = new TimePickerDialog(Context, this, hours, minutes, Is24HourView);

			if (Forms.IsLollipopOrNewer)
				dialog.CancelEvent += OnCancelButtonClicked;

			return dialog;
		}

		void IPickerRenderer.OnClick()
		{
			if (_dialog != null && _dialog.IsShowing)
			{
				return;
			}

			TimePicker view = Element;
			ElementController.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, true);

			_dialog = CreateTimePickerDialog(view.Time.Hours, view.Time.Minutes);
			_dialog.Show();
		}

		void OnCancelButtonClicked(object sender, EventArgs e)
		{
			Element.Unfocus();
		}


		void SetTime(TimeSpan time)
		{
			var timeFormat = Is24HourView ? "HH:mm" : Element.Format;
			EditText.Text = DateTime.Today.Add(time).ToString(timeFormat);
			Element.InvalidateMeasureNonVirtual(Internals.InvalidationTrigger.MeasureChanged);
		}

		void UpdateFont()
		{
			EditText.Typeface = Element.ToTypeface();
			EditText.SetTextSize(ComplexUnitType.Sp, (float)Element.FontSize);
		}
		
		abstract protected void UpdateTextColor();
	}

	public class TimePickerRenderer : TimePickerRendererBase<EditText>
	{
		TextColorSwitcher _textColorSwitcher;
		[Obsolete("This constructor is obsolete as of version 2.5. Please use TimePickerRenderer(Context) instead.")]
		public TimePickerRenderer()
		{
		}

		public TimePickerRenderer(Context context) : base(context)
		{
		}

		protected override EditText CreateNativeControl()
		{
			return new PickerEditText(Context);
		}

		protected override EditText EditText => Control;
		protected override void UpdateTextColor()
		{
			_textColorSwitcher = _textColorSwitcher ?? new TextColorSwitcher(EditText.TextColors, Element.UseLegacyColorManagement());
			_textColorSwitcher.UpdateTextColor(EditText, Element.TextColor);
		}
	}

}
