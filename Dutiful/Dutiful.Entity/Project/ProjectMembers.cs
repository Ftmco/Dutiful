using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dutiful.Entity.Project;

public record ProjectMembers
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid ProjectId { get; set; }

    [Required]
    public Guid UserId { get; set; }
}
