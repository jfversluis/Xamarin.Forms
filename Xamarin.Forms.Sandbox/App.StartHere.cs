using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Reflection;
using System.Text;
using Xamarin.Forms.StyleSheets;

namespace Xamarin.Forms.Sandbox
{
	public partial class App
=======
using System.Text;

namespace Xamarin.Forms.Sandbox
{
	public partial class App 
>>>>>>> Update (#12)
	{
		// This code is called from the App Constructor so just initialize the main page of the application here
		void InitializeMainPage()
		{
<<<<<<< HEAD


			this.Resources.Add(StyleSheet.FromAssemblyResource(
				IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly,
				"Xamarin.Forms.Sandbox.Styles.css"));

			//MainPage = CreateStackLayoutPage(new[] { new Button() {  Text = "text" } });
			//MainPage.Visual = VisualMarker.Material;
			MainPage = new ShellPage();

		//	MainPage = new NavigationPage(new MainPage());
=======
			MainPage = new ContentPage()
			{
				Content = CreateStackLayout(new[] { new Button() { Text = "text" } })
			};
>>>>>>> Update (#12)
		}
	}
}
