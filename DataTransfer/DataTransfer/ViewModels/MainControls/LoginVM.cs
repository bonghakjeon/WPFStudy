using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransfer.ViewModels.MainControls
{
    public class LoginVM : Screen
    {
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyOfPropertyChange();
                }
            }
        }
        private string _id = "";

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    NotifyOfPropertyChange();
                }
            }
        }
        private string _password = "";

        public LoginVM()
        {

        }
    }
}
