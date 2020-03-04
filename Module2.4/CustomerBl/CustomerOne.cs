using CustomerContracts;

namespace CustomerBl
{
    public class CustomerOne : ICustomerDAL
    {
        public string GetCustomerName()
        {
            return "CustomerOne";
        }
    }
}