namespace Artisashop;

/// <summary>
/// Defines all role names.
/// </summary>
public static class Roles
{
    public const string Admin = "ADMIN";
    public const string User = "USER";
    public const string Seller = "SELLER";
    public const string Partner = "PARTNER";
    
    public static IEnumerable<string> AllRoles
    {
        get
        {
            yield return Admin;
            yield return User;
            yield return Seller;
            yield return Partner;
        }
    }
}

/// <summary>
/// Defines all policy names.
/// </summary>
public static class Policies
{
    public const string RequireAdminRole = "RequireAdminRole";
    public const string RequireUserRole = "RequireUserRole";
    public const string RequireSellerRole = "RequireSellerRole";
}