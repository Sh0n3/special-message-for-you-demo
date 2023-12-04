using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagment.DTOs.Input
{
    public class CardIDTO
    {
        public Guid? CardID { get; set; }
        public int UserID { get; set; }
        public int CardTemplateID { get; set; }
        public string CardText { get; set; }
        public string CardColor { get; set; }
        public string CardBackgroundColor { get; set; } 
        public string CardTextColor { get; set; } 
        public string? Animation { get; set; }
    }
}
