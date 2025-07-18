using MediatR;
using CleanDDD.Domain.Companies;
using CleanDDD.Domain.Companies.ValueObjects;
using CleanDDD.Application.Companies;

namespace CleanDDD.Application.Companies.GetCompanyInfo
{
    internal  class GetCompanyInfoCommandHandler : IRequestHandler<GetCompanyInfoCommand, List<CompanyInfoDTO>>
    {

        private readonly ICompanyReadRepository _companyRepository;
        public GetCompanyInfoCommandHandler(ICompanyReadRepository companyReadRepository)
        {
            _companyRepository = companyReadRepository;
        }

        public async Task<List<CompanyInfoDTO>> Handle(GetCompanyInfoCommand command, CancellationToken can)
        {
            List<CompanyInfoDTO> companiesEntity = await _companyRepository.GetCompanyInfoAsync(command);
            return companiesEntity;
        }
    }
}
