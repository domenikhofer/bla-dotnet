namespace better_list_app_backend_dotnet.Models;

public class CategoryModel
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public string? Emoji { get; set; }
    public int? CategoryTypeId { get; set; }
    public virtual CategoryTypeModel? CategoryType { get; set; }
    public int? ParentId { get; set; }
    [ForeignKey("ParentId")]
    public virtual ICollection<CategoryModel>? Children { get; }
    // https://stackoverflow.com/a/33417518
    public ICollection<EntryModel>? Entries { get; }
    // https://learn.microsoft.com/en-us/ef/core/modeling/relationships
}