using ControllerSample.SharedLib;
using ControllerSamples.Models;

namespace ControllerSamples.Data
{
    public static class DataSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            MovieDbContext ctx = serviceProvider.GetRequiredService<MovieDbContext>();

            if (!ctx.Movie.Any())
            {
                ctx.Movie.Add(new Movie() { Title = "Jurassic Park", Description = "T-Rex wird zu Veggie gesüchtet", Price = 10, Genre = GenreType.Action });
                ctx.Movie.Add(new Movie() { Title = "Batman", Description = "Batman und Harley Quinn beziehen eine WG", Price = 9.99m , Genre = GenreType.Romance });

                ctx.Movie.Add(new Movie() { Title = "Jurassic Park 2", Description = "T-Rex wird zu Veggie gesüchtet", Price = 10, Genre = GenreType.Action });
                ctx.Movie.Add(new Movie() { Title = "Batman 2", Description = "Batman und Harley Quinn beziehen eine WG", Price = 9.99m, Genre = GenreType.Romance });

                ctx.Movie.Add(new Movie() { Title = "Jurassic Park 3", Description = "T-Rex wird zu Veggie gesüchtet", Price = 10, Genre = GenreType.Action });
                ctx.Movie.Add(new Movie() { Title = "Batman 3", Description = "Batman und Harley Quinn beziehen eine WG", Price = 9.99m, Genre = GenreType.Romance });

                ctx.Movie.Add(new Movie() { Title = "Jurassic Park 4", Description = "T-Rex wird zu Veggie gesüchtet", Price = 10, Genre = GenreType.Action });
                ctx.Movie.Add(new Movie() { Title = "Batman 4", Description = "Batman und Harley Quinn beziehen eine WG", Price = 9.99m, Genre = GenreType.Romance });

                ctx.Movie.Add(new Movie() { Title = "Jurassic Park 5", Description = "T-Rex wird zu Veggie gesüchtet", Price = 10, Genre = GenreType.Action });
                ctx.Movie.Add(new Movie() { Title = "Batman 5", Description = "Batman und Harley Quinn beziehen eine WG", Price = 9.99m, Genre = GenreType.Romance });


                ctx.Movie.Add(new Movie() { Title = "Jurassic Park 6", Description = "T-Rex wird zu Veggie gesüchtet", Price = 10, Genre = GenreType.Action });
                ctx.Movie.Add(new Movie() { Title = "Batman 6", Description = "Batman und Harley Quinn beziehen eine WG", Price = 9.99m, Genre = GenreType.Romance });


                ctx.Movie.Add(new Movie() { Title = "Jurassic Park 7", Description = "T-Rex wird zu Veggie gesüchtet", Price = 10, Genre = GenreType.Action });
                ctx.Movie.Add(new Movie() { Title = "Batman 7", Description = "Batman und Harley Quinn beziehen eine WG", Price = 9.99m, Genre = GenreType.Romance });



                ctx.SaveChanges();
            }
        }
    }
}
