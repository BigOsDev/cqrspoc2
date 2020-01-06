using System;
using System.Collections.Generic;
using System.Text;

namespace CQRS
{
    public interface IResponse
    {
        Guid Id { get; }
    }
}
