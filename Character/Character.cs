using System;
using Equipment;

namespace Character
{
	public abstract class Character : BaseClasses.Entity, ICombatCapable
	{
		//Character Stats
		public BaseClasses.Race CharacterRace{ get; set; }
		public int Health{ get; set; }
		public int Mana{ get; set; }
		public int Level{get;set;}


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
		//Abstract methods
		public abstract int AttackDamage();
		//Allow a character to attack another
		//Negative
       	public int AttackTarget (ICombatCapable target)
		{
			double roll;
			Random numberGenerator = new Random ();
			//negative if below target level, positive if above
			int levelDifference = this.CombatLevel - target.CombatLevel;
			double hitChance = this.StrikeChance - target.EvasionChance;
			//level difference penalty or bonus to hit
			hitChance += Convert.ToDouble (levelDifference) / 100;

			roll=numberGenerator.NextDouble();
			//must BEAT the roll, favours defender.
			if (hitChance > roll) {
				//hit the target, determine if it was blocked
				roll=numberGenerator.NextDouble();
				if(roll < target.BlockChance){

					return this.InflictDamage(target, this.AttackDamage ());
				}
				else{
					return this.InflictDamage(target, this.AttackDamage ()-target.BlockAmount);
				}
			} else {
				return Constants.Combat.TARGET_MISSED;

		}
	}

}

