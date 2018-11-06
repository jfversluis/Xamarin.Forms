using Gdk;
using Gtk;
using System;
using System.Linq;
using Xamarin.Forms.Platform.GTK.Extensions;

namespace Xamarin.Forms.Platform.GTK.Controls
{
	public class Page : Table
	{
		private Gdk.Rectangle _lastAllocation = Gdk.Rectangle.Zero;
<<<<<<< HEAD
<<<<<<< HEAD
		private GtkFormsContainer _headerContainer;
		private GtkFormsContainer _contentContainerWrapper;
		private Fixed _contentContainer;
		private HBox _toolbar;
		private GtkFormsContainer _content;
=======
		private EventBox _headerContainer;
		private EventBox _contentContainerWrapper;
		private Fixed _contentContainer;
		private HBox _toolbar;
		private EventBox _content;
>>>>>>> Update from origin (#8)
=======
		private GtkFormsContainer _headerContainer;
		private GtkFormsContainer _contentContainerWrapper;
		private Fixed _contentContainer;
		private HBox _toolbar;
		private GtkFormsContainer _content;
>>>>>>> Update from origin (#11)
		private ImageControl _image;
		private Gdk.Color _defaultBackgroundColor;

		public HBox Toolbar
		{
			get
			{
				return _toolbar;
			}
			set
			{
				if (_toolbar != value)
				{
					RefreshToolbar(value);
				}
			}
		}

<<<<<<< HEAD
<<<<<<< HEAD
		public GtkFormsContainer Content
=======
		public EventBox Content
>>>>>>> Update from origin (#8)
=======
		public GtkFormsContainer Content
>>>>>>> Update from origin (#11)
		{
			get
			{
				return _content;
			}
			set
			{
				if (_content != value)
				{
					RefreshContent(value);
				}
			}
		}

		public Page() : base(1, 1, true)
		{
			BuildPage();
		}

<<<<<<< HEAD
<<<<<<< HEAD
		public void SetToolbarColor(Color backgroundColor)
		{
			_headerContainer.SetBackgroundColor(backgroundColor);
		}

		public void SetBackgroundColor(Color backgroundColor)
		{
			_contentContainerWrapper.SetBackgroundColor(backgroundColor);
		}

		public async void SetBackgroundImage(ImageSource imageSource)
		{
			_image.Pixbuf = await imageSource.GetNativeImageAsync();
		}

		public void PushModal(Widget modal)
		{
			Children.Last().Hide();
			Attach(modal, 0, 1, 0, 1);
			modal.ShowAll();
		}

		public void PopModal(Widget modal)
		{
			if (Children.Length > 0)
			{
				Remove(modal);
			}
			Children.Last().Show();
		}

		public override void Destroy()
		{
			base.Destroy();
			if (_contentContainerWrapper != null)
			{
				_contentContainerWrapper.SizeAllocated -= OnContentContainerWrapperSizeAllocated;
				_contentContainerWrapper = null;
			}
			_contentContainer = null;
			_image = null;
			_toolbar = null;
			_content = null;
			_headerContainer = null;
=======
		public void SetToolbarColor(Gdk.Color? backgroundColor)
=======
		public void SetToolbarColor(Color backgroundColor)
>>>>>>> Update from origin (#11)
		{
			_headerContainer.SetBackgroundColor(backgroundColor);
		}

		public void SetBackgroundColor(Color backgroundColor)
		{
			_contentContainerWrapper.SetBackgroundColor(backgroundColor);
		}

		public void SetBackgroundImage(string backgroundImagePath)
		{
			if (string.IsNullOrEmpty(backgroundImagePath))
			{
				return;
			}

			try
			{
				_image.Pixbuf = new Pixbuf(backgroundImagePath);
			}
			catch (Exception ex)
			{
				Internals.Log.Warning("Page BackgroundImage", "Could not load background image: {0}", ex);
			}
		}

		public void PushModal(Widget modal)
		{
			Children.Last().Hide();
			Attach(modal, 0, 1, 0, 1);
			modal.ShowAll();
		}

		public void PopModal(Widget modal)
		{
			if (Children.Length > 0)
			{
				Remove(modal);
			}
			Children.Last().Show();
		}

		public override void Destroy()
		{
			base.Destroy();
			if (_contentContainerWrapper != null)
			{
				_contentContainerWrapper.SizeAllocated -= OnContentContainerWrapperSizeAllocated;
				_contentContainerWrapper = null;
			}
<<<<<<< HEAD
>>>>>>> Update from origin (#8)
=======
			_contentContainer = null;
			_image = null;
			_toolbar = null;
			_content = null;
			_headerContainer = null;
>>>>>>> Update from origin (#11)
		}

		private void BuildPage()
		{
			_defaultBackgroundColor = Style.Backgrounds[(int)StateType.Normal];

			_toolbar = new HBox();
<<<<<<< HEAD
<<<<<<< HEAD
			_content = new GtkFormsContainer();

			var root = new VBox(false, 0);

			_headerContainer = new GtkFormsContainer();
=======
			_content = new EventBox();

			var root = new VBox(false, 0);

			_headerContainer = new EventBox();
>>>>>>> Update from origin (#8)
=======
			_content = new GtkFormsContainer();

			var root = new VBox(false, 0);

			_headerContainer = new GtkFormsContainer();
>>>>>>> Update from origin (#11)
			root.PackStart(_headerContainer, false, false, 0);

			_image = new ImageControl();
			_image.Aspect = ImageAspect.Fill;

<<<<<<< HEAD
<<<<<<< HEAD
			_contentContainerWrapper = new GtkFormsContainer();
=======
			_contentContainerWrapper = new EventBox();
>>>>>>> Update from origin (#8)
=======
			_contentContainerWrapper = new GtkFormsContainer();
>>>>>>> Update from origin (#11)
			_contentContainerWrapper.SizeAllocated += OnContentContainerWrapperSizeAllocated;
			_contentContainer = new Fixed();
			_contentContainer.Add(_image);
			_contentContainerWrapper.Add(_contentContainer);

			root.PackStart(_contentContainerWrapper, true, true, 0); // Should fill all available space

			Attach(root, 0, 1, 0, 1);

			ShowAll();
		}

		private void RefreshToolbar(HBox newToolbar)
		{
<<<<<<< HEAD
<<<<<<< HEAD
			_toolbar.Destroy();
=======
			_headerContainer.RemoveFromContainer(_toolbar);
>>>>>>> Update from origin (#8)
=======
			_toolbar.Destroy();
>>>>>>> Update from origin (#11)
			_toolbar = newToolbar;
			_headerContainer.Add(_toolbar);
			_toolbar.ShowAll();
		}

<<<<<<< HEAD
<<<<<<< HEAD
		private void RefreshContent(GtkFormsContainer newContent)
		{
			_content.Destroy();
=======
		private void RefreshContent(EventBox newContent)
		{
			_contentContainer.RemoveFromContainer(_content);
>>>>>>> Update from origin (#8)
=======
		private void RefreshContent(GtkFormsContainer newContent)
		{
			_content.Destroy();
>>>>>>> Update from origin (#11)
			_content = newContent;
			_contentContainer.Add(_content);
			_content.ShowAll();
		}

		private void OnContentContainerWrapperSizeAllocated(object o, SizeAllocatedArgs args)
		{
			_image.SetSizeRequest(args.Allocation.Width, args.Allocation.Height);
		}
	}
}
