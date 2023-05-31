using HCI_main_project.Commands;
using HCI_main_project.Model.Services;
using HCI_main_project.View;
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
    public class LoginViewModel : ViewModelBase, IDataErrorInfo
    {
        public Boolean _firstLoad = true;

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
                ApplicationHelper.User = this.service.Login(Email, Password);
            }
            catch (Exception ex)
            {
                // do something
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
                return result;
            }
        }

        #endregion
    }
}
