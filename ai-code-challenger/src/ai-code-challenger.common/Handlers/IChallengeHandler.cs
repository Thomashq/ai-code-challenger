using ai_code_challenger.common.Model;
using ai_code_challenger.common.Request.Categories.Challenge;
using ai_code_challenger.common.Response;

namespace ai_code_challenger.common.Handlers;

public interface IChallengeHandler
{
    Task<Response<Challenge?>> CreateAsync(CreateChallengeRequest request);
    
    Task<Response<Challenge?>> UpdateAsync(UpdateChallengeRequest request);

    Task<Response<Challenge?>> DeleteAsync(DeleteChallengeRequest request);

    Task<Response<List<Challenge>?>> DeleteListAsync(DeleteListOfChallengesRequest request);

    Task<PagedResponse<List<Challenge>?>> GetAllAsync(GetAllChallengesRequest request);

    Task<PagedResponse<List<Challenge>?>> GetByPeriodAsync(GetChallengesByPeriodRequest request);

    Task<Response<Challenge?>> GetById(GetChallengeByIdRequest request);
    
}
