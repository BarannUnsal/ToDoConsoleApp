using System;
using System.Collections.Generic;
using ToDo_App_Entities;

namespace ToDo_App_DataAccess_Abstract
{
    public interface IBoardDal
    {
        Board Get(int id);
        
        List<Board> GetAll();
        
        void Add(Board board);
        
        void Update(Board board);
        
        void Delete(Board board);
    }
}