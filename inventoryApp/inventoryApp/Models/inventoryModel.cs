using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventoryApp.Models
{
    public class inventoryModel
    {
        public int itemNum { get; set; }
        public string itemDescription { get; set; }
        public decimal pricePerItem { get; set; }
        public int quantityOnHand { get; set; }
        public decimal ourCostPerItem { get; set; }
        public decimal valueOfItem { get; set; }

        public inventoryRepository.inventoryModel ToRepositoryModel()
        {
            var repositoryModel = new inventoryRepository.inventoryModel
            {
                itemNum = itemNum,
                itemDescription = itemDescription,
                pricePerItem = pricePerItem,
                quantityOnHand = quantityOnHand,
                ourCostPerItem = ourCostPerItem,
                valueOfItem = valueOfItem
            };

            return repositoryModel;
        }

        public static inventoryModel ToModel(inventoryRepository.inventoryModel respositoryModel)
        {
            var inventoryModel = new inventoryModel
            {
                itemNum = respositoryModel.itemNum,
                itemDescription = respositoryModel.itemDescription,
                pricePerItem = respositoryModel.pricePerItem,
                quantityOnHand = respositoryModel.quantityOnHand,
                ourCostPerItem = respositoryModel.ourCostPerItem,
                valueOfItem = respositoryModel.valueOfItem
            };

            return inventoryModel;
        }
    }
}