namespace ai_code_challenger.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
public class RegisterViewModel
{
    [Required]
    [DataType(DataType.Text)]
    public string? Login { get; set; }
    
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirme a senha")]
    [Compare("Password", ErrorMessage = "As senhas devem ser iguais")]
    public string? ConfirmPassword { get; set; }
}
