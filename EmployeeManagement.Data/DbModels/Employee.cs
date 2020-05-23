using Microsoft.AspNetCore.Identity;
using System;

namespace EmployeeManagement.Data.DbModels
{
    public class Employee : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TaxId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }
    }
}
