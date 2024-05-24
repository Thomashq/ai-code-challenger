using ai_code_challenger.Data;
using ai_code_challenger.common;
using ai_code_challenger.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ai_code_challenger.EndPoints
{
    public static class ChallengeEndpoints
    {
        public static void MapChallengeEndpoints(this WebApplication app)
        {
            app.MapGet("/admin/challenges/{skip:int}/{take:int}", async (DataContext context, int skip, int take) =>
            {
                try
                {
                    var totalCount = await context.Challenge.CountAsync();

                    if (totalCount == 0)
                        return Results.NotFound("No questions found found");

                    var challengList = await context.Challenge
                    .AsNoTracking()
                    .Where(a => a.DeleteDate == null)
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

                    return Results.Ok(challengList);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o erro a seguir: " + ex.Message);
                }
            }).WithTags("Challenge").WithSummary("Get all not deleted questions");

            app.MapGet("/admin/challenges/{id:long}", async (DataContext context, long id) =>
            {
                var challenge = await context.Challenge
                .FirstOrDefaultAsync(a => a.DeleteDate == null && a.Id == id);

                if (challenge == null)
                    Results.NotFound($"Nenhuma conta com o id {id} foi encontrada");

                return Results.Ok(challenge);
            }).WithTags("Challenge").WithSummary("Get challenge by id");

            app.MapPut("/admin/challenges/{id:long}", async (DataContext context, long id, Challenge updatedChallenge) =>
            {
                try
                {
                    var challenge = await context.Challenge.FirstOrDefaultAsync(a => a.DeleteDate != null && a.Id == id);

                    if (challenge == null)
                        Results.NotFound($"A questão com id {id} não foi encontrada");

                    foreach (var property in typeof(Challenge).GetProperties())
                    {
                        var keyAttribute = property.GetCustomAttribute<KeyAttribute>();
                        if (keyAttribute == null)
                        {
                            var updatedValues = property.GetValue(updatedChallenge);
                            if (updatedValues != null)
                                property.SetValue(challenge, updatedValues);
                        }
                    }

                    challenge.UpdateDate = DateTime.UtcNow;
                    context.Challenge.Update(challenge);

                    await context.SaveChangesAsync();

                    return Results.Ok("Questão atualizada com sucesso");
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o erro a seguir: " + ex.Message);
                }
            }).WithTags("Challenge").WithSummary("Update challenge by id");

            app.MapPost("/admin/challenges", async (DataContext context, Challenge challenge) =>
            {
                try
                {
                    challenge.CreationDate = DateTime.UtcNow;
                    challenge.IsSolved = false;
                    await context.Challenge.AddAsync(challenge);

                    await context.SaveChangesAsync();

                    return Results.Ok("Desafio criado com sucesso");
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o erro a seguir: " + ex.Message);
                }
            }).WithTags("Challenge").WithSummary("Add new challenge");

            app.MapDelete("/admin/challenges/{id:long}", async (DataContext context, long id) =>
            {
                try
                {
                    var challenge = await context.Challenge.FirstOrDefaultAsync(a => a.DeleteDate == null && a.Id == id);

                    if (challenge == null)
                        Results.NotFound($"A questão com id {id} não foi encontrada");

                    challenge.DeleteDate = DateTime.UtcNow;

                    context.Challenge.Update(challenge);

                    await context.SaveChangesAsync();

                    return Results.Ok($"A questão com o id {id}, foi atualizada com sucesso");
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu o erro a seguir: " + ex.Message);
                }
            }).WithTags("Challenge").WithSummary("Delete challenge by id");

            app.MapDelete("/admin/challenges", async (DataContext context, [FromBody] Util ids) =>
            {
                try
                {
                    List<long> idList = ids.ids;

                    var challengesToDelete = await context.Challenge
                    .Where(s => idList.Contains(s.Id) && s.DeleteDate == null)
                    .ToListAsync();

                    if (challengesToDelete.Count == 0)
                        return Results.NotFound($"Não foi possível achar nenhuma conta para deletar");

                    foreach (var challenge in challengesToDelete)
                        challenge.DeleteDate = DateTime.UtcNow;

                    context.Challenge.UpdateRange(challengesToDelete);
                    await context.SaveChangesAsync();

                    return Results.Ok("Questões deletadas com sucesso");
                }
                catch (Exception ex)
                {
                    throw new Exception("Oocorreu o erro a seguir: " + ex.Message);
                }
            }).WithTags("Challenge").WithSummary("Delete list of challenges");
        }
    }
}
