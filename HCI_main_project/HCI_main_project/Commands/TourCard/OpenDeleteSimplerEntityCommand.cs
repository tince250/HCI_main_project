using HCI_main_project.Components;
using HCI_main_project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCI_main_project.Commands
{
    public class OpenDeleteSimplerDialogCommand : CommandBase
    {
        private int entityId;
        private string entityType;

        public OpenDeleteSimplerDialogCommand(int entityId, string entityType)
        {
            this.entityId = entityId;
            this.entityType = entityType;
        }

        public override void Execute(object? parameter)
        {
            ApplicationHelper.ToDeleteId = entityId;

            var dialogType = DialogType.DELETE_ATTRACTION;

            if (entityType == "accommodation")
                dialogType = DialogType.DELETE_ACCOMMODATION;
            else if (entityType == "restaurant")
                dialogType = DialogType.DELETE_RESTAURANT;


            var dialog = new HCI_main_project.Components.ConfirmDialog(dialogType, null);

            // Set the row and column span to cover the entire grid
            dialog.SetValue(Grid.RowSpanProperty, ApplicationHelper.HomePageVm.mainGrid.RowDefinitions.Count);
            dialog.SetValue(Grid.ColumnSpanProperty, ApplicationHelper.HomePageVm.mainGrid.ColumnDefinitions.Count);


            ApplicationHelper.HomePageVm.mainGrid.Children.Add(dialog);
        }
    }
}
