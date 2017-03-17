using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;

namespace hw3
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {

        public SecondWindow()
        {
            InitializeComponent();
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            AddHandler(GridViewColumnHeader.ClickEvent, new RoutedEventHandler(GridViewColumnHeader_Click));

        }

        private void Sort(string sortBy)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            dataView.SortDescriptions.Clear();

            if (sortBy == "System.Windows.Controls.GridViewColumnHeader: Password")
            {
                //MessageBox.Show("Password");
                dataView.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));
            }
            if (sortBy == "System.Windows.Controls.GridViewColumnHeader: Name")
            {
                //MessageBox.Show("Name");
                dataView.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
            }
        }


        private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader columnClicked = e.OriginalSource as GridViewColumnHeader;
            //string test = columnClicked.Column.Header as string;
            //MessageBox.Show(test);
            Sort(columnClicked.ToString());
        }

    }
}
