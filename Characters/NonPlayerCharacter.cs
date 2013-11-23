using System;
using Level;

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
		private double _evasion;
		private double _hitChance;
		private double _blockChance;
		private int _block;
		private bool _canBlock;
		private int _armour;


		public override int ArmourValue(){
			return _armour;
		}
		public override bool CanBlock(){
			return _canBlock;
		}
		public override double BlockChance(){
			return _blockChance;
		}
		public override int BlockAmount(){
			return _block;
		}
		public override double StrikeChance(){
			return _hitChance;
		}
		public override double EvasionChance(){
			return _evasion;
		}
		public override int CombatLevel { 
			get {
				return Level;
			}
		}
		public NonPlayerCharacter(
					string name,
					string description,
					int armour,
					bool ableToBlock,
					double blockChance,
					int blockAmount,
					double hitChance,
					double dodgeChance,
					int combatLevel,
					Tile location){

			//End params
			Name = name;
			Description = description;
			_armour = armour;
			_canBlock = ableToBlock;
			_block = blockAmount;
			_blockChance = blockChance;
			_hitChance = hitChance;
			_evasion = dodgeChance;
			Level = combatLevel;
			PresentLocation = location;
		}
	}
}

