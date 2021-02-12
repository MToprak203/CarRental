using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessfullResult : Result
    {
        public SuccessfullResult(string message) : base(true, message)
        {

        }

        public SuccessfullResult() : base(true)
        {

        }
    }
}
