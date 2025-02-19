using System.Text.Json.Serialization;

namespace crudcrudapi.Models
{
    public class Product
    {
        [JsonPropertyName("_id")] // Matches CrudCrud's property name
        public string ProductId
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public double Price
        {
            get; set;
        }
    }
}