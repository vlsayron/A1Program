using System.ComponentModel.Composition;
using CustomerContracts;

namespace CustomerDal.Plugins
{
    //[Export(typeof(ICustomerDAL))]
    public class CustomerOne : ICustomerDAL
    {
        public string GetCustomerName()
        {
            return "CustomerOne";
        }
    }
}