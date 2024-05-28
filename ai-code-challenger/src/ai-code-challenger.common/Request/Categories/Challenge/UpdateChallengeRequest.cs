using System.ComponentModel.DataAnnotations;
using ai_code_challenger.common.Enums;

namespace ai_code_challenger.common.Request.Challenges;

public class UpdateChallengeRequest : Request
{
    [Required(ErrorMessage = "Resposta Inválida")]
    public string Answer { get; set; }

    [Required(ErrorMessage = "A resposta tem que conter uma linguagem para correção")]
    public ESupportedLanguages Laguage { get; set; } = ESupportedLanguages.C;

    public bool IsSolved { get; set; } = false;
}
