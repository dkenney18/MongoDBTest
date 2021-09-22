using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace ItemStoreForSimpleAdventureGame
{
    [BsonIgnoreExtraElements]
    public class Player
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public int Money { get; set; }

        [JsonProperty]
        public int Health { get; set; }

        [JsonProperty]
        public int Level { get; set; }

        [JsonProperty]
        public int Damage { get; set; }

        [JsonProperty]
        public Item LeftHand { get; set; }

        [JsonProperty]
        public Item RightHand { get; set; }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
