using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS.Interfaces
{
    public class Result : IResponse
    {
        public Result(bool isSuccess, string message = null)
        {
            this.Id = Guid.NewGuid();
            this.IsSuccess = isSuccess;
            this.Message = message;
        }

        public Guid Id { get; private set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static Result Success()
        {
            return new Result(true);
        }

        public static Result Failed()
        {
            return new Result(false);
        }
        public static Result Failed(string message)
        {
            return new Result(false, message);
        }
    }
}
