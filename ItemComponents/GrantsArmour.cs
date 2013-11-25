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
		/// <summary>
		/// Initializes a new instance of the <see cref="ItemComponents.GrantsArmour"/> class.
		/// </summary>
		/// <param name="armour">How much armour will be granted by the component</param>
		public GrantsArmour(int armour){
			_armourIncrease = armour;
		}
		/// <summary>
		/// Adds the effect this component has to an item(generally will be the parent item)
		/// </summary>
		/// <param name="affected">Item to accept the effect</param>
		public void ApplyEffect(Item affected){
			affected.ItemEffect.Armour += _armourIncrease;
		}
		/// <summary>
		/// Removes the effect this component has from an item(generally will be the parent item)
		/// </summary>
		/// <param name="affected">Item to lose the effect</param>
		public void RemoveEffect(Item affected){
			affected.ItemEffect.Armour -= _armourIncrease;
		}
	}
}

