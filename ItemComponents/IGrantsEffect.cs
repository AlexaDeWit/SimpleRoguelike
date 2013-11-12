using System;
using Characters;

namespace ItemComponents
{
	public interface IGrantsEffect : IItemComponent
	{
		void ApplyEffect(Character affected);
		void RemoveEffect(Character affected);
	}
}

