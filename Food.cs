using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace ItemStoreForSimpleAdventureGame
{
    [BsonIgnoreExtraElements]
    public class Food
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public int Value { get; set; }

        [JsonProperty]
        public int Amount { get; set; }

        [JsonProperty]
        public int Damage { get; set; }

        [JsonProperty]
        public string Tag { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
