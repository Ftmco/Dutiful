﻿namespace Dutiful.Entity.Project;


public record Card
{

    [Key]
    public Guid Id { get; set; }


    [Required]
    public string Title { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }
}
