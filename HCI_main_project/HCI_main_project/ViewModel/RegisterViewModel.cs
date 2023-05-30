using HCI_main_project.Commands;
using HCI_main_project.Model.Services;
using HCI_main_project.Models;
using HCI_main_project.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCI_main_project.ViewModel
{
    public class RegisterViewModel : ViewModelBase, IDataErrorInfo
    {
        public Boolean _firstLoad = true;
        private readonly DelegateCommand _registerClickCommand;
        public ICommand RegisterClickCommand => _registerClickCommand;
        private readonly IAuthService service;
        //private readonly LoginPage loginPage;

        public RegisterViewModel(IAuthService service) 
        {
            _firstLoad = true;
            //this.loginPage = loginPage;
            this.service = service;
            _registerClickCommand = new DelegateCommand(OnRegisterClick);
        }

        private void OnRegisterClick(object commandParameter)
        {
            try
            {
                User newUser = new User
                {
                    Email = Email,
                    FirstName = Name,
                    LastName = LastName,
                    Password = Password,
                    Role = UserRole.TRAVELER
                };
                service.Register(newUser);
                ApplicationHelper.User = service.GetByEmail(Email);
                //ApplicationHelper.NavigationService.Navigate(loginPage);

            }
            catch (Exception ex)
            {
                // do something
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _firstLoad = false;
                SetProperty(ref _name, value);
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                _firstLoad = false;
                SetProperty(ref _lastName, value);
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                _firstLoad = false;
                SetProperty(ref _email, value);
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _firstLoad = false;
                SetProperty(ref _password, value);
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set
            {
                _firstLoad = false;
                SetProperty(ref _confirmPassword, value);
            }
        }



        #region IDataErrorInfo Members
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (_firstLoad) { return result; }
                if (columnName == "Name")
                {
                    if (string.IsNullOrEmpty(Name))
                        result = "Please enter a name";
                    if (Name.Any(char.IsDigit))
                        result = "Invalid name format";
                }
                if (columnName == "LastName")
                {
                    if (string.IsNullOrEmpty(LastName))
                        result = "Please enter a last name";
                    if (LastName.Any(char.IsDigit))
                        result = "Invalid last name format";
                }
                if (columnName == "Email")
                {
                    if (string.IsNullOrEmpty(Email))
                        result = "Please enter a email";
                    try
                    {
                        MailAddress m = new MailAddress(Email);
                    }
                    catch (Exception)
                    {
                        result = "Invalid email format";
                    }
                }
                if (columnName == "Password")
                {
                    if (string.IsNullOrEmpty(Password))
                        result = "Please enter a password";
                    if (Password.Length < 8)
                        result = "8 characters or longer";
                }
                if (columnName == "ConfirmPassword")
                {
                    if (string.IsNullOrEmpty(ConfirmPassword))
                        result = "Please confirm a password";
                    if (!string.Equals(ConfirmPassword, Password))
                        result = "Passwords don't match";
                }
                return result;
            }
        }

        #endregion

    }
}
