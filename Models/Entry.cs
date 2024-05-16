namespace better_list_app_backend_dotnet.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string? Value { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public bool IsDone { get; set; }
        public Category? Category { get; set; }

        // Todo: Add SoftDelete property

    }
}