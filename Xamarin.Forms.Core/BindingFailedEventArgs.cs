using System;

namespace Xamarin.Forms.Core
{
	public class BindingFailedEventArgs : EventArgs
	{
		public BindingPropertyNotFound PropertyNotFound { get; set; }
		public BindingConverterFailed ConverterFailed { get; set; }
		public BindingIndexParsingFailed IndexParsingFailed { get; set; }
	}	

	public class BindingPropertyNotFound
	{
		public BindingPropertyNotFound(string bindingName, string bindingContext, Type targetType, string propertyName)
		{
			BindingName = bindingName;
			BindingContext = bindingContext;
			TargetType = targetType;
			PropertyName = propertyName;
		}

		public string BindingName { get; }
		public string BindingContext { get; }
		public Type TargetType { get; }
		public string PropertyName { get; }
	}

	public class BindingConverterFailed
	{
		public BindingConverterFailed(object conversionTarget, Type targetType)
		{
			ConversionTarget = conversionTarget;
			TargetType = targetType;
		}

		public object ConversionTarget { get; set; }
		public Type TargetType { get; set; }
	}

	public class BindingIndexParsingFailed
	{
		public BindingIndexParsingFailed(string attemptedIndexString, Type sourceType)
		{
			AttemptedIndexString = attemptedIndexString;
			SourceType = sourceType;
		}

		public string AttemptedIndexString { get; set; }
		public Type SourceType { get; set; }
	}
}