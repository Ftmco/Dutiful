namespace Dutiful.Entity.Project;

public record WorkList
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }
         
    //Navigation Property
    //Relationships
        
    public virtual ICollection<Card> Card { get; set; }
}
