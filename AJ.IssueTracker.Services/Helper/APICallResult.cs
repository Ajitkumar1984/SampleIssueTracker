using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJ.IssueTracker.Services
{
    public class APICallResult<T>
    {
       
        public bool Succeeded;
        public string ErrorMessage { get; set; }
        public T Value { get; set; }
      
    }
}
