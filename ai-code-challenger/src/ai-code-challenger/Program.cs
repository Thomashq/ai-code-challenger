using ai_code_challenger.Data;
using ai_code_challenger.EndPoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("AIChallenges"));
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapAccountEndpoints();

app.Run();
