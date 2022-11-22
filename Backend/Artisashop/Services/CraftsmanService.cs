namespace Artisashop.Services;

using System.Linq.Expressions;
using Base;
using Exceptions;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public interface ICraftsmanService :
    IReadRepository<Account, string>
{
    public Task ChangeValidationStatusAsync(Account craftsman, bool isValidated);

    public Task ChangeValidationStatusAsync(string craftsmanId, bool isValidated);

    public Task ChangeStatusAsync(Account account, bool isActive);

    public Task ChangeStatusAsync(string craftsmanId, bool isActive);
}

public class CraftsmanService : BaseReadOnlyRepository<Account, string>, ICraftsmanService
{
    public CraftsmanService(StoreDbContext dbContext) : base(dbContext, dbContext.Users)
    {
    }

    public async Task ChangeValidationStatusAsync(Account craftsman, bool isValidated)
    {
        throw new NotImplementedException();
    }

    public async Task ChangeValidationStatusAsync(string craftsmanId, bool isValidated)
    {
        var craftsman = await GetAsync(craftsmanId);
        if (craftsman == null)
        {
            throw new ArtisashopException("Cannot find craftsman with id: " + craftsmanId);
        }
        await ChangeValidationStatusAsync(craftsman, isValidated);
    }

    public async Task ChangeStatusAsync(Account account, bool isActive)
    {
        throw new NotImplementedException();
    }

    public async Task ChangeStatusAsync(string craftsmanId, bool isActive)
    {
        throw new NotImplementedException();
    }
}