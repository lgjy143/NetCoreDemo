using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOC.Application
{
    public class Demo2Service : IDemo2Service
    {
        public string Test()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
