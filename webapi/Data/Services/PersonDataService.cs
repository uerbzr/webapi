using webapi.Data;
using webapi.Data.DataStore;
using webapi.Interfaces;

namespace webapi.Data.Services
{
    public class PersonDataService : IPersonDataService
    {
        IPersonDataStore _db;
        public PersonDataService(IPersonDataStore db)
        {
            _db = db;
        }

        public bool Add(IPerson person)
        {
            if (person != null)
            {
                person.Id = _db.People.Count + 1;
                _db.People.Add(person);
                return true;

            }
            return false;
        }
        public IEnumerable<IPerson> GetAll()
        {
            return _db.People;
        }
        public bool UpdateUser(IPerson person)
        {
            var index = _db.People.FindIndex(x => x.Id == person.Id);
            var p = _db.People.ElementAt(index);
            if (p != null)
            {
                p.Email = person.Email;
                p.Name = person.Name;
                return true;
            }
            return false;
        }
        public bool DeleteUser(int id)
        {
            var itemToRemove = _db.People.Single(r => r.Id == id);
            return _db.People.Remove(itemToRemove);
        }

    }
}
