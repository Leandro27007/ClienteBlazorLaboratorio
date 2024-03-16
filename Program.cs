using BlazorStrap;
using CurrieTechnologies.Razor.SweetAlert2;
using LaboratorioBlazorUI;
using LaboratorioBlazorUI.AlertasSweet;
using LaboratorioBlazorUI.Auth;
using LaboratorioBlazorUI.Servicios;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");




builder.Services.AddHttpClient();

builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<JwtAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthStateProvider>((provider => provider.GetRequiredService<JwtAuthStateProvider>()));
builder.Services.AddScoped<ILoginServices, JwtAuthStateProvider>((provider => provider.GetRequiredService<JwtAuthStateProvider>()));


//Injecte el servicio para poder usarlo en toda mi aplicacion.
builder.Services.AddScoped<ITurnoServices, TurnoService>();
builder.Services.AddScoped<IPruebaLabService, PruebaLabService>();
builder.Services.AddScoped<IReciboService, ReciboService>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IUsuarioServices, UsuarioService>();
builder.Services.AddScoped<IReporteService, ReporteService>();
builder.Services.AddScoped<Alertas>();

builder.Services.AddSweetAlert2();
builder.Services.AddRadzenComponents();
builder.Services.AddBlazorBootstrap();
builder.Services.AddBlazorStrap();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7290/api/") });

await builder.Build().RunAsync();
