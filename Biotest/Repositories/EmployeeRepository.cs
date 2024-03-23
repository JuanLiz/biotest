using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee?> GetEmployee(int id);
        Task<Employee> PostEmployee(Employee employee);
        Task<Employee> PutEmployee(int id, Employee employee);
        Task<Employee> DeleteEmployee(int id);
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
            return await _db.Employee.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _db.Employee.ToListAsync();
        }

        public async Task<Employee> PostEmployee(Employee employee)
        {
            _db.Employee.Add(employee);
            await _db.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> PutEmployee(int id, Employee employee)
        {
            _db.Employee.Update(employee);
            await _db.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            
            // Change state to deleted
            throw new NotImplementedException();
        }

        
    }
    
}