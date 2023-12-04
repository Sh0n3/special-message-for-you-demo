using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagment.Entities
{
    public class CardTemplate
    {
        public int CardTemplateID { get; set; }
        public string CardTemplateName { get; set; }
        public string CardTemplateContent { get; set; }
        public ICollection<Card> Cards { get; set; } 
    }
}
