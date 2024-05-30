using ai_code_challenger.common;
using ai_code_challenger.common.Handlers;
using ai_code_challenger.Data;
using ai_code_challenger.Handlers;
using Microsoft.EntityFrameworkCore;

namespace ai_code_challenger.Api;

public static class BuilderExtension
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        ApiConfiguration.ConnectionString = builder.Configuration.GetConnectionString("AIChallenges") ?? string.Empty;
        Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
        Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontEndUrl") ?? string.Empty;
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x=>{
            x.CustomSchemaIds(n => n.FullName);
        });
    }

    public static void AddDataContext (this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddDbContext<DataContext>(x=> {
                x.UseNpgsql(ApiConfiguration.ConnectionString);
            });
    }

    public static void AddCrossOrigin (this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options => options.AddPolicy(
                ApiConfiguration.CorsPolicyName,
                policy => policy
                    .WithOrigins([
                        Configuration.BackendUrl,
                        Configuration.FrontendUrl
                    ])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            )
        );
    }

    public static void AddServices (this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddTransient<IChallengeHandler, ChallengeHandler>();
        
        builder
            .Services
            .AddTransient<IAccountHandler, AccountHandler>();
    }
}   
