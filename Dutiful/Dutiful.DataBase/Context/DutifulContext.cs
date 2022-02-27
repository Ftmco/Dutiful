using Dutiful.Entity.Project;
using Dutiful.Entity.Team;
using Microsoft.EntityFrameworkCore;

namespace Dutiful.DataBase.Context;

public class DutifulContext : DbContext
{
    public DutifulContext(DbContextOptions<DutifulContext> options) : base(options)
    { }

}