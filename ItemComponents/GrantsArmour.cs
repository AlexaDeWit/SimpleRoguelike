using System;
using Characters;
using Effects;

namespace ItemComponents
{
	/*
	 * <summary>
	 * Allows an item to contribute to its wielder's total armour
	 * </summary>
	 */
	public class GrantsArmour : IGrantsEffect
	{
		private Effect _armourIncrease = new Effect ();
		public GrantsArmour(int armour){
			_armourIncrease.Armour = armour;
		}
		public void ApplyEffect(Character affected){
			affected.StatusEffects.Add (this._armourIncrease);
		}
		public void RemoveEffect(Character affected){
			affected.StatusEffects.Remove (this._armourIncrease);
		}
	}
}

