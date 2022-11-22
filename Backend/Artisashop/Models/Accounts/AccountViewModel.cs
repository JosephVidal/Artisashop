namespace Artisashop.Models.ViewModel.Accounts;

public class AccountViewModel
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string? Job { get; set; }
    public required string? Biography { get; set; }
    public required string? ProfilePicture { get; set; }
    public required string? Address { get; set; }
    public required string? AddressGps { get; set; }
    public required DateTime? CreatedAt { get; set; }
}