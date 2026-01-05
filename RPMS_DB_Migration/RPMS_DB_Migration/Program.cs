using System.Runtime.Versioning;
using RPMS_DB_Migration.Components;
using RPMS_DB_Migration.Services;

var builder = WebApplication.CreateBuilder(args);

// Register Blazor + Razor Pages
//builder.Services.AddRazorPages();
//builder.Services.AddServerSideBlazor();

// runtime check: register these services only when actually running on Windows
if (OperatingSystem.IsWindows())
{
    builder.Services.AddSingleton<MigrationService>();
    builder.Services.AddSingleton<AccessReaderService>();
}

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode(); // maps App.razor as entry point

app.Run();
