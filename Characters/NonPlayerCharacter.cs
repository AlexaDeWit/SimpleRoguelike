using System;

namespace Characters
{
	
	/*
	 * <summary>
	 * Nonplayer characters function like player characters but with much simpler mechanics.
	 * A goblin doesn't need to have complex calculations for its damage based on its equipment...
	 * 
	 * It simply has a static damage component of its own.
	 * </summary>
	 */
	public class NonPlayerCharacter : Character
	{	
		//Combat Stats
		//And Combat Interface implementation, from Character class inheritence
		public override int ArmourValue{get;set;}
		public override bool CanBlock{ get; set; }
		public override double BlockChance{ get;set; }
		public override int BlockAmount{ get;set; }
		public override double StrikeChance{ get { return StrikeChance; } }
		public override double EvasionChance{ get { return EvasionChance; }}
		public override bool CanBloack{ get; set;}
		public override int CombatLevel { 
			get {
				return Level;
			}
		}
		
	}
}

