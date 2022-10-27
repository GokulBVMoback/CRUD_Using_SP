using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Using_SP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CRUDSP cRUDSP = new CRUDSP();
            
            Console.WriteLine("Employee Management Application");
            Console.WriteLine("Select Operation:");
            Console.WriteLine("1 Add Employee Details");
            Console.WriteLine("2 Display All Employee");
            Console.WriteLine("3 Display Employee you want to see");
            Console.WriteLine("4 Edit Employees");
            Console.WriteLine("5 Delete Employee Detail");
            Console.WriteLine("Press 'x' key to exit");
            var operation = Console.ReadLine();
            while (true)
            {
                switch (operation)
                {
                    case "1":
                        cRUDSP.Create();
                        break;
                    case "2":
                        cRUDSP.DisplayAll(); 
                        break;
                    case "3":
                        cRUDSP.Display();
                        break;
                    case "4":
                        cRUDSP.Update();
                        break;
                    case "5":
                        cRUDSP.Delete();
                        break;
                    case "x":
                        return;
                    default:
                        Console.WriteLine("Select valid Operation");
                        break;
                }
                Console.Write("\nSelect Operation:");
                operation = Console.ReadLine();
            }
        }
    }
}
