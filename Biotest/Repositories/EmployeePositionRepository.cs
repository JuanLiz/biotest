using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IEmployeePositionRepository
    {
        Task<IEnumerable<EmployeePosition>> GetEmployeePositions();
        Task<EmployeePosition?> GetEmployeePosition(int id);
        Task<EmployeePosition> UpdateEmployeePosition(EmployeePosition employeePosition);
        Task<EmployeePosition> CreateEmployeePosition(EmployeePosition employeePosition);
        Task<EmployeePosition?> DeleteEmployeePosition(int id);
    }

    public class EmployeePositionRepository(ApplicationDbContext db) : IEmployeePositionRepository
    {
        public async Task<EmployeePosition?> GetEmployeePosition(int id)
        {
            return await db.EmployeePosition.FindAsync(id);
        }

        public async Task<IEnumerable<EmployeePosition>> GetEmployeePositions()
        {
            return await db.EmployeePosition.ToListAsync();
        }

        public async Task<EmployeePosition> CreateEmployeePosition(EmployeePosition employeePosition)
        {
            db.EmployeePosition.Add(employeePosition);
            await db.SaveChangesAsync();
            return employeePosition;
        }

        public async Task<EmployeePosition> UpdateEmployeePosition(EmployeePosition employeePosition)
        {
            db.Entry(employeePosition).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return employeePosition;
        }

        public async Task<EmployeePosition?> DeleteEmployeePosition(int id)
        {
            EmployeePosition? employeePosition = await db.EmployeePosition.FindAsync(id);
            if (employeePosition == null) return employeePosition;
            employeePosition.IsActive = false;
            db.Entry(employeePosition).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return employeePosition;
        }

    }

}