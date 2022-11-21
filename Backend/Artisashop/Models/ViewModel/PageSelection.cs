namespace Artisashop.Models.ViewModel;

/// <summary>
/// Used to only take a certain amount of items from a list.
/// </summary>
public class PageSelection
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}