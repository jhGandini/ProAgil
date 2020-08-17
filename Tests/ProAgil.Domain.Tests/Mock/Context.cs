// using Flunt.Notifications;
// using ProAgil.Domain.Entities;

// namespace ProAgil.Domain.Tests.Mock
// {
//     public class Context : DbContext
//     {
//         public Context()
//         {
//             var options = new DbContextOptionsBuilder<MovieDbContext>()
//                 .UseInMemoryDatabase(databaseName: "MovieListDatabase")
//                 .Options;
//         }
//         public Context(DbContextOptions<ProAgilContext> options) : base(options)
//         {
//             this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
//         }
//         protected override void OnModelCreating(ModelBuilder modelBuilder)
//         {
//             base.OnModelCreating(modelBuilder);
//             modelBuilder.Ignore<Notification>();
//             modelBuilder.Entity<Event>(new EventMap().Configure);
//             modelBuilder.Entity<Batch>(new BatchMap().Configure);
//         }

//         public DbSet<Event> Event { get; set; }
//         public DbSet<Batch> Batch { get; set; }
//     }
// }