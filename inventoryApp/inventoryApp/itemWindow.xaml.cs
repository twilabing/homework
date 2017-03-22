using inventoryApp.Models;
using System;
using System.Windows;


namespace inventoryApp
{
    /// <summary>
    /// Interaction logic for inventoryWindow.xaml
    /// </summary>
    public partial class inventoryWindow : Window
    {
        public inventoryWindow()
        {
            InitializeComponent();
            ShowInTaskbar = false;
        }

        public inventoryModel Inventory { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Inventory != null)
            {
                uxSubmit.Content = "Update";
            }
            else
            {
                Inventory = new inventoryModel();
            }

            uxGrid.DataContext = Inventory;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Inventory = new inventoryModel();
            //Inventory.itemDescription = uxitemDescription.Text;
            //Inventory.pricePerItem = decimal.Parse(uxpricePerItem.Text);
            //Inventory.quantityOnHand = int.Parse(uxquantityOnHand.Text);
            //Inventory.ourCostPerItem = decimal.Parse(uxourCostPerItem.Text);

            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new inventoryWindow();

            if (window.ShowDialog() == true)
            {
                var uiinventoryModel = window.Inventory;

                var repositoryInventoryModel = uiinventoryModel.ToRepositoryModel();

                App.inventoryRepository.Add(repositoryInventoryModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());
            }
        }

    }
}
