using Artichaut.Models;

namespace Artichaut.Interfaces.IService
{
    public interface IUtils
    {
        public int RandomNumber(int min, int max);
        public string RandomString(int size);
        public string RandomCode(int size);
        public Task<Account> GetFromCookie(HttpRequest request, StoreDbContext db);
        public void UpdateObject(object modelToUpdate, object modelUpdating);
    }
}
