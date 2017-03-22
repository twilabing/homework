using inventoryDB;
using System.Collections.Generic;
using System.Linq;

namespace inventoryRepository
{
    public class inventoryModel
    {
        public int itemNum { get; set; }
        public string itemDescription { get; set; }
        public decimal pricePerItem { get; set; }
        public int quantityOnHand { get; set; }
        public decimal ourCostPerItem { get; set; }
        public decimal valueOfItem { get; set; }

    }

    public class inventoryRepository
    {
        public inventoryModel Add(inventoryModel inventoryModel)
        {
            var inventoryDb = ToDbModel(inventoryModel);

            //DatabaseManager.Instance.Items.Add(inventoryDb);
            DatabaseManager.Instance.ITEMS.Add(inventoryDb);
            DatabaseManager.Instance.SaveChanges();

            inventoryModel = new inventoryModel
            {
                itemNum = inventoryDb.itemNum,
                itemDescription = inventoryDb.itemDescription,
                pricePerItem = inventoryDb.pricePerItem,
                quantityOnHand = inventoryDb.quantityOnHand,
                ourCostPerItem = inventoryDb.ourCostPerItem
            };
            return inventoryModel;
        }

        public List<inventoryModel> GetAll()
        {
            // Use .Select() to map the database inventory to inventoryModel
            var items = DatabaseManager.Instance.ITEMS
              .Select(t => new inventoryModel
              {
                  itemNum = t.itemNum,
                  itemDescription = t.itemDescription,
                  pricePerItem = t.pricePerItem,
                  quantityOnHand = t.quantityOnHand,
                  ourCostPerItem = t.ourCostPerItem
              }).ToList();

            return items;
        }

        public bool Update(inventoryModel inventoryModel)
        {
            var original = DatabaseManager.Instance.ITEMS.Find(inventoryModel.itemNum);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(inventoryModel));
                DatabaseManager.Instance.SaveChanges();
            }

            return false;
        }

        public bool Remove(int itemNum)
        {
            var items = DatabaseManager.Instance.ITEMS
                                .Where(t => t.itemNum == itemNum);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.ITEMS.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private ITEM ToDbModel(inventoryModel inventoryModel)
        {
            var inventoryDb = new ITEM
            {
                itemNum = inventoryModel.itemNum,
                itemDescription = inventoryModel.itemDescription,
                pricePerItem = inventoryModel.pricePerItem,
                quantityOnHand = inventoryModel.quantityOnHand,
                ourCostPerItem = inventoryModel.ourCostPerItem
                //,valueOfItem = inventoryModel.valueOfItem
            };

            return inventoryDb;
        }
    }
}