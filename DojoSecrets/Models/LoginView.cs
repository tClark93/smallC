using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DojoSecrets.Models
{
    public class LoginView
    {
        public User regUser {get; set;}
        public Login logUser {get; set;}
    }
}