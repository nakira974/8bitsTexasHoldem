using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ASP.NETCoreWebApplication1.Data;
using ASP.NETCoreWebApplication1.Hubs;
using ASP.NETCoreWebApplication1.Services;
using Lkhsoft.Utility;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.HttpLogging;
using Serilog;
using TexasHoldem.Models;
using TexasHoldem.Models.Services;
using JsonSerializer = Lkhsoft.Utility.JsonSerializer;
using WebSocketOptions = Microsoft.AspNetCore.Builder.WebSocketOptions;


try
{
    var builder = WebApplication.CreateBuilder(args);

    
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .WriteTo.Console()
        //.WriteTo.File("logs/rumble-.txt", rollingInterval: RollingInterval.Day)
        .CreateLogger();
    
    builder.Logging.ClearProviders();
    builder.Logging.AddSerilog(Log.Logger);
    
    builder.Services.AddHttpLogging(options =>
    {
        options.LoggingFields = HttpLoggingFields.RequestProtocol| HttpLoggingFields.RequestHeaders | HttpLoggingFields.RequestBody | HttpLoggingFields.Response ;
    });
    
// Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<ApplicationDbContext>();

    builder.Services.AddIdentityServer()
        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

    builder.Services.AddAuthentication()
        .AddIdentityServerJwt();

    /*
    builder.Services.AddCors(options =>
    {
        options.
    });*/
    builder.Services.AddControllersWithViews();
    builder.Services.AddRazorPages();
    builder.Services.AddSignalR();
    builder.Services.AddTransient<IJsonSerializer, JsonSerializer>();
    builder.Services
        .AddScoped<IGameService<PokerServiceBase<PokerServiceBase<ASP.NETCoreWebApplication1.Services.TexasHoldem>>>,
            TexasHoldemService>();
    
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("PokerGamePolicy", builder => builder.WithOrigins("http://localhost:7129/api/hubs")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetIsOriginAllowed((host) => true));
    });

    builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            options.JsonSerializerOptions.WriteIndented = true;
            options.JsonSerializerOptions.AllowTrailingCommas = false;
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        });


    var app = builder.Build();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
        app.UseMigrationsEndPoint();
    else
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();

    app.UseAuthentication();
    app.UseIdentityServer();
    app.UseAuthorization();

    app.MapControllerRoute(
        "default",
        "{controller}/{action=Index}/{id?}");
    app.MapRazorPages();

    app.MapFallbackToFile("index.html");
    
    app.MapHub<TexasHoldemHub>("api/hubs/Texas_Holdem", options =>
    {
        options.Transports = HttpTransportType.WebSockets;
    });

    app.UseHttpLogging();

    app.Run();
}
catch (Exception e)
{
    Console.WriteLine(e);
}