using ai_code_challenger.common;
using ai_code_challenger.Data;
using ai_code_challenger.Services;
using Microsoft.AspNetCore.Mvc;

namespace ai_code_challenger.EndPoints;

public static class AuthenticationEndpoint
{
    public static void MapAuthenticationEndpoint(this WebApplication app)
    {
        app.MapPost("/authenticate/login", (DataContext context, [FromBody]Login login) =>
        {
            try
            {
                login.Password = Criptography.PasswordEncrypt(login.Password);

                var account = context.Account.FirstOrDefault(a => (a.Login == login.UsernameOrEmail && a.Password == login.Password)  
                || (a.Mail == login.UsernameOrEmail && a.Password == login.Password));

                if(account == null)
                    return Results.NotFound("Nome ou senha inválidos");
                
                var token = TokenService.GenerateToken(account);

                return Results.Ok(token);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível efetuar login" + ex.Message);
            }
        });

        app.MapPost("/authenticate/register", async (DataContext context, Account account) =>
        {
            try
            {
                account.Password = Criptography.PasswordEncrypt(account.Password);
                account.CreationDate = DateTime.UtcNow;
                account.IsVerified = false;
                account.Role = "user";

                var existingAccount = context.Account.FirstOrDefault(a => a.Login == account.Login || a.Mail == account.Mail);

                if (existingAccount != null)
                    return Results.Problem("Já existe uma conta com o email ou username registrados");

                await context.Account.AddAsync(account);
                await context.SaveChangesAsync();

                var token = TokenService.GenerateToken(account);

                return Results.Ok("Conta criada com sucesso");
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível registrar: " + ex.Message);
            }
        });
    }
}
