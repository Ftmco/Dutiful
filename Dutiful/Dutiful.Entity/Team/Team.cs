namespace Dutiful.Entity.Team;

public record Team
{

    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string? Image { get; set; }
        
    //Navigation Property
    //Relationships

    public virtual ICollection<Project.Project> Project { get; set; }

}
