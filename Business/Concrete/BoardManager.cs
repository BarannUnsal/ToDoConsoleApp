
using System.Collections.Generic;
using ToDo_App_Business_Abstract;
using ToDo_App_DataAccess_Abstract;
using ToDo_App_Entities;

namespace ToDo_App_Business_Concrete
{
    public class BoardManager : IBoardService
    {
        private IBoardDal _boardDal;
        
        public BoardManager(IBoardDal boardDal)
        {
            _boardDal = boardDal;
        }
        
        public void Add(Board board)
        {
            _boardDal.Add(board);
        }

        public void Delete(Board board)
        {
            _boardDal.Delete(board);
        }

        public Board Get(int id)
        {
            return _boardDal.Get(id);
        }

        public List<Board> GetAll()
        {
            return _boardDal.GetAll();
        }

        public void Update(Board board)
        {
            _boardDal.Update(board);
        }
    }
}