using System;
using System.Collections.Generic;

namespace DALContracts.Repositories
{
    public interface IRepository<out T> where T : class
    {
        IEnumerable<T> SelectAll();
        T SelectById<T2>(T2 id);
        IEnumerable<T> Find(Func<T, bool> predicate);

    }
}