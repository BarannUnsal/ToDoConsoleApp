using System;
using System.Collections.Generic;
using System.Linq;
using ToDo_App_DataAccess_Abstract;
using ToDo_App_Entities;

namespace ToDo_App_DataAccess_Concrete
{
    public class BoardDal : IBoardDal
    {
        public List<Board> _board;

        public BoardDal()
        {
            _board = new List<Board>{
                new Board{BoardId = 1, BoardName = "ToDo"},
                new Board{BoardId = 2, BoardName = "In Progress"},
                new Board{BoardId = 3, BoardName = "Done"}
            };
        }

        public void Add(Board board)
        {
            _board.Add(board);
        }

        public void Delete(Board board)
        {
            Board boardDelete = _board.SingleOrDefault(x => x.BoardId == board.BoardId);
            _board.Remove(boardDelete);
        }

        public Board Get(int id)
        {
            return _board.SingleOrDefault(x => x.BoardId == id);
        }

        public List<Board> GetAll()
        {
            return _board;
        }

        public void Update(Board board)
        {
            Board boardUpdate = _board.SingleOrDefault(x => x.BoardId == board.BoardId);
            boardUpdate.BoardId = board.BoardId;
            boardUpdate.BoardName = board.BoardName;
        }
    }
}