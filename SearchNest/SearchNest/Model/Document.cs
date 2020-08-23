using System.Text.Json.Serialization;
namespace SearchNest.Model
{
public class Document 
    {
        public Document (string text, int id)
        {
            this.Text = text;
            this.ID = id;
        }

        [JsonPropertyName("id")]
        public int ID {get;set;}

        [JsonPropertyName("text")]
        public string Text {get;set;}

    }
}