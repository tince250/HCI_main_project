using MaterialDesignThemes.Wpf;
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

namespace HCI_main_project
{
    public class NavbarItem : RadioButton
    {
        public static readonly DependencyProperty KindProperty =
           DependencyProperty.Register("Kind", typeof(PackIconKind), typeof(NavbarItem), new PropertyMetadata(PackIconKind.Null));
        
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(NavbarItem), new PropertyMetadata(""));


        static NavbarItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NavbarItem), new FrameworkPropertyMetadata(typeof(NavbarItem)));
        }

        public PackIconKind Kind
        {
            get { return (PackIconKind)GetValue(KindProperty); }
            set { SetValue(KindProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
   
    }
}
