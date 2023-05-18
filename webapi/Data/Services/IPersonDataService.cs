using webapi.Interfaces;

namespace webapi.Data.Services
{
    public interface IPersonDataService
    {
        bool Add(IPerson person);
        IEnumerable<IPerson> GetAll();
        bool UpdateUser(IPerson person);
        bool DeleteUser(int id);
    }
}
