using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HCI_main_project.Commands
{
    public static class DropBehavior
    {
        public static readonly DependencyProperty DropCommandProperty =
            DependencyProperty.RegisterAttached(
                "DropCommand",
                typeof(ICommand),
                typeof(DropBehavior),
                new PropertyMetadata(null, DropCommandChanged));

        public static void SetDropCommand(DependencyObject element, ICommand value)
        {
            element.SetValue(DropCommandProperty, value);
        }

        public static ICommand GetDropCommand(DependencyObject element)
        {
            return (ICommand)element.GetValue(DropCommandProperty);
        }

        private static void DropCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var rectangle = d as Rectangle;
            if (rectangle == null)
                return;

            if (e.NewValue is ICommand command)
            {
                rectangle.Drop += (sender, args) =>
                {
                    if (command.CanExecute(args))
                        command.Execute(args);
                };
            }
            else if (e.OldValue is ICommand oldCommand)
            {
                rectangle.Drop -= (sender, args) =>
                {
                    if (oldCommand.CanExecute(args))
                        oldCommand.Execute(args);
                };
            }
        }
    }

}
