<<<<<<< HEAD
using System;
using Xamarin.Forms.Internals;

=======
>>>>>>> Update (#12)
namespace Xamarin.Forms.Platform.Android
{
	internal class TemplatedItemViewHolder : SelectableViewHolder
	{
<<<<<<< HEAD
		readonly ItemContentView _itemContentView;
		readonly DataTemplate _template;
		DataTemplate _selectedTemplate;

		public View View { get; private set; }

		public TemplatedItemViewHolder(ItemContentView itemContentView, DataTemplate template) : base(itemContentView)
		{
			_itemContentView = itemContentView;
			_template = template;
=======
		public View View { get; }

		public TemplatedItemViewHolder(global::Android.Views.View itemView, View rootElement) : base(itemView)
		{
			View = rootElement;
>>>>>>> Update (#12)
		}

		protected override void OnSelectedChanged()
		{
			base.OnSelectedChanged();

<<<<<<< HEAD
			if (View == null)
			{
				return;
			}

=======
>>>>>>> Update (#12)
			VisualStateManager.GoToState(View, IsSelected 
				? VisualStateManager.CommonStates.Selected 
				: VisualStateManager.CommonStates.Normal);
		}
<<<<<<< HEAD

		public void Recycle(ItemsView itemsView)
		{
			View.BindingContext = null;
			itemsView.RemoveLogicalChild(View);
		}

		public void Bind(object itemBindingContext, ItemsView itemsView)
		{
			var template = _template.SelectDataTemplate(itemBindingContext, itemsView);

			if(template != _selectedTemplate)
			{
				_itemContentView.Recycle();
				View = (View)template.CreateContent();
				_itemContentView.RealizeContent(View);
				_selectedTemplate = template;
			}

			// Set the binding context before we add it as a child of the ItemsView; otherwise, it will
			// inherit the ItemsView's binding context
			View.BindingContext = itemBindingContext;

			itemsView.AddLogicalChild(View);
		}
=======
>>>>>>> Update (#12)
	}
}