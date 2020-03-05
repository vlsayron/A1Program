using ConsoleApp.Contracts;
using CustomContainer.Attributes;

namespace ConsoleApp.CustomerBl
{
    public class CustomerBLLTwo
    {
        [Import]
        public ICustomerDAL Dal { get; set; }
        [Import]
        public ILogger Logger { get; set; }
        public CustomerBLLTwo(ICustomerDAL dal, ILogger logger)
        {
            Dal = dal;
            Logger = logger;
        }

        public string GetLogMessage()
        {
            return Logger.Log(
                $"BLL Name:'{nameof(CustomerBLLTwo)}', BLL hash: '{GetHashCode()}', Dal hash: '{Dal.GetCustomerHash()}'");
        }
    }
}
