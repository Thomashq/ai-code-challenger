using ai_code_challenger.EndPoints.Api;
using ai_code_challenger.common;
using ai_code_challenger.common.Handlers;
using ai_code_challenger.common.Response;
using Microsoft.AspNetCore.Mvc;
using ai_code_challenger.common.Request.Categories.Challenges;

namespace ai_code_challenger.EndPoints.ChallengeEndpoints;

public class GetChallengesByPeriodEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/period", HandleAsync)
        .WithName("Get: Get by period")
        .WithSummary("Recupera os desafios em um determinado período de tempo")
        .WithOrder(7)
        .Produces<PagedResponse<List<Challenge>?>>();

    public static async Task<IResult> HandleAsync(
        IChallengeHandler handler,
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
        [FromQuery] int pageSize = Configuration.DefaultPageSize)
    {
        var request = new GetChallengesByPeriodRequest
        {
            AccountId = ApiConfiguration.AccountId,
            PageNumber = pageNumber,
            PageSize = pageSize,
            StartDate = startDate,
            EndDate = endDate
        };

        var result = await handler.GetByPeriodAsync(request);

        return result.IsSuccess 
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}