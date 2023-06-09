using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;
using Artisashop.Interfaces.IService;
using Artisashop.Models;
using Microsoft.EntityFrameworkCore;

namespace Artisashop.Services
{
    public class Utils : IUtils
    {
        public Utils()
        {

        }

        /// <summary>
        /// Get a random number between two numbers
        /// </summary>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>A number</returns>
        public int RandomNumber(int min, int max)
        {
            Random random = new();
            return random.Next(min, max);
        }

        /// <summary>
        /// Get a random string from a defined size
        /// </summary>
        /// <param name="size">Size of the string to generate</param>
        /// <returns>A string</returns>
        public string RandomString(int size)
        {
            StringBuilder builder = new();
            Random random = new();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Get a random code from a defined size
        /// </summary>
        /// <param name="size">Size of the string to generate</param>
        /// <returns>A code</returns>
        public string RandomCode(int size)
        {
            StringBuilder builder = new();
            if (size <= 5)
                return builder.Append(RandomString(size)).ToString();
            builder.Append(RandomString((size - 4) / 3 * 2));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString((size - 4) / 3));
            return builder.ToString();
        }

        public async Task<Account> GetFromCookie(HttpRequest request, StoreDbContext db)
        {
            string? token = request.Headers["Authorization"].ToString().Split(" ")[1];
            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);
            var username = jwt.Claims.First(claim => claim.Type == "sub").Value;
            return await db.Users!.SingleAsync(u => u.UserName == username);
        }

        public void UpdateObject(object modelToUpdate, object modelUpdating)
        {
            PropertyInfo[] properties = modelToUpdate.GetType().GetProperties();
            PropertyInfo[] propertiesBis = modelUpdating.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                foreach (PropertyInfo propertyBis in propertiesBis)
                    if (property.Name == propertyBis.Name)
                        property.SetValue(modelToUpdate, propertyBis.GetValue(modelUpdating));
            }
        }
    }
}