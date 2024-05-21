using System.ComponentModel.DataAnnotations.Schema;

namespace better_list_app_backend_dotnet.Models;

public class CategoryDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Emoji { get; set; }
    public CategoryType? CategoryType { get; set; }
    public int? ParentId { get; set; }
    [ForeignKey("ParentId")]
    public virtual List<CategoryDto>? Children { get; set; }

    public CategoryDto(Category category)
    {
        Id = category.Id;
        Name = category.Name;
        Emoji = category.Emoji;
        CategoryType = category.CategoryType;
        ParentId = category.ParentId;
        Children = category.Children?.Select(c => new CategoryDto(c)).ToList();
    }
}