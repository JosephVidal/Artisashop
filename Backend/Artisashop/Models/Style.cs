namespace Artisashop.Models;

using System.ComponentModel.DataAnnotations;
using Artisashop.Models.Interface;

public class Style : IIdentifiable, ICreatedAt
{
    public Style()
    {
    }

    public Style(string name, string description, string image)
    {
        Name = name;
        Description = description;
        Image = image;
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public DateTime? CreatedAt { get; set; }
}