using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactLibrary.Exceptions
{
    internal class NoContactsException:Exception
    {
        public NoContactsException(string message):base(message) { }
    }
}
