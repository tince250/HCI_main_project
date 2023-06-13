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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCI_main_project.ViewModel
{
    public class RegisterViewModel : ViewModelBaseS, IDataErrorInfo
    {
        private readonly string[] FIELDS = { "Name", "LastName", "Email", "Password", "ConfirmPassword" };
        public Boolean _firstLoad = true;
        private readonly DelegateCommand _registerClickCommand;
        public ICommand RegisterClickCommand => _registerClickCommand;
        private readonly IAuthService service;

        public RegisterViewModel(IAuthService service) 
        {
            _firstLoad = true;
            this.service = service;
            _registerClickCommand = new DelegateCommand(OnRegisterClick);
        }

        private void OnRegisterClick(object commandParameter)
        {
            try
            {
                ErrorHappend = false;
                RegisterSuccess = false;
                User newUser = new User
                {
                    Email = Email,
                    FirstName = Name,
                    LastName = LastName,
                    Password = Password,
                    Role = UserRole.TRAVELER
                };

                if (validateAll())
                {
                    service.Register(newUser);
                    //ApplicationHelper.User = service.GetByEmail(Email);
                    ErrorMessage = "Account registered successfully. Please login.";
                    RegisterSuccess = true;
                }
                else
                {
                    ErrorMessage = "Check your inputs and try again.";
                    ErrorHappend = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "User with given email already exists.")
                    ErrorMessage = ex.Message;
                else
                    ErrorMessage = "Check your inputs and try again.";
                ErrorHappend = true;
            }
        }

        private bool _errorHappend;
        public bool ErrorHappend
        {
            get => _errorHappend;
            set
            {
                SetProperty(ref _errorHappend, value);
            }
        }

        private bool _registerSuccess;
        public bool RegisterSuccess
        {
            get => _registerSuccess;
            set
            {
                SetProperty(ref _registerSuccess, value);
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                SetProperty(ref _errorMessage, value);
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
                return validate(columnName);
            }
        }

        public bool isHappenedC;
        public bool IsHappenedP
        {
            get => isHappenedC;
            set
            {
                SetProperty(ref isHappenedC, value);
            }
        }

        public bool isHappenedCP;
        public bool IsHappenedCP
        {
            get => isHappenedCP;
            set
            {
                SetProperty(ref isHappenedCP, value);
            }
        }

        private string validate(string columnName)
        {
            string result = null;
            if (_firstLoad) { return result; }
            if (columnName == "Name")
            {
                if (string.IsNullOrEmpty(Name))
                    result = "Name field can not be empty!";
                if (!string.IsNullOrEmpty(Name) && !Regex.IsMatch(Name, "^[a-zA-Z ]+$"))
                    result = "Invalid characters. Only letters are allowed!";
            }
            if (columnName == "LastName")
            {
                if (string.IsNullOrEmpty(LastName))
                    result = "Last name field can not be empty!";
                if (!string.IsNullOrEmpty(LastName) && !Regex.IsMatch(LastName, "^[a-zA-Z ]+$"))
                    result = "Invalid characters. Only letters are allowed!";
            }
            if (columnName == "Email")
            {
                if (string.IsNullOrEmpty(Email))
                    result = "Email field can not be empty!";
                try
                {
                    MailAddress m;
                    if (!string.IsNullOrEmpty(Email))
                        m = new MailAddress(Email);
                }
                catch (Exception)
                {
                    result = "Invalid email format. Email should include '@'!";
                }
            }
            if (columnName == "Password")
            {
                if (string.IsNullOrEmpty(Password))
                {
                    result = "Password field can not be empty!";
                    IsHappenedP = true;
                }
                else if (!string.IsNullOrEmpty(Password) && Password.Length < 8)
                {
                    result = "Password field should have 8 or more characters!";
                    IsHappenedP = true;
                }
                else
                    IsHappenedP = false;
            }
            if (columnName == "ConfirmPassword")
            {
                if (string.IsNullOrEmpty(ConfirmPassword))
                {
                    result = "Please confirm a password";
                    IsHappenedCP = true;
                }
                else if (!string.IsNullOrEmpty(ConfirmPassword) && !string.Equals(ConfirmPassword, Password))
                {
                    result = "Passwords don't match!";
                    IsHappenedCP = true;
                }
                else
                    IsHappenedCP = false;
            }
            return result;
            
        }

        #endregion


        private bool validateAll()
        {
            foreach (String columnName in FIELDS)
            {
                if (validate(columnName) != null) return false;
            }
            return true;
        } 
    }
}
