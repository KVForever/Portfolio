﻿using DataEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KalPortfolio.Models
{
    public class CreateAccount
    {
        public string Username { get; set; }

        public string Password { get; set; }  

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public List<Role> Roles { get; set; } = new List<Role>();

        public List<int> SelectedRoles { get; set; } = new List<int>();

        public string FirstName { get; set; }

        public string LastName { get; set; }   
    }
}