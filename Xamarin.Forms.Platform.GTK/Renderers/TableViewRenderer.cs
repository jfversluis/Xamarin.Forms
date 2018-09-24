using System;
using System.ComponentModel;
using Xamarin.Forms.Platform.GTK.Extensions;

namespace Xamarin.Forms.Platform.GTK.Renderers
{
	public class TableViewRenderer : ViewRenderer<TableView, Controls.TableView>
	{
		private const int DefaultRowHeight = 44;

		private bool _disposed;
		private Controls.TableView _tableView;

		protected override void UpdateBackgroundColor()
		{
			base.UpdateBackgroundColor();

			UpdateBackgroundView();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (disposing && !_disposed)
			{
				_disposed = true;

				if (_tableView != null)
				{
					_tableView.OnItemTapped -= OnItemTapped;
				}
			}
		}

		protected override void OnElementChanged(ElementChangedEventArgs<TableView> e)
		{
<<<<<<< HEAD
			if (e.OldElement != null)
			{
				e.OldElement.ModelChanged -= OnModelChanged;
			}

=======
>>>>>>> Update from origin (#8)
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					// Custom control very similar to ListView.
					_tableView = new Controls.TableView();
					_tableView.OnItemTapped += OnItemTapped;

					SetNativeControl(_tableView);
				}

				SetSource();
				UpdateRowHeight();
				UpdateHasUnevenRows();
				UpdateBackgroundView();
<<<<<<< HEAD

				e.NewElement.ModelChanged += OnModelChanged;
				OnModelChanged(e.NewElement, EventArgs.Empty);
=======
>>>>>>> Update from origin (#8)
			}

			base.OnElementChanged(e);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == TableView.RowHeightProperty.PropertyName)
				UpdateRowHeight();
			else if (e.PropertyName == TableView.HasUnevenRowsProperty.PropertyName)
			{
				UpdateHasUnevenRows();
				SetSource();
			}
		}

<<<<<<< HEAD
		void SetSource()
=======
		private void SetSource()
>>>>>>> Update from origin (#8)
		{
			Control.Root = Element.Root;
		}

<<<<<<< HEAD
		void UpdateRowHeight()
=======
		private void UpdateRowHeight()
>>>>>>> Update from origin (#8)
		{
			var hasUnevenRows = Element.HasUnevenRows;

			if (hasUnevenRows)
			{
				return;
			}

			var rowHeight = Element.RowHeight;

			Control.SetRowHeight(rowHeight > 0 ? rowHeight : DefaultRowHeight);
		}

<<<<<<< HEAD
		void UpdateHasUnevenRows()
=======
		private void UpdateHasUnevenRows()
>>>>>>> Update from origin (#8)
		{
			var hasUnevenRows = Element.HasUnevenRows;

			if (hasUnevenRows)
			{
				Control.SetHasUnevenRows();
			}
			else
			{
				UpdateRowHeight();
			}
		}

<<<<<<< HEAD
		void UpdateBackgroundView()
=======
		private void UpdateBackgroundView()
>>>>>>> Update from origin (#8)
		{
			if (Element.BackgroundColor.IsDefault)
			{
				return;
			}

			var backgroundColor = Element.BackgroundColor.ToGtkColor();
			Control.SetBackgroundColor(backgroundColor);
		}

<<<<<<< HEAD
		void OnItemTapped(object sender, Controls.ItemTappedEventArgs args)
=======
		private void OnItemTapped(object sender, Controls.ItemTappedEventArgs args)
>>>>>>> Update from origin (#8)
		{
			if (Element == null)
				return;

<<<<<<< HEAD
			if (args.Item is Cell cell)
=======
			var cell = args.Item as Cell;

			if (cell != null)
>>>>>>> Update from origin (#8)
			{
				if (cell.IsEnabled)
				{
					Element.Model.RowSelected(cell);
				}
			}
		}
<<<<<<< HEAD

		void OnModelChanged(object sender, EventArgs e)
		{
			SetSource();
		}
	}
}
=======
	}
}
>>>>>>> Update from origin (#8)
