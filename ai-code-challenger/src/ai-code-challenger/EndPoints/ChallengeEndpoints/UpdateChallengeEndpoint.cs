using ai_code_challenger.common;
using ai_code_challenger.common.Handlers;
using ai_code_challenger.common.Request.Categories.Challenges;
using ai_code_challenger.common.Response;
using ai_code_challenger.EndPoints.Api;

namespace ai_code_challenger.EndPoints.ChallengeEndpoints;

public class UpdateChallengeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPut("/{id}", HandleAsync)
        .WithName("Challenges: Update challenge")
        .WithDescription("Atualiza o desafio")
        .WithOrder(4)
        .Produces<Response<Challenge?>>();

    private static async Task<IResult> HandleAsync(IChallengeHandler handler, long id)
    {
        var request = new UpdateChallengeRequest
        {
            AccountId = ApiConfiguration.AccountId,
            ChallengeId = id
        };
        var response = await handler.UpdateAsync(request);

        return response.IsSuccess
            ? TypedResults.Ok(response)
            : TypedResults.BadRequest(response);
    }
}