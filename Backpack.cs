using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace ItemStoreForSimpleAdventureGame
{
    [BsonIgnoreExtraElements]
    public class Backpack
    {
        [JsonProperty]
        public string OwnerID { get; set; }

        [JsonProperty]
        public Item Item { get; set; }
    }
}
