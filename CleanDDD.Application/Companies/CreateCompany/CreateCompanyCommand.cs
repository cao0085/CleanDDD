using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanDDD.Domain.Companies;

namespace CleanDDD.Application.Companies.CreateCompany
{
    public record CreateCompanyCommand(
        string Name,
        int Type,
        string ShortName,
        string EnName,
        string SerialNo,
        string Address,
        string RegisterNo, // string, 傳進來再轉成 ValueObject
        string Tel,
        string TaxIDNo,
        byte State
    ) : IRequest<Company>;

}
