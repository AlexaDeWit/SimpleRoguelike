using System;
using System.Collections.Generic;
using BaseClasses;

namespace Characters
{
	/*
	 * <summary>
	 * This is the base and abstracted character class used to derive both player-characters and nonplayer characters,
	 * such that they can have shared functionality and be treated as the same thing externally, but allow them both
	 * to have different systems for deriving things like attack damage
	 * </summary>
	 */
	public abstract class Character : BaseClasses.Entity, Combat.ICombatCapable
	{
		//Character Stats
		public Race CharacterRace{ get; set; } 
		public int MaxHealth{ get; set; } 
		public int Health{ get; set; } 
		public int HealthRegen{ get; set; }
		public int MaxMana{ get; set; }
		public int Mana{ get; set; }
		public int ManaRegen{ get; set; }
		public int Level{get;set;}
		//Sum of all attack damage sources
		public List<DiceRoll> DamageComponents=new List<DiceRoll>();
		
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
		public abstract double StrikeChance{ get; }
		public abstract double EvasionChance{ get;}
		public abstract int CombatLevel{ get;}
		public abstract bool CanBlock{ get; set; }
		//DamageCalculation
		public int CalculateDamage ()
		{
			int total=0;
			foreach (DiceRoll d in DamageComponents) {
				total += d.Roll();
			}
			return total;
		}

		//Percentage Chance
		public double SuccessRoll ()
		{
			Random numberGenerator = new Random ();
			return numberGenerator.NextDouble();
		}
		//Allow a character to attack another
		public abstract int SufferDamage(int damage);
       	
	}

}

