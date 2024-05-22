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
                    new CategoryTypeModel
                    {
                        Name = "Movie/TV Show"
                    },
                    new CategoryTypeModel
                    {
                        Name = "Game"
                    },
                     new CategoryTypeModel
                     {
                         Name = "Book"
                     }
                );

                context.SaveChanges();  // Better solution for multiple saves?

                context.Categories.AddRange(
                    new CategoryModel
                    {
                        Name = "Activities",
                        Emoji = null,
                        CategoryType = null,
                        ParentId = null,
                    },
                    new CategoryModel
                    {
                        Name = "Summer",
                        Emoji = "☀️",
                        CategoryType = null,
                        ParentId = 1, // TODO: find better way to get id
                    },
                    new CategoryModel
                    {
                        Name = "Winter",
                        Emoji = "❄️",
                        CategoryType = null,
                        ParentId = 1,
                    },
                    new CategoryModel
                    {
                        Name = "Media",
                        Emoji = null,
                        CategoryType = null,
                        ParentId = null,
                    },
                    new CategoryModel
                    {
                        Name = "Movies",
                        Emoji = "🎬",
                        CategoryType = context.CategoryTypes.Single(ct => ct.Name == "Movie/TV Show"),
                        ParentId = 4,
                    },
                    new CategoryModel
                    {
                        Name = "Series",
                        Emoji = "📺",
                        CategoryType = context.CategoryTypes.Single(ct => ct.Name == "Movie/TV Show"),
                        ParentId = 4,
                    },
                    new CategoryModel
                    {
                        Name = "Games",
                        Emoji = "🎮",
                        CategoryType = context.CategoryTypes.Single(ct => ct.Name == "Game"),
                        ParentId = 4,
                    },
                    new CategoryModel
                    {
                        Name = "Books",
                        Emoji = "📘",
                        CategoryType = context.CategoryTypes.Single(ct => ct.Name == "Book"),
                        ParentId = 4,
                    },
                    new CategoryModel
                    {
                        Name = "Food",
                        Emoji = null,
                        CategoryType = null,
                        ParentId = null,
                    },
                    new CategoryModel
                    {
                        Name = "Restaurants ZH",
                        Emoji = "🍽️",
                        CategoryType = null,
                        ParentId = 9,
                    },
                    new CategoryModel
                    {
                        Name = "Restaurants Elsewhere",
                        Emoji = "🍜",
                        CategoryType = null,
                        ParentId = 9,
                    },
                    new CategoryModel
                    {
                        Name = "Recipes",
                        Emoji = "📄",
                        CategoryType = null,
                        ParentId = 9,
                    },
                    new CategoryModel
                    {
                        Name = "Cooking / Baking Ideas",
                        Emoji = "🥐",
                        CategoryType = null,
                        ParentId = 9,
                    },
                    new CategoryModel
                    {
                        Name = "Projects",
                        Emoji = null,
                        CategoryType = null,
                        ParentId = null,
                    },
                    new CategoryModel
                    {
                        Name = "General",
                        Emoji = "🪚",
                        CategoryType = null,
                        ParentId = 14,
                    },
                    new CategoryModel
                    {
                        Name = "Programming",
                        Emoji = "💻",
                        CategoryType = null,
                        ParentId = 14,
                    },
                    new CategoryModel
                    {
                        Name = "Other",
                        Emoji = null,
                        CategoryType = null,
                        ParentId = null,
                    },
                    new CategoryModel
                    {
                        Name = "Gift-Ideas",
                        Emoji = "🎁",
                        CategoryType = null,
                        ParentId = 17,
                    },
                    new CategoryModel
                    {
                        Name = "Miscellaneous",
                        Emoji = "✨",
                        CategoryType = null,
                        ParentId = 17,
                    }
                );
                context.SaveChanges();

                context.Entries.AddRange(
                   new EntryModel
                   {
                       Value = "Klima Plexiglass",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Pink Apple",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Velo Keller",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Raffi Theater Tix",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Abdeckplanen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Kleider Org",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Wäsche",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Creme",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Kitchen utensils",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Bewerbung Garten",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Brille Kratzer",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Baum schneiden",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Pflanzen züchten",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Pflanzen pflanzen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Saisonabo bäder",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Ausflüge planen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Pflanzen ricardo",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Sachen Verkaufen/Vergeben",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Job",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Face yoga",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Better List App",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "DataAnnotation",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Hide Klima",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Ahv DataAnnotation",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Terasse putzen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Sofa putzen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Reduit ausmisten",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Keller ausmisten",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Umtopfen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Dropbox aufräumen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Disney Paris",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Monstera umtopfen + Bambusstab",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Produkte aufbrauchen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "ÖV Abo überprüfen",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Luftbefeuchter Keller",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Pflanzen giessen wöchentlich",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Balkon pflanze verschieben",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Pflanzen Balkon",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Stretching routine",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Meditation?",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Folie Rückwand Küche",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Gampel Tickets",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Raiffeisen wechseln",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Checkup / Blutbild",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "Badi Abo ZH",
                       Url = null,
                       Image = null,
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Summer")
                   },
                   new EntryModel
                   {
                       Value = "The Croods",
                       Url = "https://www.themoviedb.org/movie/49519",
                       Image = "/hkjPDCe6qmPcrkinqTgv0ygcrHg.jpg",
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Movies")
                   },
                   new EntryModel
                   {
                       Value = "Saving Mr. Banks",
                       Url = "https://www.themoviedb.org/movie/140823",
                       Image = "/4RkcUe5PKnYvrCwMjk8giUAoID7.jpg",
                       IsDone = false,
                       Category = context.Categories.Single(c => c.Name == "Movies")
                   },
                   new EntryModel
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


