using HCI_main_project.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace HCI_main_project.ViewModel
{
    public class LoginViewModel : ViewModelBase, IDataErrorInfo
    {
        public Boolean _firstLoad = true;

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _firstLoad = false;
                SetProperty(ref _username, value);
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
        private readonly DelegateCommand _changeUsernameCommand;
        public ICommand ChangeUsernameCommand => _changeUsernameCommand;

        public LoginViewModel()
        {
            _firstLoad = true;
            _changeUsernameCommand = new DelegateCommand(OnLoginClick);
        }

        private void OnLoginClick(object commandParameter)
        {
            Username = "Walter";
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
                if (columnName == "Username")
                {
                    if (string.IsNullOrEmpty(Username))
                        result = "Please enter a username";
                }
                if (columnName == "Password")
                {
                    if (string.IsNullOrEmpty(Password))
                        result = "Please enter a password";
                }
                return result;
            }
        }

        #endregion
    }
}
