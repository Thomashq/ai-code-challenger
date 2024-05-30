using System.ComponentModel.DataAnnotations;

namespace ai_code_challenger.common.Request.Categories.Account;

public class UpdateAccountRequest : Request
{
    [Required(ErrorMessage = "Id inválido")]
    public long AccountId { get; set; } = 0;
    
    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Mail { get; set; }

    public int? SolvedAmmount { get; set; } = 0;

    public bool? IsVerified { get; set; } = false;

    //Admins poderão criar contas de admin no site
    public string? AccountType { get; set; }
}