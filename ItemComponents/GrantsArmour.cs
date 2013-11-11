using System;
using Characters;

namespace ItemComponents
{
	public class GrantsArmour : IEquippable
	{
		private int ArmourValue;
		public GrantsArmour(int armour){
			ArmourValue=armour;
		}
		public void OnEquip(Character owner){
			owner.ArmourValue += this.ArmourValue;
		}
		public void OnUnequip(Character owner){
			owner.ArmourValue -= this.ArmourValue;
		}
	}
}

