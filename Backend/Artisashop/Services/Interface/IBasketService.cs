namespace Artisashop.Services.Interface;

using Models;

public interface IBasketService
{
    public Task<BasketItem> GetBasketFromUser(string userName);
    public Task<BasketItem> UpdateBasketItem(BasketItem basketItem);
    public Task<BasketItem> CreateBasketItem(BasketItem basketItem);
    public Task DeleteBasketItem(int id);
}