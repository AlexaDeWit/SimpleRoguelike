using System;

namespace Equipment
{
	public class GrantsArmour : IEquippable
	{
		private int ArmourValue;
		public GrantsArmour(int armour){
			ArmourValue=armour;
		}
		public void OnEquip(){
		}
		public void OnUnequip(){
		}
	}
}

