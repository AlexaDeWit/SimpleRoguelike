using System;
using Characters;

namespace ItemComponents
{
	public interface IConsumeEffect : IItemComponent
	{
		void ApplyEffect(PlayerCharacter affected);
		void RemoveEffect(PlayerCharacter affected);
	}
}

