using Employee.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Api.Repository
{
    public interface IEmployeeRepo
    {
        Task<IEnumerable<EmployeeDetails>> GetEmployees();

        Task<EmployeeDetails> GetEmployeeById(int employeeId);

        Task<EmployeeDetails> CreateEmployee(EmployeeDetails employee);

        Task<EmployeeDetails> UpdateEmployee(int employeeId, EmployeeDetails employee);

        Task<EmployeeDetails> DeleteEmployee(int EmployeeId);
    }
}
