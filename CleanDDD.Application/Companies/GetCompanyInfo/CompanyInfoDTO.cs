using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDDD.Application.Companies.GetCompanyInfo
{
    public class CompanyInfoDTO
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string EnName { get; set; }
        public string SerialNo { get; set; }
        public string Address { get; set; }
        public string RegisterNo { get; set; }
    }
}
