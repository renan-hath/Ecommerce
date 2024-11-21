using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.Interfaces
{
    public interface IJobScheduler
    {
        void Schedule<T>(Expression<Func<T, Task>> methodCall, TimeSpan delay);
    }
}
