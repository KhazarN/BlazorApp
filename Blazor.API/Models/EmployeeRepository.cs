using BlazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Blazor.API.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;
        public EmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var result = await context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);
            if (result != null)
            {
                context.Employees.Remove(result);
                await context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            var result = await context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await context.Employees.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var getEmployee = await context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
            if (getEmployee != null)
            {
                getEmployee.FirstName = employee.FirstName;
                getEmployee.LastName = employee.LastName;
                getEmployee.Gender = employee.Gender;
                getEmployee.BirthDate = employee.BirthDate;
                getEmployee.DepartmentId = employee.DepartmentId;
                getEmployee.PhotoPath = employee.PhotoPath;
                await context.SaveChangesAsync();
                return getEmployee;
            }
            return null;
        }
    }
}
