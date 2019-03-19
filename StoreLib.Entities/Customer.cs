using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StoreLib.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Address[] Addresses { get; set; }

        public CreditCard[] Cards { get; set; }

        public string EmailAddress { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}