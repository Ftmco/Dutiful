using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dutiful.Entity.File;

/// <summary>
/// File Entity
/// File Table 
/// </summary>
public record TFile
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Directory { get; set; }

    [Required]
    public string OriginalName { get; set; }

    [Required]
    public DateTime CreateDate { get; set; }

    [Required]
    public string Mime { get; set; }

    [Required]
    public short Enum { get; set; }
}
