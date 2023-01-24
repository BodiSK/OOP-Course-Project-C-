using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectLibrary
{
    class InvalidValueExeption: Exception
    {
        public InvalidValueExeption(string message): 
            base(message)
        {

        }
    }
}
