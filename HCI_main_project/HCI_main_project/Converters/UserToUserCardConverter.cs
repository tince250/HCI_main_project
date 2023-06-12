using HCI_main_project.Components;
using HCI_main_project.Model.Entities;
using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HCI_main_project.Converters
{
    internal class UserToUserCardConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value is UserCardContent content)
            {
                if (content != null)
                {
                    var userCard = new UserCard();
                    userCard.UserContent = content;

                    return userCard;
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
