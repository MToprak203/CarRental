using System.Collections.Generic;

namespace Core.Utilities.Results.Concrete
{
    public class SuccessfulDataResult<T> : DataResult<T>
    {
        public SuccessfulDataResult(T data, string message) : base(data, true, message)
        {
            
        }

        public SuccessfulDataResult(T data) : base(data, true)
        {

        }

        public SuccessfulDataResult() : base(default, true)
        {

        }
    }
}