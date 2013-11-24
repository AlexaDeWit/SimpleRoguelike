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
		//Player Specific Attributes
		public int Hunger{ get; set; }
		public int Intelligence{ get; set; }
		public int Endurance{ get; set; }
		public int Agility{ get; set; }
		public int Strength{ get; set; }
		public int Charisma{ get; set; }
		public int Experience{ get; set; }
		//Inventory
		public List<Item> Backpack = new List<Item> ();

		//Currently Equipped
		public List<Item> EquippedItems=new List<Item>();

		//Derived Attributes
		public override int ArmourValue (){
			int armourBonus = 0;
			foreach (Effect buff in StatusEffects) {
				armourBonus += buff.Armour;
			}
			return Agility*Mechanics.ARMOUR_PER_AGILITY + armourBonus + BaseArmour;
		}


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
		public override bool CanBlock(){
			foreach (Item i in EquippedItems) {
				if (i.Supports<CanBlockAttacks> ()) {
					return true;
				}
			}
			return false;
		}
		public override int CombatLevel {
			get {
				return Level;
			}
		}

		public PlayerCharacter(string name, string description, Race race){
			Name = name;
			Description = description;
			CharacterRace = race;
			Hunger = 0;
			Strength = race.BaseStrenth;
			Intelligence = race.BaseIntelligence;
			Agility = race.BaseAgility;
			Charisma = race.BaseCharisma;
			Endurance = race.BaseEndurance;

			Health = MaxHealth();
			Mana = MaxMana();
		}
		public override int MaxHealth ()
		{
			int total = 0;
			total += Endurance * Mechanics.HEALTH_PER_ENDURANCE;
			foreach (Effect buff in StatusEffects) {
				total += buff.MaxHealth;
			}
			return total + BaseHealth;
		}
		public override int MaxMana(){
			int total = 0;
			total += Intelligence * Mechanics.MANA_PER_INTELLIGENCE;
			foreach (Effect buff in StatusEffects) {
				total += buff.MaxMana;
			}
			return total + BaseMana;
		}
		public override double StrikeChance (){
				double bonusHitChance;
				bonusHitChance = (this.Agility / 
				                  (this.Agility + CombatConst.AGILITY_BONUS_RATIO_HIT))
									*CombatConst.STRIKE_CHANCE_SCALING_RATIO;
				return CombatConst.BASE_HIT_CHANCE + bonusHitChance;
		}
		public override double EvasionChance(){
				double bonusEvadeChance;
				bonusEvadeChance = (this.Agility /
				                    (this.Agility + CombatConst.AGILITY_BONUS_RATIO_EVADE))
									*CombatConst.STRIKE_CHANCE_SCALING_RATIO;
				return CombatConst.BASE_EVASION_CHANCE + bonusEvadeChance;
		}

		//Consume an item, may be charge based
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

