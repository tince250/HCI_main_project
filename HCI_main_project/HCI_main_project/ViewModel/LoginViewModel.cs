using HCI_main_project.Commands;
using HCI_main_project.Model.Services;
using HCI_main_project.Models;
using HCI_main_project.Pages;
using HCI_main_project.View;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace HCI_main_project.ViewModel
{
    public class LoginViewModel : ViewModelBaseS, IDataErrorInfo
    {
        public Boolean _firstLoad = true;

        private bool _errorHappend;
        public bool ErrorHappend
        {
            get => _errorHappend;
            set
            {
                SetProperty(ref _errorHappend, value);
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
        public string Password { 
            get => _password; 
            set
            {
                _firstLoad = false;
                SetProperty(ref _password, value);
            } 
        }
        private readonly DelegateCommand _loginClickCommand;
        public ICommand LoginClickCommand => _loginClickCommand;

        private readonly IAuthService service;
        public LoginViewModel(IAuthService service)
        {
            this.service = service;
            _firstLoad = true;
            _loginClickCommand = new DelegateCommand(OnLoginClick);
        }

        private void OnLoginClick(object commandParameter)
        {
            try
            {
                ErrorHappend = false;
                if (validate("Email") == null && validate("Password") == null)
                {
                    ApplicationHelper.User = this.service.Login(Email, Password);
                    Homepage homePage = new Homepage();
                    ApplicationHelper.NavigationService.Navigate(homePage);
                }
                else
                {
                    ErrorMessage = "Check your inputs and try again.";
                    ErrorHappend = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Bad credentials.Please try again.")
                    ErrorMessage = ex.Message;
                else
                    ErrorMessage = "Check your inputs and try again.";
                ErrorHappend = true;
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

        private string validate(string columnName)
        {
            string result = null;
            if (_firstLoad) { return result; }
            if (columnName == "Email")
            {
                if (string.IsNullOrEmpty(Email))
                    result = "Please enter a email";

                try
                {
                    MailAddress m;
                    if (!string.IsNullOrEmpty(Email))
                        m = new MailAddress(Email);
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
                if (!string.IsNullOrEmpty(Password) && Password.Length < 8)
                    result = "8 characters or longer";
            }
            return result;
        }

        #endregion
    }
}
