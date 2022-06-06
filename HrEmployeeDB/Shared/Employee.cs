namespace HrEmployeeDB.Shared
{
    public class Employee
    {
        public int EmployeeID{ get; set; }
        // if running through entity framework these would be decorated with the restrictions eg min and max age
        public DateTime DateOfBirth { get; set; }

        public Department Department { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
    }
}