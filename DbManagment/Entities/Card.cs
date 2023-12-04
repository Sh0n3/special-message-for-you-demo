using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManagment.Entities
{
	public class Card
	{
		public Guid CardID { get; set; }
		public int UserID { get; set; }
		public int CardTemplateID { get; set; }
		public string CardText { get; set; }
		public string CardColor { get; set; } //Color Picker
		public string CardBackgroundColor { get; set; } //Color Picker
		public string CardTextColor { get; set; } //Color Picker
		public string? Animation { get; set; }

		public User User { get; set; }
		public CardTemplate CardTemplate { get; set; }
		public ICollection<CardImage>? CardImages { get; set;}

	}
}
