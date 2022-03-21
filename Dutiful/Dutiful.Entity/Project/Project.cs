namespace Dutiful.Entity.Project;

public record Project
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    [Required]
    public Guid TeamId { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }
}
