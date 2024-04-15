using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee?> GetEmployee(int id);
        Task<Employee> CreateEmployee(Employee employee);
        Task<Employee> PutEmployee(int id, Employee employee);
        Task<Employee?> DeleteEmployee(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Employee?> GetEmployee(int id)
        {
            // Simplified function to get a patient by id
            return await _db.Employee.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            // Simplified function to get all patients
            return await _db.Employee.ToListAsync();
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            // Simplified function to add a patient
            _db.Employee.Add(employee);
            await _db.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> PutEmployee(int id, Employee employee)
        {
            // Simplified function to update a patient
            _db.Entry(employee).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return employee;
        }

        public Task<Employee?> DeleteEmployee(int id)
        {
            // Change boolean state
            throw new NotImplementedException();
        }

    }
    
}