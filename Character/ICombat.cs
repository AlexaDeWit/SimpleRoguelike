using System;

namespace Character
{
	public interface ICombat
	{
		int GetArmourValue();
		double GetBlockChance();
		int GetBlockAmmount();
		double GetStrikeChance();
		double GetEvasionChance();
		int GetCombatLevel();
	}
}

