using System.ComponentModel.DataAnnotations;
using ai_code_challenger.common.Enums;
using ai_code_challenger.common.Utility;

namespace ai_code_challenger.common.Request.Categories.Challenge;

public class UpdateChallengeRequest : Request
{
    [Required(ErrorMessage = "Id inválido")]
    public long? ChallengeId { get; set; }

    [Required(ErrorMessage = "Resposta Inválida")]
    public string? Answer { get; set; } = string.Empty;

    [Required(ErrorMessage = "Título inválido")]
    public string? Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "A resposta tem que conter uma linguagem para correção")]
    public string? Laguage { get; set; } = ESupportedLanguages.C.GetEnumDescription();

    public bool IsSolved { get; set; } = false;
}
