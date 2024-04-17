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
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee?> DeleteEmployee(int id);
    }

    public class EmployeeRepository(ApplicationDbContext db) : IEmployeeRepository
    {
        public async Task<Employee?> GetEmployee(int id)
        {
            // Simplified function to get a patient by id
            return await db.Employee.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            // Simplified function to get all patients
            return await db.Employee.ToListAsync();
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            // Simplified function to add a patient
            db.Employee.Add(employee);
            await db.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            // Simplified function to update a patient
            db.Entry(employee).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee?> DeleteEmployee(int id)
        {
            Employee? employee = await db.Employee.FindAsync(id);
            if (employee == null) return employee;
            employee.IsActive = false;
            db.Entry(employee).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return employee;
        }

    }
    
}