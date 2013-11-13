using System;
using Equipment;
using BaseClasses;
using Constants;
using System.Collections.Generic;
using Items;
using ItemComponents;


namespace Characters
{
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
		public Inventory Backpack{ get;private set;}

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
				                    (this.Agility + CombatConst.AGILITY_BONUS_RATIO_HIT))
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

