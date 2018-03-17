using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOC.Application
{
    public class LogService
    {
        public void Error(string message)
        {
            Console.WriteLine(message);
        }
    }
}
