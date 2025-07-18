using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CleanDDD.Domain.Companies.Exceptions;

namespace CleanDDD.Domain.Companies.ValueObjects
{
    public sealed class RegisterNo : ValueObject
    {
        public string Value { get; }

        private RegisterNo(string value)
        {
            if (!Regex.IsMatch(value, @"^\d{8}$"))
                throw new InvalidRegisterNoException(value);

            Value = value;
        }

        public static RegisterNo Create(string value)
        { 
            return new RegisterNo(value);
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
