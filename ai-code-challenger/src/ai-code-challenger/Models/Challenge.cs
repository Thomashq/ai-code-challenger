using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ai_code_challenger.Models
{
    public class Challenge:BaseModel
    {
        [Required(ErrorMessage = "É necessário enviar o enunciado")]
        public string? Wording { get; set; }

        public bool? IsSolved { get; set; } = false;
        
        public string? Answer { get; set; }

        [Required(ErrorMessage = "É necessário informar quem resolveu a questão.")]
        [ForeignKey("Account")]
        public long AccountId { get; set; }
    }
}
