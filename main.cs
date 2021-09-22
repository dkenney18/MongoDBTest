using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;

class Program {
  public static MongoClient client = new MongoClient("mongodb+srv://root:123@cluster0.pchwk.mongodb.net/ItemStoreAPI?retryWrites=true&w=majority");
  public static void Main(string[] args) {
    var registry = new ItemRegistry();
    var database = client.GetDatabase("ItemStoreAPI");
    var item_collection = database.GetCollection < Item > ("Items");
    var player_collection = database.GetCollection < Item > ("Items");
    var backpack_collection = database.GetCollection < Item > ("Items");

    var player = new Player {
      Name = "Devin",
        Money = 100000,
        Health = 1000,
        Level = 500,
        Damage = 100,
        LeftHand = new Item {
          Name = "Wooden_Sword",
            Value = 1000,
            Amount = 1,
            Damage = 10,
            Tag = "Weapon"
        },
        RightHand = new Item {
          Name = "Wooden_Sword",
            Value = 1000,
            Amount = 1,
            Damage = 10,
            Tag = "Weapon"
        },
    };

    ClearCollection();
    SetUpGameItems(registry);
    AddItems(registry);
    AddPlayer(player);
  }

  public static void AddItems(ItemRegistry registry) {
    var database = client.GetDatabase("ItemStoreAPI");
    var collection = database.GetCollection < BsonDocument > ("Items");
    foreach(var item in registry.Items()) {
      var i = new Item {
        Name = item.name.ToString(),
          Value = item.value,
          Amount = item.amount,
          Damage = item.damage,
          Tag = item.tag.ToString()
      };
      collection.InsertOne(i);
    }
  }
  public static void AddItem(BsonDocument doc) {
    var database = client.GetDatabase("ItemStoreAPI");
    var collection = database.GetCollection < BsonDocument > ("Items");

    collection.InsertOne(doc);
  }

  public static Item FindItemByName(string name) {
    var database = client.GetDatabase("ItemStoreAPI");
    var collection = database.GetCollection < BsonDocument > ("Items");
    var filter = Builders < BsonDocument > .Filter.Eq("name", name);
    var item = collection.FindSync(filter);

    try {
     return item.ToList()[0];
    } catch (Exception ex) {
      Console.WriteLine("Couldn't Find: " + name);
    }
  }

  public static void ClearCollection() {
    var database = client.GetDatabase("ItemStoreAPI");
    var collection = database.GetCollection < Item > ("Items");
    var player_collection = database.GetCollection < Player > ("Players");

    collection.DeleteMany(FilterDefinition < Item > .Empty);
    player_collection.DeleteMany(FilterDefinition < Player > .Empty);
  }

  public static void RemoveDocByID(string id) {
    var database = client.GetDatabase("ItemStoreAPI");
    var collection = database.GetCollection < BsonDocument > ("Items");
    var filter = Builders < BsonDocument > .Filter.Eq("id", id);
    collection.DeleteOne(filter);
  }

  public static void SetUpGameItems(ItemRegistry registry) {

    //Ores
    registry.AddItemToRegestry(new Ore(ItemName.Gold_Ore, 10, 1, 1));
    registry.AddItemToRegestry(new Ore(ItemName.Silver_Ore, 5, 1, 1));
    registry.AddItemToRegestry(new Ore(ItemName.Bronze_Ore, 2, 1, 1));
    registry.AddItemToRegestry(new Ore(ItemName.Copper_Ore, 1, 1, 1));
    registry.AddItemToRegestry(new Ore(ItemName.Iron_Ore, 1, 1, 1));

    //Ingots
    registry.AddItemToRegestry(new Ingot(ItemName.Gold_Ingot, 30, 1, 1));
    registry.AddItemToRegestry(new Ingot(ItemName.Silver_Ingot, 15, 1, 1));
    registry.AddItemToRegestry(new Ingot(ItemName.Bronze_Ingot, 6, 1, 1));
    registry.AddItemToRegestry(new Ingot(ItemName.Copper_Ingot, 3, 1, 1));
    registry.AddItemToRegestry(new Ingot(ItemName.Iron_Ingot, 3, 1, 1));
    registry.AddItemToRegestry(new Ingot(ItemName.Steel_Ingot, 3, 1, 1));

    //Wood Weapons
    registry.AddItemToRegestry(new Weapon(ItemName.Wood_Sword, 1000, 15, 2));
    registry.AddItemToRegestry(new Weapon(ItemName.Wood_Axe, 500, 5, 1));

    //Copper Weapons
    registry.AddItemToRegestry(new Weapon(ItemName.Copper_Sword, 1000, 15, 1));
    registry.AddItemToRegestry(new Weapon(ItemName.Copper_Axe, 500, 5, 1));

    //Bronze Weapons
    registry.AddItemToRegestry(new Weapon(ItemName.Bronze_Sword, 1000, 15, 1));
    registry.AddItemToRegestry(new Weapon(ItemName.Bronze_Axe, 500, 5, 1));

    //Silver Weapons
    registry.AddItemToRegestry(new Weapon(ItemName.Silver_Sword, 1000, 15, 1));
    registry.AddItemToRegestry(new Weapon(ItemName.Silver_Axe, 500, 5, 1));

    //Gold Weapons
    registry.AddItemToRegestry(new Weapon(ItemName.Gold_Sword, 1000, 15, 1));
    registry.AddItemToRegestry(new Weapon(ItemName.Gold_Axe, 500, 5, 1));

    //Iron Weapons
    registry.AddItemToRegestry(new Weapon(ItemName.Iron_Sword, 1000, 15, 1));
    registry.AddItemToRegestry(new Weapon(ItemName.Iron_Axe, 500, 5, 1));

    //Steel Weapons
    registry.AddItemToRegestry(new Weapon(ItemName.Steel_Sword, 1000, 15, 1));
    registry.AddItemToRegestry(new Weapon(ItemName.Steel_Axe, 500, 5, 1));

    //Foods
    registry.AddItemToRegestry(new Food(ItemName.Apple, 1, 1, 1));
    registry.AddItemToRegestry(new Food(ItemName.Orange, 3, 3, 1));
    registry.AddItemToRegestry(new Food(ItemName.Mango, 5, 5, 1));
    registry.AddItemToRegestry(new Food(ItemName.Pear, 6, 6, 1));
    registry.AddItemToRegestry(new Food(ItemName.Starfruit, 10, 10, 1));
    registry.AddItemToRegestry(new Food(ItemName.Tomato, 2, 2, 1));

    //Items
    registry.AddItemToRegestry(new Item(ItemName.Wood, 3, 1, 1));
    registry.AddItemToRegestry(new Item(ItemName.Sticks, 1, 1, 1));
  }
}