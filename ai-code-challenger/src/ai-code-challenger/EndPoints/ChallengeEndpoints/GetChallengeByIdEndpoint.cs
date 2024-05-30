using ai_code_challenger.common;
using ai_code_challenger.common.Handlers;
using ai_code_challenger.common.Request.Categories.Challenges;
using ai_code_challenger.common.Response;
using ai_code_challenger.EndPoints.Api;

namespace ai_code_challenger.EndPoints.ChallengeEndpoints;

public class GetChallengeByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{id}", HandleAsync)
            .WithName("Challenges: GetById")
            .WithDescription("Encontrar desafio pelo Id")
            .WithOrder(2)
            .Produces<Response<Challenge?>>();

    private static async Task<IResult> HandleAsync(IChallengeHandler handler, long id)
    {
        var request = new GetChallengeByIdRequest
        {
            AccountId = ApiConfiguration.AccountId,
            Id = id
        };
        var response = await handler.GetById(request);

        return response.IsSuccess
            ? TypedResults.Ok(response)
            : TypedResults.BadRequest(response);
    }
}
