using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "The Shawshank Redemption",
                    ReleaseDate = DateTime.Parse("1994-2-2"),
                    Genre = "Thriller/Crime",
                    Rating = "R",
                    Price = 9.4M
                },
                new Movie
                {
                    Title = "The Godfather ",
                    ReleaseDate = DateTime.Parse("1972-5-21"),
                    Genre = "Crime",
                    Rating = "R",
                    Price = 7.79M
                },
                new Movie
                {
                    Title = "Forrest Gump",
                    ReleaseDate = DateTime.Parse("1994-1-3"),
                    Genre = "Comedy/Romance",
                    Rating = "R",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Fight Club",
                    ReleaseDate = DateTime.Parse("1999-1-8"),
                    Genre = "Action/Crime",
                    Rating = "R",
                    Price = 9.8M
                },
                new Movie
                {
                    Title = "Joker",
                    ReleaseDate = DateTime.Parse("2019-4-15"),
                    Genre = "Thriller/Crime",
                    Rating = "R",
                    Price = 6.99M
                }
            );
            context.SaveChanges();
        }
    }
}