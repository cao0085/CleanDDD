using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDDD.Domain.PasswordHash
{
    public interface IPasswordHasher
    {
        string Hash(string plainText);
        bool Verify(string plainText, string hash);
    }

    public class PasswordHash : ValueObject
    {
        public string Value { get; }

        private PasswordHash(string value) => Value = value;

        public static PasswordHash FromPlain(string plain, IPasswordHasher hasher)
            => new PasswordHash(hasher.Hash(plain));

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
