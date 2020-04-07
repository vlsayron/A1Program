using ConsoleApp.Contracts;
using CustomContainer.Attributes;

namespace ConsoleApp.CustomerBl
{
    [ImportConstructor]
    public class CustomerBLLOne
    {
        private readonly ICustomerDAL _dal;
        private readonly ILogger _logger;
        public CustomerBLLOne(ICustomerDAL dal, ILogger logger)
        {
            _dal = dal;
            _logger = logger;
        }
        
        public string GetLogMessage()
        {
            return _logger.Log(
                $"BLL Name:'{nameof(CustomerBLLOne)}', BLL hash: '{GetHashCode()}', Dal hash: '{_dal.GetCustomerHash()}'");
        }


    }
}