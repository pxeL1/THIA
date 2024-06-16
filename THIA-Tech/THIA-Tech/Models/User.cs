using Microsoft.AspNetCore.Identity;
using System.Numerics;

namespace THIA_Tech.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Roles Role { get; set; }
        public enum Roles
        {
            Admin,
            Employee,
            Customer
        }
    }
}
