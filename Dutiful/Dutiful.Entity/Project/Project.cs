using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
