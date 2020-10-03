using System;

namespace BlazorApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }  
        public string PhotoPath { get; set; }
    }
}
