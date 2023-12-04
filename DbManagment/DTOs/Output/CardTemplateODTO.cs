using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagment.DTOs.Output
{
    public class CardTemplateODTO
    {
        public int CardTemplateID { get; set; }
        public string CardTemplateName { get; set; }
        public string CardTemplateContent { get; set; }
        public List<CardODTO>? Cards { get; set; }

    }
}
