using ConsoleApp.Contracts;
using CustomContainer.Attributes;

namespace ConsoleApp.CustomerBl
{
    [Export(typeof(ICustomerDAL))]
    public class CustomerDAL : ICustomerDAL
    {
        public string GetCustomerHash()
        {
            return $"{GetHashCode()}";
        }

    }
}