namespace ai_code_challenger.common.Request.Categories.Account;

public class GetAccountsByPeriodRequest : PagedRequest
{
    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }
}
