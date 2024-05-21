using System.Text.Json.Serialization;

namespace better_list_app_backend_dotnet.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string? Value { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public bool IsDone { get; set; }
        [JsonIgnore]
        public Category? Category { get; set; }

        // TODO: Add SoftDelete property

    }
}