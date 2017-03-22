using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inventoryDB;

namespace inventoryRepository
{
    public class DatabaseManager
    {
        private static readonly inventoryEntities entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new inventoryEntities();
            entities.Database.Connection.Open();
            
        }

        // Provide an accessor to the database
        public static inventoryEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}