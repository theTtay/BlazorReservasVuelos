using BlazorReservasVuelos.Data;
using BlazorReservasVuelos.Services;
using BlazorReservasVuelos.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Cnn")
    ?? throw new InvalidOperationException("Connection string 'Cnn' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<IVueloService, VueloService>();
builder.Services.AddScoped<IDestinoService, DestinoService>();
builder.Services.AddScoped<IAvionService, AvionService>();
builder.Services.AddScoped<IPilotoService, PilotoService>();
builder.Services.AddScoped<IHorarioService, HorarioService>();
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
