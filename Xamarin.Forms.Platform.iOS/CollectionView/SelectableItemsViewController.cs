using System;
<<<<<<< HEAD
using System.Collections.Generic;
=======
>>>>>>> Update (#12)
using Foundation;
using UIKit;

namespace Xamarin.Forms.Platform.iOS
{
	public class SelectableItemsViewController : ItemsViewController
	{
		protected readonly SelectableItemsView SelectableItemsView;

		public SelectableItemsViewController(SelectableItemsView selectableItemsView, ItemsViewLayout layout) 
			: base(selectableItemsView, layout)
		{
			SelectableItemsView = selectableItemsView;
		}

		// _Only_ called if the user initiates the selection change; will not be called for programmatic selection
		public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
<<<<<<< HEAD
			FormsSelectItem(indexPath);
=======
			UpdateFormsSelection();
>>>>>>> Update (#12)
		}

		// _Only_ called if the user initiates the selection change; will not be called for programmatic selection
		public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath)
		{
<<<<<<< HEAD
			FormsDeselectItem(indexPath);
		}

		// Called by Forms to mark an item selected 
		internal void SelectItem(object selectedItem)
		{
			var index = GetIndexForItem(selectedItem);
			CollectionView.SelectItem(index, true, UICollectionViewScrollPosition.None);
		}

		// Called by Forms to clear the native selection
		internal void ClearSelection()
		{
			var selectedItemIndexes = CollectionView.GetIndexPathsForSelectedItems();

			foreach (var index in selectedItemIndexes)
			{
				CollectionView.DeselectItem(index, true);
			}
		}

		void FormsSelectItem(NSIndexPath indexPath)
		{
			var mode = SelectableItemsView.SelectionMode;

			switch (mode)
			{
				case SelectionMode.None:
					break;
				case SelectionMode.Single:
					SelectableItemsView.SelectedItem = GetItemAtIndex(indexPath);
					break;
				case SelectionMode.Multiple:
					SelectableItemsView.SelectedItems.Add(GetItemAtIndex(indexPath));
					break;
			}
		}

		void FormsDeselectItem(NSIndexPath indexPath)
		{
			var mode = SelectableItemsView.SelectionMode;

			switch (mode)
			{
				case SelectionMode.None:
					break;
				case SelectionMode.Single:
					break;
				case SelectionMode.Multiple:
					SelectableItemsView.SelectedItems.Remove(GetItemAtIndex(indexPath));
					break;
			}
		}

		internal void UpdateNativeSelection()
		{
			if (SelectableItemsView == null)
			{
				return;
			}

=======
			UpdateFormsSelection();
		}

		internal void ClearSelection()
		{
			var paths = CollectionView.GetIndexPathsForSelectedItems();

			foreach (var path in paths)
			{
				CollectionView.DeselectItem(path, false);
			}
		}

		// Called by Forms to mark an item selected 
		internal void SelectItem(object selectedItem)
		{
			var index = GetIndexForItem(selectedItem);
			CollectionView.SelectItem(index, true, UICollectionViewScrollPosition.None);
		}

		void UpdateFormsSelection()
		{
>>>>>>> Update (#12)
			var mode = SelectableItemsView.SelectionMode;

			switch (mode)
			{
				case SelectionMode.None:
<<<<<<< HEAD
					return;
				case SelectionMode.Single:
					var selectedItem = SelectableItemsView.SelectedItem;

					if (selectedItem != null)
					{
						SelectItem(selectedItem);
					}
					else
					{
						// SelectedItem has been set to null; if an item is selected, we need to de-select it
						ClearSelection();
					}
				
					return;
				case SelectionMode.Multiple:
					SynchronizeNativeSelectionWithSelectedItems();
					break;
=======
					SelectableItemsView.SelectedItem = null;
					// TODO hartez Clear SelectedItems
					return;
				case SelectionMode.Single:
					var paths = CollectionView.GetIndexPathsForSelectedItems();
					if (paths.Length > 0)
					{
						SelectableItemsView.SelectedItem = GetItemAtIndex(paths[0]);
					}
					// TODO hartez Clear SelectedItems
					return;
				case SelectionMode.Multiple:
					// TODO hartez Handle setting SelectedItems to all the items at the selected paths	
					return;
				default:
					throw new ArgumentOutOfRangeException();
>>>>>>> Update (#12)
			}
		}

		internal void UpdateSelectionMode()
		{
			var mode = SelectableItemsView.SelectionMode;

			switch (mode)
			{
				case SelectionMode.None:
					CollectionView.AllowsSelection = false;
					CollectionView.AllowsMultipleSelection = false;
					break;
				case SelectionMode.Single:
					CollectionView.AllowsSelection = true;
					CollectionView.AllowsMultipleSelection = false;
					break;
				case SelectionMode.Multiple:
					CollectionView.AllowsSelection = true;
					CollectionView.AllowsMultipleSelection = true;
					break;
			}

<<<<<<< HEAD
			UpdateNativeSelection();
		}

		void SynchronizeNativeSelectionWithSelectedItems()
		{
			var selectedItems = SelectableItemsView.SelectedItems;
			var selectedIndexPaths = CollectionView.GetIndexPathsForSelectedItems();

			foreach (var path in selectedIndexPaths)
			{
				var itemAtPath = GetItemAtIndex(path);
				if (ShouldNotBeSelected(itemAtPath, selectedItems))
				{
					CollectionView.DeselectItem(path, true);
				}
			}

			foreach (var item in selectedItems)
			{
				SelectItem(item);
			}
		}

		bool ShouldNotBeSelected(object item, IList<object> selectedItems)
		{
			for (int n = 0; n < selectedItems.Count; n++)
			{
				if (selectedItems[n] == item)
				{
					return false;
				}
			}

			return true;
=======
			UpdateFormsSelection();
>>>>>>> Update (#12)
		}
	}
}