namespace ai_code_challenger.common.Request.Challenges;

public class GetChallengesByPeriodRequest : PagedRequest
{
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
