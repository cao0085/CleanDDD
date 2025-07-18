using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanDDD.Domain.PasswordHash;

namespace CleanDDD.TestDoubles.PasswordHash
{
    /// <summary>
    /// 超級陽春的假雜湊器：Hash = "[FAKE]" + 反轉字串
    /// </summary>
    public class FakePasswordHasher : IPasswordHasher
    {
        public string Hash(string plainText)
        {
            var reversed = new string(plainText.Reverse().ToArray());
            return $"[FAKE]{reversed}";
        }

        public bool Verify(string plainText, string hash) =>
            hash == Hash(plainText);
    }
}

