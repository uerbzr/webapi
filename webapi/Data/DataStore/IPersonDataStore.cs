
using webapi.Models;

namespace webapi.Data.DataStore
{
    public interface IPersonDataStore
    {
        List<Person> People { get; set; }
    }
}