using CleanDDD.Domain.Companies;
using CleanDDD.Domain.PasswordHash;
using CleanDDD.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanDDD.Domain.Users.Events;


namespace CleanDDD.Application.Users.CreateUser
{
    public class CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IMediator mediator) : IRequestHandler<CreateUserCommand, bool>
    {

        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly IMediator _mediator = mediator;
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

            var targetCompanySerialNo = "CHT-20250715";
            await _mediator.Publish(new UserCreatedEvent(targetCompanySerialNo), cancellationToken);

            return true;
        }
    }
}
