namespace Dutiful.Entity.Project;

public record Project
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }

    [Required]
    public Guid TeamId { get; set; }

    //Navigation Property
    //Relationships

    public virtual Team.Team Team { get; set; }

    public virtual ICollection<WorkList> WorkList { get; set; }
}

