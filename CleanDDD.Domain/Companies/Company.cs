using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanDDD.Domain;
using CleanDDD.Domain.Companies.ValueObjects;

namespace CleanDDD.Domain.Companies
{
    public sealed class Company : Entity
    {
        public Guid CompanyInfoId { get; private set; }
        public string Name { get; private set; }
        public int Type { get; private set; }
        public string ShortName { get; private set; }
        public string EnName { get; private set; }
        public string SerialNo { get; private set; }
        public string Address { get; private set; }
        public RegisterNo RegisterNo { get; private set; }
        public string Tel { get; private set; }
        public string TaxIDNo { get; private set; }
        public byte State { get; private set; }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Company(
            Guid id,
            string name,
            int type,
            string shortName,
            string enName,
            string serialNo,
            string address,
            RegisterNo registerNo,
            string tel,
            string taxIdNo,
            byte state
        )
        {
            CompanyInfoId = id;
            Name = name;
            Type = type;
            ShortName = shortName;
            EnName = enName;
            SerialNo = serialNo;
            Address = address;
            RegisterNo = registerNo;
            Tel = tel;
            TaxIDNo = taxIdNo;
            State = state;

            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Company Create(
            string name,
            int type,
            string shortName,
            string enName,
            string serialNo,
            string address,
            RegisterNo registerNo,
            string tel,
            string taxIdNo,
            byte state)
        {
            return new Company(
                Guid.NewGuid(),
                name,
                type,
                shortName,
                enName,
                serialNo,
                address,
                registerNo,
                tel,
                taxIdNo,
                state
            );
        }

        public void Update(
            string name,
            string shortName,
            string enName,
            string address,
            string tel,
            string taxIdNo,
            byte state)
        {
            Name = name;
            ShortName = shortName;
            EnName = enName;
            Address = address;
            Tel = tel;
            TaxIDNo = taxIdNo;
            State = state;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

//SELECT TOP(1000) [CompanyInfoId]
//      ,[Name]
//      ,[Type]
//      ,[ShortName]
//      ,[EnName]
//      ,[SerialNo]
//      ,[Address]
//      ,[RegisterNo]
//      ,[Tel]
//      ,[TaxIDNo]
//      ,[State]
//      ,[UpdatedAt]
//      ,[CreatedAt]
//FROM[NPCSTesting].[dbo].[CompanyInfo]
