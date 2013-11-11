using System;

namespace Characters
{
	
	
	public class NonPlayerCharacter : Character
	{	
		//Combat Stats
		//And Combat Interface implementation, from Character class inheritence
		public override int ArmourValue{get;set;}
		public override double BlockChance{ get;set; }
		public override int BlockAmmount{ get;set; }
		public override double StrikeChance{ get; set;}
		public override double EvasionChance{ get; set;}
		public override int CombatLevel { 
			get {
				return Level;
			}
			set;}


	}
}

