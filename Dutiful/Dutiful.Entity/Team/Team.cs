using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dutiful.Entity.Team;

public record Team
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Token { get; set; }

    [Required]
    public Guid OwnerId { get; set; }

    public string Bio { get; set; }
}
