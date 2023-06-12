using HCI_main_project.Components;
using HCI_main_project.Help;
using HCI_main_project.ViewModel;
using Microsoft.Extensions.DependencyInjection;
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

namespace HCI_main_project.View
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly LoginViewModel viewModel;

        public LoginPage()
        {
            InitializeComponent();
            viewModel = App.serviceProvider.GetRequiredService<LoginViewModel>();
            DataContext = viewModel;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            BindingExpression bindingExpr = textBox.GetBindingExpression(TextBox.TextProperty);

            // Manually trigger the validation
            bindingExpr.UpdateSource();
        }


        private void PasswordBox_Changed(object sender, RoutedEventArgs e)
        {
            BindablePasswordBox passwordBox = (BindablePasswordBox)sender;
            BindingExpression bindingExpr = passwordBox.GetBindingExpression(BindablePasswordBox.PasswordProperty);
            bindingExpr.UpdateSource();

        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (viewModel.LoginClickCommand.CanExecute(null))
                    viewModel.LoginClickCommand.Execute(null);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HelpProvider.SetHelpKey((DependencyObject)this, "LoginHelp");
            string str = HelpProvider.GetHelpKey((DependencyObject)this);
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            HelpProvider.ShowHelp(str, mainWindow);
        }
    }
}
