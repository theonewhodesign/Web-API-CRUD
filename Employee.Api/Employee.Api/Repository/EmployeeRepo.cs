using Employee.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Api.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeContext _employeeContext;

        /// <summary>
        /// Employee Context Dependency injection
        /// </summary>
        /// <param name="employeeContext"></param>
        public EmployeeRepo(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        /// <summary>
        /// Get Employees
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<EmployeeDetails>> GetEmployees()
        {
            return await _employeeContext.EmployeeDetails.ToListAsync();
        }

        /// <summary>
        /// Get Employee by Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<EmployeeDetails> GetEmployeeById(int employeeId)
        {
            return await _employeeContext.EmployeeDetails.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
        }

        /// <summary>
        /// Add Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<EmployeeDetails> CreateEmployee(EmployeeDetails employee)
        {
            var employeeResult = await _employeeContext.EmployeeDetails.AddAsync(employee);
            await _employeeContext.SaveChangesAsync();
            return employeeResult.Entity;
        }

        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public async Task<EmployeeDetails> DeleteEmployee(int EmployeeId)
        {
            var employeeDetail = await _employeeContext.EmployeeDetails.FirstOrDefaultAsync(x => x.EmployeeId == EmployeeId);
            _employeeContext.EmployeeDetails.Remove(employeeDetail);
            await _employeeContext.SaveChangesAsync();
            return employeeDetail;
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="employeeDetails"></param>
        /// <returns></returns>
        public async Task<EmployeeDetails> UpdateEmployee(int employeeId, EmployeeDetails employee)
        {
            var employeeResult = await _employeeContext.EmployeeDetails.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            if (employeeResult != null)
            {
                employeeResult.Firstname = employee.Firstname;
                employeeResult.Lastname = employee.Lastname;
                employeeResult.City = employee.City;
                await _employeeContext.SaveChangesAsync();
            }
            return employeeResult;
        }
    }
}
