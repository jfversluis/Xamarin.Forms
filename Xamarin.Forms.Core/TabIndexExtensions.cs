using System.Collections.Generic;
using Xamarin.Forms.Internals;
<<<<<<< HEAD
using System.Linq;
using System;
=======
>>>>>>> Update from origin (#8)

namespace Xamarin.Forms
{
	public static class TabIndexExtensions
	{
<<<<<<< HEAD
		public static SortedDictionary<int, List<ITabStopElement>> GetSortedTabIndexesOnParentPage(this VisualElement element, out int countChildrensWithTabStopWithoutThis)
		{
			return new SortedDictionary<int, List<ITabStopElement>>(TabIndexExtensions.GetTabIndexesOnParentPage(element, out countChildrensWithTabStopWithoutThis));
		}

		public static IDictionary<int, List<ITabStopElement>> GetTabIndexesOnParentPage(this ITabStopElement element, out int countChildrensWithTabStopWithoutThis, bool checkContainsElement = true)
		{
			countChildrensWithTabStopWithoutThis = 0;

			Element parentPage = (element as NavigableElement).Parent;
=======
		public static IDictionary<int, List<VisualElement>> GetTabIndexesOnParentPage(this VisualElement element, out int countChildrensWithTabStopWithoutThis)
		{
			countChildrensWithTabStopWithoutThis = 0;

			Element parentPage = element.Parent;
>>>>>>> Update from origin (#8)
			while (parentPage != null && !(parentPage is Page))
				parentPage = parentPage.Parent;

			var descendantsOnPage = parentPage?.VisibleDescendants();
<<<<<<< HEAD

			if (parentPage is Shell shell)
				descendantsOnPage = shell.Items;

			if (descendantsOnPage == null)
				return null;

			var childrensWithTabStop = new List<ITabStopElement>();
			foreach (var descendant in descendantsOnPage)
			{
				if (descendant is ITabStopElement visualElement && visualElement.IsTabStop)
					childrensWithTabStop.Add(visualElement);
			}
			if (checkContainsElement && !childrensWithTabStop.Contains(element))
=======
			if (descendantsOnPage == null)
				return null;

			var childrensWithTabStop = new List<VisualElement>();
			foreach (var descendant in descendantsOnPage)
			{
				if (descendant is VisualElement visualElement && visualElement.IsTabStop)
					childrensWithTabStop.Add(visualElement);
			}
			if (!childrensWithTabStop.Contains(element))
>>>>>>> Update from origin (#8)
				return null;

			countChildrensWithTabStopWithoutThis = childrensWithTabStop.Count - 1;
			return childrensWithTabStop.GroupToDictionary(c => c.TabIndex);
		}

<<<<<<< HEAD
		public static ITabStopElement FindNextElement(this ITabStopElement element, bool forwardDirection, IDictionary<int, List<ITabStopElement>> tabIndexes, ref int tabIndex) 
		{
			if (!tabIndexes.TryGetValue(tabIndex, out var tabGroup))
				return null;

=======
		public static VisualElement FindNextElement(this VisualElement element, bool forwardDirection, IDictionary<int, List<VisualElement>> tabIndexes, ref int tabIndex)
		{
			var tabGroup = tabIndexes[tabIndex];
>>>>>>> Update from origin (#8)
			if (!forwardDirection)
			{
				// search prev element in same TabIndex group
				var prevSubIndex = tabGroup.IndexOf(element) - 1;
				if (prevSubIndex >= 0 && prevSubIndex < tabGroup.Count)
				{
					return tabGroup[prevSubIndex];
				}
				else // search prev element in prev TabIndex group
				{
					var smallerMax = int.MinValue;
					var tabIndexesMax = int.MinValue;
					foreach (var index in tabIndexes.Keys)
					{
						if (index < tabIndex && smallerMax < index)
							smallerMax = index;
						if (tabIndexesMax < index)
							tabIndexesMax = index;
					}
					tabIndex = smallerMax != int.MinValue ? smallerMax : tabIndexesMax;
					return tabIndexes[tabIndex][0];
				}
			}
			else // Forward
			{
				// search next element in same TabIndex group
				var nextSubIndex = tabGroup.IndexOf(element) + 1;
				if (nextSubIndex > 0 && nextSubIndex < tabGroup.Count)
				{
					return tabGroup[nextSubIndex];
				}
				else // search next element in next TabIndex group
				{
					var biggerMin = int.MaxValue;
					var tabIndexesMin = int.MaxValue;
					foreach (var index in tabIndexes.Keys)
					{
						if (index > tabIndex && biggerMin > index)
							biggerMin = index;
						if (tabIndexesMin > index)
							tabIndexesMin = index;
					}
					tabIndex = biggerMin != int.MaxValue ? biggerMin : tabIndexesMin;
					return tabIndexes[tabIndex][0];
				}
			}
		}
	}
}