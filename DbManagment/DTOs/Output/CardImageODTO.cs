using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagment.DTOs.Output
{
    public class CardImageODTO
    {
        public int CardImageID { get; set; }
        public Guid CardID { get; set; }
        public string CardImagePath { get; set; }
        public string CardImageName { get; set; }
        public string CardImageOriginalName { get; set; }
        public UserODTO User {  get; set; }
    }
}
