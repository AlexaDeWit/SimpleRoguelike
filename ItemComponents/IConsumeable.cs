using System;
using Characters;

namespace ItemComponents
{
	public interface IConsumeable
	{
		int MaxCharges{ get;}
		int ChargesRemaining{ get;}
		void ApplyEffect(PlayerCharacter affected);
		void RemoveEffect(PlayerCharacter affected);
	}
}

