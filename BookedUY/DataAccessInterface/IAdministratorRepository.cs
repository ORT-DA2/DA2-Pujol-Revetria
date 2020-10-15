using Domain;

namespace DataAccessInterface
{
    public interface IAdministratorRepository : IRepository<Administrator>
    {
        Administrator GetByEmail(string email);
    }
}