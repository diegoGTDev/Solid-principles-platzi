using System.Security.Cryptography.X509Certificates;
using SingleResponsability;

StudentRepository studentRepository = new();
ExportHelper<Student> exportHelper = new();
// ExportHelper<Student>.ExportStudents(studentRepository.GetAll());
exportHelper.ExportToCSV(studentRepository.GetAll());
Console.WriteLine("Proceso Completado");