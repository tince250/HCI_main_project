using HCI_main_project.Model.Entities;
using HCI_main_project.Models;
using System;
using System.Collections.Generic;
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

namespace HCI_main_project.User_Controls
{
    public partial class SimplerCard : UserControl
    {


        public SimpleCardContent CardContent
        {
            get { return (SimpleCardContent)GetValue(CardContentProperty); }
            set {
                SetValue(CardContentProperty, value);
            }
        }

        public static readonly DependencyProperty CardContentProperty =
            DependencyProperty.Register("CardContentProperty", typeof(SimpleCardContent), typeof(SimplerCard), new PropertyMetadata(null));



        public SimplerCard()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
