using System;

namespace Items
{
	public class Item : BaseClasses.Entity
	{
		public const string MASS_UNIT = "kg";
		public int Weight{ get; set; }//expressed in Kilograms
		public string Description { get; set; }

	}
}

