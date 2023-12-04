using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagment.DTOs.Input
{
    public class CardTemplateIDTO
    {
        public int? CardTemplateID { get; set; }
        public string CardTemplateName { get; set; }
        public string CardTemplateContent { get; set; }
    }
}
