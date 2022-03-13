using System;
using System.Collections.Generic;
using ToDo_App_Entities;

namespace ToDo_App_DataAccess_Abstract
{
    public interface IPersonDal
    {
        Person Get(int id);
        
        List<Person> GetAll();
        
        void Add(Person person);
        
        void Update(Person person);
        
        void Delete(Person person);
    }
}