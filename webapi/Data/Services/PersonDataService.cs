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
            if (_db.People.Any(p => p.Id == person.Id)) return false;
            person.Id = _db.People.Max(a => a.Id) + 1;
            if (person != null)
            {

                //person.Id = _db.People.MaxBy(x => x.Id).Id  _db.People.MaxBy(x => x.Id).Id ? 1;
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
            if(_db.People.Any(x => x.Id==id)==false) return false;
            var itemToRemove = _db.People.Single(r => r.Id == id);
            return _db.People.Remove(itemToRemove);
        }

    }
}
