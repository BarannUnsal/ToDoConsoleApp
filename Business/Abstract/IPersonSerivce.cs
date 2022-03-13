

using System.Collections.Generic;
using ToDo_App_Entities;

namespace ToDo_App_Business_Abstract
{
    public interface IPersonService
    {
        Person Get(int id);
        
        List<Person> GetAll();
        
        void Add(Person person);
        
        void Update(Person person);
        
        void Delete(Person person);
    }
}