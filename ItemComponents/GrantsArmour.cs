using System;
using Characters;

namespace ItemComponents
{
	public class GrantsArmour : IGrantsEffect
	{
		private int ArmourValue;
		public GrantsArmour(int armour){
			ArmourValue=armour;
		}
		public void OnEquip(Character affected){
			affected.ArmourValue += this.ArmourValue;
		}
		public void OnUnequip(Character affected){
			affected.ArmourValue -= this.ArmourValue;
		}
	}
}

