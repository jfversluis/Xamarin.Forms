<<<<<<< HEAD
﻿using Windows.ApplicationModel.Core;
using System;
using Windows.UI.Xaml.Media;
=======
﻿using Windows.UI.Xaml.Media;
>>>>>>> Update from origin (#11)
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Platform.UWP
{
	internal class WindowsTicker : Ticker
	{
<<<<<<< HEAD
		[ThreadStatic]
		static Ticker s_ticker;

=======
>>>>>>> Update from origin (#11)
		protected override void DisableTimer()
		{
			CompositionTarget.Rendering -= RenderingFrameEventHandler;
		}

		protected override void EnableTimer()
		{
			CompositionTarget.Rendering += RenderingFrameEventHandler;
		}

		void RenderingFrameEventHandler(object sender, object args)
		{
			SendSignals();
<<<<<<< HEAD
		}

		protected override Ticker GetTickerInstance()
		{
			if (CoreApplication.Views.Count > 1)
			{
				// We've got multiple windows open, we'll need to use the local ThreadStatic Ticker instead of the 
				// singleton in the base class 
				if (s_ticker == null)
				{
					s_ticker = new WindowsTicker();
				}

				return s_ticker;
			}

			return base.GetTickerInstance();
=======
>>>>>>> Update from origin (#11)
		}
	}
}