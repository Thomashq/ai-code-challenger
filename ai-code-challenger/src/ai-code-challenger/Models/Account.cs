namespace ai_code_challenger.Models
{
    public class Account:BaseModel
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Mail { get; set; }

        public int? SolvedAmmount { get; set; }

        public bool IsVerified { get; set; }
    }
}
