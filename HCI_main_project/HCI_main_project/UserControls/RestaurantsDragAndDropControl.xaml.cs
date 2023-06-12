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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HCI_main_project.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;
using Microsoft.Extensions.DependencyInjection;

namespace HCI_main_project.UserControls
{
    /// <summary>
    /// Interaction logic for RestaurantsDragAndDropControl.xaml
    /// </summary>
    public partial class RestaurantsDragAndDropControl : UserControl
    {
        TripagoContext _dbContext;
        public RestaurantsDragAndDropControl()
        {
            InitializeComponent();
            startLeftRightPoint = new Point();
            startRightLeftPoint = new Point();
            _dbContext = App.serviceProvider.GetRequiredService<TripagoContext>();
            //setMockUp();
            Restaurants = new ObservableCollection<Restaurant>();
            Restaurants2 = new ObservableCollection<Restaurant>();
            InitializeComponent();
            Restaurants2.CollectionChanged += Restaurants2_CollectionChanged;
            DataContext = this;

        }

        public void loadFromDb()
        {
            List<Restaurant> restaurants = _dbContext.Restaurants.ToList();

            // Add the attractions to the ObservableCollection
            foreach (Restaurant restaurant in restaurants)
            {
                Restaurants.Add(restaurant);
            }
        }

        public void loadForEdit(List<Restaurant> tourRestaurants)
        {
            List<Restaurant> allRestaurants = _dbContext.Restaurants.ToList();
            foreach (Restaurant restaurant in allRestaurants)
            {
                // Check if the second list contains an item with the same ID
                Restaurant matchingRestaurant = tourRestaurants.FirstOrDefault(a => a.Id == restaurant.Id);

                // If a match is found, remove the item from the second list
                if (matchingRestaurant != null)
                    Restaurants2.Add(restaurant);
                else
                    Restaurants.Add(restaurant);
            }
        }

        private void Restaurants2_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Restaurants2));
        }

        public bool IsValid()
        {
            return Restaurants2.Count != 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void setMockUp()
        {
            ObservableCollection<Restaurant> o = new ObservableCollection<Restaurant>();
            o.Add(new Restaurant { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Sava's Monestry", Id = 1 });
            o.Add(new Restaurant { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Kalemegdan", Id = 2 });
            o.Add(new Restaurant { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Marakana", Id = 3 });
            o.Add(new Restaurant { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Sava's Monestry", Id = 11 });
            o.Add(new Restaurant { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Kalemegdan", Id = 21 });
            o.Add(new Restaurant { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Marakana", Id = 31 });

            Restaurants = o;


        }
        private ObservableCollection<Restaurant> _restaurants;
        public ObservableCollection<Restaurant> Restaurants
        {
            get { return _restaurants; }
            set
            {
                _restaurants = value;
            }
        }

        public ObservableCollection<Restaurant> Restaurants2 { get; set; }

        private Point startLeftRightPoint;
        private Point startRightLeftPoint;

        private void LeftRight_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startLeftRightPoint = e.GetPosition(null);
        }

        private void LeftRight_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startLeftRightPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                // Find the data behind the ListViewItem
                Restaurant restaurant = (Restaurant)listView.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", restaurant);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }

        private void LeftRight_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Restaurant restaurant = e.Data.GetData("myFormat") as Restaurant;
                Restaurants.Remove(restaurant);
                var itemToRemove = Restaurants2.FirstOrDefault(item => item.Id == restaurant.Id);
                if (itemToRemove != null)
                {
                    Restaurants2.Remove(itemToRemove);
                }
                Restaurants2.Add(restaurant);
            }
        }

        private void LeftRight_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }


        private void RightLeft_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startRightLeftPoint = e.GetPosition(null);
        }

        private void RightLeft_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startRightLeftPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                // Find the data behind the ListViewItem
                Restaurant student = (Restaurant)listView.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", student);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }

        private void RightLeft_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Restaurant student = e.Data.GetData("myFormat") as Restaurant;
                Restaurants2.Remove(student);
                var itemToRemove = Restaurants.FirstOrDefault(item => item.Id == student.Id);
                if (itemToRemove != null)
                {
                    Restaurants.Remove(itemToRemove);
                }
                Restaurants.Add(student);
            }
        }

        private void RightLeft_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

    }
}
