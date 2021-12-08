namespace Dutiful.Entity.Project;



public record Card
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

    //Navigation Property
    //Relationships

    public virtual WorkList WorkList { get; set; }

    public virtual ICollection<WorkTask> WorkTask { get; set; }
}
