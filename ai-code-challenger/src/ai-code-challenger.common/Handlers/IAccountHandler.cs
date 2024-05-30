using ai_code_challenger.common.Request.Categories.Account;
using ai_code_challenger.common.Response;

namespace ai_code_challenger.common.Handlers;

public interface IAccountHandler
{
    Task<Response<Account?>> CreateAsync(CreateAccountRequest request);
    
    Task<Response<Account?>> UpdateAsync(UpdateAccountRequest request);

    Task<Response<Account?>> DeleteAsync(DeleteAccountRequest request);

    Task<Response<Account?>> DeleteAsync(DeleteLIstOfAccountRequest request);

    Task<PagedResponse<List<Account?>>> GetAllAsync(GetAllAccountsRequest request);

    Task<PagedResponse<List<Account?>>> GetByPeriodAsync(GetAccountsByPeriodRequest request);

    Task<Response<Account?>> GetAccountById(GetAccountByIdRequest request);
    
}
