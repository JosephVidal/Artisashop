using System.ComponentModel.DataAnnotations;
using Artisashop.Models.Interface;

namespace Artisashop.Models;

public class Complaint : IIdentifiable, ICreatedAt, IUpdatedAt
{
    public int Id { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Description { get; set; }

    [Required]
    public string UserId { get; set; } = null!;
    public virtual Account? User { get; set; }

    public int? ProductId { get; set; }
    public virtual Product? Product { get; set; }

    public int? OrderId { get; set; }
    public virtual Bill? Order { get; set; }

    public ComplaintStatus Status { get; set; }
}