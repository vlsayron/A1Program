using System.Collections.Generic;
using System.IO;
using Module5Linq2db.Models;

namespace FileHandler.FileBuilder
{
    internal interface IFileBuilder
    {
        MemoryStream BuildFile(IEnumerable<Order> orders);
    }
}
