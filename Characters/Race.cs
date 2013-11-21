using System;

namespace Characters
{
	/*
	 * <summary>
	 * A race, ie humans/orcs/etc, and its associated base attributes, as well as diet.
	 * </summary>
	 */
	public class Race
	{
		public int BaseStrenth{ get;private set; }
		public int BaseAgility{ get;private set; }
		public int BaseEndurance{ get;private set; }
		public int BaseIntelligence{ get;private set; }
		public int BaseCharisma{ get;private set; }

		public Race(int strength, int agility, int endurance, int intelligence, int charisma){
			BaseStrenth=strength;
			BaseAgility=agility;
			BaseEndurance=endurance;
			BaseIntelligence=intelligence;
			BaseCharisma=charisma;
		}

	}
}

