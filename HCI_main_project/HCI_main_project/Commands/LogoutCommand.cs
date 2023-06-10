using HCI_main_project.View;
using HCI_main_project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Commands
{
    public class LogoutCommand : CommandBase
    {
        private HomepageViewModel homepageViewModel;

        public LogoutCommand(HomepageViewModel homepageViewModel)
        {
            this.homepageViewModel = homepageViewModel;
        }

        public override void Execute(object? parameter)
        {
            ApplicationHelper.User = null;
            LoginPage loginPage = new LoginPage();
            ApplicationHelper.NavigationService.Navigate(loginPage);
        }
    }
}
