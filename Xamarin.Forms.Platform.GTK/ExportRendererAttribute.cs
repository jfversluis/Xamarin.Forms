using System;

namespace Xamarin.Forms
{
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
	public sealed class ExportRendererAttribute : HandlerAttribute
	{
<<<<<<< HEAD
		public ExportRendererAttribute(Type handler, Type target) : this(handler, target, null)
		{
		}

		public ExportRendererAttribute(Type handler, Type target, Type[] supportedVisuals) : base(handler, target, supportedVisuals)
=======
		public ExportRendererAttribute(Type handler, Type target) : base(handler, target)
>>>>>>> Update from origin (#8)
		{
		}
	}
}
