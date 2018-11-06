using Gtk;
using System;
using System.Collections.Generic;
using Xamarin.Forms.Platform.GTK.Cells;
using Xamarin.Forms.Platform.GTK.Extensions;

namespace Xamarin.Forms.Platform.GTK.Controls
{
	public class TableView : ScrolledWindow
	{
		private VBox _root;
		private TableRoot _source;
		private List<Container> _cells;

		public delegate void ItemTappedEventHandler(object sender, ItemTappedEventArgs args);
		public event ItemTappedEventHandler OnItemTapped = null;

		public TableView()
		{
			BuildTableView();
		}

		public TableRoot Root
		{
			get
			{
				return _source;
			}
			set
			{
<<<<<<< HEAD
<<<<<<< HEAD
				_source = value;
				RefreshSource(_source);
=======
				if (_source != value)
				{
					_source = value;
					RefreshSource(_source);
				}
>>>>>>> Update from origin (#8)
=======
				_source = value;
				RefreshSource(_source);
>>>>>>> Update from origin (#11)
			}
		}

		public void SetBackgroundColor(Gdk.Color backgroundColor)
		{
			Child?.ModifyBg(StateType.Normal, backgroundColor);
		}

		public void SetRowHeight(int rowHeight)
		{
			foreach (var cell in _cells)
			{
				cell.HeightRequest = rowHeight;
			}
		}

		public void SetHasUnevenRows()
		{
			foreach (var cell in _cells)
			{
				var rowHeight = GetUnevenRowCellHeight(cell);

				cell.HeightRequest = rowHeight;
			}
		}

<<<<<<< HEAD
<<<<<<< HEAD
		int GetUnevenRowCellHeight(Container cell)
=======
		private int GetUnevenRowCellHeight(Gtk.Container cell)
>>>>>>> Update from origin (#8)
=======
		int GetUnevenRowCellHeight(Container cell)
>>>>>>> Update from origin (#11)
		{
			int height = -1;

			var formsCell = GetXamarinFormsCell(cell);

			if (formsCell != null)
			{
				height = Convert.ToInt32(formsCell.Height);
			}

			return height;
		}

<<<<<<< HEAD
<<<<<<< HEAD
		Cell GetXamarinFormsCell(Container cell)
=======
		private Cell GetXamarinFormsCell(Container cell)
>>>>>>> Update from origin (#8)
=======
		Cell GetXamarinFormsCell(Container cell)
>>>>>>> Update from origin (#11)
		{
			try
			{
				var formsCell = cell
				   .GetType()
				   .GetProperty("Cell")
				   .GetValue(cell, null) as Cell;

				return formsCell;
			}
			catch
			{
				return null;
			}
		}

<<<<<<< HEAD
<<<<<<< HEAD
		void BuildTableView()
=======
		private void BuildTableView()
>>>>>>> Update from origin (#8)
=======
		void BuildTableView()
>>>>>>> Update from origin (#11)
		{
			CanFocus = true;
			ShadowType = ShadowType.None;
			HscrollbarPolicy = PolicyType.Never;
			VscrollbarPolicy = PolicyType.Automatic;
			BorderWidth = 0;

			_root = new VBox(false, 0);

<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> Update from origin (#11)
			Viewport viewPort = new Viewport
			{
				ShadowType = ShadowType.None
			};

<<<<<<< HEAD
=======
			Viewport viewPort = new Viewport();
			viewPort.ShadowType = ShadowType.None;
>>>>>>> Update from origin (#8)
=======
>>>>>>> Update from origin (#11)
			viewPort.Add(_root);

			Add(viewPort);

			_cells = new List<Container>();
		}

<<<<<<< HEAD
<<<<<<< HEAD
		void RefreshSource(TableRoot source)
		{
			// Clear
			_cells.Clear();

			foreach (var child in _root.AllChildren)
			{
				_root.RemoveFromContainer((Widget)child);
			}

			// Add Title
			if (!string.IsNullOrEmpty(source.Title))
			{
=======
		private void RefreshSource(TableRoot source)
=======
		void RefreshSource(TableRoot source)
>>>>>>> Update from origin (#11)
		{
			// Clear
			_cells.Clear();

			foreach (var child in _root.AllChildren)
			{
				_root.RemoveFromContainer((Widget)child);
			}

			// Add Title
			if (!string.IsNullOrEmpty(source.Title))
			{
<<<<<<< HEAD
				// Add Title
>>>>>>> Update from origin (#8)
=======
>>>>>>> Update from origin (#11)
				var titleSpan = new Span()
				{
					FontSize = 16,
					Text = source.Title ?? string.Empty
				};

				Gtk.Label title = new Gtk.Label();
				title.SetAlignment(0, 0);
				title.SetTextFromSpan(titleSpan);
				_root.PackStart(title, false, false, 0);
			}

			// Add Table Section
			for (int i = 0; i < source.Count; i++)
			{
<<<<<<< HEAD
<<<<<<< HEAD
				if (source[i] is TableSection tableSection)
=======
				var tableSection = source[i] as TableSection;

				if (tableSection != null)
>>>>>>> Update from origin (#8)
=======
				if (source[i] is TableSection tableSection)
>>>>>>> Update from origin (#11)
				{
					var tableSectionSpan = new Span()
					{
						FontSize = 12,
<<<<<<< HEAD
						Text = tableSection.Title ?? string.Empty,
						TextColor = tableSection.TextColor
=======
						Text = tableSection.Title ?? string.Empty
>>>>>>> Update from origin (#8)
					};

					// Table Section Title
					Gtk.Label sectionTitle = new Gtk.Label();
					sectionTitle.SetAlignment(0, 0);
					sectionTitle.SetTextFromSpan(tableSectionSpan);
					_root.PackStart(sectionTitle, false, false, 0);

					// Table Section Separator
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> Update from origin (#11)
					EventBox separator = new EventBox
					{
						HeightRequest = 1
					};

<<<<<<< HEAD
=======
					EventBox separator = new EventBox();
					separator.HeightRequest = 1;
>>>>>>> Update from origin (#8)
=======
>>>>>>> Update from origin (#11)
					separator.ModifyBg(StateType.Normal, Color.Black.ToGtkColor());
					_root.PackStart(separator, false, false, 0);

					// Cells
					_cells.Clear();

					for (int j = 0; j < tableSection.Count; j++)
					{
						var cell = tableSection[j];

						var renderer =
							(Cells.CellRenderer)Internals.Registrar.Registered.GetHandlerForObject<IRegisterable>(cell);
						var nativeCell = renderer.GetCell(cell, null, null);

						if (nativeCell != null)
						{
							nativeCell.ButtonPressEvent += (sender, args) =>
							{
<<<<<<< HEAD
<<<<<<< HEAD
								if (sender is CellBase gtkCell && gtkCell.Cell != null)
=======
								var gtkCell = sender as CellBase;

								if (gtkCell != null && gtkCell.Cell != null)
>>>>>>> Update from origin (#8)
=======
								if (sender is CellBase gtkCell && gtkCell.Cell != null)
>>>>>>> Update from origin (#11)
								{
									var selectedCell = gtkCell.Cell;

									OnItemTapped?.Invoke(this, new ItemTappedEventArgs(selectedCell));
								}
							};
							_cells.Add(nativeCell);
						}
					}

					foreach (var cell in _cells)
					{
						_root.PackStart(cell, false, false, 0);
					}
				}
<<<<<<< HEAD
<<<<<<< HEAD

				// Refresh
				_root.ShowAll();
=======
>>>>>>> Update from origin (#8)
=======

				// Refresh
				_root.ShowAll();
>>>>>>> Update from origin (#11)
			}
		}
	}
}
