using System;
using Equipment;
using BaseClasses;
using Constants;


namespace Character
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
		public int Experience{ get; set;}
		//Inventory
		public Inventory Backpack{ get; set; }
		//Currently Equipped
        public Weapon EquippedWeapon { get; set; }
		public Armour EquippedHelm{ get; set; }
		public Armour EquippedBoots{ get; set; }
		public Armour EquippedChest{ get; set; }
		public Armour EquippedPants{ get; set; }
        public Shield  EquippedShield{ get; set; }
        public Accessory EquippedRing { get; set; }
		public Accessory EquippedNeck { get; set; }
		//Derived Attributes
		public override int ArmourValue {
			set;
			get {
				int totalArmourValue = 0;
				totalArmourValue += EquippedHelm.ArmourValue;
				totalArmourValue += EquippedHelm.ArmourValue;
				totalArmourValue += EquippedHelm.ArmourValue;
				totalArmourValue += EquippedHelm.ArmourValue;
				totalArmourValue += EquippedHelm.ArmourValue;
				return totalArmourValue;
			}
		}
        

		//Set a new equipment loadoout
		public void SetLoadout(Armour helm, Armour boots, Armour chest, Armour pants, Weapon weapon,Shield shield, Accessory ring, Accessory neck)
        {
			EquippedHelm = helm;
			EquippedBoots = boots;
			EquippedChest = chest;
			EquippedPants = pants;
			EquippedWeapon = weapon;
			EquippedShield = shield;
            EquippedRing = ring;
            EquippedNeck = neck;
		}

		//Derived Attribute Calculations
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
	}
}

