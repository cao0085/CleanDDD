using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDDD.Domain.Companies
{
    public interface ICompanyRepository
    {
        Task CreateCompanyAsync(Company company);

        Task AddCompanyHeadcountAsync(string serialNo);
    }
}
