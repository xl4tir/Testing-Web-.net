using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTesting.Domain.Enum
{
    public enum StatusCode
    {
        OK = 200,

        TestingNotFound = 10,

        
        InternalServerError = 500,
        UserNotFound = 0
    }
}
