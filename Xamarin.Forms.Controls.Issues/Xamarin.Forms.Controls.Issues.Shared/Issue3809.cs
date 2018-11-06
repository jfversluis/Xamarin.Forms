﻿using System.Linq;
using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;


#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
using Xamarin.Forms.Core.UITests;
#endif

namespace Xamarin.Forms.Controls.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 3809, "SetUseSafeArea is wiping out Page Padding ")]
	public class Issue3809 : TestMasterDetailPage
	{
		const string _setPagePadding = "Set Page Padding";
		const string _safeAreaText = "Safe Area Enabled: ";
		const string _paddingLabel = "paddingLabel";
		const string _safeAreaAutomationId = "SafeAreaAutomation";

		Label label = null;
		protected override void Init()
		{
			label = new Label()
			{
				AutomationId = _paddingLabel
			};

			Master = new ContentPage() { Title = "Master" };
			Button button = null;
			button = new Button()
			{
				Text = $"{_safeAreaText}{true}",
				AutomationId = _safeAreaAutomationId,
				Command = new Command(() =>
				{
					bool safeArea = !Detail.On<PlatformConfiguration.iOS>().UsingSafeArea();
					Detail.On<PlatformConfiguration.iOS>().SetUseSafeArea(safeArea);
					button.Text = $"{_safeAreaText}{safeArea}";
					Device.BeginInvokeOnMainThread(() => label.Text = $"{Detail.Padding.Left}, {Detail.Padding.Top}, {Detail.Padding.Right}, {Detail.Padding.Bottom}");
				})
			};

			Detail = new ContentPage()
			{
				Title = "Details",
				Content = new StackLayout()
				{
					Children =
					{
						new ListView(ListViewCachingStrategy.RecycleElement)
						{
							ItemsSource = Enumerable.Range(0,200).Select(x=> x.ToString()).ToList()
						},
						label,
						button,
						new Button()
						{
							Text = _setPagePadding,
							Command = new Command(() =>
							{
								Detail.Padding = new Thickness(25, 25, 25, 25);
								Device.BeginInvokeOnMainThread(() => label.Text = $"{Detail.Padding.Left}, {Detail.Padding.Top}, {Detail.Padding.Right}, {Detail.Padding.Bottom}");
							})
						}
					}
				}
			};

			Detail.Padding = new Thickness(25, 25, 25, 25);
			Detail.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			label.Text = $"{Detail.Padding.Left}, {Detail.Padding.Top}, {Detail.Padding.Right}, {Detail.Padding.Bottom}";
		}

#if UITEST
		[Test]
		public void SafeAreaInsetsBreaksAndroidPadding()
		{
			// ensure initial paddings are honored
			RunningApp.WaitForElement($"{_safeAreaText}{true}");
			var element = RunningApp.WaitForElement(_paddingLabel).First();

			bool usesSafeAreaInsets = false;
<<<<<<< HEAD
			if (element.ReadText() != "25, 25, 25, 25")
				usesSafeAreaInsets = true;

			Assert.AreNotEqual(element.ReadText(), "0, 0, 0, 0");
			if (!usesSafeAreaInsets)
				Assert.AreEqual(element.ReadText(), "25, 25, 25, 25");
=======
			if (element.Text != "25, 25, 25, 25")
				usesSafeAreaInsets = true;

			Assert.AreNotEqual(element.Text, "0, 0, 0, 0");
			if (!usesSafeAreaInsets)
				Assert.AreEqual(element.Text, "25, 25, 25, 25");
>>>>>>> Update from origin (#11)

			// disable Safe Area Insets
			RunningApp.Tap(_safeAreaAutomationId);
			RunningApp.WaitForElement($"{_safeAreaText}{false}");
			element = RunningApp.WaitForElement(_paddingLabel).First();

			if (usesSafeAreaInsets)
<<<<<<< HEAD
				Assert.AreEqual(element.ReadText(), "0, 0, 0, 0");
			else
				Assert.AreEqual(element.ReadText(), "25, 25, 25, 25");
=======
				Assert.AreEqual(element.Text, "0, 0, 0, 0");
			else
				Assert.AreEqual(element.Text, "25, 25, 25, 25");
>>>>>>> Update from origin (#11)

			// enable Safe Area insets
			RunningApp.Tap(_safeAreaAutomationId);
			RunningApp.WaitForElement($"{_safeAreaText}{true}");
			element = RunningApp.WaitForElement(_paddingLabel).First();
<<<<<<< HEAD
			Assert.AreNotEqual(element.ReadText(), "0, 0, 0, 0");

			if (!usesSafeAreaInsets)
				Assert.AreEqual(element.ReadText(), "25, 25, 25, 25");
=======
			Assert.AreNotEqual(element.Text, "0, 0, 0, 0");

			if (!usesSafeAreaInsets)
				Assert.AreEqual(element.Text, "25, 25, 25, 25");
>>>>>>> Update from origin (#11)


			// Set Padding and then disable safe area insets
			RunningApp.Tap(_setPagePadding);
			RunningApp.Tap(_safeAreaAutomationId);
			RunningApp.WaitForElement($"{_safeAreaText}{false}");
			element = RunningApp.WaitForElement(_paddingLabel).First();
<<<<<<< HEAD
			Assert.AreEqual(element.ReadText(), "25, 25, 25, 25");
=======
			Assert.AreEqual(element.Text, "25, 25, 25, 25");
>>>>>>> Update from origin (#11)

		}
#endif
	}
}
