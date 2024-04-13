using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IEmployeePositionRepository
    {
        Task<IEnumerable<EmployeePosition>> GetEmployeePositions();
        Task<EmployeePosition?> GetEmployeePosition(int id);
        Task<EmployeePosition> PutEmployeePosition(int id, EmployeePosition employeePosition);
        Task<EmployeePosition> PostEmployeePosition(EmployeePosition employeePosition);
        Task<EmployeePosition?> DeleteEmployeePosition(int id);
    }

    public class EmployeePositionRepository : IEmployeePositionRepository
    {

        private readonly ApplicationDbContext _db;

        public EmployeePositionRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<EmployeePosition?> GetEmployeePosition(int id)
        {
            // Simplified function to get a patient by id
            return await _db.EmployeePosition.FindAsync(id);
        }

        public async Task<IEnumerable<EmployeePosition>> GetEmployeePositions()
        {
            // Simplified function to get all patients
            return await _db.EmployeePosition.ToListAsync();
        }

        public async Task<EmployeePosition> PostEmployeePosition(EmployeePosition employeePosition)
        {
            // Simplified function to add a patient
            _db.EmployeePosition.Add(employeePosition);
            await _db.SaveChangesAsync();
            return employeePosition;
        }

        public async Task<EmployeePosition> PutEmployeePosition(int id, EmployeePosition employeePosition)
        {
            // Simplified function to update a patient
            _db.Entry(employeePosition).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return employeePosition;
        }

        public Task<EmployeePosition?> DeleteEmployeePosition(int id)
        {
            // Change boolean state
            throw new NotImplementedException();
        }

    }
    
}