using DbManagment.Context;
using DbManagment.Entities;
using DbManagment.Repositories;
using DbManagment.Schema.Mutation;
using DbManagment.Schema.Query;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddPooledDbContextFactory<DbContextSMFY>(options => {
	options.UseNpgsql(builder.Configuration["ConnectionStrings:SMFY"]);
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<CardRepository>();
builder.Services.AddScoped<CardImageRepository>();
builder.Services.AddScoped<CardTemplateRepository>();
builder.Services.AddGraphQLServer()
	.AddQueryType<Query>()
	.AddMutationType<Mutation>()
	.AddProjections()
	.AddFiltering()
	.AddSorting();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
app.MapGraphQL("/graphql");

app.Run();
