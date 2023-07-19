using Liskov;

CalculateSalaryMonthly(new List<Employee>() {
    new EmployeeFullTime("Pepito Pérez", 160, 10),
    new EmployeeContractor("Manuel Lopera", 180)
});

void CalculateSalaryMonthly(List<Employee> employees) 
{
    foreach (var item in employees)
    {
        Console.WriteLine($"El salario de {item.Fullname} es: {item.CalculateSalary():C2}");   
    }
}