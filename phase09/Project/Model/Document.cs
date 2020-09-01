using System.Text.Json.Serialization;
namespace SearchNest.Model
{
    public class Document
    {
        public Document(string text, int id, string name)
        {
            Text = text;
            Id = id;
            Name = name;

        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }


    }
}