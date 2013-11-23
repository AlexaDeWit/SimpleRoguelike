using System;

namespace Effects
{
	/*
	 * <summary>
	 * Represents a buff or debuff to a character. Contains a 
	 * field for every buff/debuff a player can experience.
	 * Shitty approach to doing things, but, hey.
	 * </summary>
	 */
	
	//Seriously consider consending all effects of an item into this class and putting it in the item,

	public class Effect
	{
		public int Armour{ get; set;}
		public int MaxHealth{ get; set; }
		public int MaxMana{ get; set;}
		public int Filling{ get; set; }
		public Effect ()
		{
			Armour = 0;
			MaxHealth = 0;
			MaxMana = 0;
			Filling = 0;
		}
	}
}

