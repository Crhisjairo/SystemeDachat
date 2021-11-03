using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemeDachat.Models
{
    public class NullProductException : Exception
    {
        public NullProductException() { }

        public NullProductException(string message)
            : base(message) { }

        public NullProductException(string message, Exception inner)
            : base(message, inner) { }
    }
}
