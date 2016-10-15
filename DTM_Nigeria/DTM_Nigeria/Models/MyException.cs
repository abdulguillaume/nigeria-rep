using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTM_Nigeria.Models
{
    public class MyException: Exception
    {
        public MyException()
        { }

        public MyException(string message) : base(message)
        { 
        }
    }
}