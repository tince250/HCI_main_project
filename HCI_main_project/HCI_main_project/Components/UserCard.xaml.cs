using HCI_main_project.Model.Entities;
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
    /// Interaction logic for UserCard.xaml
    /// </summary>
    public partial class UserCard : UserControl
    {

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("ContentProperty", typeof(UserCardContent), typeof(UserCard),
                new PropertyMetadata(null));

        public UserCardContent UserContent
        {
            get { return (UserCardContent)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        public UserCard()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
