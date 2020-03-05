//using CustomerContracts;

//namespace CustomerBl
//{
//    public class CustomerBLL: ICustomerBLL
//    {
//        private readonly ICustomerDAL _dal;
//        private readonly Logger _logger;
//        public CustomerBLL(ICustomerDAL dal, Logger logger)
//        {
//            _dal = dal;
//            _logger = logger;
//        }
        
//        public string GetLogMessage()
//        {
//            var customerName = _dal.GetCustomerName();
//            return _logger.Log($"Customer name: {customerName}");
//        }


//    }
//}