using System;

namespace Lett.Extensions.Exceptions
{
    public class DataTableException : Exception
    {
        public DataTableException(string message) : base($"Lett.Extensions.DataTable Exception; {message}")
        {
        }
    }
}