using MediatR;

namespace CleanDDD.Application.Companies.GetCompanyInfo
{
    public sealed record GetCompanyInfoCommand(
        int?CompanyInfoId,
        string? Name,
        string? SerialNo,
        string? Address,
        int? RegisterNo
    ) : IRequest<List<CompanyInfoDTO>>;

}
