
using System.Collections.Generic;
using ToDo_App_Entities;

namespace ToDo_App_Business_Abstract
{
    public interface IBoardService
    {
        Board Get(int id);
        
        List<Board> GetAll();
        
        void Add(Board board);
        
        void Update(Board board);
        
        void Delete(Board board);
    }
}