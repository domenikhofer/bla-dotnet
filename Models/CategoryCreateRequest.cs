namespace better_list_app_backend_dotnet.Models;

public class CategoryCreateRequest
{
    [Required]
    public string? Name { get; set; }
    public string? Emoji { get; set; }
    public int? CategoryTypeId { get; set; }
    public int? ParentId { get; set; }

}