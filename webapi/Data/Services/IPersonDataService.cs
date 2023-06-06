
using webapi.Models;

namespace webapi.Data.Services
{
    public interface IPersonDataService
    {
        bool Add(Person person);
        IEnumerable<Person> GetAll();
        bool UpdateUser(Person person);
        bool DeleteUser(int id);
    }
}
