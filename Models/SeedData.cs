using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace better_list_app_backend_dotnet.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any categories.
                if (context.Categories.Any())
                {
                    return;   // DB has been seeded
                }

                // https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-8.0&tabs=visual-studio#seed-the-database

                // TODO: move seeder data to json file or something prettier

                context.CategoryTypes.AddRange(
                    new CategoryType
                    {
                        Name = "Movie/TV Show"
                    },
                    new CategoryType
                    {
                        Name = "Game"
                    },
                     new CategoryType
                     {
                         Name = "Book"
                     }
                );

                context.SaveChanges();  // Better solution for multiple saves?

                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Activities",
                        Emoji = null,
                        CategoryType = null,
                        ParentId = null,
                    },
                    new Category
                    {
                        Name = "Summer",
                        Emoji = "☀️",
                        CategoryType = null,
                        ParentId = 1, // TODO: find better way to get id
                    },
                    new Category
                    {
                        Name = "Winter",
                        Emoji = "❄️",
                        CategoryType = null,
                        ParentId = 1,
                    },
                    new Category
                    {
                        Name = "Media",
                        Emoji = null,
                        CategoryType = null,
                        ParentId = null,
                    },
                    new Category
                    {
                        Name = "Movies",
                        Emoji = "🎬",
                        CategoryType = context.CategoryTypes.Single(ct => ct.Name == "Movie/TV Show"),
                        ParentId = 4,
                    },
                    new Category
                    {
                        Name = "Series",
                        Emoji = "📺",
                        CategoryType = context.CategoryTypes.Single(ct => ct.Name == "Movie/TV Show"),
                        ParentId = 4,
                    },
                    new Category
                    {
                        Name = "Games",
                        Emoji = "🎮",
                        CategoryType = context.CategoryTypes.Single(ct => ct.Name == "Game"),
                        ParentId = 4,
                    },
                    new Category
                    {
                        Name = "Books",
                        Emoji = "📘",
                        CategoryType = context.CategoryTypes.Single(ct => ct.Name == "Book"),
                        ParentId = 4,
                    },
                    new Category
                    {
                        Name = "Food",
                        Emoji = null,
                        CategoryType = null,
                        ParentId = null,
                    },
                    new Category
                    {
                        Name = "Restaurants ZH",
                        Emoji = "🍽️",
                        CategoryType = null,
                        ParentId = 9,
                    },
                    new Category
                    {
                        Name = "Restaurants Elsewhere",
                        Emoji = "🍜",
                        CategoryType = null,
                        ParentId = 9,
                    },
                    new Category
                    {
                        Name = "Recipes",
                        Emoji = "📄",
                        CategoryType = null,
                        ParentId = 9,
                    },
                    new Category
                    {
                        Name = "Cooking / Baking Ideas",
                        Emoji = "🥐",
                        CategoryType = null,
                        ParentId = 9,
                    },
                    new Category
                    {
                        Name = "Projects",
                        Emoji = null,
                        CategoryType = null,
                        ParentId = null,
                    },
                    new Category
                    {
                        Name = "General",
                        Emoji = "🪚",
                        CategoryType = null,
                        ParentId = 14,
                    },
                    new Category
                    {
                        Name = "Programming",
                        Emoji = "💻",
                        CategoryType = null,
                        ParentId = 14,
                    },
                    new Category
                    {
                        Name = "Other",
                        Emoji = null,
                        CategoryType = null,
                        ParentId = null,
                    },
                    new Category
                    {
                        Name = "Gift-Ideas",
                        Emoji = "🎁",
                        CategoryType = null,
                        ParentId = 17,
                    },
                    new Category
                    {
                        Name = "Miscellaneous",
                        Emoji = "✨",
                        CategoryType = null,
                        ParentId = 17,
                    }
                );
                context.SaveChanges();

                context.Entries.AddRange(
                   new Entry
                   {
                       Value = "Klima Plexiglass",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Pink Apple",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Velo Keller",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Raffi Theater Tix",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Abdeckplanen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Kleider Org",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Wäsche",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Creme",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Kitchen utensils",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Bewerbung Garten",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Brille Kratzer",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Baum schneiden",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Pflanzen züchten",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Pflanzen pflanzen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Saisonabo bäder",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Ausflüge planen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Pflanzen ricardo",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Sachen Verkaufen/Vergeben",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Job",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Face yoga",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Better List App",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "DataAnnotation",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Hide Klima",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Ahv DataAnnotation",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Terasse putzen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Sofa putzen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Reduit ausmisten",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Keller ausmisten",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Umtopfen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Dropbox aufräumen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Disney Paris",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Monstera umtopfen + Bambusstab",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Produkte aufbrauchen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "ÖV Abo überprüfen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Luftbefeuchter Keller",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Pflanzen giessen wöchentlich",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Balkon pflanze verschieben",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Pflanzen Balkon",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Stretching routine",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Meditation?",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Folie Rückwand Küche",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Gampel Tickets",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Raiffeisen wechseln",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Checkup / Blutbild",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "Badi Abo ZH",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new Entry
                   {
                       Value = "The Croods",
                       Url = "https://www.themoviedb.org/movie/49519",
                       Image = "/hkjPDCe6qmPcrkinqTgv0ygcrHg.jpg",
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Movies")
                   },
                   new Entry
                   {
                       Value = "Saving Mr. Banks",
                       Url = "https://www.themoviedb.org/movie/140823",
                       Image = "/4RkcUe5PKnYvrCwMjk8giUAoID7.jpg",
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Movies")
                   },
                   new Entry
                   {
                       Value = "Hairspray",
                       Url = "https://www.themoviedb.org/movie/2976",
                       Image = "/fgMka3HtFvI5OgW1eYdR9XpySxH.jpg",
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Movies")
                   }

                );
                context.SaveChanges();

            }
        }
    }
}


