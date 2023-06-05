using Append.Blazor.Sidepanel;
using Budgeteer.Clients.WebApplication.Data;
using MudBlazor;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Base setup
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Services
builder.Services.AddRestServices();

// MudBlazor
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;

    config.SnackbarConfiguration.PreventDuplicates = true;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

// HTTP clients
builder.Services.AddHttpClient("Budgeteer.Services.CommandApi", client => client.BaseAddress = new Uri(builder.Configuration.GetConnectionString("Budgeteer.Services.CommandApi")));
builder.Services.AddHttpClient("Budgeteer.Services.QueryApi", client => client.BaseAddress = new Uri(builder.Configuration.GetConnectionString("Budgeteer.Services.QueryApi")));

// Sidepanel
builder.Services.AddSidepanel();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
