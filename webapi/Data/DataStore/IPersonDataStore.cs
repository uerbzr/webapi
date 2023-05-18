using webapi.Interfaces;
using webapi.Models;

namespace webapi.Data.DataStore
{
    public interface IPersonDataStore
    {
        List<IPerson> People { get; set; }
    }
}