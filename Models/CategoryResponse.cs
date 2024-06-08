namespace better_list_app_backend_dotnet.Models;

// TODO: Move requests and responses to a separate folder?

public class CategoryResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Emoji { get; set; }
    public CategoryTypeModel? CategoryType { get; set; }

    public int? ParentId { get; set; }
    [ForeignKey("ParentId")]
    public virtual List<CategoryResponse>? Subcategories { get; set; }

    public CategoryResponse(CategoryModel category)
    {
        Id = category.Id;
        Name = category.Name;
        Emoji = category.Emoji;
        CategoryType = category.CategoryType;
        ParentId = category.ParentId;
        Subcategories = category.Children?.Select(c => new CategoryResponse(c)).ToList();
    }
}