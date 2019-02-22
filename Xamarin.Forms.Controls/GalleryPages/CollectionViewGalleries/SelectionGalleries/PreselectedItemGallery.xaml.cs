<<<<<<< HEAD
﻿using System.Linq;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
>>>>>>> Update (#12)
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Controls.GalleryPages.CollectionViewGalleries.SelectionGalleries
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PreselectedItemGallery : ContentPage
	{
		readonly DemoFilteredItemSource _demoFilteredItemSource = new DemoFilteredItemSource();

<<<<<<< HEAD
		public PreselectedItemGallery()
		{
			InitializeComponent();
=======
		public PreselectedItemGallery ()
		{
			InitializeComponent ();
>>>>>>> Update (#12)

			CollectionView.ItemTemplate = ExampleTemplates.PhotoTemplate();
			CollectionView.ItemsSource = _demoFilteredItemSource.Items;

			CollectionView.SelectedItem = _demoFilteredItemSource.Items.Skip(2).First();
			CollectionView.SelectionMode = SelectionMode.Single;
		}
	}
}