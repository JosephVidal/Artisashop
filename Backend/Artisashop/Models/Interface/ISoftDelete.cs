namespace Artisashop.Models.Interface;

public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }

    public bool Delete()
    {
        if (IsDeleted) return false;

        IsDeleted = true;
        DeletedAt = DateTime.Now;

        return true;
    }

    public bool Restore()
    {
        if (!IsDeleted) return false;

        IsDeleted = false;
        DeletedAt = null;

        return true;
    }
}