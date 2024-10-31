using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountLibrary.Exceptions
{
    internal class IdNotExistInListException:Exception
    {
        public IdNotExistInListException(string message):base(message) { }
    }
}
