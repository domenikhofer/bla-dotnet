using System.Text.Json.Serialization;

namespace better_list_app_backend_dotnet.Models
{
    public class EntriesCreateModel
    {
        public string? Value { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public bool IsDone { get; set; }
        public int CategoryId { get; set; }
    }
}