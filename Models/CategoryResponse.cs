namespace better_list_app_backend_dotnet.Models;

// TODO: Move requests and responses to a separate folder?

public class CategoryResponse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Emoji { get; set; }
    [ForeignKey("ParentId")]
    public virtual List<CategoryResponse>? Children { get; set; }

    public CategoryResponse(CategoryModel category)
    {
        Id = category.Id;
        Name = category.Name;
        Emoji = category.Emoji;
        Children = category.Children?.Select(c => new CategoryResponse(c)).ToList();
    }
}