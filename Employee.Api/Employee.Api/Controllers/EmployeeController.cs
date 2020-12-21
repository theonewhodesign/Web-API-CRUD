using Employee.Api.Repository;
using Employee.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _repository;

        /// <summary>
        /// IEmployeeRepo context dependency injection
        /// </summary>
        /// <param name="context"></param>
        public EmployeeController(IEmployeeRepo repository)
        {
            _repository = repository;
        }


        #region HttpGet
        /// <summary>
        /// Get Employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDetails>>> GetEmployees()
        {
            try
            {
                return Ok(await _repository.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Error retrieving all employees data from the database");
            }
        }


        /// <summary>
        /// Get Employee By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetails>> GetEmployeeById(int id)
        {
            var employeeResult = await _repository.GetEmployeeById(id);
            if (employeeResult != null)
            {
                return Ok(employeeResult);
            }
            return StatusCode(StatusCodes.Status404NotFound, $"Requested id - {id} is not found");
        }
        #endregion


        #region HttpPost
        /// <summary>
        /// Create Employee
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<EmployeeDetails>> CreateEmployee(EmployeeDetails employee)
        {
            try
            {
                await _repository.CreateEmployee(employee);

                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmployeeId }, employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Error retrieving all employees data from the database");
            }
 
        }
        #endregion


        #region HttpPut
        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDetails>> UpdateEmployee(int id, EmployeeDetails employee)
        {
            var validEmployeeId = _repository.GetEmployeeById(id);
            if (validEmployeeId.Result == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    var employeeResult = await _repository.UpdateEmployee(id, employee);
                    return Ok(employeeResult);
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error while creating employee in database");
                }
            }


        }
        #endregion


        #region HttpDelete
        /// <summary>
        /// Delete Employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDetails>> DeleteEmployee(int id)
        {
            try
            {
                await _repository.DeleteEmployee(id);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Requested id - {id} is not found");
            }
        }
        #endregion
    }
}
