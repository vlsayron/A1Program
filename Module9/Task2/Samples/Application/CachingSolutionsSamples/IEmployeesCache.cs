using System.Collections.Generic;
using NorthwindLibrary;

namespace CachingSolutionsSamples
{
    public interface IEmployeesCache
    {
        IEnumerable<Employee> Get(string forUser);
        void Set(string forUser, IEnumerable<Employee> employees);
    }
}