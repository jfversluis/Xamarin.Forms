﻿using System;
using System.Collections.ObjectModel;

namespace Xamarin.Forms.Controls.GalleryPages.CollectionViewGalleries
{
<<<<<<< HEAD
	internal class ItemAdder : ObservableCollectionModifier
=======
	internal class ItemAdder : ObservableCollectionModifier 
>>>>>>> Update (#12)
	{
		public ItemAdder(CollectionView cv) : base(cv, "Adder")
		{
		}

		protected override void ModifyObservableCollection(ObservableCollection<CollectionViewGalleryTestItem> observableCollection, params int[] indexes)
		{
			var item = new CollectionViewGalleryTestItem(DateTime.Now, "Added", "oasis.jpg", observableCollection.Count);
			observableCollection.Add(item);
		}
	}
}