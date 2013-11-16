using System;
using Characters;

namespace ItemComponents
{
	/*
	 * <summary>
	 * Allows an item to contribute to its wielder's total armour
	 * </summary>
	 */
	public class GrantsArmour : IGrantsEffect
	{
		private int ArmourValue;
		public GrantsArmour(int armour){
			ArmourValue=armour;
		}
		public void ApplyEffect(Character affected){
			affected.ArmourValue += this.ArmourValue;
		}
		public void RemoveEffect(Character affected){
			affected.ArmourValue -= this.ArmourValue;
		}
	}
}

