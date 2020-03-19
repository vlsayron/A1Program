using System;
using System.Data.SqlClient;

namespace NorthwindDAL
{
    internal static class SafeReadData
    {
        public static string SafeGetString(this SqlDataReader reader, int colIndex)
        {
            return !reader.IsDBNull(colIndex) ? reader.GetString(colIndex) : string.Empty;
        }
        public static int SafeGetInt(this SqlDataReader reader, int colIndex)
        {
            return !reader.IsDBNull(colIndex) ? reader.GetInt32(colIndex) : default;
        }
        public static DateTime? SafeGetDateTime(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetDateTime(colIndex);
            }

            return null;
        }
    }
}
