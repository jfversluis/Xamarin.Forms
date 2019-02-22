using System;
using System.ComponentModel;
using Android.Content;

namespace Xamarin.Forms.Platform.Android
{
	public class SelectableItemsViewRenderer : ItemsViewRenderer
	{
		SelectableItemsView SelectableItemsView => (SelectableItemsView)ItemsView;
<<<<<<< HEAD
		SelectableItemsViewAdapter SelectableItemsViewAdapter => (SelectableItemsViewAdapter)ItemsViewAdapter;
=======

		SelectableItemsViewAdapter SelectableItemsViewAdapter => (SelectableItemsViewAdapter)ItemsViewAdapter; 
>>>>>>> Update (#12)

		public SelectableItemsViewRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs changedProperty)
		{
			base.OnElementPropertyChanged(sender, changedProperty);
<<<<<<< HEAD

			if (changedProperty.IsOneOf(SelectableItemsView.SelectedItemProperty, 
				SelectableItemsView.SelectedItemsProperty, 
				SelectableItemsView.SelectionModeProperty))
=======
			
			if (changedProperty.Is(SelectableItemsView.SelectedItemProperty))
>>>>>>> Update (#12)
			{
				UpdateNativeSelection();
			}
		}

		protected override void SetUpNewElement(ItemsView newElement)
		{
			if (newElement != null && !(newElement is SelectableItemsView))
			{
				throw new ArgumentException($"{nameof(newElement)} must be of type {typeof(SelectableItemsView).Name}");
			}

			base.SetUpNewElement(newElement);

			UpdateNativeSelection();
		}

		protected override void UpdateAdapter()
		{
			ItemsViewAdapter = new SelectableItemsViewAdapter(SelectableItemsView);
			SwapAdapter(ItemsViewAdapter, true);
		}

<<<<<<< HEAD
		void UpdateNativeSelection()
		{
			var mode = SelectableItemsView.SelectionMode;

			SelectableItemsViewAdapter.ClearNativeSelection();

			switch (mode)
			{
				case SelectionMode.None:
					return;

				case SelectionMode.Single:
					var selectedItem = SelectableItemsView.SelectedItem;
					SelectableItemsViewAdapter.MarkNativeSelection(selectedItem);
					return;

				case SelectionMode.Multiple:
					var selectedItems = SelectableItemsView.SelectedItems;
					
					foreach(var item in selectedItems)
					{
						SelectableItemsViewAdapter.MarkNativeSelection(item);
					}
					return;
			}
=======
		void ClearSelection()
		{
			for (int i = 0, size = ChildCount; i < size; i++)
			{
				var holder = GetChildViewHolder(GetChildAt(i));
				
				if (holder is SelectableViewHolder selectable)
				{
					selectable.IsSelected = false;
				}
			}
		}

		void MarkItemSelected(object selectedItem)
		{
			var position = ItemsViewAdapter.GetPositionForItem(selectedItem);
			var selectedHolder = FindViewHolderForAdapterPosition(position);
			if (selectedHolder == null)
			{
				return;
			}

			if (selectedHolder is SelectableViewHolder selectable)
			{
				selectable.IsSelected = true;
			}
		}

		void UpdateNativeSelection()
		{
			var mode = SelectableItemsView.SelectionMode;
			var selectedItem = SelectableItemsView.SelectedItem;

			if (selectedItem == null)
			{
				if (mode == SelectionMode.None || mode == SelectionMode.Single)
				{
					ClearSelection();
				}

				// If the mode is Multiple and SelectedItem is set to null, don't do anything
				return;
			}

			if (mode != SelectionMode.Multiple)
			{
				ClearSelection();
				MarkItemSelected(selectedItem);
			}

			// TODO hartez 2018/11/06 22:32:07 This doesn't cover all the possible cases yet; need to handle multiple selection	
>>>>>>> Update (#12)
		}
	}
}