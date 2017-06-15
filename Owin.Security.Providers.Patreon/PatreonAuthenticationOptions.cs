using System;
using System.Collections.Generic;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Owin.Security.Providers.Patreon.Provider;

namespace Owin.Security.Providers.Patreon
{
    public class PatreonAuthenticationOptions : AuthenticationOptions
    {
        public class PatreonAuthenticationEndpoints
        {
            /// <summary>
            /// Endpoint which is used to redirect users to request Patreon access
            /// </summary>
            /// <remarks>
            /// Defaults to https://www.patreon.com/oauth2/authorize
            /// </remarks>
            public string AuthorizationEndpoint { get; set; }

            /// <summary>
            /// Endpoint which is used to exchange code for access token
            /// </summary>
            /// <remarks>
            /// Defaults to https://api.patreon.com/oauth2/token
            /// </remarks>
            public string TokenEndpoint { get; set; }

            public string UserEndpoint { get; set; }
        }

        private const string AuthorizationEndPoint = "https://www.patreon.com/oauth2/authorize";
        private const string TokenEndpoint = "https://api.patreon.com/oauth2/token";
        private const string UserEndpoint = "https://api.patreon.com/oauth2/api/current_user";

        /// <summary>
        ///     Gets or sets timeout value in milliseconds for back channel communications with Patreon.
        /// </summary>
        /// <value>
        ///     The back channel timeout in milliseconds.
        /// </value>
        public TimeSpan BackchannelTimeout { get; set; }

        /// <summary>
        ///     The request path within the application's base path where the user-agent will be returned.
        ///     The middleware will process this request when it arrives.
        ///     Default value is "/signin-Patreon".
        /// </summary>
        public PathString CallbackPath { get; set; }

        /// <summary>
        ///     Get or sets the text that the user can display on a sign in user interface.
        /// </summary>
        public string Caption
        {
            get { return Description.Caption; }
            set { Description.Caption = value; }
        }

        /// <summary>
        ///     Gets or sets the Patreon supplied Client ID
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        ///     Gets or sets the Patreon supplied Client Secret
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets the sets of OAuth endpoints used to authenticate against Patreon.  Overriding these endpoints allows you to use Patreon Enterprise for
        /// authentication.
        /// </summary>
        public PatreonAuthenticationEndpoints Endpoints { get; set; }

        /// <summary>
        ///     Gets or sets the <see cref="IPatreonAuthenticationProvider" /> used in the authentication events
        /// </summary>
        public IPatreonAuthenticationProvider Provider { get; set; }
        
        /// <summary>
        /// A list of permissions to request.
        /// </summary>
        public IList<string> Scope { get; private set; }

        /// <summary>
        ///     Gets or sets the name of another authentication middleware which will be responsible for actually issuing a user
        ///     <see cref="System.Security.Claims.ClaimsIdentity" />.
        /// </summary>
        public string SignInAsAuthenticationType { get; set; }

        /// <summary>
        /// Gets or sets the mode of the Patreon authentication page.  Can be none, login, or consent.  Defaults to none.
        /// </summary>
        public string Prompt { get; set; }

        /// <summary>
        ///     Gets or sets the type used to secure data handled by the middleware.
        /// </summary>
        public ISecureDataFormat<AuthenticationProperties> StateDataFormat { get; set; }

        /// <summary>
        ///     Initializes a new <see cref="PatreonAuthenticationOptions" />
        /// </summary>
        public PatreonAuthenticationOptions()
            : base("Patreon")
        {
            Caption = Constants.DefaultAuthenticationType;
            CallbackPath = new PathString("/signin-patreon");
            AuthenticationMode = AuthenticationMode.Passive;
            Scope = new List<string>
            {
                "users", "pledges-to-me", "my-campaign"
            };
            BackchannelTimeout = TimeSpan.FromSeconds(60);
            Endpoints = new PatreonAuthenticationEndpoints
            {
                AuthorizationEndpoint = AuthorizationEndPoint,
                TokenEndpoint = TokenEndpoint,
                UserEndpoint = UserEndpoint,
            };
            Prompt = "none";
        }
    }
}