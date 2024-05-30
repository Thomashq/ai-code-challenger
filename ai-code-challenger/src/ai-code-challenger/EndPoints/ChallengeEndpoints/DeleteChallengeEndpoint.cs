using ai_code_challenger.common;
using ai_code_challenger.common.Handlers;
using ai_code_challenger.common.Request.Categories.Challenges;
using ai_code_challenger.common.Response;
using ai_code_challenger.EndPoints.Api;

namespace ai_code_challenger.EndPoints.ChallengeEndpoints;

public class DeleteChallengeEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/{id}", HandleAsync)
            .WithName("Challenges: Delete")
            .WithDescription("Deletar desafio")
            .WithOrder(3)
            .Produces<Response<Challenge?>>();

    private static async Task<IResult> HandleAsync(IChallengeHandler handler, long id)
    {
        var request = new DeleteChallengeRequest
        {
            AccountId = ApiConfiguration.AccountId,
            ChallengeId = id
        };
        var response = await handler.DeleteAsync(request);

        return response.IsSuccess
            ? TypedResults.Ok(response)
            : TypedResults.BadRequest(response);
    }
}
