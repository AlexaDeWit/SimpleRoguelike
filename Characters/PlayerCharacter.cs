using System;
using BaseClasses;
using Constants;
using System.Collections.Generic;
using Items;
using ItemComponents;
using Level;

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

		public int DamageIgnore{ get; set; }

		//Derived Attributes
		public override int ArmourValue {set;get;}
		public override double BlockChance{ set; get; }
		public override int BlockAmount{ set; get; }
		public override bool CanBlock { set; get; }
		public override int CombatLevel {
			get {
				return Level;
			}
		}
		public Tile PresentLocation{ get; set; }

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

			MaxHealth = Endurance * Constants.Mechanics.HEALTH_PER_ENDURANCE;
			Health = MaxHealth;
			MaxMana = Endurance * Constants.Mechanics.MANA_PER_INTELLIGENCE;
			Mana = MaxMana;
		}

		public override double StrikeChance {
			get {
				double bonusHitChance=0;
				bonusHitChance = (this.Agility / 
				                  (this.Agility + CombatConst.AGILITY_BONUS_RATIO_HIT))
									*CombatConst.STRIKE_CHANCE_SCALING_RATIO;
				return CombatConst.BASE_HIT_CHANCE + bonusHitChance;
			}
		}
		public override double EvasionChance {
			get {
				double bonusEvadeChance=0;
				bonusEvadeChance = (this.Agility /
				                    (this.Agility + CombatConst.AGILITY_BONUS_RATIO_EVADE))
									*CombatConst.STRIKE_CHANCE_SCALING_RATIO;
				return CombatConst.BASE_EVASION_CHANCE + bonusEvadeChance;
			}
		}
		public override int SufferDamage (int damage)
		{
			int damageToSuffer = damage - DamageIgnore;
			if (damageToSuffer > 0) {
				Health -= damageToSuffer;
				return damageToSuffer;
			} else {
				return 0;
			}
		}
	}

}

