using Microsoft.AspNetCore.Authentication;

namespace Artichaut.Configuration;

public static class Authentication
{
    public static AuthenticationBuilder AddArtisashopAuthentication(this IServiceCollection serviceCollection)
        => serviceCollection.AddAuthentication(options =>
        {
        });
}