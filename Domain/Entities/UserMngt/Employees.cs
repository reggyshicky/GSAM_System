using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace LoginTestAPI.Models.Domain
{
    public class Employees
    {
        //Simulation of an Active Directory, stores the company's employees /corebanking users
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool isActive { get; set; }
        public string Department { get; set; }
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }

        public IdentityRole RoleName { get; set; }

    }
}



