using System.Text;
using Artisashop;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Artisashop.Hubs;
using Artisashop.Models;
using CmaApi.Api;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RechercheEntreprisesApi.Api;
using Artisashop.Interfaces.IService;
using Artisashop.Services.MailService;
using System.Text.Json.Serialization;
using Artisashop.Services;

var builder = WebApplication.CreateBuilder(args);

var jwtConfig = builder.Configuration.GetSection("Jwt");
builder.Services.Configure<JwtConfiguration>(jwtConfig);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddControllers()
.AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; });
builder.Services.AddRazorPages();
builder.Services.AddSignalR();

builder.Services.AddIdentity<Account, IdentityRole>()
    .AddEntityFrameworkStores<StoreDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
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
});

builder.Services.AddTransient<IRechercheTextuelleApiAsync, RechercheTextuelleApi>();
builder.Services.AddTransient<IDefaultApiAsync, DefaultApi>();

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
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

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "api/{controller}/{action=Index}/{id?}");
app.MapRazorPages();

app.MapFallbackToFile("index.html");
app.MapHub<ChatHub>("/chatHub");

app.Run();

public partial class Program { }