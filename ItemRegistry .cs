using System.Collections.Generic;
 class ItemRegistry
    {
        private readonly List<Item> items = new();

        public Item GetItemByName(ItemName itemName)
        {
            return items.Find(item => item.name.Equals(itemName));
        }

        public void AddItemToRegestry(Item item)
        {
            items.Add(item);
        }

        public List<Item> Items()
        {
            return items;
        }
    }