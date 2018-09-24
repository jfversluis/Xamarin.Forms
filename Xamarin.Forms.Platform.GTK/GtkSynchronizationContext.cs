using GLib;
using System;
using System.Threading;

namespace Xamarin.Forms.Platform.GTK
{
	public class GtkSynchronizationContext : SynchronizationContext
	{
		public override void Post(SendOrPostCallback d, object state)
		{
<<<<<<< HEAD
			Gtk.Application.Invoke((s, e) =>
			{
				d(state);
=======
			Idle.Add(() =>
			{
				d(state);
				return false;
>>>>>>> Update from origin (#8)
			});
		}

		public override void Send(SendOrPostCallback d, object state)
		{
			if (System.Threading.Thread.CurrentThread.ManagedThreadId == FormsWindow.MainThreadID)
			{
				d(state);
			}
			else
			{
				var evt = new ManualResetEvent(false);
				Exception exception = null;

<<<<<<< HEAD
				Gtk.Application.Invoke((s, e) =>
=======
				Idle.Add(() =>
>>>>>>> Update from origin (#8)
				{
					try
					{
						d(state);
					}
					catch (Exception ex)
					{
						exception = ex;
					}
					finally
					{
						evt.Set();
					}
<<<<<<< HEAD
=======
					return false;
>>>>>>> Update from origin (#8)
				});

				evt.WaitOne();

				if (exception != null)
					throw exception;
			}
		}
	}
}
