using Biotest.Model;

namespace Biotest.Repositories
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployee();
        Employee GetEmployee(int id);
        Employee PutEmployee(int id, Employee employee);
        Employee PostEmployee(Employee employee);
        Employee DeleteEmployee(int id);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployee()
        {
            throw new NotImplementedException();
        }

        public Employee PostEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee PutEmployee(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
        
    }
    
}