namespace Liskov
{
    public class EmployeeFullTime : Employee
    {
        public int extrahours;
        public EmployeeFullTime(string fullname, int hoursWorked, int extrahours) : base(fullname, hoursWorked)
        {
            this.extrahours = extrahours;
            this.Fullname = fullname;
            this.HoursWorked = hoursWorked;
        }
        
        public override decimal CalculateSalary(){
            decimal hourValue = 50;
            return hourValue * (HoursWorked+extrahours);
        }
    }
}