using Microsoft.EntityFrameworkCore;

namespace NpgsqlIncludeIssue;



// Check IncludeIssueController for example usage
public class DatabaseContext : DbContext
{
    public DbSet<BaseMyClass> BaseMyClasses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseNpgsql(@"connection string");
        optionsBuilder.LogTo(Console.WriteLine);
    }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BaseMyClass>().OwnsOne(v => v.Information);
    }
}
    
public class BaseMyClass
{
    public Guid Id { get; set; }
    public bool BaseEntityProperty { get; set; }
    public Information Information { get; set; }
}

public class Information
{
    public bool Boolean { get; set; }
    public Nav1 Nav1 { get; set; }
    public Nav2 Nav2 { get; set; }
}
    
public class Nav1
{
    public Guid Id { get; set; }
}
    
public class Nav2
{
    public Guid Id { get; set; }
}