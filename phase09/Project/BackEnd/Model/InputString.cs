using System.Text.Json.Serialization;

namespace BackEnd.Model
{
    public class InputString
    {
        [JsonPropertyName("input")]
        public string Input { get; set; } 
        
    }
}