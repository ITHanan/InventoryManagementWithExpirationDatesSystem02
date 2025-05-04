using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty ;
        public string EmailAddress { get; set; } = string.Empty;
        public string Role { get; set; } = "User";
        public string Surname { get; set; } = string.Empty;// MR. Miss.
        public string GivenName { get; set; } = string.Empty;

    }
}
