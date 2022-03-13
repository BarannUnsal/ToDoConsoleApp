using System;
using System.Collections.Generic;
using ToDo_App_Entities;

namespace ToDo_App_DataAccess_Abstract
{
    public interface ICardDal
    {
        Card Get(int id);
        
        List<Card> GetAll();
        
        void Add(Card card);
        
        void Update(Card card);
        
        void Delete(Card card);
    }
}