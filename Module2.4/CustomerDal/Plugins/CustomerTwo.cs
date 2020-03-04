using System.ComponentModel.Composition;
using CustomerContracts;

namespace CustomerDal.Plugins
{
    //[Export(typeof(ICustomerDAL))]
    public class CustomerTwo : ICustomerDAL
    {
        public string GetCustomerName()
        {
            return "CustomerTwo";
        }
    }
}