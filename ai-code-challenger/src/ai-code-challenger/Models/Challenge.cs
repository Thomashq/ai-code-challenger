using System.ComponentModel.DataAnnotations.Schema;

namespace ai_code_challenger.Models
{
    public class Challenge:BaseModel
    {
        public string Wording { get; set; }

        public bool IsSolved { get; set; }

        public string? Answer { get; set; }

        [ForeignKey("Account")]
        public long AccountId { get; set; }
    }
}
