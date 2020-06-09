using Microsoft.EntityFrameworkCore;

namespace Hollywood.Models
{
    public class InitialData
    {
        public static void DataSeeding(ModelBuilder modelBuilder)
        {
            #region DirectorSeed
            modelBuilder
                .Entity<Director>()
                .HasData(
                    new Director { Id = 1, Name = "Steven Spielberg" },
                    new Director { Id = 2, Name = "Martin Scorsese" },
                    new Director { Id = 3, Name = "Quentin Jerome Tarantino" },
                    new Director { Id = 4, Name = "Christopher Jonathan James Nolan" }
                );
            #endregion

            #region MovieSeed
            modelBuilder
                .Entity<Movie>()
                .HasData(
                    new Movie { Id = 1, Title = "Jaws", DirectorId = 1 },
                    new Movie { Id = 2, Title = "The Wolf of Wall Street", DirectorId = 2 },
                    new Movie { Id = 3, Title = "Pulp Fiction", DirectorId = 3 },
                    new Movie { Id = 4, Title = "Interstellar", DirectorId = 4 }
                );
            #endregion

            #region ActorSeed
            modelBuilder
                .Entity<Actor>()
                .HasData(
                    new Actor[]
                    {
                        new Actor { Id = 1, Name = "Jack Nicholson", Age = 55 },
                        new Actor { Id = 2, Name = "Marlon Brando", Age = 68 },
                        new Actor { Id = 3, Name = "Robert De Niro", Age = 54 },
                        new Actor { Id = 4, Name = "Al Pacino", Age = 64 },
                        new Actor { Id = 5, Name = "Tom Hanks", Age = 55 },
                        new Actor { Id = 6, Name = "Anthony Hopkins", Age = 66 },
                        new Actor { Id = 7, Name = "Denzel Washington", Age = 60 },
                        new Actor { Id = 8, Name = "Morgan Freeman", Age = 61 },
                        new Actor { Id = 9, Name = "Clint Eastwood", Age = 70 },
                        new Actor { Id = 10, Name = "Leonardo DiCaprio", Age = 30 }
                    }
                );
            #endregion

            #region AwardSeed
            modelBuilder
                .Entity<Award>()
                .HasData(
                    new Award[]
                    {
                        new Award { Title = AwardType.Oscar, DeliveryYear = 2018, ActorId = 1 },
                        new Award { Title = AwardType.Oscar, DeliveryYear = 2019, ActorId = 2 },
                        new Award { Title = AwardType.GoldenGlobe, DeliveryYear = 2018, ActorId = 3 },
                        new Award { Title = AwardType.GoldenGlobe, DeliveryYear = 2019, ActorId = 1 },
                        new Award { Title = AwardType.BAFTA, DeliveryYear = 2018, ActorId = 2 },
                        new Award { Title = AwardType.BAFTA, DeliveryYear = 2019, ActorId = 1 }
                    }
                );
            #endregion

            #region ActorMovieSeed
            modelBuilder
                .Entity<ActorMovie>()
                .HasData(
                    new ActorMovie[]
                    {
                        new ActorMovie { ActorId = 1, MovieId = 1 },
                        new ActorMovie { ActorId = 1, MovieId = 2 },
                        new ActorMovie { ActorId = 2, MovieId = 2 },
                        new ActorMovie { ActorId = 3, MovieId = 2 },
                        new ActorMovie { ActorId = 5, MovieId = 2 },
                        new ActorMovie { ActorId = 6, MovieId = 2 },
                        new ActorMovie { ActorId = 2, MovieId = 3 },
                        new ActorMovie { ActorId = 4, MovieId = 3 },
                        new ActorMovie { ActorId = 8, MovieId = 3 },
                        new ActorMovie { ActorId = 9, MovieId = 3 },
                        new ActorMovie { ActorId = 10, MovieId = 3 },
                        new ActorMovie { ActorId = 2, MovieId = 4 },
                        new ActorMovie { ActorId = 3, MovieId = 4 },
                        new ActorMovie { ActorId = 4, MovieId = 4 },
                        new ActorMovie { ActorId = 7, MovieId = 4 },
                        new ActorMovie { ActorId = 8, MovieId = 4 },
                        new ActorMovie { ActorId = 9, MovieId = 4 },
                        new ActorMovie { ActorId = 10, MovieId = 4 }
                    }
                );
            #endregion
        }
    }
}
