﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.ViewModel
{
    public class RegisterViewModel : ViewModelBase, IDataErrorInfo
    {
        public Boolean _firstLoad = true;

        public RegisterViewModel() 
        {
            _firstLoad = true;
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
                }
                if (columnName == "Password")
                {
                    if (string.IsNullOrEmpty(Password))
                        result = "Please enter a password";
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
