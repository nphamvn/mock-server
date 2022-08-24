using Microsoft.EntityFrameworkCore;
using MockServer.Entities;

namespace MockServer.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Request>()
            .HasOne(req => req.StaticResponse)
            .WithOne(res => res.Request)
            .HasForeignKey<StaticResponse>(req => req.RequestId);

        modelBuilder.Entity<Request>()
            .HasOne(req => req.FunctionResponse)
            .WithOne(res => res.Request)
            .HasForeignKey<FunctionResponse>(req => req.RequestId);

        // modelBuilder.Entity<Request>()
        //     .Property(p => p.Headers)
        //     .HasConversion(
        //         d => JsonConvert.SerializeObject(d),
        //         s => JsonConvert.DeserializeObject<Dictionary<string, string>>(s));
    }
}