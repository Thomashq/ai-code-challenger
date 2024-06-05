using ai_code_challenger.EndPoints.Api;
using ai_code_challenger.common.Handlers;
using ai_code_challenger.common.Model;
using ai_code_challenger.common.Request.Categories.Challenge;
using ai_code_challenger.common.Response;
using ai_code_challenger.common.Utility;
using Microsoft.AspNetCore.Mvc;

namespace ai_code_challenger.EndPoints.ChallengeEndpoints;

public class DeleteListOfChallengesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/", HandleAsync)
            .WithName("Challenges: Delete List")
            .WithDescription("Deletar lista de desafios")
            .WithOrder(6)
            .Produces<Response<List<Challenge>?>>();

    private static async Task<IResult> HandleAsync(IChallengeHandler handler, [FromBody] Util util)
    {
        var request = new DeleteListOfChallengesRequest
        {
            AccountId = ApiConfiguration.AccountId,
            Ids = util
        };
        var response = await handler.DeleteListAsync(request);

        return response.IsSuccess
            ? TypedResults.Ok(response)
            : TypedResults.BadRequest(response);
    }

}
