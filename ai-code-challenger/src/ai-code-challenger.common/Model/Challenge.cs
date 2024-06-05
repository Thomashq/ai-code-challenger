using System.ComponentModel.DataAnnotations;

namespace ai_code_challenger.common.Model;

public class Challenge : BaseModel
{
    [Required(ErrorMessage = "É necessário enviar o enunciado")]
    public string Wording { get; set; } = string.Empty;

    public bool IsSolved { get; set; } = false;

    [Required(ErrorMessage = "Título inválido")]
    public string Title { get; set; } = "";
    public string? Answer { get; set; }

    public string? Language { get; set; }

    [Required(ErrorMessage = "É necessário informar quem resolveu a questão.")]
    //[ForeignKey("Account")]
    public long AccountId { get; set; }
}
