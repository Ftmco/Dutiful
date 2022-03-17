using Dutiful.Entity.File;
using Dutiful.Entity.Project;
using Dutiful.Entity.Team;
using Microsoft.EntityFrameworkCore;

namespace Dutiful.DataBase.Context;

public class DutifulContext : DbContext
{
    public DutifulContext(DbContextOptions<DutifulContext> options) : base(options)
    { }


    public virtual DbSet<TFile> File { get; set; }

    public virtual DbSet<Card> Card { get; set; }

    public virtual DbSet<Project> Project { get; set; }

    public virtual DbSet<ProjectMembers> ProjectMembers { get; set; }

    public virtual DbSet<TaskItem> TaskItem { get; set; }

    public virtual DbSet<WorkList> WorkList { get; set; }

    public virtual DbSet<Team> Team { get; set; }

    public virtual DbSet<TeamUsers> TeamUsers { get; set; }

}