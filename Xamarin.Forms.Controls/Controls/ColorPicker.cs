using System;

namespace Xamarin.Forms.Controls
{
	public class ColorPicker : ContentView
	{
		public static readonly BindableProperty UseDefaultProperty = BindableProperty.Create(nameof(UseDefault), typeof(bool), typeof(ColorPicker), false,
			propertyChanged: OnColorChanged);

		public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(ColorPicker), Color.Default,
			propertyChanged: OnColorChanged);

		public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(ColorPicker), "Pick a color:",
			propertyChanged: OnTitleChanged);

		static readonly string[] _components = { "R", "G", "B", "A" };

		Label _titleLabel;
		Slider[] _sliders;
<<<<<<< HEAD
		Frame _box;
=======
		BoxView _box;
>>>>>>> Update (#12)
		Label _hexLabel;
		Switch _useDefault;

		public ColorPicker()
		{
			var grid = new Grid
			{
				Padding = 0,
				RowSpacing = 3,
				ColumnSpacing = 3,
				ColumnDefinitions =
				{
					new ColumnDefinition { Width = 20 },
					new ColumnDefinition { Width = GridLength.Star },
					new ColumnDefinition { Width = 60 },
				},
			};

			_titleLabel = new Label { Text = (string)TitleProperty.DefaultValue };
			grid.AddChild(_titleLabel, 0, 0, 2);

			_useDefault = new Switch
			{
				IsToggled = true,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
			_useDefault.Toggled += OnUseDefaultToggled;
			grid.AddChild(_useDefault, 2, 0);

			_sliders = new Slider[_components.Length];
			for (var i = 0; i < _components.Length; i++)
			{
				_sliders[i] = new Slider
				{
					VerticalOptions = LayoutOptions.Center,
					Minimum = 0,
					Maximum = 255,
					Value = 255
				};
				_sliders[i].ValueChanged += OnColorSliderChanged;
				var label = new Label
				{
					Text = _components[i],
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center
				};
				grid.AddChild(label, 0, i + 1);
				grid.AddChild(_sliders[i], 1, i + 1);
			}

<<<<<<< HEAD
			_box = new Frame
			{
				BackgroundColor = Color,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
				BorderColor = Color.Black,

=======
			_box = new BoxView
			{
				Color = Color,
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
>>>>>>> Update (#12)
			};
			grid.AddChild(_box, 2, 1, 1, 3);

			_hexLabel = new Label
			{
				Text = ColorToHex(Color),
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				FontSize = 10,
			};
			grid.AddChild(_hexLabel, 2, 4);

			Content = grid;
		}

<<<<<<< HEAD
		public void InitWithColor(Color color)
		{
			_sliders[0].Value = color.R * 255;
			_sliders[1].Value = color.G * 255;
			_sliders[2].Value = color.B * 255;
			_sliders[3].Value = color.A * 255;
		}

=======
>>>>>>> Update (#12)
		public string Title
		{
			get => (string)GetValue(TitleProperty);
			set => SetValue(TitleProperty, value);
		}

		public bool UseDefault
		{
			get => (bool)GetValue(UseDefaultProperty);
			set => SetValue(UseDefaultProperty, value);
		}

		public Color Color
		{
			get => (Color)GetValue(ColorProperty);
			set => SetValue(ColorProperty, value);
		}

		public event EventHandler<ColorPickedEventArgs> ColorPicked;

		void OnColorSliderChanged(object sender, ValueChangedEventArgs e)
		{
			var color = Color.FromRgba(
				(int)_sliders[0].Value,
				(int)_sliders[1].Value,
				(int)_sliders[2].Value,
				(int)_sliders[3].Value);
			Color = color;
		}

		private void OnUseDefaultToggled(object sender, ToggledEventArgs e)
		{
			UseDefault = !e.Value;

			foreach (var slider in _sliders)
				slider.IsEnabled = e.Value;
		}

		static void OnColorChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (bindable is ColorPicker picker)
			{
				var color = picker.UseDefault ? Color.Default : picker.Color;
				picker._hexLabel.Text = color.IsDefault ? "<default>" : ColorToHex(color);
<<<<<<< HEAD
				picker._box.BackgroundColor = color;
=======
				picker._box.Color = color;
>>>>>>> Update (#12)
				picker.ColorPicked?.Invoke(picker, new ColorPickedEventArgs(color));
			}
		}

		static void OnTitleChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (bindable is ColorPicker picker)
			{
				picker._titleLabel.Text = picker.Title;
			}
		}

		static string ColorToHex(Color color)
		{
			var a = (int)(color.A * 255);
			var r = (int)(color.R * 255);
			var g = (int)(color.G * 255);
			var b = (int)(color.B * 255);

			var value = a << 24 | r << 16 | g << 8 | b;

			return "#" + value.ToString("X");
		}
	}

	public class ColorPickedEventArgs : EventArgs
	{
		public ColorPickedEventArgs(Color color)
		{
			Color = color;
		}

		public Color Color { get; }
	}
}
