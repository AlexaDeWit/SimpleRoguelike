using System;
using Equipment;

namespace Character
{
	public abstract class Character : BaseClasses.Entity, ICombat
	{
		//Character Stats
		public BaseClasses.Race CharacterRace{ get; set; }
		public int Health{ get; set; }
		public int Mana{ get; set; }
		public int Level{get;set;}


		public Faction CharacterFaction{ get; set; }

		//Wallet
		public long Currency{ get; set; }


		public abstract int ArmourValue{get;set;}
		public abstract double BlockChance{ get;set; }
		public abstract int BlockAmmount{ get;set; }
		public abstract double StrikeChance{ get; set;}
		public abstract double EvasionChance{ get; set;}
		public abstract int CombatLevel{ get; set;}

       
	}

}

