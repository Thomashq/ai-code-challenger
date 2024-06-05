using System.ComponentModel.DataAnnotations;
using ai_code_challenger.common.Enums;
using ai_code_challenger.common.Utility;

namespace ai_code_challenger.common.Request.Categories.Account;

public class CreateAccountRequest : Request
{
    [Required(ErrorMessage = "Login inválido")]
    [MaxLength(20, ErrorMessage = "O login deve conter no máximo 20 caracteres")]
    public string Login { get; set; } = "";

    [Required(ErrorMessage = "Senha inválida")]
    public string Password { get; set; } = "";

    [Required(ErrorMessage = "E-mail inválido")]
    public string Mail { get; set; } = "";

    public int? SolvedAmmount { get; set; } = 0;

    public bool IsVerified { get; set; } = false;

    //Admins poderão criar contas de admin no site
    public string AccountType { get; set; } = EAccountType.User.GetEnumDescription();
}
