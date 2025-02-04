using ApplicationCore.Contracts.Services;
using ApplicationCore.Contracts.Repository;

namespace Infrastructure.Services {
    public class CastService : ICastService {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository) {
            _castRepository = castRepository;
        }
    }
}