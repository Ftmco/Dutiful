using Dutiful.Entity.Project;
using Dutiful.Entity.Team;
using Microsoft.EntityFrameworkCore;

namespace Dutiful.DataBase.Context;

public class DutifulContext : DbContext
{
    public DutifulContext(DbContextOptions<DutifulContext> options) : base(options)
    { }

    public virtual DbSet<Team> Team { get; set; }

    public virtual DbSet<Project> Project { get; set; }

    public virtual DbSet<WorkList> WorkList { get; set; }

    public virtual DbSet<Card> Card { get; set; }

    public virtual DbSet<WorkTask> WorkTask { get; set; }
}