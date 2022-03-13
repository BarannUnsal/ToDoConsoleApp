using System;
using System.Collections.Generic;
using System.Linq;
using ToDo_App_DataAccess_Abstract;
using ToDo_App_Entities;

namespace ToDo_App_DataAccess_Concrete
{
    public class CardDal : ICardDal
    {
        public List<Card> _cards;

        public CardDal()
        {
            _cards = new List<Card>{
                new Card{CardId = 1, Title = "Card 1" , Description = "", BoardId = 1, PersonId = 1, Size = Size.S},
                new Card{CardId = 2, Title = "Card 2" , Description = "" , BoardId = 2, PersonId = 2, Size = Size.M},
                new Card{CardId = 3, Title = "Card 3",  Description = "", BoardId = 3, PersonId = 3, Size = Size.L}
            };
        }

        public void Add(Card card)
        {
            _cards.Add(card);
        }

        public void Delete(Card card)
        {
            Card cardDelete = _cards.SingleOrDefault(x => x.CardId == card.CardId);
            _cards.Remove(cardDelete);
        }

        public Card Get(int id)
        {
            return _cards.SingleOrDefault(x => x.CardId == id);
        }

        public List<Card> GetAll()
        {
            return _cards;
        }

        public void Update(Card card)
        {
            Card cardUpdate = _cards.SingleOrDefault(x => x.CardId == card.CardId);
            cardUpdate.Title = card.Title;
            cardUpdate.Description = card.Description;
            cardUpdate.BoardId = card.BoardId;
            cardUpdate.PersonId = card.PersonId;
            cardUpdate.Size = card.Size;
        }
    }
}