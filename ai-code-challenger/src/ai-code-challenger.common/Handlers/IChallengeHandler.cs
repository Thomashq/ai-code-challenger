using ai_code_challenger.common.Request.Challenges;
using ai_code_challenger.common.Response;

namespace ai_code_challenger.common.Handlers;

public interface IChallengeHandler
{
    Task<Response<Challenge?>> CreateAsync(CreateChallengeRequest request);
    
    Task<Response<Challenge?>> UpdateAsync(UpdateChallengeRequest request);

    Task<Response<Challenge?>> DeleteAsync(DeleteChallengeRequest request);

    Task<Response<Challenge?>> DeleteAsync(DeleteListOfChallengesRequest request);

    Task<PagedResponse<List<Challenge?>>> GetAllAsync(GetAllChallengesRequest request);

    Task<PagedResponse<List<Challenge?>>> GetByPeriodAsync(GetChallengesByPeriodRequest request);

    Task<Response<Challenge?>> GetChallengeById(GetChallengeByIdRequest request);
    
}
