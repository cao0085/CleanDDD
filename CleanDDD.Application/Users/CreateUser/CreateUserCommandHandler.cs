using CleanDDD.Domain.Companies;
using CleanDDD.Domain.PasswordHash;
using CleanDDD.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CleanDDD.Application.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {

        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // 將明文密碼轉為 PasswordHash（封裝雜湊）
            var passwordHash = PasswordHash.FromPlain(request.Password, _passwordHasher);

            // 建立 Domain 層的 User（你可用 new User(...) 或用靜態工廠 User.Create(...)）
            var user = User.Create(
                id: Guid.NewGuid(),
                name: request.Name,
                passwordHash: passwordHash.Value, // ✅ 取出字串儲存
                type: request.Type,
                nickname: request.Nickname,
                email: request.Email ?? string.Empty, // 避免 null
                state: request.State
            );

            await _userRepository.CreateUserAsync(user);
            return true;
        }
    }
}
