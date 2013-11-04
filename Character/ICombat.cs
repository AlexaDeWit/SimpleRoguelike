using System;

namespace Character
{
	public interface ICombat
	{
		int ArmourValue{get;}
		double BlockChance{ get; }
		int BlockAmmount{ get; }
		double StrikeChance{ get; }
		double EvasionChance{ get; }
		int CombatLevel{ get; }
	}
}

