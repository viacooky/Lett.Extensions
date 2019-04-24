using System;

namespace Lett.Extensions.Exceptions
{
    public class LettExtensionsDataTableException : Exception
    {
        public LettExtensionsDataTableException(string message) : base($"Lett.Extensions.DataTable Exception; {message}")
        {
        }
    }
}