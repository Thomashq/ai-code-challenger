using ai_code_challenger.common;
using ai_code_challenger.common.Handlers;
using ai_code_challenger.common.Request.Categories.Challenges;
using ai_code_challenger.common.Response;
using ai_code_challenger.EndPoints.Api;
using Microsoft.AspNetCore.Components;

namespace ai_code_challenger.EndPoints.ChallengeEndpoints;

public class CreateChallengeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Challenges: Create")
            .WithDescription("Criar novo desafio")
            .WithOrder(1)
            .Produces<Response<Challenge?>>();

    private static async Task<IResult> HandleAsync(IChallengeHandler handler, CreateChallengeRequest request)
    {
        request.AccountId = ApiConfiguration.AccountId;
        var response = await handler.CreateAsync(request);

        return response.IsSuccess
            ? TypedResults.Created($"v1/challenges/{response.Data?.Id}", response)
            : TypedResults.BadRequest(response);
    }
}
