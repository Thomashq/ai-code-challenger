namespace ai_code_challenger.common.Request.Categories.Challenge;

public class GetChallengesByPeriodRequest : PagedRequest
{
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
