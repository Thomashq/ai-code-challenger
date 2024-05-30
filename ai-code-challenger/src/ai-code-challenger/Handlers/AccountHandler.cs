using System.Data.Entity;
using System.Reflection.Metadata.Ecma335;
using ai_code_challenger.common;
using ai_code_challenger.common.Enums;
using ai_code_challenger.common.Handlers;
using ai_code_challenger.common.Request.Categories.Account;
using ai_code_challenger.common.Response;
using ai_code_challenger.Data;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace ai_code_challenger;

public class AccountHandler(DataContext context) : IAccountHandler
{
    public async Task<Response<Account?>> CreateAsync(CreateAccountRequest request)
    {
        try
        {
            var account = new Account
            {
                Login = request.Login,
                Password = request.Password,
                Mail = request.Mail,
                SolvedAmmount = 0,
                IsVerified = false,
                Role = EAccountType.User.GetEnumDescription(),
                CreationDate = DateTime.UtcNow
            };

            await context.Account.AddAsync(account);
            await context.SaveChangesAsync();

            return new Response<Account?>(account, 201, "Conta criada com sucesso");
        }
        catch (Exception ex)
        {
            //Melhorar com sistemas de logs posteriormente com log de erro para registrar
            return new Response<Account?>(null, 500, "Não foi possível criar conta");
        }
    }

    public async Task<Response<Account?>> DeleteAsync(DeleteAccountRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Account?>> DeleteAsync(DeleteLIstOfAccountRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Account?>> GetAccountById(GetAccountByIdRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResponse<List<Account?>>> GetAllAsync(GetAllAccountsRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedResponse<List<Account?>>> GetByPeriodAsync(GetAccountsByPeriodRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<Account?>> UpdateAsync(UpdateAccountRequest request)
    {
        try
        {
            //processo de reidratação 
            throw new NotImplementedException();
        }
        catch(Exception ex)
        {
            return new Response<Account?>(null, 500, "Não foi possível atualizar a conta");
        }
    }
}
