namespace Dutiful.Entity.Project;

public record WorkTask
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid CardId { get; set; }

    //Navigation Property
    //Relationships

    public virtual Card Card { get; set; }
}

