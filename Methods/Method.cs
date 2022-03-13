using System;
using System.Linq;
using ToDo_App_Business_Abstract;
using ToDo_App_Business_Concrete;
using ToDo_App_DataAccess_Concrete;
using ToDo_App_Entities;

namespace ToDo_App_Methods
{
    public class Method
    {
        ICardService _cardService = new CardManager(new CardDal());

        IPersonService _personService = new PersonManager(new PersonDal());

        IBoardService _boardService = new BoardManager(new BoardDal());


        public Method() { }

        public void Start()
        {
            Console.WriteLine("ToDo Uygulamasına Hoş Geldiniz! \n Lütfen yapmak istediğiniz işlemi seçiniz");
            Console.WriteLine("_____________________");

            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşıma ");
            Console.WriteLine("(5) Kişi Ekleme");
            Console.WriteLine("(6) Çıkış");
        }
        public bool CheckNumber(int number)
        {
            if (number >= 1 && number <= 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddPerson()
        {
            Console.WriteLine("Kişi Ekleme \n *****************");
            Console.WriteLine("Kişi Adı Giriniz: ");
            string ad = Console.ReadLine();
            Console.WriteLine("Kişi Soydı Giriniz: ");
            string soyad = Console.ReadLine();
            Console.WriteLine("Kişi ID Giriniz: ");
            int id = Convert.ToInt32(Console.ReadLine());
            this._personService.Add(new Person()
            {
                PersonName = ad,
                PersonLastName = soyad,
                PersonId = id
            });
            this.ListPerson();
            
        }

        public void ListBoard()
        {
            Console.WriteLine("Board Listesi \n ********************");
            try
            {
                int boardcount = _boardService.GetAll().Count;
                int cardCount = _cardService.GetAll().Count;
                for (int i = 1; i < boardcount; i++)
                {
                    int boardId = _boardService.GetAll().Where(x => x.BoardId == i).FirstOrDefault().BoardId;
                    int cardId = _cardService.GetAll().Where(x => x.BoardId == boardId).FirstOrDefault().CardId;

                    Console.WriteLine($" {_boardService.GetAll().Where(x => x.BoardId == i).FirstOrDefault().BoardName.ToUpper()} Line");
                    Console.WriteLine("___________________");

                    foreach (var item in _cardService.GetAll().Where(x => x.BoardId == boardId))
                    {
                        Console.WriteLine("Başlık: {0}", item.Title);
                        Console.WriteLine("İçerik: {0}", item.Description);
                        Console.WriteLine("Atanan Kişi: {0}", item.PersonId);
                        Console.WriteLine("Büyüklük: {0}", item.Size);
                    }
                }
            }
            catch (SystemException e)
            {
                Console.WriteLine("Hata", e);
                throw;
            }
            Start();
        }

        public void AddBoard()
        {
            Console.WriteLine("Board Eklemek \n ***************");
            Console.WriteLine("Başlık Giriniz: ");
            string baslik = Console.ReadLine();
            Console.WriteLine("İçerik Giriniz: ");
            string icerik = Console.ReadLine();
            Console.WriteLine("Büyüklük Seçiniz -> XS(1), S(2), M(3), L(4), XL(5): ");
            int buyukluk = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kişi Seçiniz: ");
            ListPerson();
            Console.WriteLine(" : ");
            int kisi = Convert.ToInt32(Console.ReadLine());
            var personSelectId = _personService.GetAll().Where(x => x.PersonId == kisi).FirstOrDefault().PersonId;

            if (personSelectId != 0)
            {
                _cardService.Add(new Card
                {
                    Title = baslik,
                    Description = icerik,
                    Size = (Size)buyukluk,
                    PersonId = kisi,
                    BoardId = 1
                });
            }
            else
            {
                Console.WriteLine("Hatalı giriş yaptınız! Lütfen kontrol edin.");
                AddBoard();
            }

            this.Start();
        }

        public void ListPerson()
        {
            foreach (var item in _personService.GetAll())
            {
                Console.WriteLine("{0} {1} {2}", item.PersonId, item.PersonName, item.PersonLastName);
            }
        }

        public void DeleteBoard()
        {
            Console.WriteLine(" Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.WriteLine("Lütfen kart başlığını yazınız:");
            string baslik = Console.ReadLine();
            var cardName = _cardService.GetAll().Find(x => x.Title == baslik);

            if (baslik != cardName.Title)
            {
                Console.WriteLine(" Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine(" * Silmeyi sonlandırmak için : (1)");
                Console.WriteLine(" * Yeniden denemek için : (2)");
                int kullaniciSecim = Convert.ToInt32(Console.ReadLine());

                switch (kullaniciSecim)
                {
                    case 1:
                        Start();
                        break;
                    case 2:
                        DeleteBoard();
                        break;
                }
            }
            else
            {
                Console.WriteLine("{0} kart siliniyor onaylıyor musunuz? (y/n)", cardName.Title);
                char select = Convert.ToChar(Console.ReadLine());
                if (select == 'y')
                {
                    var deleteCard = _cardService.GetAll().FirstOrDefault(x => x.Title == baslik);
                    _cardService.Delete(deleteCard);
                }
            }
        }

        public void MoveCard()
        {
            Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
            Console.WriteLine("Kart başlığı bilgisini girin: ");
            string baslik = Console.ReadLine();
            var cardName = _cardService.GetAll().Find(x => x.Title == baslik);

            if (baslik != cardName.Title)
            {
                Console.WriteLine(" Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine(" * İşlemi sonlandırmak için : (1)");
                Console.WriteLine(" * Yeniden denemek için : (2)");
                int secim = Convert.ToInt32(Console.ReadLine());
                switch (secim)
                {
                    case 1:
                        Start();
                        break;
                    case 2:
                        MoveCard();
                        break;
                    default:
                        Console.WriteLine("Hatalı bilgi girdiniz!");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Kart Bilgileri: ");
                Console.WriteLine("___________");

                foreach (var item in _cardService.GetAll().Where(x => x.Title == baslik))
                {
                    Console.WriteLine("Başlık: {0}", item.Title);
                    Console.WriteLine("Açıklama: {0}", item.Description);
                    Console.WriteLine("Büyükülük: {0}", item.Size);
                    Console.WriteLine("Kullanıcı: {0}", _personService.GetAll().Where(x => x.PersonId == item.PersonId).FirstOrDefault().PersonName, _personService.GetAll().Where(x => x.PersonId == item.PersonId).FirstOrDefault().PersonLastName);
                    Console.WriteLine("Line: {0}", item.BoardId);
                }

                Console.WriteLine("Lütfen taşımak istediğiniz Line seçin: ");
                foreach (var item in _boardService.GetAll())
                {
                    Console.WriteLine("{0} {0}", item.BoardId, item.BoardName.ToUpper());
                }
                int boardId = Convert.ToInt32(Console.ReadLine());
                var card = _cardService.GetAll().FirstOrDefault(x => x.Title == baslik);
                var cardId = _cardService.GetAll().Where(x => x.Title == baslik);
                var cardBoardId = _cardService.GetAll().Where(x => x.Title == baslik);

                _cardService.Update(new Card
                {
                    CardId = card.CardId,
                    Title = card.Title,
                    Description = card.Description,
                    Size = card.Size,
                    PersonId = card.PersonId,
                    BoardId = card.BoardId
                });
            }

            ListBoard();
        }
    }
}