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
using System.Collections.Specialized;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace HCI_main_project.UserControls
{
    /// <summary>
    /// Interaction logic for AttractionsDragAndDropControl.xaml
    /// </summary>
    public partial class AttractionsDragAndDropControl : UserControl 
    {

        TripagoContext _dbContext;

        public AttractionsDragAndDropControl()
        {
            startLeftRightPoint = new Point();
            startRightLeftPoint = new Point();
            //setMockUp();
            _dbContext = App.serviceProvider.GetRequiredService<TripagoContext>();
            InitializeComponent();
            Attractions = new ObservableCollection<Attraction>();
            Attractions2 = new ObservableCollection<Attraction>();
            Attractions2.CollectionChanged += Attractions2_CollectionChanged;
            DataContext = this;
        }

        public void loadFromDb()
        {
            List<Attraction> attractions = _dbContext.Attractions.ToList();

            // Add the attractions to the ObservableCollection
            foreach (Attraction attraction in attractions)
            {
                Attractions.Add(attraction);
            }
        }

        public void loadForEdit(List<Attraction> tourAttractions)
        {
            List<Attraction> allAttractions = _dbContext.Attractions.ToList();
            foreach (Attraction attraction in allAttractions)
            {
                // Check if the second list contains an item with the same ID
                Attraction matchingAttraction = tourAttractions.FirstOrDefault(a => a.Id == attraction.Id);

                // If a match is found, remove the item from the second list
                if (matchingAttraction != null)
                    Attractions2.Add(attraction);
                else
                    Attractions.Add(attraction);
            }
        }

        private void Attractions2_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Attractions2));  
        }

        public bool IsValid()
        {
            return Attractions2.Count != 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void setMockUp()
        {
            ObservableCollection<Attraction> o = new ObservableCollection<Attraction>();
            o.Add(new Attraction { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Sava's Monestry", Id=1 });
            o.Add(new Attraction { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Kalemegdan", Id=2 });
            o.Add(new Attraction { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Marakana", Id=3 });
            o.Add(new Attraction { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Sava's Monestry", Id = 11 });
            o.Add(new Attraction { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Kalemegdan", Id = 21 });
            o.Add(new Attraction { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Marakana", Id = 31 });

            Attractions = o;
        }
        private ObservableCollection<Attraction> _attractions;
        public ObservableCollection<Attraction> Attractions
        {
            get { return _attractions; }
            set
            {
                _attractions = value;
            }
        }

        public ObservableCollection<Attraction> Attractions2 { get; set; }

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
                Attraction attraction = (Attraction)listView.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", attraction);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }

        private void LeftRight_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Attraction attraction = e.Data.GetData("myFormat") as Attraction;
                Attractions.Remove(attraction);
                var itemToRemove = Attractions2.FirstOrDefault(item => item.Id == attraction.Id);
                if (itemToRemove != null)
                {
                    Attractions2.Remove(itemToRemove);
                }
                Attractions2.Add(attraction);
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
                Attraction student = (Attraction)listView.ItemContainerGenerator.
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
                Attraction student = e.Data.GetData("myFormat") as Attraction;
                Attractions2.Remove(student);
                var itemToRemove = Attractions.FirstOrDefault(item => item.Id == student.Id);
                if (itemToRemove != null)
                {
                    Attractions.Remove(itemToRemove);
                }
                Attractions.Add(student);
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
