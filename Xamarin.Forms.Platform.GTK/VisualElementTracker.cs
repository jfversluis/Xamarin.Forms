﻿using Gtk;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.GTK.Extensions;

namespace Xamarin.Forms.Platform.GTK
{
	public class VisualElementTracker<TElement, TNativeElement> : IDisposable where TElement : VisualElement where TNativeElement : Widget
	{
		private bool _isDisposed;
		private TNativeElement _control;
		private TElement _element;
<<<<<<< HEAD
<<<<<<< HEAD
		private GtkFormsContainer _container;
=======
		private EventBox _container;
>>>>>>> Update from origin (#8)
=======
		private GtkFormsContainer _container;
>>>>>>> Update from origin (#11)
		private bool _invalidateArrangeNeeded;

		private readonly NotifyCollectionChangedEventHandler _collectionChangedHandler;

		public event EventHandler Updated;

		public VisualElementTracker()
		{
			_collectionChangedHandler = ModelGestureRecognizersOnCollectionChanged;
		}

<<<<<<< HEAD
<<<<<<< HEAD
		public GtkFormsContainer Container
=======
		public EventBox Container
>>>>>>> Update from origin (#8)
=======
		public GtkFormsContainer Container
>>>>>>> Update from origin (#11)
		{
			get { return _container; }
			set
			{
				if (_container == value)
					return;

				if (_container != null)
				{
					_container.ButtonPressEvent -= OnContainerButtonPressEvent;
				}

				_container = value;

				UpdatingGestureRecognizers();

				UpdateNativeControl();
			}
		}

		public TNativeElement Control
		{
			get { return _control; }
			set
			{
				if (_control == value)
					return;

				if (_control != null)
				{
					_control.ButtonPressEvent -= OnControlButtonPressEvent;
				}

				_control = value;
				UpdateNativeControl();

				if (PreventGestureBubbling)
				{
					UpdatingGestureRecognizers();
				}
			}
		}

		public bool PreventGestureBubbling { get; set; }

		public TElement Element
		{
			get { return _element; }
			set
			{
				if (_element == value)
					return;

				if (_element != null)
				{
					_element.BatchCommitted -= OnRedrawNeeded;
					_element.PropertyChanged -= OnPropertyChanged;

					var view = _element as View;
					if (view != null)
					{
						var oldRecognizers = (ObservableCollection<IGestureRecognizer>)view.GestureRecognizers;
						oldRecognizers.CollectionChanged -= _collectionChangedHandler;
					}
				}

				_element = value;

				if (_element != null)
				{
					_element.BatchCommitted += OnRedrawNeeded;
					_element.PropertyChanged += OnPropertyChanged;

					var view = _element as View;
					if (view != null)
					{
						var newRecognizers = (ObservableCollection<IGestureRecognizer>)view.GestureRecognizers;
						newRecognizers.CollectionChanged += _collectionChangedHandler;
					}
				}

				UpdateNativeControl();
			}
		}

		protected virtual void UpdateNativeControl()
		{
			if (Element == null || Container == null)
				return;

			UpdateVisibility(Element, Container);
			UpdateOpacity(Element, Container);
			UpdateScaleAndRotation(Element, Container);
			UpdateInputTransparent(Element, Container);

			if (_invalidateArrangeNeeded)
			{
				MaybeInvalidate();
			}
			_invalidateArrangeNeeded = false;

			OnUpdated();
		}

		public void Dispose()
		{
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_isDisposed)
				return;

			_isDisposed = true;

			if (!disposing)
				return;

			if (_container != null)
			{
				_container.ButtonPressEvent -= OnContainerButtonPressEvent;
			}

			if (_element != null)
			{
				_element.BatchCommitted -= OnRedrawNeeded;
				_element.PropertyChanged -= OnPropertyChanged;

				var view = _element as View;
				if (view != null)
				{
					var oldRecognizers = (ObservableCollection<IGestureRecognizer>)view.GestureRecognizers;
					oldRecognizers.CollectionChanged -= _collectionChangedHandler;
				}
			}

			if (_control != null)
			{
				_control.ButtonPressEvent -= OnControlButtonPressEvent;
			}

<<<<<<< HEAD
<<<<<<< HEAD
			Container.Destroy();
=======
			Container.Dispose();
>>>>>>> Update from origin (#8)
=======
			Container.Destroy();
>>>>>>> Update from origin (#11)
			Container = null;
		}

		protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (Element.Batched)
			{
<<<<<<< HEAD
<<<<<<< HEAD
				if (e.PropertyName == VisualElement.XProperty.PropertyName ||
					e.PropertyName == VisualElement.YProperty.PropertyName ||
=======
				if (e.PropertyName == VisualElement.XProperty.PropertyName || 
					e.PropertyName == VisualElement.YProperty.PropertyName || 
>>>>>>> Update from origin (#8)
=======
				if (e.PropertyName == VisualElement.XProperty.PropertyName ||
					e.PropertyName == VisualElement.YProperty.PropertyName ||
>>>>>>> Update from origin (#11)
					e.PropertyName == VisualElement.WidthProperty.PropertyName ||
					e.PropertyName == VisualElement.HeightProperty.PropertyName)
				{
					_invalidateArrangeNeeded = true;
				}
				return;
			}

<<<<<<< HEAD
<<<<<<< HEAD
			if (e.PropertyName == VisualElement.AnchorXProperty.PropertyName ||
=======
			if (e.PropertyName == VisualElement.AnchorXProperty.PropertyName || 
>>>>>>> Update from origin (#8)
=======
			if (e.PropertyName == VisualElement.AnchorXProperty.PropertyName ||
>>>>>>> Update from origin (#11)
				e.PropertyName == VisualElement.AnchorYProperty.PropertyName)
			{
				UpdateScaleAndRotation(Element, Container);
			}
			else if (e.PropertyName == VisualElement.ScaleProperty.PropertyName)
			{
				UpdateScaleAndRotation(Element, Container);
			}
<<<<<<< HEAD
<<<<<<< HEAD
			else if (e.PropertyName == VisualElement.TranslationXProperty.PropertyName ||
				e.PropertyName == VisualElement.TranslationYProperty.PropertyName ||
					 e.PropertyName == VisualElement.RotationProperty.PropertyName ||
					 e.PropertyName == VisualElement.RotationXProperty.PropertyName ||
=======
			else if (e.PropertyName == VisualElement.TranslationXProperty.PropertyName || 
				e.PropertyName == VisualElement.TranslationYProperty.PropertyName ||
					 e.PropertyName == VisualElement.RotationProperty.PropertyName || 
					 e.PropertyName == VisualElement.RotationXProperty.PropertyName || 
>>>>>>> Update from origin (#8)
=======
			else if (e.PropertyName == VisualElement.TranslationXProperty.PropertyName ||
				e.PropertyName == VisualElement.TranslationYProperty.PropertyName ||
					 e.PropertyName == VisualElement.RotationProperty.PropertyName ||
					 e.PropertyName == VisualElement.RotationXProperty.PropertyName ||
>>>>>>> Update from origin (#11)
					 e.PropertyName == VisualElement.RotationYProperty.PropertyName)
			{
				UpdateRotation(Element, Container);
			}
			else if (e.PropertyName == VisualElement.IsVisibleProperty.PropertyName)
			{
				UpdateVisibility(Element, Container);
			}
			else if (e.PropertyName == VisualElement.OpacityProperty.PropertyName)
			{
				UpdateOpacity(Element, Container);
			}
			else if (e.PropertyName == VisualElement.InputTransparentProperty.PropertyName)
			{
				UpdateInputTransparent(Element, Container);
			}
		}

		private void ModelGestureRecognizersOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
		{
			UpdatingGestureRecognizers();
		}

		private void OnUpdated()
		{
			Updated?.Invoke(this, EventArgs.Empty);
		}

		private void OnRedrawNeeded(object sender, EventArgs e)
		{
			UpdateNativeControl();
		}

		private void UpdatingGestureRecognizers()
		{
			var view = Element as View;
			IList<IGestureRecognizer> gestures = view?.GestureRecognizers;

			if (_container == null || gestures == null)
				return;

			_container.ButtonPressEvent -= OnContainerButtonPressEvent;

<<<<<<< HEAD
<<<<<<< HEAD
			if (gestures.GetGesturesFor<TapGestureRecognizer>().Any() || gestures.GetGesturesFor<ClickGestureRecognizer>().Any())
=======
			if (gestures.GetGesturesFor<TapGestureRecognizer>(g => g.NumberOfTapsRequired == 1).Any())
>>>>>>> Update from origin (#8)
=======
			if (gestures.GetGesturesFor<TapGestureRecognizer>().Any() || gestures.GetGesturesFor<ClickGestureRecognizer>().Any())
>>>>>>> Update from origin (#11)
			{
				_container.ButtonPressEvent += OnContainerButtonPressEvent;
			}
			else
			{
				if (_control != null && PreventGestureBubbling)
				{
					_control.ButtonPressEvent += OnControlButtonPressEvent;
				}
			}

			bool hasPinchGesture = gestures.GetGesturesFor<PinchGestureRecognizer>().GetEnumerator().MoveNext();
			bool hasPanGesture = gestures.GetGesturesFor<PanGestureRecognizer>().GetEnumerator().MoveNext();

			if (!hasPinchGesture && !hasPanGesture)
				return;
		}

		private void MaybeInvalidate()
		{
			if (Element.IsInNativeLayout)
				return;

			var parent = Container.Parent;
			parent?.QueueDraw();
			Container.QueueDraw();
		}

		// TODO: Implement Scale
<<<<<<< HEAD
<<<<<<< HEAD
		private static void UpdateScaleAndRotation(VisualElement view, Gtk.Widget eventBox)
=======
		private static void UpdateScaleAndRotation(VisualElement view, EventBox eventBox)
>>>>>>> Update from origin (#8)
=======
		private static void UpdateScaleAndRotation(VisualElement view, Gtk.Widget eventBox)
>>>>>>> Update from origin (#11)
		{
			double anchorX = view.AnchorX;
			double anchorY = view.AnchorY;
			double scale = view.Scale;

			UpdateRotation(view, eventBox);
		}

		// TODO: Implement Rotation
<<<<<<< HEAD
<<<<<<< HEAD
		private static void UpdateRotation(VisualElement view, Gtk.Widget eventBox)
=======
		private static void UpdateRotation(VisualElement view, EventBox eventBox)
>>>>>>> Update from origin (#8)
=======
		private static void UpdateRotation(VisualElement view, Gtk.Widget eventBox)
>>>>>>> Update from origin (#11)
		{
			if (view == null)
				return;

			double anchorX = view.AnchorX;
			double anchorY = view.AnchorY;
			double rotationX = view.RotationX;
			double rotationY = view.RotationY;
			double rotation = view.Rotation;
			double translationX = view.TranslationX;
			double translationY = view.TranslationY;
			double scale = view.Scale;

			var viewRenderer = Platform.GetRenderer(view) as Widget;

			if (viewRenderer == null)
				return;

			if (rotationX % 360 == 0 &&
				rotationY % 360 == 0 &&
				rotation % 360 == 0 &&
				translationX == 0 &&
				translationY == 0 &&
				scale == 1)
			{
				return;
			}
			else
			{
				viewRenderer.MoveTo(
					scale == 0 ? 0 : translationX / scale,
					scale == 0 ? 0 : translationY / scale);
			}
		}

<<<<<<< HEAD
<<<<<<< HEAD
		private static void UpdateVisibility(VisualElement view, Gtk.Widget eventBox)
=======
		private static void UpdateVisibility(VisualElement view, EventBox eventBox)
>>>>>>> Update from origin (#8)
=======
		private static void UpdateVisibility(VisualElement view, Gtk.Widget eventBox)
>>>>>>> Update from origin (#11)
		{
			eventBox.Visible = view.IsVisible;
		}

		// TODO: Implement Opacity
<<<<<<< HEAD
<<<<<<< HEAD
		private static void UpdateOpacity(VisualElement view, Gtk.Widget eventBox)
=======
		private static void UpdateOpacity(VisualElement view, EventBox eventBox)
>>>>>>> Update from origin (#8)
=======
		private static void UpdateOpacity(VisualElement view, Gtk.Widget eventBox)
>>>>>>> Update from origin (#11)
		{

		}

		// TODO: Implement InputTransparent
<<<<<<< HEAD
<<<<<<< HEAD
		private static void UpdateInputTransparent(VisualElement view, Gtk.Widget eventBox)
		{

=======
		private static void UpdateInputTransparent(VisualElement view, EventBox eventBox)
		{
	
>>>>>>> Update from origin (#8)
=======
		private static void UpdateInputTransparent(VisualElement view, Gtk.Widget eventBox)
		{

>>>>>>> Update from origin (#11)
		}

		private void OnContainerButtonPressEvent(object o, ButtonPressEventArgs args)
		{
<<<<<<< HEAD
<<<<<<< HEAD
			var button = args.Event.Button;
			if (button != 1 && button != 3)
=======
			if (args.Event.Button != 1)
>>>>>>> Update from origin (#8)
=======
			var button = args.Event.Button;
			if (button != 1 && button != 3)
>>>>>>> Update from origin (#11)
			{
				return;
			}

			var view = Element as View;

			if (view == null)
				return;

<<<<<<< HEAD
<<<<<<< HEAD
			int numClicks = 0;
			switch (args.Event.Type)
			{
				case Gdk.EventType.ThreeButtonPress:
					numClicks = 3;
					break;
				case Gdk.EventType.TwoButtonPress:
					numClicks = 2;
					break;
				case Gdk.EventType.ButtonPress:
					numClicks = 1;
					break;
				default:
					return;
			}

			// Taps or Clicks
			if (button == 1)
			{
				IEnumerable<TapGestureRecognizer> tapGestures = view.GestureRecognizers
					.GetGesturesFor<TapGestureRecognizer>(g => g.NumberOfTapsRequired == numClicks);

				foreach (TapGestureRecognizer recognizer in tapGestures)
					recognizer.SendTapped(view);

				IEnumerable<ClickGestureRecognizer> clickGestures = view.GestureRecognizers
					.GetGesturesFor<ClickGestureRecognizer>(g => g.NumberOfClicksRequired == numClicks &&
															g.Buttons == ButtonsMask.Primary);

				foreach (ClickGestureRecognizer recognizer in clickGestures)
					recognizer.SendClicked(view, ButtonsMask.Primary);
			}
			else
			{
				// right click
				IEnumerable<ClickGestureRecognizer> rightClickGestures = view.GestureRecognizers
					.GetGesturesFor<ClickGestureRecognizer>(g => g.NumberOfClicksRequired == numClicks &&
															g.Buttons == ButtonsMask.Secondary);

				foreach (ClickGestureRecognizer recognizer in rightClickGestures)
					recognizer.SendClicked(view, ButtonsMask.Secondary);
=======
			if (args.Event.Type == Gdk.EventType.TwoButtonPress)
=======
			int numClicks = 0;
			switch (args.Event.Type)
>>>>>>> Update from origin (#11)
			{
				case Gdk.EventType.ThreeButtonPress:
					numClicks = 3;
					break;
				case Gdk.EventType.TwoButtonPress:
					numClicks = 2;
					break;
				case Gdk.EventType.ButtonPress:
					numClicks = 1;
					break;
				default:
					return;
			}

			// Taps or Clicks
			if (button == 1)
			{
				IEnumerable<TapGestureRecognizer> tapGestures = view.GestureRecognizers
					.GetGesturesFor<TapGestureRecognizer>(g => g.NumberOfTapsRequired == numClicks);

				foreach (TapGestureRecognizer recognizer in tapGestures)
					recognizer.SendTapped(view);
<<<<<<< HEAD
>>>>>>> Update from origin (#8)
=======

				IEnumerable<ClickGestureRecognizer> clickGestures = view.GestureRecognizers
					.GetGesturesFor<ClickGestureRecognizer>(g => g.NumberOfClicksRequired == numClicks &&
															g.Buttons == ButtonsMask.Primary);

				foreach (ClickGestureRecognizer recognizer in clickGestures)
					recognizer.SendClicked(view, ButtonsMask.Primary);
			}
			else
			{
				// right click
				IEnumerable<ClickGestureRecognizer> rightClickGestures = view.GestureRecognizers
					.GetGesturesFor<ClickGestureRecognizer>(g => g.NumberOfClicksRequired == numClicks &&
															g.Buttons == ButtonsMask.Secondary);

				foreach (ClickGestureRecognizer recognizer in rightClickGestures)
					recognizer.SendClicked(view, ButtonsMask.Secondary);
>>>>>>> Update from origin (#11)
			}
		}

		private void OnControlButtonPressEvent(object o, ButtonPressEventArgs args)
		{
			args.RetVal = true;
		}
	}
}
