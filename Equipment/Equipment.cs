using System;
using Items;

namespace Equipment
{
	
	
	public class Equipment : Items
	{
		//Stats
		public int Durability{ get; set; }
		//Type
		public bool Magical{ get; set; }
		public bool Rare{ get; set; }
		public bool Unique{ get; set; }

		
		public Equipment ()
		{
		}
	}
}

