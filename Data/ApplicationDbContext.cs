namespace better_list_app_backend_dotnet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<EntryModel> Entries { get; set; }
        public DbSet<CategoryTypeModel> CategoryTypes { get; set; }
    }
}