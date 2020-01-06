using CQRS.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Definitions
{
    public class ObjectResult<T> : Result
    {
        public T Result { get; set; }

        public ObjectResult(T result, bool isSuccess = true, string message = null) : base(isSuccess, message)
        {
            this.Result = result;
        }

        public ObjectResult(bool isSuccess, string message) : base(isSuccess, message)
        {
        }

        public static ObjectResult<T> Success(T result)
        {
            return new ObjectResult<T>(result, true);
        }

        public static ObjectResult<T> Success(string errorMessage)
        {
            return new ObjectResult<T>(false, errorMessage);
        }

    }
}
