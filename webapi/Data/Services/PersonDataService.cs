using webapi.Data;
using webapi.Data.DataStore;
using webapi.Models;

namespace webapi.Data.Services
{
    public class PersonDataService : IPersonDataService
    {
        IPersonDataStore _db;
        public PersonDataService(IPersonDataStore db)
        {
            _db = db;
        }

        public bool Add(Person person)
        {
            if (_db.People.Any(p => p.Id == person.Id)) return false;
            person.Id = _db.People.Count>0 ? _db.People.Max(a => a.Id) + 1 : 1;
            if (person != null)
            {
                _db.People.Add(person);
                return true;

            }
            return false;
        }
        public IEnumerable<Person> GetAll()
        {
            return _db.People;
        }
        public bool UpdateUser(Person person)
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
            if(_db.People.Any(x => x.Id==id)==false) return false;
            var itemToRemove = _db.People.Single(r => r.Id == id);
            return _db.People.Remove(itemToRemove);
        }

    }
}
