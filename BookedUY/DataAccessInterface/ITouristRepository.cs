using Domain;

namespace DataAccessInterface
{
    public interface ITouristRepository : IRepository<Tourist>
    {
        Tourist GetByEmail(string email);
    }
}