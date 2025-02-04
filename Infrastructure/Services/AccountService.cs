using ApplicationCore.Contracts.Services;
using ApplicationCore.Contracts.Repository;

namespace Infrastructure.Services {
    public class AccountService : IAccountService {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
    }
}