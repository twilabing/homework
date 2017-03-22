using inventoryApp.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace inventoryApp
{
    public partial class MainWindow : Window
    {

        private inventoryModel selectedItem;

        private void uxinventoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedItem = (inventoryModel)uxinventoryList.SelectedValue;
        }

        public MainWindow()
        {
            InitializeComponent();

            LoadInventory();
        }

        private void LoadInventory()
        {
            var inventory = App.inventoryRepository.GetAll();

            uxinventoryList.ItemsSource = inventory
                .Select(t => inventoryModel.ToModel(t))
                .ToList();

  
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new inventoryWindow();

            if (window.ShowDialog() == true)
            {
                var uiInventorytModel = window.Inventory;
                var repositoryInventorytModel = uiInventorytModel.ToRepositoryModel();

                App.inventoryRepository.Add(repositoryInventorytModel);

                LoadInventory();
            }
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new inventoryWindow();
            window.Inventory= selectedItem;

            if (window.ShowDialog() == true)
            {
                App.inventoryRepository.Update(window.Inventory.ToRepositoryModel());
                LoadInventory();
            }
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedItem != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }
        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.inventoryRepository.Remove(selectedItem.itemNum);
            selectedItem = null;
            LoadInventory();
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedItem != null);
        }

    }

}