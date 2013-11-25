using System;
using Levels;

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
		/// <summary>
		/// Calculates the upper limit of the character's health
		/// </summary>
		/// <returns>The maximum health the character is permitted to have</returns>
		public override int MaxHealth (){
			return BaseHealth;
		}
		/// <summary>
		/// Calculates the upper limit of the character's mana
		/// </summary>
		/// <returns>The maximum mana the character is permitted to have</returns>
		public override int MaxMana (){
			return BaseMana;
		}
		/// <summary>
		/// Calculates the total armour a character has.
		/// </summary>
		/// <returns>Character's total armour</returns>
		public override int ArmourValue(){
			return BaseArmour;
		}
		/// <summary>
		/// Whether or not the character can block an attack.
		/// </summary>
		/// <returns>True if the character can block attacks</returns>
		public override bool CanBlock(){
			return _canBlock;
		}
		/// <summary>
		/// Determines the character's chance to block an attack
		/// </summary>
		/// <returns>The block chance.</returns>
		public override double BlockChance(){
			return _blockChance;
		}
		/// <summary>
		/// Determine's the amount of damage a character can block from an attack
		/// </summary>
		/// <returns>The amount to block. (0.0 to 1.0)</returns>
		public override int BlockAmount(){
			return _block;
		}
		/// <summary>
		/// Determines the character's chance to land an attack
		/// </summary>
		/// <returns>The hit chance.</returns>
		public override double StrikeChance(){
			return _hitChance;
		}
		/// <summary>
		/// Determines the character's chance to dodge an attack
		/// </summary>
		/// <returns>The dge chance. (0.0 to 1.0)</returns>
		public override double EvasionChance(){
			return _evasion;
		}
		/// <summary>
		/// The character's effective level when engaging in combat
		/// </summary>
		/// <returns>The effective level (0.0 to 1.0)</returns>
		public override int CombatLevel { 
			get {
				return Level;
			}
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="Characters.NonPlayerCharacter"/> class.
		/// Important note: This character will insert itself into the game map.
		/// </summary>
		/// <param name="name">NPC's Name.</param>
		/// <param name="description">NPC's Description.</param>
		/// <param name="armour">The Armour the NPC will have in combat</param>
		/// <param name="ableToBlock">If set to <c>true</c> able to block.</param>
		/// <param name="blockChance">The NPC's chance to block(zero for unable) as a double from 0 to 1</param>
		/// <param name="blockAmount">The amount of damage blocked when successful</param>
		/// <param name="hitChance">The NPC's chance to hit as a double from 0 to 1</param>
		/// <param name="dodgeChance">The NPC's chance to hit as a double from 0 to 1</param>
		/// <param name="combatLevel">The level of the NPC</param>
		/// <param name="maxHealth">Max health.</param>
		/// <param name="maxMana">Max mana.</param>
		/// <param name="location">The tile to place the NPC on.</param>
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
					int maxHealth,
					int maxMana,
					Tile location){
			//End params
			Name = name;
			Description = description;
			BaseArmour = armour;
			_canBlock = ableToBlock;
			_block = blockAmount;
			_blockChance = blockChance;
			_hitChance = hitChance;
			_evasion = dodgeChance;
			Level = combatLevel;
			BaseHealth = maxHealth;
			BaseMana = maxMana;
			PresentLocation = location;
		}
	}
}

