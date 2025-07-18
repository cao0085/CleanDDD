using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CleanDDD.Domain.Users.Events
{
    public sealed record UserCreatedEvent(string SerialNo) : INotification;
}
