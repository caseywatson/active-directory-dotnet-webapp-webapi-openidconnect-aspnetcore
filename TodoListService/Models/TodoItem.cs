using Newtonsoft.Json;

namespace TodoListService.Models
{
    public class TodoItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Owner { get; set; }
        public string Title { get; set; }
    }
}
