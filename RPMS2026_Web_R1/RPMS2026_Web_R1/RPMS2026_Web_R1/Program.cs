using Microsoft.EntityFrameworkCore;
using RPMS2026_Web_R1.Client.Pages;
using RPMS2026_Web_R1.Components;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Grids;
using Syncfusion.Blazor.Data;
using Syncfusion.Licensing;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Register Syncfusion license key
SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF5cWWdCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWH1fdHRURWlYU0J+XkdWYUo=");

// Register Syncfusion Blazor services
builder.Services.AddSyncfusionBlazor();

// Register HttpClient for server-side Blazor
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<RPMS2026_Web_R1.Data.Rpms2026WebContext>(option=>
                option.UseSqlServer(builder.Configuration.GetConnectionString("RPMS2026_Web")));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(RPMS2026_Web_R1.Client._Imports).Assembly);

app.MapControllers();

app.Run();
