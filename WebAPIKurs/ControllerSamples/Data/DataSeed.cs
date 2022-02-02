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
                ctx.SaveChanges();
            }
        }
    }
}
