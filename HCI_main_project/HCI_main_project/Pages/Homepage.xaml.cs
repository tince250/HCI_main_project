using HCI_main_project.Components;
using HCI_main_project.Models;
using HCI_main_project.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace HCI_main_project.Pages
{

    public partial class Homepage : Page
    {
        public Homepage()
        {
            InitializeComponent();
            DataContext = new HomepageViewModel(mainGrid, priceFromBox, priceToBox, dateFrom, dateTo);
            Loaded += (sender, e) =>
            {
                Focus();
            };
        }

        private void searchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CardsList.Items.Filter = SearchObjects;
        }

        private bool SearchObjects(object obj)
        {
            if (obj is Tour tour)
            {
                return tour.Name.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase);
            }

            if (obj is Attraction attraction)
            {
                return attraction.Name.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase);
            }

            if (obj is Accommodation accommodation)
            {
                return accommodation.Name.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase);
            }

            if (obj is Restaurant restaurant)
            {
                return restaurant.Name.Contains(searchBox.Text, StringComparison.OrdinalIgnoreCase);
            }

            return false;

        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.S)
            {
                searchBox.Focus();
            } 
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.F)
            {
                if (this.DataContext is HomepageViewModel vm)
                {
                    vm.ExpandFilters = !vm.ExpandFilters;
                }
            }
        }

        private void openDeleteDialog(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Add(new ConfirmDialog(DialogType.DELETE_TOUR));
        }
    }
}
