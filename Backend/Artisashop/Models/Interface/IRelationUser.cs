namespace Artisashop.Models.Interface;

using Artisashop.Models;

public interface IRelationUser
{
    public string UserId { get; set; }
    public Account? User { get; set; }
}