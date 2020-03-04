using System;
using CustomerBl;
using CustomerContracts;
using IoCContainer;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var container = new CustomContainer();

            container.AddType<ILogger, Logger>();
            container.AddType(typeof(ICustomerDAL), typeof(CustomerOne));
            container.AddType(typeof(ICustomerBLL), typeof(CustomerBLL));

            var customerBLL1 = (CustomerBLL)container.CreateInstance(typeof(CustomerBLL));
            var customerBLL2 = container.CreateInstance<CustomerBLL>();
            var customerBLL3 = container.CreateInstance<ICustomerBLL>();
            
            Console.WriteLine(customerBLL1.GetLogMessage());
            Console.WriteLine(customerBLL2.GetLogMessage());
            Console.WriteLine(customerBLL3.GetLogMessage());
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

        }
    }
}