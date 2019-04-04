using System;
using Ums.Core.Models;
using Ums.Manager;

namespace UMS.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student()
            {
                Name = "Mr B",
                Reg = "002",
                Roll = "2"
            };

            var studentManager = new StudentManager();

            var message = studentManager.Save(student);
            Console.WriteLine(message);
            Console.WriteLine();

            var students = studentManager.GetAll();
            foreach (var s in students)
            {
                Console.WriteLine(s.Name);
            }
        }
    }
}
