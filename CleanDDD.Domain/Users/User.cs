using CleanDDD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanDDD.Domain.Users
{
    public sealed class User : Entity
    {
        public string Name { get; private set; }
        public string PasswordHash { get; private set; }
        public int Type { get; private set; }
        public string Nickname { get; private set; }
        public string Email { get; private set; }

        // Token 資訊
        public string RefreshToken { get; private set; }
        public DateTime? RefreshTokenExpires { get; private set; }

        // 狀態與時間戳
        public byte State { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // --- 建構函式封裝，外部禁止直接 new ---
        private User(
            string name,
            string passwordHash,
            int type,
            string nickname,
            string email,
            byte state)
        {
            Name = name;
            PasswordHash = passwordHash;
            Type = type;
            Nickname = nickname;
            Email = email;
            State = state;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        // --- 靜態工廠方法 ---
        public static User Create(
            Guid id,
            string name,
            string passwordHash,
            int type,
            string nickname,
            string email,
            byte state = 1)
        {
            // 可以在這裡加入驗證邏輯
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required");
            if (string.IsNullOrWhiteSpace(passwordHash)) throw new ArgumentException("PasswordHash is required");

            return new User(name, passwordHash, type, nickname, email, state);
        }
    }
}
