using Ignis.Components;
using Ignis.Components.Server;
using jinx_debt_tracker.Interfaces;
using jinx_debt_tracker.Models;
using jinx_debt_tracker.Services;
using Refit;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration["BaseUri"];

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddIgnis();
builder.Services.AddIgnisServer();
builder.Services.AddScoped<GameService>();
builder.Services.AddScoped<PlayerService>();
builder.Services.AddRefitClient<IGameApi>()
    .ConfigureHttpClient(c =>c.BaseAddress = new Uri(connectionString));
builder.Services.AddRefitClient<IPlayerApi>()
    .ConfigureHttpClient(c =>c.BaseAddress = new Uri(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();