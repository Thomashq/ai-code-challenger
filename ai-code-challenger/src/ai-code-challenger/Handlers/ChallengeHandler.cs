using System.Data;
using System.Data.Entity;
using ai_code_challenger.common;
using ai_code_challenger.common.Handlers;
using ai_code_challenger.common.Request.Categories.Challenges;
using ai_code_challenger.common.Response;
using ai_code_challenger.Data;

namespace ai_code_challenger.Handlers;

public class ChallengeHandler(DataContext context) : IChallengeHandler
{
    public async Task<Response<Challenge?>> CreateAsync(CreateChallengeRequest request)
    {
        try
        {
            var challenge = new Challenge
            {
                Wording = request.Wording,
                Title = request.Title,
                IsSolved = false,
                CreationDate = DateTime.UtcNow,
                AccountId = request.AccountId
            };

            await context.Challenge.AddAsync(challenge);
            await context.SaveChangesAsync();

            return new Response<Challenge?>(challenge, 201, "Desafio criado com sucesso");
        }
        catch (Exception ex)
        {
            return new Response<Challenge?>(null, 500, "Não foi possível criar o desafio");
        }
    }

    public async Task<Response<Challenge?>> DeleteAsync(DeleteChallengeRequest request)
    {
        try
        {
            var challenge = await context
                .Challenge
                .FirstOrDefaultAsync(x => x.Id == request.ChallengeId && x.DeleteDate == null);

            if (challenge == null)
                return new Response<Challenge?>(null, 404, "Desafio não encontrado");

            challenge.UpdateDate = DateTime.UtcNow;
            challenge.DeleteDate = DateTime.UtcNow;

            context.Challenge.Update(challenge);
            await context.SaveChangesAsync();

            return new Response<Challenge?>(challenge, message: "Desafio deletado com sucesso");
        }
        catch (Exception ex)
        {
            return new Response<Challenge?>(null, 500, "Não foi possível deletar o desafio");
        }
    }

    public async Task<Response<List<Challenge>?>> DeleteListAsync(DeleteListOfChallengesRequest request)
    {
        try
        {
            List<long> idList = request.Ids.ids;

            var challengesToDelete = await context
                .Challenge
                .Where(s => idList.Contains(s.Id) && s.DeleteDate == null)
                .ToListAsync();

            if (challengesToDelete == null)
                return new Response<List<Challenge>?>(null, 404, "Desafios não encontrados");

            foreach (var challenge in challengesToDelete)
            {
                challenge.UpdateDate = DateTime.UtcNow;
                challenge.DeleteDate = DateTime.UtcNow;
            }

            context.Challenge.UpdateRange(challengesToDelete);
            await context.SaveChangesAsync();

            return new Response<List<Challenge>?>(null, message: "Desafios deletados com sucesso");
        }
        catch (Exception ex)
        {
            return new Response<List<Challenge>?>(null, 500, "Não foi possível deletar os desafio");
        }
    }

    public async Task<PagedResponse<List<Challenge>?>> GetAllAsync(GetAllChallengesRequest request)
    {
        try
        {
            var query = context
                .Challenge
                .AsNoTracking()
                .Where(x => x.AccountId == request.AccountId && x.DeleteDate == null)
                .OrderBy(x => x.Title);

            var challenges = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();

            return new PagedResponse<List<Challenge>?>(
                challenges,
                count,
                request.PageNumber,
                request.PageSize);
        }
        catch (Exception ex)
        {
            return new PagedResponse<List<Challenge>?>(null, 500, "Não foi possível encontrar os desafios");
        }
    }

    public async Task<PagedResponse<List<Challenge>?>> GetByPeriodAsync(GetChallengesByPeriodRequest request)
    {
        try
        {
            request.StartDate ??= DateTime.UtcNow.GetFirstDay();
            request.EndDate ??= DateTime.UtcNow.GetLastDay();

            var query = context.Challenge
                .AsNoTracking()
                .Where(x => x.CreationDate >= request.StartDate &&
                            x.DeleteDate <= request.EndDate)
                .OrderBy(x => x.CreationDate);

            var challenges = await query
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var count = await query.CountAsync();
            return new PagedResponse<List<Challenge>?>(
                challenges,
                count,
                request.PageNumber,
                request.PageSize
            );
        }
        catch (Exception ex)
        {
            return new PagedResponse<List<Challenge>?>(null, 500, "Não foi possível encontrar os desafios");
        }
    }

    public async Task<Response<Challenge?>> GetById(GetChallengeByIdRequest request)
    {
        try
        {
            var challenge = await context
                .Challenge
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.DeleteDate == null);

            return challenge is null
                ? new Response<Challenge?>(null, 404, message: "Não foi possível encontrar o desafio")
                : new Response<Challenge?>(challenge);
        }
        catch (Exception)
        {
            return new Response<Challenge?>(null, 500, "Não foi possível encontrar o desafio");
        }
    }

    public async Task<Response<Challenge?>> UpdateAsync(UpdateChallengeRequest request)
    {
        try
        {
            var challenge = await context
                .Challenge
                .FirstOrDefaultAsync(x => x.Id == request.ChallengeId && x.DeleteDate == null);

            if (challenge == null)
                return new Response<Challenge?>(null, 404, "Desafio não encontrado");

            challenge.Answer = request.Answer;
            challenge.IsSolved = request.IsSolved;
            challenge.Language = request.Laguage;
            challenge.Title = request.Title;
            challenge.UpdateDate = DateTime.UtcNow;

            context.Challenge.Update(challenge);

            await context.SaveChangesAsync();

            return new Response<Challenge?>(challenge, message: "Desafio atualizado com sucesso");
        }
        catch (Exception ex)
        {
            return new Response<Challenge?>(null, 500, "Não foi possível atualizar o desafio");
        }
    }
}