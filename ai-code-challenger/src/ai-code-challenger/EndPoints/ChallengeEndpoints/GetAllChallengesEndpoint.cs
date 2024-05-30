using ai_code_challenger.EndPoints.Api;
using ai_code_challenger.common;
using ai_code_challenger.common.Handlers;
using ai_code_challenger.common.Request.Categories.Challenges;
using ai_code_challenger.common.Response;
using Microsoft.AspNetCore.Mvc;

namespace ai_code_challenger.EndPoints.ChallengeEndpoints;

public class GetAllChallengesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/", HandleAsync)
            .WithName("Challenges: GetAll Paginated")
            .WithDescription("Recura todos os desafios com paginação")
            .WithOrder(5)
            .Produces<PagedResponse<List<Challenge>?>>();

    private static async Task<IResult> HandleAsync(IChallengeHandler handler, [FromQuery] int pageNumber = Configuration.DefaultPageNumber, [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetAllChallengesRequest
        {
            AccountId = ApiConfiguration.AccountId,
            PageNumber = pageNumber,
            PageSize = pageSize
        };

        var result = await handler.GetAllAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
