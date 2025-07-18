using CleanDDD.Domain;
using CleanDDD.Domain.Companies.ValueObjects;
using CleanDDD.Infrastructure.Persistence.BaseDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanDDD.Application.Companies.GetCompanyInfo;
using CleanDDD.Application.Companies;
using CleanDDD.Infrastructure.Persistence.BaseDb;
using CleanDDD.Domain.Companies;
using DomainCompany = CleanDDD.Domain.Companies.Company;

namespace CleanDDD.Infrastructure.Persistence.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        public readonly BaseDbContext _baseDbContext;
        public CompanyRepository(BaseDbContext baseDbContext)
        {
            _baseDbContext = baseDbContext;
        }

        public async Task CreateCompanyAsync(DomainCompany company)
        {
            var entity = new CompanyInfo
            {
                Name = company.Name,
                Type = company.Type,
                ShortName = company.ShortName,
                EnName = company.EnName,
                SerialNo = company.SerialNo,
                Address = company.Address,
                RegisterNo = company.RegisterNo.Value,                 // ValueObject unwrap
                Tel = company.Tel,
                TaxIDNo = company.TaxIDNo,
                State = company.State,        // string/int → byte
                CreatedAt = company.CreatedAt,
                UpdatedAt = company.UpdatedAt
            };

            await _baseDbContext.CompanyInfo.AddAsync(entity);
            await _baseDbContext.SaveChangesAsync();
        }
    }

    public class CompanyReadRepository : ICompanyReadRepository
    {
        public readonly BaseDbContext _baseDbContext;
        public CompanyReadRepository(BaseDbContext baseDbContext)
        {
            _baseDbContext = baseDbContext;
        }

        public async Task<List<CompanyInfoDTO>> GetCompanyInfoAsync(GetCompanyInfoCommand command)
        {
            var query = _baseDbContext.CompanyInfo.AsNoTracking().AsQueryable();

            if (command.CompanyInfoId != null)
                query = query.Where(c => c.CompanyInfoId == command.CompanyInfoId.Value);

            if (!string.IsNullOrWhiteSpace(command.Name))
                query = query.Where(c => EF.Functions.Like(c.Name, $"%{command.Name}%"));

            if (!string.IsNullOrWhiteSpace(command.SerialNo))
                query = query.Where(c => c.SerialNo == command.SerialNo);

            // 3. 投影成 DTO（只撈必要欄位）
            return await query.Select(c => new CompanyInfoDTO
            {
                Name = c.Name,
                ShortName = c.ShortName,
                EnName = c.EnName,
                SerialNo = c.SerialNo,
                Address = c.Address,
                RegisterNo = c.RegisterNo
            }).ToListAsync();
        }
    }
}
