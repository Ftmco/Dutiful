namespace Dutiful.Entity.Project;

public record WorkList
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }

    [Required]
    public short Type { get; set; }

    [Required]
    public Guid WorkListId { get; set; }

}
