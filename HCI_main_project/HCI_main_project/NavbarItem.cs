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
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:HCI_main_project"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:HCI_main_project;assembly=HCI_main_project"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:NavbarItem/>
    ///
    /// </summary>
    public class NavbarItem : Button
    {
        public static readonly DependencyProperty KindProperty =
           DependencyProperty.Register("Kind", typeof(PackIconKind), typeof(NavbarItem), new PropertyMetadata(PackIconKind.Null));
        
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(NavbarItem), new PropertyMetadata(""));
        
        public static readonly DependencyProperty IsSelectedProperty =
           DependencyProperty.Register("IsSelected", typeof(Boolean), typeof(NavbarItem), new PropertyMetadata(false));


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
   
        public Boolean IsSelected
        {
            get { return (Boolean)GetValue(IsSelectedProperty); }
            set { 
                SetValue(IsSelectedProperty, value);
            }
        }
 
        protected override void OnClick()
        {
            base.OnClick();

            IsSelected = !IsSelected;
        }
    }
}
