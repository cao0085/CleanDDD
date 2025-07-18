using CleanDDD.Application.Companies.GetCompanyInfo;

namespace CleanDDD.Application.Companies
{
    public interface ICompanyReadRepository
    {
        public Task<List<CompanyInfoDTO>> GetCompanyInfoAsync(GetCompanyInfoCommand command);
    }
}
