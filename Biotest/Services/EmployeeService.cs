using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee?> GetEmployee(int id);
        Task<Employee> CreateEmployee(Employee employee);

        Task<Employee> PutEmployee(
                       int id,
                       string Name,
                       string LastName,
                       int GenderID,
                       int EmployeePositionID);

        Task<Employee?> DeleteEmployee(int id);
    }

    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        public async Task<Employee?> GetEmployee(int id)
        {
            return await employeeRepository.GetEmployee(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await employeeRepository.GetEmployees();
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            return await employeeRepository.CreateEmployee(employee);
        }

        public async Task<Employee> PutEmployee(
            int id,
            string Name,
            string LastName,
            int GenderID,
            int EmployeePositionID
        )
        {
            Employee? newEmployee = await employeeRepository.GetEmployee(id);
            if (newEmployee == null)
            {
                throw new Exception("Employee not found");
            }
            else
            {
                newEmployee.Name = Name;
                newEmployee.LastName = LastName;
                newEmployee.GenderID = GenderID;
                newEmployee.EmployeePositionID = EmployeePositionID;
                return await employeeRepository.PutEmployee(id, newEmployee);
            }
        }

        public async Task<Employee?> DeleteEmployee(int id)
        {
            return await employeeRepository.DeleteEmployee(id);
        }
    }
}
