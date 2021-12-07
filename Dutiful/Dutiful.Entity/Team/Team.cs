namespace Dutiful.Entity.Team;

public record Team
{

    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }


}
