using GitHub_Service;
using Microsoft.OpenApi.Models; // Add this using directive for Swagger support  

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGitHubintegration(options =>
{
    builder.Configuration.GetSection("GitHubIntegrationOptions").Bind(options);
});
builder.Services.Configure<GitHubIntegrationOptions>(builder.Configuration.GetSection("GitHubIntegrationOptions"));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi  
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  
    app.UseSwaggerUI();  
}

app.UseAuthorization();

app.MapControllers();

app.Run();
