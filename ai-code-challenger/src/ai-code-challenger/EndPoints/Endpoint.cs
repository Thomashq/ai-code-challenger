using ai_code_challenger.EndPoints.Api;
using ai_code_challenger.EndPoints.ChallengeEndpoints;

namespace ai_code_challenger.EndPoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

        endpoints.MapGroup("/")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK" });

        endpoints.MapGroup("v1/challenges")
            .WithTags("Challenges")
            .MapEndpoint<CreateChallengeEndpoint>()
            .MapEndpoint<UpdateChallengeEndpoint>()
            .MapEndpoint<DeleteChallengeEndpoint>()
            .MapEndpoint<DeleteListOfChallengesEndpoint>()
            .MapEndpoint<GetAllChallengesEndpoint>()
            .MapEndpoint<GetChallengeByIdEndpoint>()
            .MapEndpoint<GetChallengesByPeriodEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app) where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
