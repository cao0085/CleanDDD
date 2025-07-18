using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDDD.Domain
{
    public interface IOutboxRepository
    {
        Task AddAsync(INotification @event);
    }
}
