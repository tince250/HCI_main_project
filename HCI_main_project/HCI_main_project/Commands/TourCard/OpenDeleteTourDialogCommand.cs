﻿using HCI_main_project.Components;
using HCI_main_project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_main_project.Commands
{
    public class OpenDeleteTourDialogCommand : CommandBase
    {
        private int tourId;

        public OpenDeleteTourDialogCommand(int tourId)
        {
            this.tourId = tourId;
        }

        public override void Execute(object? parameter)
        {
            ApplicationHelper.ToDeleteId = tourId;

            var dialog = new HCI_main_project.Components.ConfirmDialog(DialogType.DELETE_TOUR, null);

            // Set the row and column span to cover the entire grid
            dialog.SetValue(Grid.RowSpanProperty, ApplicationHelper.HomePageVm.mainGrid.RowDefinitions.Count);
            dialog.SetValue(Grid.ColumnSpanProperty, ApplicationHelper.HomePageVm.mainGrid.ColumnDefinitions.Count);


            ApplicationHelper.HomePageVm.mainGrid.Children.Add(dialog);
        }
    }
}
