namespace Biotest.Model
{
    public class Employee
    {
        public required int EmployeeID { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required int GenderID { get; set; }
        public required int EmployeePositionID { get; set; }
        public required Gender Gender { get; set; }
        public required EmployeePosition EmployeePosition { get; set; }

    }
}
