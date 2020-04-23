﻿using NorthwindLibrary;
using System.Collections.Generic;

namespace CachingSolutionsSamples
{
    public interface ISuppliersCache
    {
        IEnumerable<Supplier> Get(string forUser);
        void Set(string forUser, IEnumerable<Supplier> suppliers);
    }
}