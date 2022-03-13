using System;

namespace ToDo_App_Entities
{
    public class Card
    {
        public int CardId { get; set; }

        public string Description { get; set; }
        
        public string Title { get; set; }
        
        public int BoardId { get; set; }
        
        public int PersonId { get; set; }
        
        public Enum Size { get; set; }
    }
}