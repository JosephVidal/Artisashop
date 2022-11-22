namespace Artisashop.Services;

using Base;
using Interface;
using Microsoft.EntityFrameworkCore;
using Models;

public interface IBasketService : ICrudRepository<BasketItem, int>
{
}

public class BasketService : BaseCrudRepository<BasketItem, int>, IBasketService
{
    public BasketService(StoreDbContext dbContext) : base(dbContext, dbContext.BasketItems)
    {
    }
}