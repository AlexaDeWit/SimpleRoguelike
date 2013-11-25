using System;
using Characters;
using BaseClasses;
using Items;

namespace ItemComponents
{

	/// <summary>
	/// Interface that allows items to contribute to their wielder's attack damage.
	/// Dependant upon the DiceRoll class which determines its damage component
	/// Only one Damage component is allowed on a given item.
	/// </summary>
	public class ContributesDamage : IGrantsEffect
	{
		private DiceRoll _diceDamage;
		/// <summary>
		/// Initializes a new instance of the <see cref="ItemComponents.ContributesDamage"/> class.
		/// </summary>
		/// <param name="diceSize">The size of the dice to use for calculating damage</param>
		/// <param name="diceCount">How many times to roll the dice when calculating damage</param>
		public ContributesDamage (int diceSize, int diceCount)
		{
			_diceDamage = new DiceRoll(diceSize,diceCount);
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="ItemComponents.ContributesDamage"/> class.
		/// </summary>
		/// <param name="dice">A diceroll object which will be used to calculate the damage done</param>
		public ContributesDamage (DiceRoll dice)
		{
			_diceDamage = dice;
		}
		/// <summary>
		/// Adds the effect this component has to an item(generally will be the parent item)
		/// </summary>
		/// <param name="affected">Item to accept the effect</param>
		/// <param name="owner">Owner.</param>
		public void ApplyEffect(Item owner){
			owner.ItemEffect.DamageComponent = _diceDamage;
		}
		/// <summary>
		/// Removes the effect this component has from an item(generally will be the parent item)
		/// </summary>
		/// <param name="affected">Item to lose the effect</param>
		/// <param name="owner">Owner.</param>
		public void RemoveEffect(Item owner){
			owner.ItemEffect.DamageComponent = _diceDamage;
		}
	}
}

