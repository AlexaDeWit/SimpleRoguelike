using System;
using Equipment;
using BaseClasses;
using Constants;


namespace Character
{
	class PlayerCharacter : Character
	{
		//Player Specific Attributes
		private int _hunger{ get; set; }
		private int _intelligence{ get; set; }
		private int _endurance{ get; set; }
		private int _agility{ get; set; }
		private int _strength{ get; set; }
		private int _charisma{ get; set; }
		//Inventory
		private Inventory _inventory{ get; set; }


		public int CalculateStamina ()
		{
			return 0;
		}

		public int CalculateHitRating ()
		{
			return 0;
		}

		public int CalculateEvasionRating ()
		{
			return 0;
		}
		//Begin Implementing ICombat, inherited from Character
		public override int GetArmourValue ()
		{
			int totalArmourValue=0;
			totalArmourValue += _helm._armourValue;
			totalArmourValue += _chest._armourValue;
			totalArmourValue += _boots._armourValue;
			totalArmourValue += _pants._armourValue;
			totalArmourValue += _shield._armourValue;
			return totalArmourValue;

		}
		public override double GetBlockChance(){
			//placeholder for full calculations
			return _shield._blockChance;
		}
		public override int GetBlockAmmount(){
			return _shield._blockValue;
		}
		public override double GetStrikeChance(){
			return CombatConstants.BASE_HIT_CHANCE;
		}
		public override double GetEvasionChance(){
			return CombatConstants.BASE_EVASION_CHANCE;
		}
		public override int GetCombatLevel(){
			return _level;
		}
		//end of ICombat implementation
	}
}

