using Zidy.Domain.Dto;

namespace Zidy.Domain.Interfaces
{
    public interface IServiceCustomer
    {
        public Task<List<User>> GetUsers();
        public Task<List<User>> GetUsersBySector();
        public Task<User> GetUserById(long id);
        public Task<bool> CheckSectorDiagonal();
    }
}
