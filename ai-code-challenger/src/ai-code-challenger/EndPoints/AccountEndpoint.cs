using ai_code_challenger.Data;
using ai_code_challenger.Utility;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using ai_code_challenger.common;
using System.Reflection;

namespace ai_code_challenger.EndPoints
{
    public static class AccountEndpoint
    {
        public static void MapAccountEndpoints(this WebApplication app)
        {
            app.MapGet("/admin/accounts/{skip:int}/{take:int}", async (DataContext context, int skip, int take) =>
            {
                try
                {
                    var totalCount = await context.Account.CountAsync();

                    if (totalCount == 0)
                        return Results.NotFound("No accounts found");

                    var accountsList = await context.Account
                    .AsNoTracking()
                    .Where(a=>a.DeleteDate == null)
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

                    return Results.Ok(accountsList);
                }
                catch(Exception ex)
                {
                    throw new Exception("Ocorreu o erro a seguir: " + ex.Message);
                }
            }).RequireAuthorization().WithTags("Accounts").WithSummary("Get all not deleted accounts");

            app.MapGet("/admin/accounts/{id:long}", async (DataContext context, long id) => 
            { 
                var account = await context.Account
                .FirstOrDefaultAsync(a => a.DeleteDate == null && a.Id == id);

                if(account == null)
                    Results.NotFound($"Nenhuma conta com o id {id} foi encontrada");

                return Results.Ok(account);
            }).WithTags("Accounts").WithSummary("Get account by id");

            app.MapPut("/admin/accounts/{id:long}", async (DataContext context, long id, Account updatedAccount) =>
            {
                try
                {
                    var account = await context.Account.FirstOrDefaultAsync(a => a.DeleteDate != null && a.Id == id);

                    if (account == null)
                        Results.NotFound($"A conta com id {id} não foi encontrada");

                    foreach(var property in typeof(Account).GetProperties())
                    {
                        var keyAttribute = property.GetCustomAttribute<KeyAttribute>();
                        if(keyAttribute == null)
                        {
                            var updatedValues = property.GetValue(updatedAccount);
                            if (updatedValues != null)
                                property.SetValue(account, updatedValues);
                        }
                    }

                    account.UpdateDate = DateTime.UtcNow;
                    context.Account.Update(account);

                    await context.SaveChangesAsync();

                    return Results.Ok("Conta atualizada com sucesso");
                }
                catch(Exception ex) 
                {
                    throw new Exception("Ocorreu o erro a seguir: " + ex.Message);
                }
            }).WithTags("Accounts").WithSummary("Update account by id");

            app.MapPost("/admin/accounts", async (DataContext context, Account account) =>
            {
                try
                {
                    account.CreationDate = DateTime.UtcNow;
                    account.IsVerified = false;
                    await context.Account.AddAsync(account);

                    await context.SaveChangesAsync();

                    return Results.Ok("Conta criada com sucesso");
                }
                catch(Exception ex)
                {
                    throw new Exception("Ocorreu o erro a seguir: " + ex.Message);
                }
            }).WithTags("Accounts").WithSummary("Add new account");

            app.MapDelete("/admin/accounts/{id:long}", async (DataContext context, long id) =>
            {
                try
                {
                    var account = await context.Account.FirstOrDefaultAsync(a => a.DeleteDate == null && a.Id == id);

                    if (account == null)
                        Results.NotFound($"A conta com id {id} não foi encontrada");

                    account.DeleteDate = DateTime.UtcNow;

                    context.Account.Update(account);

                    await context.SaveChangesAsync();

                    return Results.Ok($"A conta com o id {id}, foi deletada com sucesso");
                }
                catch(Exception ex)
                {
                    throw new Exception("Ocorreu o erro a seguir: " + ex.Message);
                }
            }).WithTags("Accounts").WithSummary("Delete account by id");

            app.MapDelete("/admin/accounts", async (DataContext context, [FromBody] Util ids) =>
            {
                try
                {
                    List<long> idList = ids.ids;

                    var accountsToDelete = await context.Account
                    .Where(s => idList.Contains(s.Id) && s.DeleteDate == null)
                    .ToListAsync();

                    if (accountsToDelete.Count == 0)
                        return Results.NotFound($"Não foi possível achar nenhuma conta para deletar");

                    foreach (var account in accountsToDelete)
                        account.DeleteDate = DateTime.UtcNow;
                    
                    context.Account.UpdateRange(accountsToDelete);
                    await context.SaveChangesAsync();

                    return Results.Ok("Contas deletadas com sucesso");
                }
                catch(Exception ex)
                {
                    throw new Exception("Oocorreu o erro a seguir: " + ex.Message);
                }
            }).WithTags("Accounts").WithSummary("Delete list of accounts");
        }
    }
}
