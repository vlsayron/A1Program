using System;
using System.Reflection;
using ConsoleApp.Contracts;
using ConsoleApp.CustomerBl;
using CustomContainer;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var container = new IoCContainer();

            //Registration in different ways
            container.AddType<CustomerBLLOne>();
            container.AddType(typeof(CustomerBLLTwo));
            container.AddType<ILogger, Logger>();
            container.AddType(typeof(ICustomerDAL), typeof(CustomerDAL));

            //Getting in different ways
            var customer11 = (CustomerBLLOne)container.CreateInstance(typeof(CustomerBLLOne));
            var customer12 = container.CreateInstance<CustomerBLLOne>();
            var customer13 = (CustomerBLLTwo)container.CreateInstance(typeof(CustomerBLLTwo));
            var customer14 = container.CreateInstance<CustomerBLLTwo>();

            Console.WriteLine("First container:");
            Console.WriteLine(customer11.GetLogMessage());
            Console.WriteLine(customer12.GetLogMessage());
            Console.WriteLine(customer13.GetLogMessage());
            Console.WriteLine(customer14.GetLogMessage());

            Console.WriteLine("\nSecond container:");

            //Second container
            var secondContainer = new IoCContainer();
            secondContainer.AddAssembly(Assembly.GetExecutingAssembly());

            var customer21 = (CustomerBLLOne)secondContainer.CreateInstance(typeof(CustomerBLLOne));
            var customer22 = secondContainer.CreateInstance<CustomerBLLOne>();
            var customer23 = (CustomerBLLOne)secondContainer.CreateInstance(typeof(CustomerBLLOne));
            var customer24 = secondContainer.CreateInstance<CustomerBLLOne>();

            Console.WriteLine(customer21.GetLogMessage());
            Console.WriteLine(customer22.GetLogMessage());
            Console.WriteLine(customer23.GetLogMessage());
            Console.WriteLine(customer24.GetLogMessage());

            Console.Write("\nPress any key to exit");
            Console.ReadKey();

        }


    }

}