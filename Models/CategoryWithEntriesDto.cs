using System.ComponentModel.DataAnnotations.Schema;

namespace better_list_app_backend_dotnet.Models;

public class CategoryWithEntriesDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Emoji { get; set; }
    public CategoryType? CategoryType { get; set; }
    public int? ParentId { get; set; }
    [ForeignKey("ParentId")]
    public ICollection<Entry>? Entries { get; }

    public CategoryWithEntriesDto(Category category)
    {
        Id = category.Id;
        Name = category.Name;
        Emoji = category.Emoji;
        CategoryType = category.CategoryType;
        ParentId = category.ParentId;
        Entries = category.Entries;
    }
}
