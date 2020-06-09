using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Hollywood.Models
{
    public class ActorDbContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Award> Awards { get; set; }

        public ActorDbContext(DbContextOptions<ActorDbContext> options) :base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Award>()
                .HasKey(a => new { a.Title, a.DeliveryYear });

            modelBuilder
                .Entity<Award>()
                .Property(a => a.Title)
                .HasConversion<string>();

            modelBuilder
                .Entity<Movie>()
                .HasOne(m => m.Director)
                .WithOne(d => d.Movie)
                .HasForeignKey<Movie>(d => d.DirectorId);

            modelBuilder
                .Entity<ActorMovie>()
                .HasKey(am => new { am.ActorId, am.MovieId });

            modelBuilder
                .Entity<ActorMovie>()
                .HasOne(am => am.Actor)
                .WithMany(a => a.ActorMovies)
                .HasForeignKey(am => am.ActorId)
                .HasConstraintName("Awarded");

            modelBuilder
                .Entity<ActorMovie>()
                .HasOne(am => am.Movie)
                .WithMany(m => m.ActorMovies)
                .HasForeignKey(am => am.MovieId);

            modelBuilder.Entity<Actor>()
                .Property(a => a.Name).IsRequired();

            InitialData.DataSeeding(modelBuilder);
        }
    }
}
