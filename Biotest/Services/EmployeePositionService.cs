using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface IEmployeePositionService
    {
        Task<IEnumerable<EmployeePosition>> GetEmployeePositions();
        Task<EmployeePosition?> GetEmployeePosition(int id);
        Task<EmployeePosition> CreateEmployeePosition(string Name);
        Task<EmployeePosition> UpdateEmployeePosition(int EmployeePositionID, string? Name);
        Task<EmployeePosition?> DeleteEmployeePosition(int id);

    }

    public class EmployeePositionService(IEmployeePositionRepository employeePositionRepository)
        : IEmployeePositionService
    {
        public async Task<EmployeePosition?> GetEmployeePosition(int id)
        {
            return await employeePositionRepository.GetEmployeePosition(id);
        }

        public async Task<IEnumerable<EmployeePosition>> GetEmployeePositions()
        {
            return await employeePositionRepository.GetEmployeePositions();
        }

        public async Task<EmployeePosition> CreateEmployeePosition(string Name)
        {
            return await employeePositionRepository.CreateEmployeePosition(new EmployeePosition { Name = Name });
        }

        public async Task<EmployeePosition> UpdateEmployeePosition(int EmployeePositionID, string? Name)
        {
            EmployeePosition? employeePosition = await employeePositionRepository.GetEmployeePosition(EmployeePositionID);
            if (employeePosition == null) throw new Exception("EmployeePosition not found");
            employeePosition.Name = Name ?? employeePosition.Name;
            return await employeePositionRepository.UpdateEmployeePosition(employeePosition);
        }

        public async Task<EmployeePosition?> DeleteEmployeePosition(int id)
        {
            return await employeePositionRepository.DeleteEmployeePosition(id);
        }
    }
}
