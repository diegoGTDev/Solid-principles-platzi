namespace OpenClose
{
    public class EmployeeContractor : IEmployee
    {
        public string Fullname { get; set; }
        public int HoursWorked { get; set; }
        public EmployeeContractor(string fullname, int hoursWorked)
        {
            Fullname = fullname;
            HoursWorked = hoursWorked;
        }

        public decimal CalculateSalary()
        {
            decimal hourValue = 1000M;
            decimal salary = hourValue * HoursWorked;
            return salary;
        }
    }
}