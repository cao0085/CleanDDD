using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using CleanDDD.Domain.Companies;
using CleanDDD.Domain.Companies.ValueObjects;

namespace CleanDDD.Application.Companies.CreateCompany;
    internal class CreateCompanyCommandHandler(ICompanyRepository companyRepository) : IRequestHandler<CreateCompanyCommand, Company>
    {
        private readonly ICompanyRepository _companyRepository = companyRepository;

        public async Task<Company> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            RegisterNo registerNo = RegisterNo.Create(request.RegisterNo);

            var company = Company.Create(
                name: request.Name,
                type: request.Type,
                shortName: request.ShortName,
                enName: request.EnName,
                serialNo: request.SerialNo,
                address: request.Address,
                registerNo: registerNo,
                tel: request.Tel,
                taxIdNo: request.TaxIDNo,
                state: request.State
            );

            await _companyRepository.CreateCompanyAsync(company);
            return company;
        }
    }
