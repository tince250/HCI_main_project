using HCI_main_project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HCI_main_project.Commands
{
    public class ToggleFilterPaneCommand : CommandBase
    {
        private HomepageViewModel homepageViewModel;

        public ToggleFilterPaneCommand(HomepageViewModel homepageViewModel)
        {
            this.homepageViewModel = homepageViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (parameter is FrameworkElement element)
            {
                element.Visibility = (element.Visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;
            }
        }
    }
}
