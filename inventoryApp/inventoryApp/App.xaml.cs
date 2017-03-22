using System.Windows;

namespace inventoryApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static inventoryRepository.inventoryRepository _inventoryRepository;

        static App()
        {
            _inventoryRepository = new inventoryRepository.inventoryRepository();
        }

        public static inventoryRepository.inventoryRepository inventoryRepository
        {
            get
            {
                return _inventoryRepository;
            }
        }

    }
}
