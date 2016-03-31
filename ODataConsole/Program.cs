using ODataConsole.StudentService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODataConsole
{
    class Program
    {
        // Get an entire entity set.
        static void ListAllStudents(Default.Container proxy)
        {
            foreach (var s in proxy.Students)
            {
                Console.WriteLine("{0}, {1}, {2}", s.FirstName, s.LastName, s.Major);
            }
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", 50)));
        }

        static void AddStudent(Default.Container proxy, Student student)
        {
            proxy.AddToStudents(student);
            var serviceResponse = proxy.SaveChanges();
            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}\n", operationResponse.StatusCode);
            }
        }

        static void Main(string[] args)
        {

            // TODO: Replace with your local URI.
            string serviceUri = "http://localhost:40476/odata/";
            var proxy = new Default.Container(new Uri(serviceUri));

            ListAllStudents(proxy);

            int count = proxy.Students.Count();

            var student = new Student()
            {
                FirstName = "First " + (count + 1),
                LastName = "Last " + (count + 1),
                Major = "Major " + (count + 1)
            };

            AddStudent(proxy, student);

            ListAllStudents(proxy);

            Console.ReadKey();
        }
    }

}
