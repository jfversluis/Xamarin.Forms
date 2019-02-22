<<<<<<< HEAD:Xamarin.Forms.Xaml.UnitTests/Issues/Gh5330.xaml.cs
﻿using System;
using System.Collections.Generic;
using NUnit.Framework;
=======
using NUnit.Framework;

using Xamarin.Forms.Core.UnitTests;

>>>>>>> Update (#12):Xamarin.Forms.Xaml.UnitTests/Issues/Gh2756.xaml.cs
using Xamarin.Forms;
using Xamarin.Forms.Core.UnitTests;

namespace Xamarin.Forms.Xaml.UnitTests
{
	[XamlCompilation(XamlCompilationOptions.Skip)]
	public partial class Gh5330 : ContentPage
	{
		public Gh5330() => InitializeComponent();
		public Gh5330(bool useCompiledXaml)
		{
			//this stub will be replaced at compile time
		}

		[TestFixture]
		class Tests
		{
			[SetUp] public void Setup() => Device.PlatformServices = new MockPlatformServices();
			[TearDown] public void TearDown() => Device.PlatformServices = null;

			[Test]
			public void FailOnUnresolvedDataType([Values(true)]bool useCompiledXaml)
			{
				if (useCompiledXaml)
<<<<<<< HEAD:Xamarin.Forms.Xaml.UnitTests/Issues/Gh5330.xaml.cs
					Assert.Throws<XamlParseException>(() => MockCompiler.Compile(typeof(Gh5330)));
=======
					Assert.Throws(new XamlParseExceptionConstraint(8, 16), () => MockCompiler.Compile(typeof(Gh2756)));
				else
					Assert.Throws(new XamlParseExceptionConstraint(8, 16), () => new Gh2756(useCompiledXaml));
>>>>>>> Update (#12):Xamarin.Forms.Xaml.UnitTests/Issues/Gh2756.xaml.cs
			}
		}
	}
}
