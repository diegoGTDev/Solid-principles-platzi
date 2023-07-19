
namespace OpenClose{
    public abstract class Employee{
        public string? Fullname{ get; set; }
        public int HoursWorked { get; set; }

        //Create a function that calculates the salary of an employee
        public abstract decimal CalculateSalary();
    }

}

