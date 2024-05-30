namespace ai_code_challenger.EndPoints.Api;

public interface IEndpoint
{
    static abstract void Map(IEndpointRouteBuilder app);
}
