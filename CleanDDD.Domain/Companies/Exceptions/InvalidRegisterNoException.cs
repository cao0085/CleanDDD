using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDDD.Domain.Companies.Exceptions
{
    public sealed class InvalidRegisterNoException : Exception
    {
        public InvalidRegisterNoException(string value)
            : base($"統一編號格式錯誤：'{value}' 必須為 8 位數字。")
        {
        }
    }
}
