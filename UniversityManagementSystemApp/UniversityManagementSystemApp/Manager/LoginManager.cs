using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystemApp.Gateway;
using UniversityManagementSystemApp.Models;

namespace UniversityManagementSystemApp.Manager
{
    public class LoginManager
    {
        private LoginGateway aLoginGateway;

        public LoginManager()
        {
            aLoginGateway = new LoginGateway();
        }

        public string AuthorizedUser(Login aLogin)
        {
            bool checkUser = aLoginGateway.IsUser(aLogin);

            if (checkUser == true)
            {
                return ("True");
            }

            else
            {
                return ("User Name Or Password Is Not Matched");
            }

        }

    }
}