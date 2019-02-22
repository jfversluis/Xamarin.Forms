using System;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Widget;
using AView = Android.Views.View;
using Object = Java.Lang.Object;
using ViewGroup = Android.Views.ViewGroup;

namespace Xamarin.Forms.Platform.Android
{
<<<<<<< HEAD
=======
	// TODO hartez 2018/07/25 14:43:04 Experiment with an ItemSource property change as _adapter.notifyDataSetChanged	

>>>>>>> Update (#12)
	public class ItemsViewAdapter : RecyclerView.Adapter
	{
		const int TextView = 41;
		const int TemplatedView = 42;

		protected readonly ItemsView ItemsView;
<<<<<<< HEAD
		readonly Func<View, Context, ItemContentView> _createItemContentView;
		internal readonly IItemsViewSource ItemsSource;
		bool _disposed;
=======
		readonly Func<IVisualElementRenderer, Context, AView> _createView;
		internal readonly IItemsViewSource ItemsSource;
>>>>>>> Update (#12)

		internal ItemsViewAdapter(ItemsView itemsView, Func<View, Context, ItemContentView> createItemContentView = null)
		{
			CollectionView.VerifyCollectionViewFlagEnabled(nameof(ItemsViewAdapter));

			ItemsView = itemsView;
<<<<<<< HEAD
			_createItemContentView = createItemContentView;
=======
			_createView = createView;
>>>>>>> Update (#12)
			ItemsSource = ItemsSourceFactory.Create(itemsView.ItemsSource, this);

			if (_createItemContentView == null)
			{
				_createItemContentView = (view, context) => new ItemContentView(context);
			}
		}

		public override void OnViewRecycled(Object holder)
		{
			if (holder is TemplatedItemViewHolder templatedItemViewHolder)
			{
<<<<<<< HEAD
				templatedItemViewHolder.Recycle(ItemsView);
=======
				ItemsView.RemoveLogicalChild(templatedItemViewHolder.View);
>>>>>>> Update (#12)
			}

			base.OnViewRecycled(holder);
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			switch (holder)
			{
				case TextViewHolder textViewHolder:
					textViewHolder.TextView.Text = ItemsSource[position].ToString();
					break;
				case TemplatedItemViewHolder templatedItemViewHolder:
<<<<<<< HEAD
					templatedItemViewHolder.Bind(ItemsSource[position], ItemsView);
=======
					BindableObject.SetInheritedBindingContext(templatedItemViewHolder.View, ItemsSource[position]);
>>>>>>> Update (#12)
					break;
			}
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			var context = parent.Context;

			if(viewType == TextView)
			{
				var view = new TextView(context);
				return new TextViewHolder(view);
			}

<<<<<<< HEAD
			var itemContentView = new ItemContentView(parent.Context);
			return new TemplatedItemViewHolder(itemContentView, ItemsView.ItemTemplate);
=======
			// Realize the content, create a renderer out of it, and use that
			var templateElement = (View)template.CreateContent();
			ItemsView.AddLogicalChild(templateElement);
			var itemContentControl = _createView(CreateRenderer(templateElement, context), context);

			return new TemplatedItemViewHolder(itemContentControl, templateElement);
		}

		static IVisualElementRenderer CreateRenderer(View view, Context context)
		{
			if (view == null)
			{
				throw new ArgumentNullException(nameof(view));
			}

			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			var renderer = Platform.CreateRenderer(view, context);
			Platform.SetRenderer(view, renderer);

			return renderer;
>>>>>>> Update (#12)
		}

		public override int ItemCount => ItemsSource.Count;

		public override int GetItemViewType(int position)
		{
<<<<<<< HEAD
			// Does the ItemsView have a DataTemplate?
			// TODO ezhart We could probably cache this instead of having to GetValue every time
			if (ItemsView.ItemTemplate == null)
			{
				// No template, just use the Text view
				return TextView;
			}

			return TemplatedView;
		}

		protected override void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					ItemsSource?.Dispose();
				}

				_disposed = true;

				base.Dispose(disposing);
			}
=======
			// TODO hartez We might be able to turn this to our own purposes
			// We might be able to have the CollectionView signal the adapter if the ItemTemplate property changes
			// And as long as it's null, we return a value to that effect here
			// Then we don't have to check _itemsView.ItemTemplate == null in OnCreateViewHolder, we can just use
			// the viewType parameter.
			return 42;
>>>>>>> Update (#12)
		}

		public virtual int GetPositionForItem(object item)
		{
			for (int n = 0; n < ItemsSource.Count; n++)
			{
				if (ItemsSource[n] == item)
				{
					return n;
				}
			}

			return -1;
		}
	}
}