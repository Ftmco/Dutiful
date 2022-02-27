using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dutiful.Entity.Project;

public    record Card
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }

    [Required]
    public Guid ListId { get; set; }

    [Required]
    public Guid OwnerId { get; set; }
}
