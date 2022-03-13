using System.Collections.Generic;
using ToDo_App_Business_Abstract;
using ToDo_App_DataAccess_Abstract;
using ToDo_App_Entities;

namespace ToDo_App_Business_Concrete
{
    public class CardManager : ICardService
    {
        private ICardDal _cardDal;
        
        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }
        
        public void Add(Card card)
        {
            _cardDal.Add(card);
        }

        public void Delete(Card card)
        {
            _cardDal.Delete(card);
        }

        public Card Get(int id)
        {
            return _cardDal.Get(id);
        }

        public List<Card> GetAll()
        {
            return _cardDal.GetAll();
        }

        public void Update(Card card)
        {
            _cardDal.Update(card);
        }
    }
}