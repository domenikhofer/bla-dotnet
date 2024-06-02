using System.Text.Json.Serialization;

namespace better_list_app_backend_dotnet.Models
{
    public class EntryResponse
    {
        public int Id { get; set; }
        public string? Value { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public bool IsDone { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual CategoryResponse? Category { get; set; }

        public EntryResponse(EntryModel entry)
        {
            Id = entry.Id;
            Value = entry.Value;
            Url = entry.Url;
            Image = entry.Image;
            IsDone = entry.IsDone;
            CategoryId = entry.CategoryId;
            Category = entry.Category != null ? new CategoryResponse(entry.Category) : null;
        }
    }


}