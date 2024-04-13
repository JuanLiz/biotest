using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface IEmployeePositionService
    {
        Task<IEnumerable<EmployeePosition>> GetEmployeePositions();
        Task<EmployeePosition?> GetEmployeePosition(int id);
        Task<EmployeePosition> PostEmployeePosition(EmployeePosition employeePosition);

        Task<EmployeePosition> PutEmployeePosition(
                       int id,
                       string name);

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

        public async Task<EmployeePosition> PostEmployeePosition(EmployeePosition employeePosition)
        {
            return await employeePositionRepository.PostEmployeePosition(employeePosition);
        }

        public async Task<EmployeePosition> PutEmployeePosition(
            int id,
            string name
        )
        {
            EmployeePosition? newEmployeePosition = await employeePositionRepository.GetEmployeePosition(id);
            if (newEmployeePosition == null)
            {
                throw new Exception("EmployeePosition not found");
            }
            else
            {
                newEmployeePosition.Name = name;
                return await employeePositionRepository.PutEmployeePosition(id, newEmployeePosition);
            }
        }

        public async Task<EmployeePosition?> DeleteEmployeePosition(int id)
        {
            return await employeePositionRepository.DeleteEmployeePosition(id);
        }
    }
}
