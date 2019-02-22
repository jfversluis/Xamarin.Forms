using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Maps
{
	public class Map : View, IEnumerable<Pin>
	{
		public static readonly BindableProperty MapTypeProperty = BindableProperty.Create("MapType", typeof(MapType), typeof(Map), default(MapType));

		public static readonly BindableProperty IsShowingUserProperty = BindableProperty.Create("IsShowingUser", typeof(bool), typeof(Map), default(bool));

		public static readonly BindableProperty HasScrollEnabledProperty = BindableProperty.Create("HasScrollEnabled", typeof(bool), typeof(Map), true);

		public static readonly BindableProperty HasZoomEnabledProperty = BindableProperty.Create("HasZoomEnabled", typeof(bool), typeof(Map), true);

<<<<<<< HEAD
		public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(Map), default(IEnumerable),
=======
		public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(IEnumerable), typeof(IEnumerable), typeof(Map), default(IEnumerable),
>>>>>>> Update (#12)
			propertyChanged: (b, o, n) => ((Map)b).OnItemsSourcePropertyChanged((IEnumerable)o, (IEnumerable)n));

		public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(Map), default(DataTemplate),
			propertyChanged: (b, o, n) => ((Map)b).OnItemTemplatePropertyChanged((DataTemplate)o, (DataTemplate)n));

<<<<<<< HEAD
		public static readonly BindableProperty ItemTemplateSelectorProperty = BindableProperty.Create(nameof(ItemTemplateSelector), typeof(DataTemplateSelector), typeof(Map), default(DataTemplateSelector),
			propertyChanged: (b, o, n) => ((Map)b).OnItemTemplateSelectorPropertyChanged());

=======
>>>>>>> Update (#12)
		readonly ObservableCollection<Pin> _pins = new ObservableCollection<Pin>();
		MapSpan _visibleRegion;

		public Map(MapSpan region)
		{
			LastMoveToRegion = region;

			VerticalOptions = HorizontalOptions = LayoutOptions.FillAndExpand;

			_pins.CollectionChanged += PinsOnCollectionChanged;
		}

		// center on Rome by default
		public Map() : this(new MapSpan(new Position(41.890202, 12.492049), 0.1, 0.1))
		{
		}

		public bool HasScrollEnabled
		{
			get { return (bool)GetValue(HasScrollEnabledProperty); }
			set { SetValue(HasScrollEnabledProperty, value); }
		}

		public bool HasZoomEnabled
		{
			get { return (bool)GetValue(HasZoomEnabledProperty); }
			set { SetValue(HasZoomEnabledProperty, value); }
		}

		public bool IsShowingUser
		{
			get { return (bool)GetValue(IsShowingUserProperty); }
			set { SetValue(IsShowingUserProperty, value); }
		}

		public MapType MapType
		{
			get { return (MapType)GetValue(MapTypeProperty); }
			set { SetValue(MapTypeProperty, value); }
		}

		public IList<Pin> Pins
		{
			get { return _pins; }
		}

		public IEnumerable ItemsSource
		{
			get { return (IEnumerable)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		public DataTemplate ItemTemplate
		{
			get { return (DataTemplate)GetValue(ItemTemplateProperty); }
			set { SetValue(ItemTemplateProperty, value); }
		}

<<<<<<< HEAD
		public DataTemplateSelector ItemTemplateSelector
		{
			get { return (DataTemplateSelector)GetValue(ItemTemplateSelectorProperty); }
			set { SetValue(ItemTemplateSelectorProperty, value); }
		}
		
		public event EventHandler<MapClickedEventArgs> MapClicked;
		
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SendMapClicked(Position position) => MapClicked?.Invoke(this, new MapClickedEventArgs(position));

=======
>>>>>>> Update (#12)
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void SetVisibleRegion(MapSpan value) => VisibleRegion = value;
		public MapSpan VisibleRegion
		{
			get { return _visibleRegion; }
			internal set
			{
				if (_visibleRegion == value)
					return;
				if (value == null)
					throw new ArgumentNullException(nameof(value));
				OnPropertyChanging();
				_visibleRegion = value;
				OnPropertyChanged();
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public MapSpan LastMoveToRegion { get; private set; }

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<Pin> GetEnumerator()
		{
			return _pins.GetEnumerator();
		}

		public void MoveToRegion(MapSpan mapSpan)
		{
			if (mapSpan == null)
				throw new ArgumentNullException(nameof(mapSpan));
			LastMoveToRegion = mapSpan;
			MessagingCenter.Send(this, "MapMoveToRegion", mapSpan);
		}

		void PinsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.NewItems != null && e.NewItems.Cast<Pin>().Any(pin => pin.Label == null))
				throw new ArgumentException("Pin must have a Label to be added to a map");
		}

		void OnItemsSourcePropertyChanged(IEnumerable oldItemsSource, IEnumerable newItemsSource)
		{
			if (oldItemsSource is INotifyCollectionChanged ncc)
			{
				ncc.CollectionChanged -= OnItemsSourceCollectionChanged;
			}

			if (newItemsSource is INotifyCollectionChanged ncc1)
			{
				ncc1.CollectionChanged += OnItemsSourceCollectionChanged;
			}

			_pins.Clear();
			CreatePinItems();
		}

		void OnItemTemplatePropertyChanged(DataTemplate oldItemTemplate, DataTemplate newItemTemplate)
		{
			if (newItemTemplate is DataTemplateSelector)
			{
<<<<<<< HEAD
				throw new NotSupportedException(
					$"The {nameof(Map)}.{ItemTemplateProperty.PropertyName} property only supports {nameof(DataTemplate)}." +
					$" Set the {nameof(Map)}.{ItemTemplateSelectorProperty.PropertyName} property instead to use a {nameof(DataTemplateSelector)}");
=======
				throw new NotSupportedException($"You are using an instance of {nameof(DataTemplateSelector)} to set the {nameof(Map)}.{ItemTemplateProperty.PropertyName} property. Use an instance of a {nameof(DataTemplate)} property instead to set an item template.");
>>>>>>> Update (#12)
			}

			_pins.Clear();
			CreatePinItems();
		}

<<<<<<< HEAD
		void OnItemTemplateSelectorPropertyChanged()
		{
			_pins.Clear();
			CreatePinItems();
		}

		void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			e.Apply(
				insert: (item, _, __) => CreatePin(item),
				removeAt: (item, _) => RemovePin(item),
				reset: () => _pins.Clear());
=======
		void OnItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					if (e.NewStartingIndex == -1)
						goto case NotifyCollectionChangedAction.Reset;
					foreach (object item in e.NewItems)
						CreatePin(item);
					break;
				case NotifyCollectionChangedAction.Move:
					if (e.OldStartingIndex == -1 || e.NewStartingIndex == -1)
						goto case NotifyCollectionChangedAction.Reset;
					// Not tracking order
					break;
				case NotifyCollectionChangedAction.Remove:
					if (e.OldStartingIndex == -1)
						goto case NotifyCollectionChangedAction.Reset;
					foreach (object item in e.OldItems)
						RemovePin(item);
					break;
				case NotifyCollectionChangedAction.Replace:
					if (e.OldStartingIndex == -1)
						goto case NotifyCollectionChangedAction.Reset;
					foreach (object item in e.OldItems)
						RemovePin(item);
					foreach (object item in e.NewItems)
						CreatePin(item);
					break;
				case NotifyCollectionChangedAction.Reset:
					_pins.Clear();
					break;
			}
>>>>>>> Update (#12)
		}

		void CreatePinItems()
		{
<<<<<<< HEAD
			if (ItemsSource == null || (ItemTemplate == null && ItemTemplateSelector == null))
=======
			if (ItemsSource == null || ItemTemplate == null)
>>>>>>> Update (#12)
			{
				return;
			}

			foreach (object item in ItemsSource)
			{
				CreatePin(item);
			}
		}

		void CreatePin(object newItem)
		{
<<<<<<< HEAD
			DataTemplate itemTemplate = ItemTemplate;
			if (itemTemplate == null)
				itemTemplate = ItemTemplateSelector?.SelectTemplate(newItem, this);

			if (itemTemplate == null)
				return;

			var pin = (Pin)itemTemplate.CreateContent();
=======
			if (ItemTemplate == null)
			{
				return;
			}

			var pin = (Pin)ItemTemplate.CreateContent();
>>>>>>> Update (#12)
			pin.BindingContext = newItem;
			_pins.Add(pin);
		}

		void RemovePin(object itemToRemove)
		{
<<<<<<< HEAD
			// Instead of just removing by item (i.e. _pins.Remove(pinToRemove))
			//  we need to remove by index because of how Pin.Equals() works
			for (int i = 0; i < _pins.Count; ++i)
			{
				Pin pin = _pins[i];
				if (pin.BindingContext?.Equals(itemToRemove) == true)
				{
					_pins.RemoveAt(i);
				}
=======
			Pin pinToRemove = _pins.FirstOrDefault(pin => pin.BindingContext?.Equals(itemToRemove) == true);
			if (pinToRemove != null)
			{
				_pins.Remove(pinToRemove);
>>>>>>> Update (#12)
			}
		}
	}
}