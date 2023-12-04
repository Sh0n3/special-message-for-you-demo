using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagment.Entities
{
	public class CardImage //limit to 3 for each card
	{
		public int CardImageID { get; set; }
		public Guid CardID { get; set; }
		public string CardImagePath { get; set; }
		public string CardImageName { get; set; }
		public string CardImageOriginalName { get; set; }

		public Card Card { get; set; }
	}
}
