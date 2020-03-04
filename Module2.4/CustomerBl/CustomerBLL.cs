using CustomerContracts;

namespace CustomerBl
{
    public class CustomerBLL: ICustomerBLL
    {
        private readonly ICustomerDAL _dal;
        private readonly ILogger _logger;
        public CustomerBLL(ICustomerDAL dal, ILogger logger)
        {
            _dal = dal;
            _logger = logger;
        }
        
        public string GetLogMessage()
        {
            var customerName = _dal.GetCustomerName();
            return _logger.Log($"Customer name: {customerName}");
        }

    }
}