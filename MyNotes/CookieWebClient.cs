using Android.Graphics;
using Android.Webkit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MyNotes
{
    internal class CookieWebViewClient
        : WebViewClient
    {
        private readonly CookieWebView _cookieWebView;
        internal CookieWebViewClient(CookieWebView cookieWebView)
        {
            _cookieWebView = cookieWebView;
        }

        public override void OnPageStarted(global::Android.Webkit.WebView view, string url, Bitmap favicon)
        {
            base.OnPageStarted(view, url, favicon);

            _cookieWebView.OnNavigating(new CookieNavigationEventArgs
            {
                Url = url
            });
        }

        public override void OnPageFinished(global::Android.Webkit.WebView view, string url)
        {
            var cookieHeader = CookieManager.Instance.GetCookie(url);
            var cookies = new CookieCollection();
            var cookiePairs = cookieHeader.Split('&');
            foreach (var cookiePair in cookiePairs)
            {
                var cookiePieces = cookiePair.Split('=');
                if (cookiePieces[0].Contains(":"))
                    cookiePieces[0] = cookiePieces[0].Substring(0, cookiePieces[0].IndexOf(":"));
                cookies.Add(new Cookie
                {
                    Name = cookiePieces[0],
                    Value = cookiePieces[1]
                });
            }

            _cookieWebView.OnNavigated(new CookieNavigatedEventArgs
            {
                Cookies = cookies,
                Url = url
            });
        }
    }
}
