using System;
using System.Diagnostics;
using System.Reflection;

namespace Xamarin.Forms.Core
{
	public static class DebugSettings
	{
		public static bool IsBindingTracingEnabled { get; set; }

		public delegate void BindingFailedEventHandler(Object sender, BindingFailedEventArgs e);

		public static event BindingFailedEventHandler BindingFailed;

		internal static void OnPropertyNotFound(object sourceObject, string bindingName, string bindingContext, Type targetType, string propertyName)
		{
			if (!IsBindingTracingEnabled)
				return;

			if (BindingFailed == null)
			{
				var composedPropertyNotFoundMessage = string.Format(BindingExpression.PropertyNotFoundErrorMessage, bindingName, bindingContext, targetType, propertyName);
				Debug.WriteLine(composedPropertyNotFoundMessage);
			}
			else
			{
				BindingFailed.Invoke(sourceObject, new BindingFailedEventArgs
				{
					PropertyNotFound = new BindingPropertyNotFound(bindingName, bindingContext, targetType, propertyName)
				});
			}
		}

		internal static void OnConverterFailed(object sourceObject, object value, Type targetType)
		{
			if (!IsBindingTracingEnabled)
				return;

			if (BindingFailed == null)
			{
				var composedConvertErrorMessage = string.Format(BindingExpression.ConvertErrorMessage, value, targetType);
				Debug.WriteLine(composedConvertErrorMessage);
			}
			else
			{
				BindingFailed?.Invoke(sourceObject, new BindingFailedEventArgs
				{
					ConverterFailed = new BindingConverterFailed(value, targetType)
				});
			}
		}

		internal static void OnIndexParsingFailed(string content, TypeInfo sourceType)
		{
			if (!IsBindingTracingEnabled)
				return;

			if (BindingFailed == null)
			{
				var composedIndexParsingErrorMessage = string.Format(BindingExpression.IndexParsingFailedErrorMessage, content, sourceType);
				Debug.WriteLine(composedIndexParsingErrorMessage);
			}
			else
			{
				BindingFailed?.Invoke(null, new BindingFailedEventArgs
				{
					IndexParsingFailed = new BindingIndexParsingFailed(content, sourceType)
				});
			}
		}
	}
}