using System.Linq.Expressions;

namespace Ecommerce.Application.Services.Interfaces
{
    public interface IJobScheduler
    {
        void Schedule<T>(Expression<Func<T, Task>> methodCall, TimeSpan delay);
    }
}
