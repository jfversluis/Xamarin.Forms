using System;
<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> Update (#12)
using Android.Content;
using Android.Support.V7.Widget;
using Object = Java.Lang.Object;

namespace Xamarin.Forms.Platform.Android
{
	public class SelectableItemsViewAdapter : ItemsViewAdapter
	{
		protected readonly SelectableItemsView SelectableItemsView;
<<<<<<< HEAD
		List<SelectableViewHolder> _currentViewHolders = new List<SelectableViewHolder>();

		internal SelectableItemsViewAdapter(SelectableItemsView selectableItemsView,
			Func<View, Context, ItemContentView> createView = null) : base(selectableItemsView, createView)
=======

		internal SelectableItemsViewAdapter(SelectableItemsView selectableItemsView, 
			Func<IVisualElementRenderer, Context, global::Android.Views.View> createView = null) : base(selectableItemsView, createView)
>>>>>>> Update (#12)
		{
			SelectableItemsView = selectableItemsView;
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			base.OnBindViewHolder(holder, position);

			if (!(holder is SelectableViewHolder selectable))
			{
				return;
			}

			// Watch for clicks so the user can select the item held by this ViewHolder
			selectable.Clicked += SelectableOnClicked;

<<<<<<< HEAD
			// Keep track of the view holders here so we can clear the native selection
			_currentViewHolders.Add(selectable);

			// Make sure that if this item is one of the selected items, it's marked as selected
			selectable.IsSelected = PostionIsSelected(position);
		}
	
		public override void OnViewRecycled(Object holder)
		{
			if (holder is SelectableViewHolder selectable)
			{
				_currentViewHolders.Remove(selectable);
				selectable.Clicked -= SelectableOnClicked;
				selectable.IsSelected = false;
			}

			base.OnViewRecycled(holder);
		}

		internal void ClearNativeSelection()
		{
			for (int i = 0; i < _currentViewHolders.Count; i++)
			{
				_currentViewHolders[i].IsSelected = false;
			}
		}

		internal void MarkNativeSelection(object selectedItem)
		{
=======
			var selectedItem = SelectableItemsView.SelectedItem;
>>>>>>> Update (#12)
			if (selectedItem == null)
			{
				return;
			}

<<<<<<< HEAD
			var position = GetPositionForItem(selectedItem);

			for (int i = 0; i < _currentViewHolders.Count; i++)
			{
				if (_currentViewHolders[i].AdapterPosition == position)
				{
					_currentViewHolders[i].IsSelected = true;
					return;
				}
			}
		}

		int[] GetSelectedPositions()
		{
			switch (SelectableItemsView.SelectionMode)
			{
				case SelectionMode.None:
					return new int[0];

				case SelectionMode.Single:
					var selectedItem = SelectableItemsView.SelectedItem;
					if (selectedItem == null)
					{
						return new int[0];
					}

					return new int[1] { GetPositionForItem(selectedItem) };

				case SelectionMode.Multiple:
					var selectedItems = SelectableItemsView.SelectedItems;
					var result = new int[selectedItems.Count];

					for (int n = 0; n < result.Length; n++)
					{
						result[n] = GetPositionForItem(selectedItems[n]);
					}

					return result;
			}

			return new int[0];
		}

		bool PostionIsSelected(int position)
		{
			var selectedPositions = GetSelectedPositions();
			foreach (var selectedPosition in selectedPositions)
			{
				if (selectedPosition == position)
				{
					return true;
				}
			}

			return false;
=======
			// If there's a selected item, check to see if it's this one so we can mark it 'selected'
			if (GetPositionForItem(selectedItem) == position)
			{
				selectable.IsSelected = true;
			}
		}
	
		public override void OnViewRecycled(Object holder)
		{
			if (holder is SelectableViewHolder selectable)
			{
				selectable.Clicked -= SelectableOnClicked;
				selectable.IsSelected = false;
			}

			base.OnViewRecycled(holder);
>>>>>>> Update (#12)
		}

		void SelectableOnClicked(object sender, int adapterPosition)
		{
			UpdateFormsSelection(adapterPosition);
		}

		void UpdateFormsSelection(int adapterPosition)
		{
			var mode = SelectableItemsView.SelectionMode;

			switch (mode)
			{
				case SelectionMode.None:
					// Selection's not even on, so there's nothing to do here
					return;
				case SelectionMode.Single:
					SelectableItemsView.SelectedItem = ItemsSource[adapterPosition];
					return;
				case SelectionMode.Multiple:
<<<<<<< HEAD
					var item = ItemsSource[adapterPosition];
					var selectedItems = SelectableItemsView.SelectedItems;

					if (selectedItems.Contains(item))
					{
						selectedItems.Remove(item);
					}
					else
					{
						selectedItems.Add(item);
					}
					return;
=======
					// TODO hartez 2018/11/06 22:22:42 Once SelectedItems is available, toggle ItemsSource[adapterPosition] here	
					return;
				default:
					throw new ArgumentOutOfRangeException();
>>>>>>> Update (#12)
			}
		}
	}
}