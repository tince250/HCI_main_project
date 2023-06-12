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
    /// Interaction logic for AccommodationsDragAndDrop.xaml
    /// </summary>
    public partial class AccommodationsDragAndDropControl : UserControl
    {
        TripagoContext _dbContext;
        public AccommodationsDragAndDropControl()
        {
            InitializeComponent();
            startLeftRightPoint = new Point();
            startRightLeftPoint = new Point();
            _dbContext = App.serviceProvider.GetRequiredService<TripagoContext>();
            //setMockUp();
            Accommodations = new ObservableCollection<Accommodation>();
            Accommodations2 = new ObservableCollection<Accommodation>();
            InitializeComponent();
            Accommodations2.CollectionChanged += Accommodations2_CollectionChanged;
            DataContext = this;

        }

        public void loadFromDb()
        {
            List<Accommodation> accommodations = _dbContext.Accommodations.ToList();

            // Add the attractions to the ObservableCollection
            foreach (Accommodation accommodation in accommodations)
            {
                Accommodations.Add(accommodation);
            }
        }

        public void loadForEdit(List<Accommodation> tourAccommodations)
        {
            List<Accommodation> allAccommodations = _dbContext.Accommodations.ToList();
            foreach (Accommodation accommodation in allAccommodations)
            {
                // Check if the second list contains an item with the same ID
                Accommodation matchingAccommodation = tourAccommodations.FirstOrDefault(a => a.Id == accommodation.Id);

                // If a match is found, remove the item from the second list
                if (matchingAccommodation != null)
                    Accommodations2.Add(accommodation);
                else
                    Accommodations.Add(accommodation);
            }
        }

        private void Accommodations2_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Accommodations2));
        }

        public bool IsValid()
        {
            return Accommodations2.Count != 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void setMockUp()
        {
            ObservableCollection<Accommodation> o = new ObservableCollection<Accommodation>();
            o.Add(new Accommodation { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Sava's Monestry", Id = 1 });
            o.Add(new Accommodation { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Kalemegdan", Id = 2 });
            o.Add(new Accommodation { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Marakana", Id = 3 });
            o.Add(new Accommodation { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Sava's Monestry", Id = 11 });
            o.Add(new Accommodation { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Kalemegdan", Id = 21 });
            o.Add(new Accommodation { Address = new Address { City = "Belgrade", Street = "Ljutice Bogdana", StreetNumber = 24 }, Name = "Marakana", Id = 31 });

            Accommodations = o;


        }
        private ObservableCollection<Accommodation> _accommodations;
        public ObservableCollection<Accommodation> Accommodations
        {
            get { return _accommodations; }
            set
            {
                _accommodations = value;
            }
        }

        public ObservableCollection<Accommodation> Accommodations2 { get; set; }

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
                Accommodation accommodation = (Accommodation)listView.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", accommodation);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }
        }

        private void LeftRight_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Accommodation accommodation = e.Data.GetData("myFormat") as Accommodation;
                Accommodations.Remove(accommodation);
                var itemToRemove = Accommodations2.FirstOrDefault(item => item.Id == accommodation.Id);
                if (itemToRemove != null)
                {
                    Accommodations2.Remove(itemToRemove);
                }
                Accommodations2.Add(accommodation);
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
                Accommodation student = (Accommodation)listView.ItemContainerGenerator.
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
                Accommodation student = e.Data.GetData("myFormat") as Accommodation;
                Accommodations2.Remove(student);
                var itemToRemove = Accommodations.FirstOrDefault(item => item.Id == student.Id);
                if (itemToRemove != null)
                {
                    Accommodations.Remove(itemToRemove);
                }
                Accommodations.Add(student);
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
