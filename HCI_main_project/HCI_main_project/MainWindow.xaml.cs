using HCI_main_project.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TripagoContext dbContext;
        public MainWindow(TripagoContext tripagoContext)
        {
            this.dbContext = tripagoContext;
            this.dbContext.Database.EnsureCreated();

            InitializeComponent();

            Console.WriteLine("Adding some authors into database...");
            User user = new User
            {
                Email = "user@gmail.com",
                FirstName = "tina",
                LastName = "miha",
                Password = "123",
                Role = UserRole.TRAVELER
            };
            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();

            foreach (User user1 in this.dbContext.Users)
            {
                Trace.WriteLine(user1.FirstName);
            }
        }
    }
}
