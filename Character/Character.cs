using System;
using Equipment;

namespace Character
{
	public abstract class Character : BaseClasses.Entity, BaseInterfaces.ICombatCapable
	{
		//Character Stats
		public BaseClasses.Race CharacterRace{ get; set; } 
		public int Health{ get; set; } 
		public int HealthRegen{ get; set; }
		public int Mana{ get; set; }
		public int ManaRegen{ get; set; }
		public int Level{get;set;}
		
		//Gender
		public string Gender{get;set;}

		//Resistances
		public int FireRes{ get; set; }
		public int ColdRes{ get; set; }
		public int LightningRes{ get; set; }
		public int PoisonRes{ get; set; }

		public Faction CharacterFaction{ get; set; }

		//Wallet
		public long Currency{ get; set; }

		//ICombat abstractions, different for each type of character
		public abstract int ArmourValue{get;set;}
		public abstract double BlockChance{ get;set; }
		public abstract int BlockAmount{ get;set; }
		public abstract double StrikeChance{ get; set;}
		public abstract double EvasionChance{ get; set;}
		public abstract int CombatLevel{ get; set;}
		public abstract bool CanBlock{ get; set; }
		//Abstract methods
		public abstract int AttackDamage();

		//Percentage Chance
		public double SuccessRoll ()
		{
			Random numberGenerator = new Random ();
			return numberGenerator.NextDouble();
		}
		//Allow a character to attack another
       	
	}

}

