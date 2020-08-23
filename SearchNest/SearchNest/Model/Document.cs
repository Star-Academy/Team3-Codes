using System.Text.Json.Serialization;
namespace SearchNest.Model
{
public class Document 
    {
        [JsonPropertyName("id")]
        public int ID {get;set;}

        [JsonPropertyName("text")]
        public string Text {get;set;}

        [JsonPropertyName("name")]
        public string Name {get;set;}
    }
}