using HCI_main_project.Pages;
using HCI_main_project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Commands
{
    internal class FocusSearchCommand : CommandBase
    {
        private HomepageViewModel viewModel;

        public FocusSearchCommand(HomepageViewModel homepageViewModel)
        {
            this.viewModel = homepageViewModel;
        }

        public override void Execute(object? parameter)
        {
            viewModel.IsSearchInFocus = true;
        }
    }
}
