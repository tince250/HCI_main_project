using HCI_main_project.Models;
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

namespace HCI_main_project.Components
{
    /// <summary>
    /// Interaction logic for DetailsCard.xaml
    /// </summary>
    public partial class DetailsCard : UserControl
    {
        public static readonly DependencyProperty AttractionProperty =
            DependencyProperty.Register("Attraction", typeof(Attraction), typeof(DetailsCard),
                new PropertyMetadata(new Attraction()));

        public string Attraction
        {
            get { return (string)GetValue(AttractionProperty); }
            set { SetValue(AttractionProperty, value); }
        }


        public DetailsCard()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
