using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Entities;
using ProAgil.Infra.Data.EntityMapping;

namespace ProAgil.Infra.Data.Contexts
{
    public class ProAgilContext : DbContext
    {

        //dotnet ef migrations add initial -p ../../Presentation/ProAgil.Presentatio.Api/ProAgil.Presentation.Api.csprj
        //dotnet ef --startup-project ../../Presentation/ProAgil.Presentation.Api/ProAgil.Presentation.Api.csproj migrations add initial -c ProAgilContext

        protected ProAgilContext()
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public ProAgilContext(DbContextOptions<ProAgilContext> options) : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            opt.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<Notification>();
            modelBuilder.Entity<Event>(new EventMap().Configure);
            modelBuilder.Entity<Lot>(new LotMap().Configure);
        }

        public DbSet<Event> Event { get; set; }
        public DbSet<Lot> Lot { get; set; }
    }
}