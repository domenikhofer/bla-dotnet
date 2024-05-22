using System.ComponentModel.DataAnnotations.Schema;

namespace better_list_app_backend_dotnet.Models;

public class CategoryWithEntriesResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Emoji { get; set; }
    public CategoryTypeModel? CategoryType { get; set; }
    public int? ParentId { get; set; }
    [ForeignKey("ParentId")]
    public ICollection<EntryModel>? Entries { get; }

    public CategoryWithEntriesResponse(CategoryModel category)
    {
        Id = category.Id;
        Name = category.Name;
        Emoji = category.Emoji;
        CategoryType = category.CategoryType;
        ParentId = category.ParentId;
        Entries = category.Entries;
    }
}
