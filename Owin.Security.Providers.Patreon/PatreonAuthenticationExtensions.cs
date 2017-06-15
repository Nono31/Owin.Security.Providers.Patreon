using System;

namespace Owin.Security.Providers.Patreon
{
    public static class PatreonAuthenticationExtensions
    {
        public static IAppBuilder UsePatreonAuthentication(this IAppBuilder app,
            PatreonAuthenticationOptions options)
        {
            if (app == null)
                throw new ArgumentNullException(nameof(app));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            app.Use(typeof(PatreonAuthenticationMiddleware), app, options);

            return app;
        }

        public static IAppBuilder UsePatreonAuthentication(this IAppBuilder app, string clientId, string clientSecret)
        {
            return app.UsePatreonAuthentication(new PatreonAuthenticationOptions
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            });
        }
    }
}