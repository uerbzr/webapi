using System.Runtime.CompilerServices;
using webapi.Models;

namespace webapi.Data.DataStore
{
    public class PersonDataStore : IPersonDataStore
    {
        private static List<Person> _persons = new List<Person>();
        public PersonDataStore()
        {
            if (_persons.Count == 0)
            {
                Seed();
            }
        }

        public void Seed()
        {
            People.Add(new Person() { Id = 1, Name = "Nigel", Email = "nigel@something.com" });
            People.Add(new Person() { Id = 2, Name = "Bob", Email = "bob@something.com" });
            People.Add(new Person() { Id = 3, Name = "Frank", Email = "frank@something.com" });
            People.Add(new Person() { Id = 4, Name = "Jeff", Email = "jeff@something.com" });
            People.Add(new Person() { Id = 5, Name = "Carl", Email = "carl@something.com" });
        }
        public List<Person> People { get { return _persons; } set { _persons = value; } }

    }
}
