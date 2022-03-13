

using System.Collections.Generic;
using ToDo_App_Entities;

namespace ToDo_App_Business_Abstract
{
    public interface ICardService
    {
        Card Get(int id);
        
        List<Card> GetAll();
        
        void Add(Card card);
        
        void Update(Card card);
        
        void Delete(Card card);
    }
}