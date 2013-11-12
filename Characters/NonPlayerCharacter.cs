using System;

namespace Characters
{
	
	
	public class NonPlayerCharacter : Character
	{	
		//Combat Stats
		//And Combat Interface implementation, from Character class inheritence
		public override int ArmourValue{get;set;}
		public override bool CanBlock{ get; set; }
		public override double BlockChance{ get;set; }
		public override int BlockAmount{ get;set; }
		public override double StrikeChance{ get; set;}
		public override double EvasionChance{ get; set;}
		public override int CombatLevel { 
			get {
				return Level;
			}
			set {
				CombatLevel = value;
			}
		}
		//Not implemented yet
		public override int SufferDamage(int damage){
			return 0;
		}
		
	}
}

