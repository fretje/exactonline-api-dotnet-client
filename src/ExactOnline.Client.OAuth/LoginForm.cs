using System;
using System.Windows.Forms;

namespace ExactOnline.Client.OAuth
{
    public partial class LoginForm : Form
    {
        private readonly Uri _redirectUri;

        public Uri AuthorizationUri { get; set; }

        public LoginForm(Uri redirectUri)
            : this() => _redirectUri = redirectUri;

        public LoginForm()
        {
            InitializeComponent();
            WebBrowser.Navigated += WebBrowserNavigated;
        }

        private void LoginFormLoad(object sender, EventArgs e) => WebBrowser.Navigate(AuthorizationUri);

        private void WebBrowserNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (IsRedirected(e.Url))
            {
                AuthorizationUri = e.Url;
                Hide();
            }
        }

        /// <summary>
        /// Tests whether two URLs are equal for purposes of detecting the conclusion of authorization.
        /// </summary>
        private bool IsRedirected(Uri uri)
        {
            var uriComponents = uri.GetComponents(UriComponents.SchemeAndServer | UriComponents.Path, UriFormat.Unescaped);
            var redirectUri = _redirectUri.ToString();
            if (uriComponents.EndsWith("/") && !redirectUri.EndsWith("/"))
            {
                redirectUri += "/";
            }

            return string.Equals(uriComponents, redirectUri, StringComparison.Ordinal);
        }
    }
}
