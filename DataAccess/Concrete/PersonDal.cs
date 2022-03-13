using System;
using System.Collections.Generic;
using System.Linq;
using ToDo_App_DataAccess_Abstract;
using ToDo_App_Entities;

namespace ToDo_App_DataAccess_Concrete
{
    public class PersonDal : IPersonDal
    {
        private List<Person> _person;

        public PersonDal()
        {
            _person = new List<Person> {
                                               new Person{PersonId = 1, PersonName = "Baran", PersonLastName = "Ünsal"},
                                               new Person{PersonId = 2, PersonName = "Sinem", PersonLastName = "Ünsal"}, 
                                               new Person{PersonId = 3, PersonName = "Deniz", PersonLastName = "Deniz"}
                                           };
        }

        public void Add(Person person)
        {
            _person.Add(person);
        }

        public void Delete(Person person)
        {
            Person personDelete = _person.SingleOrDefault(x => x.PersonId == person.PersonId);
            _person.Remove(personDelete);
        }

        public Person Get(int id)
        {
            return _person.SingleOrDefault(x => x.PersonId == id);
        }

        public List<Person> GetAll()
        {
            return _person;
        }

        public void Update(Person person)
        {
            Person personUpdate = _person.SingleOrDefault(x => x.PersonId == person.PersonId);
            if (personUpdate != null)
            {
                personUpdate.PersonId = person.PersonId;
                personUpdate.PersonName = person.PersonName;
                personUpdate.PersonLastName = person.PersonLastName;
            }
        }
    }
}
