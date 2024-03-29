using lab03;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using lab03.Data;
using lab03.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<UserService>();

// builder.Services.AddSignalR().AddAzureSignalR();


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

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapBlazorHub();
//     endpoints.MapFallbackToPage("/_Host");
//     endpoints.MapHub<BlazorChatSampleHub>(BlazorChatSampleHub.HubUrl);
// });
app.MapRazorPages();
app.MapHub<BlazorChatSampleHub>(BlazorChatSampleHub.HubUrl);
app.Run();