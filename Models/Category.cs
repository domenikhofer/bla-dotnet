using System.ComponentModel.DataAnnotations.Schema;

namespace better_list_app_backend_dotnet.Models;

public class Category
{
    // Todo: Add Validation + Error Messages  https://supunawa.medium.com/mysql-database-with-net-core-6-and-entity-framework-cc901bde9127#:~:text=Step%204%20%E2%80%94%20Create%20a%20Model%20Class
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Emoji { get; set; }
    public CategoryType? CategoryType { get; set; }
    public int? ParentId { get; set; }
    [ForeignKey("ParentId")]
    public virtual ICollection<Category>? Children { get; set; }
    // https://stackoverflow.com/a/33417518
    public ICollection<Entry>? Entries { get; }
    // https://learn.microsoft.com/en-us/ef/core/modeling/relationships
}