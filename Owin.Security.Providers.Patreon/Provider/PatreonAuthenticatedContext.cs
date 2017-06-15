// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Security.Claims;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Provider;
using Newtonsoft.Json.Linq;

namespace Owin.Security.Providers.Patreon.Provider
{
    /// <summary>
    /// Contains information about the login session as well as the user <see cref="System.Security.Claims.ClaimsIdentity"/>.
    /// </summary>
    public class PatreonAuthenticatedContext : BaseContext
    {
        /// <summary>
        /// Initializes a <see cref="PatreonAuthenticatedContext"/>
        /// </summary>
        /// <param name="context">The OWIN environment</param>
        /// <param name="user">The Patreon user information</param>
        /// <param name="accessToken">Patreon Access token</param>
        /// <param name="refreshToken">Patreon Refresh token</param>
        public PatreonAuthenticatedContext(IOwinContext context, JObject user, string accessToken, string refreshToken)
            : base(context)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            User = user;
            Id = user.SelectToken("data.id").ToString();
            FirstName = user.SelectToken("data.attributes.first_name").ToString();
            FullName = user.SelectToken("data.attributes.full_name").ToString();
            LastName = user.SelectToken("data.attributes.last_name").ToString();
            EMail = user.SelectToken("data.attributes.email").ToString();
            IsEMailVerified = user.SelectToken("data.attributes.is_email_verified").ToString();
            Avatar = user.SelectToken("data.attributes.image_url").ToString();
            ThumbAvatar = user.SelectToken("data.attributes.thumb_url").ToString();
            Gender = user.SelectToken("data.attributes.gender").ToString();
            IsNuked = user.SelectToken("data.attributes.is_nuked").ToString();
            IsSuspended = user.SelectToken("data.attributes.is_suspended").ToString();
        }

        public string IsSuspended { get; set; }

        public string IsNuked { get; set; }

        public string Gender { get; set; }

        public string ThumbAvatar { get; set; }

        public string Avatar { get; set; }

        public string IsEMailVerified { get; set; }

        public string EMail { get; set; }

        public string LastName { get; set; }

        public string FullName { get; set; }

        /// <summary>
        /// Gets the user json object that was retrieved from Patreon
        /// during the authorization process.
        /// </summary>
        public JObject User { get; private set; }

        /// <summary>
        /// Gets the user name extracted from the Patreon API during
        /// the authorization process.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets the user id extracted from the PatreonAPI during the
        /// authorization process.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets the Patreon access token
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets the Patreon refresh token
        /// </summary>
        public string RefreshToken { get; private set; }

        /// <summary>
        /// Gets the <see cref="ClaimsIdentity"/> representing the user
        /// </summary>
        public ClaimsIdentity Identity { get; set; }

        /// <summary>
        /// Gets or sets a property bag for common authentication properties
        /// </summary>
        public AuthenticationProperties Properties { get; set; }

    }
}
