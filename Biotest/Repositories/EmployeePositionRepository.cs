using Biotest.Model;

namespace Biotest.Repositories
{
    public interface IEmployeePositionRepository
    {
        IEnumerable<EmployeePosition> GetEmployeePositions();
        EmployeePosition GetEmployeePosition(int id);
        EmployeePosition PutEmployeePosition(int id, EmployeePosition employeePosition);
        EmployeePosition PostEmployeePosition(EmployeePosition employeePosition);
        EmployeePosition DeleteEmployeePosition(int id);
    }

    public class EmployeePositionRepository : IEmployeePositionRepository
    {
        public EmployeePosition DeleteEmployeePosition(int id)
        {
            throw new NotImplementedException();
        }

        public EmployeePosition GetEmployeePosition(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeePosition> GetEmployeePositions()
        {
            throw new NotImplementedException();
        }

        public EmployeePosition PostEmployeePosition(EmployeePosition employeePosition)
        {
            throw new NotImplementedException();
        }

        public EmployeePosition PutEmployeePosition(int id, EmployeePosition employeePosition)
        {
            throw new NotImplementedException();
        }
        
    }
    
}