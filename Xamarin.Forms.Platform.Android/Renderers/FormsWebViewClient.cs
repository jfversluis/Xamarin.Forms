using System;
<<<<<<< HEAD
using System.ComponentModel;
using Android.Graphics;
using Android.Runtime;
using Android.Webkit;
using WView = Android.Webkit.WebView;
=======
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
>>>>>>> Update from origin (#8)

namespace Xamarin.Forms.Platform.Android
{
	public class FormsWebViewClient : WebViewClient
	{
		WebNavigationResult _navigationResult = WebNavigationResult.Success;
		WebViewRenderer _renderer;
<<<<<<< HEAD
		string _lastUrlNavigatedCancel;

		public FormsWebViewClient(WebViewRenderer renderer)
			=> _renderer = renderer ?? throw new ArgumentNullException("renderer");

		protected FormsWebViewClient(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}

		bool SendNavigatingCanceled(string url) => _renderer?.SendNavigatingCanceled(url) ?? true;

		[Obsolete("ShouldOverrideUrlLoading(view,url) is obsolete as of version 4.0.0. This method was deprecated in API level 24.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		// api 19-23
		public override bool ShouldOverrideUrlLoading(WView view, string url)
			=> SendNavigatingCanceled(url);

		// api 24+
		public override bool ShouldOverrideUrlLoading(WView view, IWebResourceRequest request)
			=> SendNavigatingCanceled(request?.Url?.ToString());

		public override void OnPageStarted(WView view, string url, Bitmap favicon)
		{
			if (_renderer == null || string.IsNullOrWhiteSpace(url) || url == WebViewRenderer.AssetBaseUrl)
				return;

			var cancel = false;
			if (!url.Equals(_renderer.UrlCanceled, StringComparison.OrdinalIgnoreCase))
				cancel = SendNavigatingCanceled(url);
			_renderer.UrlCanceled = null;

			if (cancel)
			{
				_navigationResult = WebNavigationResult.Cancel;
				view.StopLoading();
			}
			else
			{
				_navigationResult = WebNavigationResult.Success;
=======

		public FormsWebViewClient(WebViewRenderer renderer)
		{
			if (renderer == null)
				throw new ArgumentNullException("renderer");
			_renderer = renderer;
		}

		protected FormsWebViewClient(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{

		}

		public override void OnPageStarted(global::Android.Webkit.WebView view, string url, Bitmap favicon)
		{
			if (_renderer?.Element == null || url == WebViewRenderer.AssetBaseUrl)
				return;

			var args = new WebNavigatingEventArgs(WebNavigationEvent.NewPage, new UrlWebViewSource { Url = url }, url);

			_renderer.ElementController.SendNavigating(args);
			_navigationResult = WebNavigationResult.Success;

			_renderer.UpdateCanGoBackForward();

			if (args.Cancel)
			{
				_renderer.Control.StopLoading();
			}
			else
			{
>>>>>>> Update from origin (#8)
				base.OnPageStarted(view, url, favicon);
			}
		}

<<<<<<< HEAD
		public override void OnPageFinished(WView view, string url)
=======
		public override void OnPageFinished(global::Android.Webkit.WebView view, string url)
>>>>>>> Update from origin (#8)
		{
			if (_renderer?.Element == null || url == WebViewRenderer.AssetBaseUrl)
				return;

			var source = new UrlWebViewSource { Url = url };
			_renderer.IgnoreSourceChanges = true;
			_renderer.ElementController.SetValueFromRenderer(WebView.SourceProperty, source);
			_renderer.IgnoreSourceChanges = false;

<<<<<<< HEAD
			bool navigate = _navigationResult == WebNavigationResult.Failure ? !url.Equals(_lastUrlNavigatedCancel, StringComparison.OrdinalIgnoreCase) : true;
			_lastUrlNavigatedCancel = _navigationResult == WebNavigationResult.Cancel ? url : null;

			if (navigate)
			{
				var args = new WebNavigatedEventArgs(WebNavigationEvent.NewPage, source, url, _navigationResult);
				_renderer.ElementController.SendNavigated(args);
			}
=======
			var args = new WebNavigatedEventArgs(WebNavigationEvent.NewPage, source, url, _navigationResult);

			_renderer.ElementController.SendNavigated(args);
>>>>>>> Update from origin (#8)

			_renderer.UpdateCanGoBackForward();

			base.OnPageFinished(view, url);
		}

		[Obsolete("OnReceivedError is obsolete as of version 2.3.0. This method was deprecated in API level 23.")]
<<<<<<< HEAD
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void OnReceivedError(WView view, ClientError errorCode, string description, string failingUrl)
=======
		public override void OnReceivedError(global::Android.Webkit.WebView view, ClientError errorCode, string description, string failingUrl)
>>>>>>> Update from origin (#8)
		{
			_navigationResult = WebNavigationResult.Failure;
			if (errorCode == ClientError.Timeout)
				_navigationResult = WebNavigationResult.Timeout;
#pragma warning disable 618
			base.OnReceivedError(view, errorCode, description, failingUrl);
#pragma warning restore 618
		}

<<<<<<< HEAD
		public override void OnReceivedError(WView view, IWebResourceRequest request, WebResourceError error)
=======
		public override void OnReceivedError(global::Android.Webkit.WebView view, IWebResourceRequest request, WebResourceError error)
>>>>>>> Update from origin (#8)
		{
			_navigationResult = WebNavigationResult.Failure;
			if (error.ErrorCode == ClientError.Timeout)
				_navigationResult = WebNavigationResult.Timeout;
			base.OnReceivedError(view, request, error);
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing)
				_renderer = null;
		}
	}
<<<<<<< HEAD
}
=======
}
>>>>>>> Update from origin (#8)
