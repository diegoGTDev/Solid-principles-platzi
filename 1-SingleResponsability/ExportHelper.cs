using System.Collections;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using Microsoft.VisualBasic;

namespace SingleResponsability
{

    public class ExportHelper<T>
    {
        private PropertyInfo[] properties = typeof(T).GetProperties();
        public static void ExportStudents(IEnumerable<Student> students)
        {
            string csv = String.Join(",", students.Select(x => x.ToString()).ToArray());
            Console.WriteLine(csv);
            StringBuilder string_builder = new();
            string_builder.AppendLine("Id,FullName,Grades");
            foreach (var student in students)
            {
                string_builder.AppendLine($"{student.Id};{student.Fullname};{String.Join("|", student.Grades)}");
            }
            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "students.csv"), string_builder.ToString());
        }


        public void ExportToCSV(IEnumerable<T> items)
        {
            var sb = new StringBuilder();
            var header = GetHeader();
            sb.AppendLine(header);

            foreach (var item in items)
            {
                var dataRow = GetDataRow(item);
                sb.AppendLine(dataRow);
            }

            var filePath = GetFilePath();
            File.WriteAllText(filePath, sb.ToString(), Encoding.Unicode);

        }

        private string GetHeader()
        {
            var properties = typeof(T).GetProperties();
            var header = string.Join(";", this.properties.Select(prop => prop.Name));
            return header;
        }

        private string GetDataRow(T item)
        {
            var dataRow = string.Join(",", this.properties.Select(prop => GetPropertyValue(prop, item)));
            return dataRow;
        }

        private string GetPropertyValue(PropertyInfo prop, T item)
        {
            var propValue = prop.GetValue(item);
            var propType = prop.PropertyType;
            Console.WriteLine($"PropType: {propType}, PropValue: {propValue}");
            if (propType != typeof(string) && typeof(IEnumerable).IsAssignableFrom(propType))
            {
                Console.WriteLine("Estoy aca");
                var enumerable = (IEnumerable?)propValue;
                var values = enumerable?.Cast<object>().Select(x => x.ToString());
                string result = string.Join("|", values);
                return result;
            }



            return propValue.ToString();
        }

        private string GetFilePath()
        {
            var typeName = typeof(T).Name;
            var fileName = $"Export_{typeName}.csv";
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            return filePath;
        }


    }
}
