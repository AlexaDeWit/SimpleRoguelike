using System;
using Characters;

namespace ItemComponents
{
	/*
	 * <summary>
	 * Base interface from which specific effect types will be drawn.
	 * 
	 * Defines the item as causing and removing affects upon a character
	 * as appropriate.
	 * </summary>
	 */
	public interface IGrantsEffect : IItemComponent
	{
		void ApplyEffect(Character affected);
		void RemoveEffect(Character affected);
	}
}

