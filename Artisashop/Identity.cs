namespace Artisashop;

/// <summary>
/// Defines all role names.
/// </summary>
public static class Roles
{
    public const string Admin = "Admin";
    public const string User = "User";
    public const string Seller = "Seller";
    public const string Partner = "Partner";
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