namespace better_list_app_backend_dotnet.Models;

public class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Emoji { get; set; }
    public CategoryType? CategoryType { get; set; }
}