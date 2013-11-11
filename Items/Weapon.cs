using System;

namespace Equipment
{
	public class Weapon : Equipment
	{
		
		public int DiceSize{ get; set; }
		public int NumberOfRolls{ get; set; }
		public bool CanCutWood{ get; set; }
		public bool CanMine{ get; set; }
		
		public Weapon (int dicesize, int rolls, bool woodcutting, bool mining)
		{
			DiceSize=dicesize;
			NumberOfRolls=rolls;
			CanCutWood=woodcutting;
			CanMine=mining;
		}
	}
}

