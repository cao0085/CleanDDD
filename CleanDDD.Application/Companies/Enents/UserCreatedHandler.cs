using CleanDDD.Domain.Users.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CleanDDD.Domain.Companies;
using CleanDDD.Application.Companies.CreateCompany;
using CleanDDD.Domain.Companies.ValueObjects;

using CleanDDD.Domain.Users.Events;

namespace CleanDDD.Application.Companies.Enents
{
    public sealed class UserCreatedEnevtHandler(ICompanyRepository companyRepository) : INotificationHandler<UserCreatedEvent>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;

        public async Task Handle(UserCreatedEvent evt, CancellationToken ct)
        {
            await _companyRepository.AddCompanyHeadcountAsync(evt.SerialNo);
        }
    }

}
