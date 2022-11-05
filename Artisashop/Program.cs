using System.Text;
using System.Text.Json.Serialization;
using Artisashop;
using Artisashop.Hubs;
using Artisashop.Interfaces.IService;
using Artisashop.Models;
using Artisashop.Services;
using Artisashop.Services.MailService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RechercheEntreprisesApi.Api;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

IConfiguration jwtConfig = builder.Configuration.GetSection("Jwt");
builder.Services.Configure<JwtConfiguration>(jwtConfig);

IConfiguration franceConnectConfig = builder.Configuration.GetSection("FranceConnect");
builder.Services.Configure<FranceConnectConfiguration>(franceConnectConfig);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddControllers()
.AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });
builder.Services.AddSignalR();

builder.Services.AddIdentity<Account, IdentityRole>()
    .AddEntityFrameworkStores<StoreDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlite("Data Source=./app.db"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    var config = jwtConfig.Get<JwtConfiguration>();

    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidIssuer = config.Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.Key))
    };
    options.RequireHttpsMetadata = false;
})
// .AddOpenIdConnect(FranceConnectConfiguration.ProviderScheme, FranceConnectConfiguration.ProviderDisplayName, oidc_options =>
//     {
//         var fcConfig = franceConnectConfig.Get<FranceConnectConfiguration>();

//         // FC refuses unknown parameters in the requests, so the two following options are needed 
//         oidc_options.DisableTelemetry = true; // This is false by default on .NET Core 3.1, and sends additional parameters such as "x-client-ver" in the requests to FC.
//         oidc_options.UsePkce = false; // This is true by default on .NET Core 3.1, and enables the PKCE mechanism which is not supported by FC.

//         // FC has restrictions in the nonce (max 128 alphanumeric characters) and errors out in the logout flow otherwise. We use this option so that the nonce does not contain a dot.
//         oidc_options.ProtocolValidator.RequireTimeStampInNonce = false;

//         oidc_options.SaveTokens = true; // This is needed to keep the id_token obtained for authentication : we have to send it back to FC to logout.

//         oidc_options.ClientId = fcConfig.ClientId;
//         oidc_options.ClientSecret = fcConfig.ClientSecret;
//         oidc_options.CallbackPath = fcConfig.CallbackPath;
//         oidc_options.SignedOutCallbackPath = fcConfig.SignedOutCallbackPath;
//         oidc_options.Authority = fcConfig.Issuer;
//         oidc_options.ResponseType = OpenIdConnectResponseType.Code;
//         oidc_options.Scope.Clear();
//         oidc_options.Scope.Add("openid");
//         foreach (string scope in fcConfig.Scopes)
//         {
//             oidc_options.Scope.Add(scope);
//         }
//         oidc_options.GetClaimsFromUserInfoEndpoint = true;
//         oidc_options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(fcConfig.ClientSecret));
//         oidc_options.Configuration = new OpenIdConnectConfiguration
//         {
//             Issuer = fcConfig.Issuer,
//             AuthorizationEndpoint = fcConfig.AuthorizationEndpoint,
//             TokenEndpoint = fcConfig.TokenEndpoint,
//             UserInfoEndpoint = fcConfig.UserInfoEndpoint,
//             EndSessionEndpoint = fcConfig.EndSessionEndpoint,
//         };
//         oidc_options.Events = new OpenIdConnectEvents
//         {
//             OnRedirectToIdentityProvider = (context) =>
//                 {
//                     context.ProtocolMessage.AcrValues = "eidas" + fcConfig.EIdasLevel;
//                     return Task.FromResult(0);
//                 }
//         };
//         // We specify claims to be kept, as .NET Core 2.0+ doesn't keep claims it does not expect.
//         oidc_options.ClaimActions.MapUniqueJsonKey("preferred_username", "preferred_username");
//         oidc_options.ClaimActions.MapUniqueJsonKey("birthcountry", "birthcountry");
//         oidc_options.ClaimActions.MapUniqueJsonKey("birthdate", "birthdate");
//         oidc_options.ClaimActions.MapUniqueJsonKey("birthplace", "birthplace");
//         oidc_options.ClaimActions.MapUniqueJsonKey("gender", "gender");
//     });
;

builder.Services.AddTransient<IRechercheTextuelleApiAsync, RechercheTextuelleApi>();
builder.Services.AddTransient<RepertoireNationalMetiersApi.Api.IDefaultApiAsync, RepertoireNationalMetiersApi.Api.DefaultApi>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Artichaut",
        Version = "v1",
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
            "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IUtils, Utils>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
    // Cleans up the database on each run
    using (var scope = app.Services.CreateScope())
    {
        using var context = scope.ServiceProvider.GetService<StoreDbContext>();
        context?.Database.EnsureCreated();
    }
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // Cleans up the database on each run
    using (var scope = app.Services.CreateScope())
    {
        using var context = scope.ServiceProvider.GetService<StoreDbContext>();
        context?.Database.EnsureCreated();
    }

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chatHub");

app.Run();

namespace Artisashop
{
    public partial class Program { }
}