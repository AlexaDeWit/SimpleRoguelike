using System;
using Equipment;
using BaseClasses;
using Constants;
using System.Collections.Generic;
using Items;


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
		public Inventory Backpack{ get; set; }

		//Currently Equipped
		public List<Item> EquippedItems=new List<Item>();
		//Derived Attributes
		public override int ArmourValue {
			set;
			get {
				}
			}
		}
        

		//Set a new equipment loadoout
		public void SetLoadout(Armour helm, Armour boots, Armour chest, Armour pants, Weapon weapon,Shield shield, Accessory[] rings, Accessory neck)
        {
			EquippedHelm = helm;
			EquippedBoots = boots;
			EquippedChest = chest;
			EquippedPants = pants;
			EquippedWeapon = weapon;
			EquippedShield = shield;
            EquippedRings = rings;
            EquippedNeck = neck;
		}

	}
}

