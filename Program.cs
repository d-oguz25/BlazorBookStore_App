using BlazorBookStore_App.Components;
using BlazorBookStore_App.Components.Services;
using Blazored.Modal;
using SERVICE.Contracts;
using AutoMapper;
using BlazorBookStore_App.Components.Models;
using Blazored.LocalStorage;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredModal();
builder.Services.AddSingleton< FavouriteBooksState>();
builder.Services.AddSingleton<UserState>();
builder.Services.AddScoped<IUserBusinessEngine,UserBusinessEngine>();
builder.Services.AddScoped<ICommentUserEngine, CommentUserEngine>();
builder.Services.AddScoped<IBookUserEngine, BookUserEngine>();
builder.Services.AddScoped<IAuthUserEngine,AuthUserEngine>();
builder.Services.AddAutoMapper(typeof(UserProfile));
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
    .AddInteractiveServerRenderMode();

app.Run();
