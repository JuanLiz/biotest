using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee?> GetEmployee(int id);

        Task<Employee> CreateEmployee(
            string Name,
            string LastName,
            int GenderID,
            int EmployeePositionID
        );

        Task<Employee> UpdateEmployee(
            int EmployeeID,
            string? Name,
            string? LastName,
            int? GenderID,
            int? EmployeePositionID
        );

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

        public async Task<Employee> CreateEmployee(
            string Name,
            string LastName,
            int GenderID,
            int EmployeePositionID
        )
        {
            return await employeeRepository.CreateEmployee(new Employee
            {
                Name = Name,
                LastName = LastName,
                GenderID = GenderID,
                EmployeePositionID = EmployeePositionID
            });
        }

        public async Task<Employee> UpdateEmployee(
            int EmployeeID,
            string? Name,
            string? LastName,
            int? GenderID,
            int? EmployeePositionID
        )
        {
            Employee? employee = await employeeRepository.GetEmployee(EmployeeID);
            if (employee == null) throw new Exception("Employee not found");
            employee.Name = Name ?? employee.Name;
            employee.LastName = LastName ?? employee.LastName;
            employee.GenderID = GenderID ?? employee.GenderID;
            employee.EmployeePositionID = EmployeePositionID ?? employee.EmployeePositionID;
            return await employeeRepository.UpdateEmployee(employee);
        }

        public async Task<Employee?> DeleteEmployee(int id)
        {
            return await employeeRepository.DeleteEmployee(id);
        }

    }
}
