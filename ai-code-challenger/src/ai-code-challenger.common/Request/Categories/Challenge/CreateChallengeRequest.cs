using System.ComponentModel.DataAnnotations;

namespace ai_code_challenger.common.Request.Categories.Challenges;

public class CreateChallengeRequest : Request
{
    [Required(ErrorMessage = "Enunciado inválido")]
    [MinLength(1, ErrorMessage = "A questão deve conter um enunciado")]
    public string Wording { get; set; } = string.Empty;

    [Required(ErrorMessage = "Título inválido")]
    public string Title { get; set; } = string.Empty;

    public bool IsSolved { get; set; } = false;
}
