namespace ai_code_challenger.common;

public class Account : BaseModel
{
    [Required(ErrorMessage = "É necessário enviar o Login")]
    [MaxLength(20, ErrorMessage = "O tamanho máximo do Login é de 20 caracteres")]
    [MinLength(3, ErrorMessage = "O Login deve ter pelo menos 5 caracteres")]
    public string? Login { get; set; }

    [Required(ErrorMessage = "É necessário enviar a Senha")]
    [MaxLength(20, ErrorMessage = "O tamanho máximo da senha é de 20 caracteres")]
    [MinLength(3, ErrorMessage = "A senha deve ter pelo menos 4 caracteres")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "É necessário informar o E-mail")]
    public string? Mail { get; set; }

    public int? SolvedAmmount { get; set; } = 0;

    public bool? IsVerified { get; set; } = false;
}
