using ApplicationCore.Contracts.Services;
using ApplicationCore.Contracts.Repository;
using System.Threading.Tasks;

namespace Infrastructure.Services {
    public class UserService : IUserService {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
    }
}