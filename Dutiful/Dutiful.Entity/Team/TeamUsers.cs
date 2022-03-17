using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dutiful.Entity.Team;

public record TeamUsers
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid TeamId { get; set; }

    [Required]
    public Guid UserId { get; set; }
}
