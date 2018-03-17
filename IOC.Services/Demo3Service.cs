using System;
using System.Collections.Generic;
using System.Text;

namespace IOC.Services
{
    public class Demo3Service : IDemo3Service
    {
        public string Test()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
