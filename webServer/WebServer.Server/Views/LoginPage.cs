using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Server.Views
{
    public class LoginPage
    {
        public const string LoginForm = @"<form action='/Login' method='POST'>
   Username: <input type='text' name='Username'/>
   Password: <input type='text' name='Password'/>
   <input type='submit' value ='Log In' /> 
</form>";


    }
}
