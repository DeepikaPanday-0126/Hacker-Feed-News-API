using HackerNewsFeed.Contracts;
using HackerNewsFeed.Data;
using HackerNewsFeed.Models;
using HackerNewsFeed.Provider;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("HackerNewsInMemoryDb"));

builder.Services.AddScoped<INewsFeedRepository, NewsFeedRepository>();


builder.Services.AddMemoryCache();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.Configure<GitHubAPISetting>(
    builder.Configuration.GetSection("GitHubApiSettings"));
builder.Services.AddHttpClient();
var app = builder.Build();
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}


app.MapControllers();

app.Run();


