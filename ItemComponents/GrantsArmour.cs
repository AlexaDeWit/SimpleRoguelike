using System;
using Characters;
using Effects;
using Items;

namespace ItemComponents
{
	/*
	 * <summary>
	 * Allows an item to contribute to its wielder's total armour
	 * </summary>
	 */
	public class GrantsArmour : IGrantsEffect
	{
		private int _armourIncrease;
		private Item _parentItem;
		public GrantsArmour(int armour){
			_armourIncrease = armour;
		}
		public void ApplyEffect(Item affected){
			affected.ItemEffect.Armour += _armourIncrease;
		}
		public void RemoveEffect(Item affected){
			affected.ItemEffect.Armour -= _armourIncrease;
		}
	}
}

