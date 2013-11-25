using System;
using Characters;
using Effects;
using Items;

namespace ItemComponents
{
	/// <summary>
	/// Interface that defines how a component will contribute an effect to an Item.
	/// </summary>
	public interface IGrantsEffect : IItemComponent
	{
		/// <summary>
		/// Adds the effect this component has to an item(generally will be the parent item)
		/// </summary>
		/// <param name="affected">Item to accept the effect</param>
		void ApplyEffect(Item affected);
		/// <summary>
		/// Removes the effect this component has from an item(generally will be the parent item)
		/// </summary>
		/// <param name="affected">Item to lose the effect</param>
		void RemoveEffect(Item affected);
	}
}

