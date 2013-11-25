using System;
using BaseClasses;
using Constants;
using System.Collections.Generic;
using Items;
using ItemComponents;
using Levels;
using Effects;

namespace Characters
{
	/*
	 * <summary>
	 * The playercharacter class. It has a large number of attributes, as well as 
	 * an inventory, list of equipped items, and all the calculations necessary to allow
	 * the player to engage in combat, using the ICombatCapable interface
	 * </summary>
	 */
	public class PlayerCharacter : Character
	{
		/// <summary>
		/// Hunger value of the character, when it reaches a threshold, the character will die from starvation
		/// </summary>
		/// <value>Current hunger value of the character, higher is bad.</value>
		public int Hunger{ get; set; }
		/// <summary>
		/// Gets or sets the intelligence of the character
		/// </summary>
		/// <value>The intelligence.</value>
		public int Intelligence{ get; set; }
		/// <summary>
		/// Gets or sets the endurance attribute of the character
		/// </summary>
		/// <value>The endurance.</value>
		public int Endurance{ get; set; }
		/// <summary>
		/// Gets or sets the agility attribute of the character
		/// </summary>
		/// <value>The agility.</value>
		public int Agility{ get; set; }
		/// <summary>
		/// Gets or sets the strength attribute of the character
		/// </summary>
		/// <value>The strength.</value>
		public int Strength{ get; set; }
		/// <summary>
		/// Gets or sets the charisma attribute of the character
		/// </summary>
		/// <value>The charisma.</value>
		public int Charisma{ get; set; }
		/// <summary>
		/// Gets or sets the experience accumulated of the character
		/// </summary>
		/// <value>The character's total experience.</value>
		public int Experience{ get; set; }
		/// <summary>
		/// All of the items currently posessed by the character, except those that are instead equipped.
		/// </summary>
		public List<Item> Backpack = new List<Item> ();
		/// <summary>
		/// All of the items the character presently has equipped
		/// </summary>
		public List<Item> EquippedItems=new List<Item>();
		/// <summary>
		/// Initializes a new instance of the <see cref="Characters.PlayerCharacter"/> class.
		/// </summary>
		/// <param name="name">The character's name.</param>
		/// <param name="description">A description of the character.</param>
		/// <param name="race">The character's race.</param>
		/// <param name="location">The location to insert the character in the map</param>
		public PlayerCharacter(string name, string description, Race race, Tile location){
			Name = name;
			Description = description;
			CharacterRace = race;
			Hunger = 0;
			Experience = 0;
			Strength = race.BaseStrenth;
			Intelligence = race.BaseIntelligence;
			Agility = race.BaseAgility;
			Charisma = race.BaseCharisma;
			Endurance = race.BaseEndurance;

			Health = MaxHealth();
			Mana = MaxMana();
			PresentLocation = location;
		}
		/// <summary>
		/// Calculates the total armour a character has.
		/// </summary>
		/// <returns>Character's total armour</returns>
		public override int ArmourValue (){
			int armourBonus = 0;
			foreach (Effect buff in StatusEffects) {
				armourBonus += buff.Armour;
			}
			return Agility*Mechanics.ARMOUR_PER_AGILITY + armourBonus + BaseArmour;
		}
		/// <summary>
		/// Determines the character's chance to block an attack
		/// </summary>
		/// <returns>The block chance.</returns>
		public override double BlockChance(){
			foreach (Item item in EquippedItems) {
				//Assume a shield item only has one block chance.
				//Design decision, game engine does not support multiple block components
				if( item.Supports<CanBlockAttacks>()){
					return item.FirstComponentOf<CanBlockAttacks> ().BlockChance;					
				}
			}
			return 0;
		}
		/// <summary>
		/// Determine's the amount of damage a character can block from an attack
		/// </summary>
		/// <returns>The amount to block. (0.0 to 1.0)</returns>
		public override int BlockAmount(){
			foreach (Item item in EquippedItems) {
				//Assume a shield item only has one block chance.
				//Design decision, game engine does not support multiple block components
				if( item.Supports<CanBlockAttacks>()){
					return item.FirstComponentOf<CanBlockAttacks> ().BlockAmount;					
				}
			}
			return 0;
		}
		/// <summary>
		/// Whether or not the character can block an attack.
		/// </summary>
		/// <returns>True if the character can block attacks</returns>
		public override bool CanBlock(){
			foreach (Item i in EquippedItems) {
				if (i.Supports<CanBlockAttacks> ()) {
					return true;
				}
			}
			return false;
		}
		/// <summary>
		/// The character's effective level when engaging in combat
		/// </summary>
		/// <returns>The effective level (0.0 to 1.0)</returns>
		/// <value>The combat level.</value>
		public override int CombatLevel {
			get {
				return Level;
			}
		}
		/// <summary>
		/// Calculates the upper limit of the character's health
		/// </summary>
		/// <returns>The maximum health the character is permitted to have</returns>
		public override int MaxHealth ()
		{
			int total = 0;
			total += Endurance * Mechanics.HEALTH_PER_ENDURANCE;
			foreach (Effect buff in StatusEffects) {
				total += buff.MaxHealth;
			}
			return total + BaseHealth;
		}
		/// <summary>
		/// Calculates the upper limit of the character's mana
		/// </summary>
		/// <returns>The maximum mana the character is permitted to have</returns>
		public override int MaxMana(){
			int total = 0;
			total += Intelligence * Mechanics.MANA_PER_INTELLIGENCE;
			foreach (Effect buff in StatusEffects) {
				total += buff.MaxMana;
			}
			return total + BaseMana;
		}
		/// <summary>
		/// Determines the character's chance to land an attack
		/// </summary>
		/// <returns>The hit chance.</returns>
		public override double StrikeChance (){
				double bonusHitChance;
				bonusHitChance = (this.Agility / 
				                  (this.Agility + CombatConst.AGILITY_BONUS_RATIO_HIT))
									*CombatConst.STRIKE_CHANCE_SCALING_RATIO;
				return CombatConst.BASE_HIT_CHANCE + bonusHitChance;
		}
		/// <summary>
		/// Determines the character's chance to dodge an attack
		/// </summary>
		/// <returns>The dge chance. (0.0 to 1.0)</returns>
		public override double EvasionChance(){
				double bonusEvadeChance;
				bonusEvadeChance = (this.Agility /
				                    (this.Agility + CombatConst.AGILITY_BONUS_RATIO_EVADE))
									*CombatConst.STRIKE_CHANCE_SCALING_RATIO;
				return CombatConst.BASE_EVASION_CHANCE + bonusEvadeChance;
		}
		/// <summary>
		/// Consume the specified Item, making its effect baseline.
		/// Will fail and return false if the item does not support consumeability.
		/// </summary>
		/// <param name="consumeable">The item to consume</param>
		/// <returns>False if item is not consumed</returns>
		public bool Consume(Item consumeable){

			if (consumeable.Supports<Consumeable> ()) {
				//Allows for multiple consume effects
				MakeEffectBaseline (consumeable.ItemEffect);
				//Will update the item to determine if it should be deleted
				consumeable.ConsumeCharge ();
				//First condition exists to allow for items the player doesn't have to be consumed
				if(this.Backpack.Contains(consumeable) && consumeable.DeleteFlag){
					this.Backpack.Remove (consumeable);
				}
				return true;
			}
			return false;
		}
	}

}

